import MaadButton from "@/components/button";
import MaadModal from "@/components/modal";
import SegmentedControl from "@/components/segmentedControl";
import Textarea from "@/components/textarea";
import { Select, Text } from "@mantine/core";
import { useForm } from "@mantine/form";
import { showNotification } from "@mantine/notifications";
import { addPeygiri, editCustomerNote } from "services/customer";
import { Textarea as MantineTextarea } from "@mantine/core";
import SelectBox from "@/components/selectBox";
import { useState } from "react";

export default function EditNote({ opened, onClose, id, description, callBack }: {
    opened: boolean,
    onClose: () => void,
    id: string
    description: string
    callBack: (newContent: string) => void
}) {

    const [loading, setLoading] = useState<boolean>(false)

    const form = useForm({
        initialValues: {
            description: description,
            type: '',
        },

        validate: {
            description: (value) => {
                if (!value) return 'توضیحات را وارد کنید'
            }
        }
    })

    async function submit(values: typeof form.values) {
        try {
            setLoading(true)
            const response = await editCustomerNote({
                description: values.description,
                note_id: id,
            })
            showNotification({ message: 'یادداشت با موفقیت ویرایش شد', title: 'عملیات موفق', color: 'green' })
            onClose()
            callBack(values.description)
            form.setFieldValue('description', values.description)
        } catch {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در ویرایش یادداشت',
                color: 'red'
            })
        } finally {
            setLoading(false)
        }
    }


    return (
        <MaadModal
            title="ویرایش یادداشت"
            opened={opened}
            onClose={onClose}
            size="70%"
            loading={loading}
        >
            <form
                onSubmit={form.onSubmit((values) => submit(values))}
                className="w-full">
                <div className="grid grid-cols-1 gap-6 mt-4">
                    <div className="col-span-1 grid grid-cols-12">
                        <label htmlFor="description" className="col-span-3">توضیحات :</label>
                        <MantineTextarea
                            className="col-span-9"
                            placeholder="توضیحات"
                            minRows={4}
                            {...form.getInputProps('description')}
                        />
                    </div>
                    {/* <div className="col-span-6">
                        <SelectBox
                            label="کالا / خدمات :"
                            searchable
                            data={[
                                { label: 'کالا', value: '1' },
                                { label: 'خدمات', value: '2' },
                            ]}
                        />
                    </div> */}
                </div>
                <div className="flex justify-end mt-8">
                    <MaadButton
                        type="submit"
                        classNames={{
                            root: 'bg-[#2141A8] text-white',
                        }}
                    >
                        ویرایش یادداشت
                    </MaadButton>
                    <MaadButton
                        onClick={() => onClose()}
                        className="mr-8"
                        classNames={{
                            root: 'bg-[#2141A8] text-white',
                        }}
                    >
                        انصراف
                    </MaadButton>
                </div>
            </form>
        </MaadModal >
    )
}