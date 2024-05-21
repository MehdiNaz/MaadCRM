'use client'
import { Head } from "@/components/form"
import TextInput from "@/components/textInput"
import SelectBox from "@/components/selectBox"
import { Loader, LoadingOverlay, Switch } from "@mantine/core"
import MaadButton from "@/components/button"
import { useEffect, useState } from "react"
import { getAllCategories, insertProduct } from "services/products"
import { useForm } from "@mantine/form"
import { showNotification } from "@mantine/notifications"
import { useRouter } from "next/navigation"
import { disableInputsandButtons, handleComma, removeComma } from "utils/helper"
import { FetcehdData } from "@/types/global"

export default function NewProduct() {

    const [categories, setCategories] = useState<any[]>([])
    const [loading, setLoading] = useState<boolean>(false)
    const [fetched, setFetched] = useState<FetcehdData>({
        category: false
    })

    const form = useForm({
        initialValues: {
            title: '',
            price: '',
            category: '',
            status: true,
            description: ''
        },

        validate: {
            title: (value) => {
                if (!value) {
                    return 'نام کالا / خدمات را وارد کنید'
                }
            },
            // price: (value) => {
            //     if (!value) {
            //         return 'قیمت را وارد کنید'
            //     }
            // },
            category: (value) => {
                if (!value) {
                    return 'دسته بندی را وارد کنید'
                }
            },
            // description: (value) => {
            //     if (!value) {
            //         return 'توضیحات را وارد کنید'
            //     }
            // }
        }
    })

    const router = useRouter()
    async function handleSubmit(values: typeof form.values) {
        try {
            setLoading(true)
            disableInputsandButtons()
            let price = values.price ? removeComma(values.price) : 0
            const response = await insertProduct({
                title: values.title,
                price: price,
                category_id: values.category,
            })
            if (response.success) {
                showNotification({
                    title: 'عملیات موفق',
                    message: 'محصول جدید با موفقیت اضافه گردید',
                    color: 'green'
                })
                form.reset()
                router.push('/products')

            }
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در ایجاد محصول جدید',
                color: 'red'
            })
        } finally {
            setLoading(false)
        }
    }

    useEffect(() => {
        const getCategories = async () => {
            try {
                const response = await getAllCategories()
                if (response.success) {
                    setCategories(response.categories)
                }
            } catch (err) {
                showNotification({
                    title: 'عملیات ناموفق',
                    message: 'خطا در دریافت دسته بندی ها',
                    color: 'red'
                })
            } finally {
                setFetched({ ...fetched, category: true })
            }
        }
        getCategories()
    }, [])


    return (
        <>
            <LoadingOverlay visible={loading} />
            <div className="w-full bg-white rounded-md shadow-sm border-t-4 border-primary ">
                <div className="px-8 py-4 border-b">
                    <Head title="ایجاد کالا / خدمات" />
                </div>
                <div className="w-full mt-12 px-8 py-4">
                    <form
                        onSubmit={form.onSubmit((values) => handleSubmit(values))}
                        className="grid grid-cols-12 gap-12">
                        <div className="col-span-12 lg:col-span-6">
                            <TextInput
                                label="نام کالا / خدمات :"
                                placeholder="نام کالا / خدمات"
                                {...form.getInputProps('title')}
                            />
                        </div>
                        <div className="col-span-12 lg:col-span-6">
                            <TextInput
                                label="قیمت :"
                                placeholder="قیمت"
                                {...form.getInputProps('price')}
                                onChange={(e) => {
                                    form.setValues({ price: handleComma(e.target.value) })
                                }}
                            />
                        </div>
                        <div className="col-span-12 lg:col-span-6">
                            <SelectBox
                                searchable
                                label="دسته بندی :"
                                placeholder="دسته بندی"
                                icon={fetched.category == false ? <Loader size={13} /> : null}
                                disabled={fetched.category == false}
                                data={
                                    categories.map((category) => {
                                        return {
                                            label: category.title,
                                            value: category.id
                                        }
                                    })
                                }
                                {...form.getInputProps('category')}
                            />
                        </div>
                        <div className="col-span-12 lg:col-span-6 grid grid-cols-12">
                            <div className="col-span-3 text-sm">وضعیت :</div>
                            <Switch
                                className="col-span-9"
                                color='green'
                                size="md"
                                defaultChecked={true}
                                {...form.getInputProps('status')}
                            />
                        </div>
                        <div className="flex col-span-12 justify-end">
                            <MaadButton
                                type="submit"
                                size="sm"
                            >
                                ایجاد
                            </MaadButton>
                        </div>
                    </form>
                </div>
            </div>
        </>
    )
}