'use client'
import DashboardContent from "@/components/dashboardContent"
import PeygirisTable from "@/components/tables/peygirisTable"
import { AiOutlinePlusCircle } from "react-icons/ai"
import Modal from "@/components/modal"
import { useEffect, useState } from "react"
import { useForm } from "@mantine/form"
import TextInput from "@/components/textInput"
import Button from "@/components/button"
import { getAllPeygiriCategory, newPeygiriCategory } from "services/peygiri"
import { showNotification } from "@mantine/notifications"
import Devider from "@/components/divider"
import Image from "next/image"
import { Center, LoadingOverlay } from "@mantine/core"
import Header from "@/components/dashboardContent/header"

export default function PeygiriSettings() {

    const [loading, setLoading] = useState<boolean>(true)
    const [openedmodal, setOpenedModal] = useState<boolean>(false)
    const [categories, setCategories] = useState<any[]>([])

    const form = useForm({
        initialValues: {
            kind: '',
        },
        validate: {
            kind: (value) => value.length <= 2 && 'نام پیگیری باید بیشتر از 2 کاراکتر باشد',
        }
    })

    async function handleSubmit(values: typeof form.values) {
        try {
            console.log(values);
            setLoading(true)
            const respose = await newPeygiriCategory({
                title: values.kind
            })
            setOpenedModal(false)
            setCategories(prev => [...prev, { id: respose.peygiri.id, title: respose.peygiri.title }])
            showNotification({
                title: 'پیگیری جدید',
                message: 'پیگیری جدید با موفقیت اضافه شد',
                color: 'teal',
            })
            form.reset()
        } catch (err) {
            showNotification({
                title: 'خطا',
                message: 'خطایی رخ داده است',
                color: 'red',
            })
        } finally {
            setLoading(false)
        }
    }


    async function getAllcategories() {
        try {
            const response = await getAllPeygiriCategory()
            setCategories([])
            response.peygiris.map((item: any) => {
                setCategories(prev => [...prev, { id: item.id, title: item.title }])
            })
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطایی رخ داده است',
                color: 'red'
            })
        } finally {
            setLoading(false)
        }
    }

    useEffect(() => {
        getAllcategories()
    }, [])

    return (
        <>
            <Modal
                opened={openedmodal}
                onClose={() => setOpenedModal(false)}
                title='نوع پیگیری جدید'
                size='lg'
                loading={loading}
            >
                <LoadingOverlay visible={loading} />
                <form
                    onSubmit={form.onSubmit(handleSubmit)}
                >
                    <TextInput
                        label='نام پیگیری'
                        placeholder='نام پیگیری'
                        {...form.getInputProps('kind')}
                    />
                    <div className="flex justify-end mt-8">
                        <Button type="submit">
                            ثبت
                        </Button>
                    </div>
                </form>
            </Modal>
            <Header title='تنظیمات پیگیری'>
                <Button onClick={() => setOpenedModal(true)}>
                    نوع جدید
                </Button>
            </Header>
            <div className="w-full mt-8">
                {!loading && categories.length === 0 ? (
                    <div className="w-full flex justify-center">
                        <div className="mt-8">
                            <Image
                                src='/icons/feedback.svg'
                                width={500}
                                height={500}
                                alt='feedback'
                            />
                            <div className="flex flex-col">
                                <span className="mt-4 text-lg leading-8">هیچ نوع پگیری شما تعریف نکرده اید! بیا یکی با هم ایجاد کنیم</span>
                                <div className="w-full flex justify-center items-center mt-8">
                                    <Button
                                        onClick={() => setOpenedModal(true)}
                                    >
                                        ایجاد نوع پیگیری
                                    </Button>
                                </div>
                            </div>
                        </div>
                    </div>
                ) : (
                    <PeygirisTable
                        data={categories}
                    />
                )}
            </div>
            {/* </DashboardContent> */}
        </>
    )
}