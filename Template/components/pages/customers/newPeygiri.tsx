import Modal from "@/components/modal";
import SegmentedControl from "@/components/segmentedControl";
import SelectBox from "@/components/selectBox";
import { useForm } from "@mantine/form";
import { showNotification } from "@mantine/notifications";
import { addPeygiri } from "services/customer";
import "dayjs/locale/fa"
import { useEffect, useState } from "react";
import { getAllPeygiriCategory } from "services/peygiri";
import Button from "@/components/button";
import { convertCalenderTimeToEn, convertDate, convertPersianDate, convertToUTC, validDate } from "utils/helper";
import DateInput from "@/components/DateInput";

export default function NewPeygiri({ opened, onClose, id, onSuccess }: {
    opened: boolean,
    onClose: () => void,
    id: string,
    onSuccess: (data: any) => void
}) {
    const [peygiriType, setPeygiriType] = useState('1');
    const [peygiriCategories, setPeygiriCategories] = useState([])

    const [resetDate, setResetDate] = useState<boolean>(false)

    const [loading, setLoading] = useState<boolean>(false)

    const form = useForm({
        initialValues: {
            category: '',
            date: null,
        },

        validate: {
            category: (value: string) => {
                return value.trim().length === 0 && 'لطفا دسته بندی را انتخاب کنید'
            },
            date: (value) => {
                if (value) {
                    value = convertDate(value)
                    if (peygiriType == '2' && !validDate(value)) {
                        return 'لطفا یک تاریخ معتبر را وارد نمایید'
                    }
                }
            }
        }
    })

    async function submit(values: typeof form.values) {
        try {
            setLoading(true)
            let date = null
            if (values.date && values.date !== null) {
                date = convertDate(values.date)
                date = convertPersianDate(date)
                date = convertToUTC(date)
            }
            const newPeygiri = {
                CustomerId: id,
                DatePeyGiry: date,
                IdPeyGiryCategory: values.category,
            }
            if (date == null) delete newPeygiri.DatePeyGiry
            const response = await addPeygiri(newPeygiri)

            if (response) {
                showNotification({ message: 'پیگیری با موفقیت افزوده شد', title: 'عملیات موفق', color: 'green' })
                onClose()
                if (onSuccess)
                    onSuccess(response.data)
                form.reset()
                setResetDate(prev => !prev)
                setPeygiriType('1')
            }
        } catch {
            showNotification({
                title: 'عملیات ناموفق',
                message: "خطا در ثبت پیگیری",
                color: 'red'
            })
        } finally {
            setLoading(false)
        }
    }

    async function getPeygiriCategories() {
        try {
            const response = await getAllPeygiriCategory()
            setPeygiriCategories([])
            if (response.peygiris.length === 0) {
                setPeygiriCategories([{ label: 'موردی یافت نشد', value: '', disabled: true }])
            } else {
                response.peygiris.map((item) => {
                    setPeygiriCategories(peygiri => [...peygiri, {
                        value: item.id,
                        label: item.title
                    }])
                })
            }
        } catch (err) {
            setPeygiriCategories([{ label: 'موردی یافت نشد', value: '', disabled: true }])
        }
    }

    useEffect(() => {
        getPeygiriCategories()
    }, [])

    useEffect(() => {
        setPeygiriType('1')
    }, [onClose])

    return (
        <Modal
            title="افزودن پیگیری"
            opened={opened}
            onClose={onClose}
            size="80%"
            loading={loading}
        >
            <form
                onSubmit={form.onSubmit((values) => submit(values))}
                className="w-full">
                <div className="w-[50%] mx-auto mb-14">
                    <SegmentedControl
                        onChange={(value: string) => setPeygiriType(value)}
                    />
                </div>
                <div className="grid grid-cols-2 my-4 gap-8">
                    <div className="col-span-1">
                        <SelectBox
                            label="انتخاب کنید :"
                            placeholder="انتخاب کنید"
                            data={peygiriCategories}
                            maxDropdownHeight={150}
                            searchable
                            {...form.getInputProps('category')}
                        />
                    </div>
                    {peygiriType === '2' && (
                        <div className="col-span-1 items-center">
                            <DateInput
                                label="تاریخ :"
                                onChange={(value) => {
                                    form.setValues({ 'date': value })
                                }}
                                reset={resetDate}
                                error={form.errors.date}
                            />
                        </div>
                    )}
                </div>
                <div className="col-span-12 grid grid-cols-1">
                    <div className="flex justify-end mt-8">
                        <Button
                            type="submit"
                            classNames={{
                                root: 'bg-[#2141A8] text-white',
                            }}
                        >
                            ثبت پیگیری
                        </Button>
                        <Button
                            onClick={() => onClose()}
                            className="mr-8"
                            classNames={{
                                root: 'bg-[#2141A8] text-white',
                            }}
                        >
                            انصراف
                        </Button>
                    </div>
                </div>
            </form>
        </Modal>
    )
}