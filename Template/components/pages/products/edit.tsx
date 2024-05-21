'use client'
import DashboardContent from "@/components/dashboardContent"
import { Head } from "@/components/form"
import TextInput from "@/components/textInput"
import SelectBox from "@/components/selectBox"
import { LoadingOverlay, Switch, Textarea } from "@mantine/core"
import FileUploader from "@/components/fileUploader"
import MaadButton from "@/components/button"
import { FaEdit } from "react-icons/fa"
import { useEffect, useState } from "react"
import { getAllCategories, getProductByID, insertProduct, updateProduct } from "services/products"
import { useForm } from "@mantine/form"
import { showNotification } from "@mantine/notifications"
import { useRouter } from "next/navigation"
import { handleComma, removeComma } from "@/utils/helper"

export default function EditProdcut({ productID }: { productID: string }) {

    const [loading, setLoading] = useState<boolean>(true)
    const [categories, setCategories] = useState<any[]>([])


    const form = useForm({
        initialValues: {
            id: '',
            title: '',
            price: '',
            category: '',
            status: false,
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
            let price = removeComma(values.price)
            const response = await updateProduct({
                id: values.id,
                title: values.title,
                price: price,
                category_id: values.category,
            })
            if (response.success) {
                showNotification({
                    title: 'عملیات موفق',
                    message: 'محصول با موفقیت ویرایش گردید',
                    color: 'green'
                })
                router.push('/products')
            }
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در ویرایش محصول',
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
                    title: "عملیات ناموفق",
                    message: "خطا در دریافت اططلاعات دسته بندی",
                    color: 'red'
                })
            }
        }
        getCategories()
    }, [])


    useEffect(() => {
        const getProduct = async (productID: string) => {
            try {
                const response = await getProductByID(productID)
                form.setValues({
                    id: response.product.id,
                    title: response.product.title,
                    category: response.product.category_id,
                    description: response.product.description,
                    price: response.product.price,
                    // status: response.data.statusTypeProduct
                })
                setLoading(false)
            } catch (err) {
                showNotification({
                    title: "عملیات ناموفق",
                    message: "خطا در دریافت اطلاعات محصول",
                    color: 'red'
                })
            }
        }
        getProduct(productID)

    }, [])


    return (
        // <DashboardContent divider={false} breadcrumbTitle="ویرایش کالا / خدمات" active_menu="products">
        <div className="w-full bg-white rounded-md shadow-sm border-t-4 border-primary mt-8">
            <div className="px-8 py-4 border-b">
                <Head title="ویرایش کالا / خدمات" />
            </div>
            <div className="w-full mt-12 px-8 py-4 relative">
                <LoadingOverlay visible={loading} />
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
                        <div className="col-span-3">وضعیت :</div>
                        <Switch
                            className="col-span-9"
                            color='green'
                            size="md"
                            defaultChecked={true}
                            {...form.getInputProps('status')}
                        />
                    </div>
                    {/* <div className="col-span-12 lg:col-span-6 grid grid-cols-12">
                            <div className="col-span-3">توضیحات :</div>
                            <Textarea
                                className="col-span-9"
                                classNames={{
                                    input: '!min-h-[120px]'
                                }}
                                placeholder="توضیحات"
                                {...form.getInputProps('description')}
                            />
                        </div> */}
                    {/* <div className="col-span-12 lg:col-span-6 grid grid-cols-12">
                            <span className="col-span-3">تصویر</span>
                            <FileUploader
                                className="col-span-9"
                            />
                        </div> */}
                    <div className="flex col-span-12 justify-end">
                        <MaadButton
                            type="submit"
                            size="sm"
                        >
                            ثبت تغیرات
                        </MaadButton>
                    </div>
                </form>
            </div>
        </div>
        // </DashboardContent>
    )
}