'use client'
import DashboardContent from "@/components/dashboardContent"
import Button from "@/components/button"
import Modal from "@/components/modal"
import { useEffect, useState } from "react"
import { useForm } from "@mantine/form"
import TextInput from "@/components/textInput"
import Divider from '@/components/divider'
import { getAllCategories, getAllproducts, newCategory } from "services/products"
import { showNotification } from "@mantine/notifications"
import { useRouter } from "next/navigation"
import CategoryTable from "@/components/tables/products/category"
import NewProductCategory from "@/components/products/newCategory"
import ProductsHeader from "./header"
import Header from "@/components/dashboardContent/header"
import { Center } from "@mantine/core"
import Image from "next/image"

export default function ProductCategories() {

    const [loading, setLoading] = useState<boolean>(true)

    const [opened, setOpened] = useState<boolean>(false)

    const [categories, setCategories] = useState([])
    async function getCategories() {
        try {
            const response = await getAllCategories()
            if (response.success) {
                setCategories(response.categories)
                setLoading(false)
            }
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در دریافت اطلاعات دسته بندی ها',
                color: 'red'
            })
        }
    }
    useEffect(() => {
        getCategories()
    }, [])

    return (
        <>
            <NewProductCategory opened={opened} onClose={() => setOpened(false)}
                onSuccess={(newCategory) => {
                    const newCategories = [...categories]
                    newCategories.push(newCategory)
                    setCategories(newCategories)
                }}
            />
            <Header title='دسته بندی کالا / خدمات'>
                <div className="w-full">
                    <ProductsHeader
                        newCategory={() => setOpened(true)}
                    />
                </div>
            </Header>
            <div className="w-full mt-8">
                {loading == false && categories.length == 0 ? (
                    <Center>
                        <Image
                            src='/icons/product-not-found.svg'
                            width={400}
                            height={400}
                            alt="products not found"
                        />
                    </Center>
                ) : (
                    <CategoryTable data={categories} />
                )}
            </div>
        </>
    )
}