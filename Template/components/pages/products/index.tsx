'use client'
import Button from "@/components/button"
import { useEffect, useState } from "react"
import ProductsTable from "@/components/tables/productsTable"
import { getAllproducts } from "services/products"
import { showNotification } from "@mantine/notifications"
import ProductsHeader from "./header";
import Image from "next/image"
import Link from "next/link"
import NewProductCategory from "@/components/products/newCategory"
import Header from "@/components/dashboardContent/header"

export default function Products() {

    const [opened, setOpened] = useState<boolean>(false)
    const [fetched, setFetched] = useState<boolean>(false)
    const [products, setProcust] = useState([])

    async function getProducts() {
        try {
            const response = await getAllproducts()
            if (response.success) {
                setProcust(response.products)
                setFetched(true)
            }
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در دریافت اطلاعات محصولات',
                color: 'orange'
            })
        }
    }

    useEffect(() => {
        getProducts()
    }, [])


    return (
        <>
            <NewProductCategory opened={opened} onClose={() => setOpened(false)} />
            <Header title='لیست کالا / خدمات' >
                <div className="w-full flex justify-end">
                    <ProductsHeader
                        newCategory={() => setOpened(true)}
                    />
                </div>
            </Header>
            <div className="w-full mt-8">
                {fetched && products && products.length == 0 && (
                    <div className="w-full flex flex-col items-center justify-center">
                        <Image
                            src='/icons/product-not-found.svg'
                            width={400}
                            height={400}
                            alt="products not found"
                        />
                        <span className="text-md my-8">اولین کالا / خدمات خود را ایجاد کنید</span>
                        <Link href="/products/new">
                            <Button>
                                ایجاد محصول
                            </Button>
                        </Link>
                    </div>
                ) ||
                    <ProductsTable
                        data={products}
                    />
                }
            </div>
        </>
    )
}