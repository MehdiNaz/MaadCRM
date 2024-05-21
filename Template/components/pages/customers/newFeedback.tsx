import MaadButton from "@/components/button"
import { useForm } from "@mantine/form"
import { showNotification } from "@mantine/notifications"
import { newCustomerNote, newFeedback } from "services/customer"
import SelectBox from "@/components/selectBox"
import { useEffect, useState } from "react"
import Modal from "@/components/modal"
import Textarea from "@/components/textarea"
import UsersSelect from "@/components/select/users"
import ProductsSelect from "@/components/products/productsSelect"
import FeedbackTypes from "@/components/select/feedbackTypes"
import { disableInputsandButtons, enableInputsandButtons } from "utils/helper"

export default function NewFeedback({ opened, onClose, id }: {
    opened: boolean,
    onClose: () => void,
    id: string
}) {

    const [loading, setLoading] = useState<boolean>(false)

    const form = useForm({
        initialValues: {
            description: '',
            category: '',
            IdCustomer: id,
            IdProduct: '',
            IdUser: ''
        },

        validate: {
            category: (value) => value === '' && 'نوع بازخورد را انتخاب کنید',
        }
    })

    async function submit(values: typeof form.values) {
        try {
            disableInputsandButtons()
            setLoading(true)
            const response = await newFeedback({
                customer_id: id,
                feedback_category_id: values.category,
                feedback_product_id: values.IdProduct,
                description: values.description,
                feedback_user: values.IdUser
            })

            if (response) {
                showNotification({ message: 'بازخورد با موفقیت افزوده شد', title: 'عملیات موفق', color: 'green' })
                onClose()
                form.reset()
                setFeedbackType('1')
            }
        } catch {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطایی در افزودن بازخورد رخ داد',
                color: 'red'
            })
        } finally {
            setLoading(false)
            enableInputsandButtons()
        }
    }

    const [feedbackType, setFeedbackType] = useState<string>('1')


    useEffect(() => {
        form.reset()
    }, [onClose])

    return (
        <Modal
            title="ثبت بازخورد"
            opened={opened}
            onClose={onClose}
            size="70%"
            loading={loading}
        >
            <form
                onSubmit={form.onSubmit((values) => submit(values))}
                className="w-full">
                <div className="grid grid-cols-12 gap-6 mt-4">
                    <div className="col-span-6">
                        <SelectBox
                            label="بازخورد درباره :"
                            defaultValue="1"
                            data={[
                                { label: 'همکار', value: '1' },
                                { label: 'کالا / خدمات', value: '2' },
                                { label: 'فرآیند خرید', value: '3' },
                            ]}
                            onChange={(value) => setFeedbackType(value)}

                        />
                    </div>
                    {feedbackType === '1' && (
                        <div className="col-span-6">
                            <UsersSelect
                                label="انتخاب همکار :"
                                searchable
                                clearable
                                {...form.getInputProps('IdUser')}
                            />
                        </div>
                    )}
                    {feedbackType === '2' && (
                        <div className="col-span-6">
                            <ProductsSelect
                                clearable
                                label="نام کالا یا خدمات :"
                                {...form.getInputProps('IdProduct')}
                            />
                        </div>
                    )}
                    <div className="col-span-6">
                        <FeedbackTypes
                            label="نوع باخورد :"
                            feedbackType={parseInt(feedbackType)}
                            searchable
                            clearable
                            {...form.getInputProps('category')}
                        />
                    </div>
                    <div className="col-span-12">
                        <Textarea
                            label="توضیحات :"
                            {...form.getInputProps('description')}
                        />
                    </div>
                </div>
                <div className="flex justify-end mt-8">
                    <MaadButton
                        type="submit"
                        classNames={{
                            root: 'bg-[#2141A8] text-white',
                        }}
                    >
                        ثبت بازخورد
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
        </Modal >
    )
}