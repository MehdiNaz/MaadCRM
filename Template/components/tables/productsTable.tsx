'use client'
import { ClientsTableType } from '@/types/customComponents'
import { FiEdit } from 'react-icons/fi'
import { RiDeleteBin6Line } from 'react-icons/ri'
import './clientsTable.css'
import { Text, Tooltip } from '@mantine/core'
import TableTitle from './tableTitle'
import Link from 'next/link'
import { modals } from '@mantine/modals'
import { showNotification } from '@mantine/notifications'
import { deleteProduct } from 'services/products'
import NoItem from '../noItem'
import { handleComma } from 'utils/helper'
import Table from './table'
import { useEffect, useState } from 'react'

export default function ProductsTable({ data }: ClientsTableType) {

    const [products, setProducts] = useState(data)

    useEffect(() => {
        setProducts(data)
    }, [data])

    async function deleteproduct(id) {
        try {
            const response = await deleteProduct(id)
            if (response) {
                showNotification({
                    title: 'عملیات موفق',
                    message: 'کالا / خدمات با موفقیت حذف شد',
                    color: 'green'
                })

                setProducts((products) => {
                    return products.filter(item => item.id != id)
                })
            }
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'حذف کالا / خدمات با مشکل مواجه شد',
                color: 'red'
            })
        }
    }

    const handleDelete = (id) => modals.openConfirmModal({
        title: 'حذف کالا / خدمات',
        children: (
            <Text size="sm">
                آیا از حذف این کالا / خدمات مطمئن هستید؟
            </Text>
        ),
        labels: { confirm: 'حذف', cancel: 'لغو' },
        onConfirm: () => deleteproduct(id),
        confirmProps: { color: 'red' },
    })

    return (
        <>
            <Table
                columns={[
                    {
                        label: 'عنوان',
                        id: 'title'
                    },
                    {
                        label: 'دسته بندی',
                        id: 'category'
                    },
                    {
                        label: 'قیمت (تومان)',
                        id: 'price'
                    },
                    {
                        label: 'عملیات',
                        id: 'actions'
                    }
                ]}
                data={
                    products.map((product, index) => {
                        return {
                            title: <Link href={'/products/edit/' + product.id}>{product.title}</Link>,
                            category: product.category.title,
                            price: product.price ? handleComma(product.price) : 'ندارد',
                            actions: (
                                <div className='flex justify-center'>
                                    <div className="flex mx-3">
                                        <Tooltip
                                            withArrow
                                            classNames={{
                                                tooltip: '!text-11p',
                                            }}
                                            label="ویرایش">
                                            <Link
                                                href={`products/edit/${product.id}`}
                                            >
                                                <FiEdit size={16} />
                                            </Link>
                                        </Tooltip>
                                    </div>
                                    <div className="flex">
                                        <Tooltip
                                            withArrow
                                            classNames={{
                                                tooltip: '!bg-red-500 !text-white !text-11p',
                                            }}
                                            label="حذف">
                                            <button
                                                onClick={() => handleDelete(product.id)}
                                            >
                                                <RiDeleteBin6Line size={16} />
                                            </button>
                                        </Tooltip>
                                    </div>
                                </div>
                            )
                        }
                    })
                }
            />
        </>
    )
}