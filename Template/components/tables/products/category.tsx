'use client'
import { ClientsTableType } from '@/types/customComponents'
import { FiEdit } from 'react-icons/fi'
import { RiDeleteBin6Line } from 'react-icons/ri'
import '../clientsTable.css'
import { Center, Text, Tooltip } from '@mantine/core'
import TableTitle from '../tableTitle'
import Link from 'next/link'
import { modals } from '@mantine/modals'
import { showNotification } from '@mantine/notifications'
import { deleteProduct, deleteProductCategory, updateProductCategory } from 'services/products'
import { handleComma } from 'utils/helper'
import Modal from '@/components/modal'
import { useEffect, useState } from 'react'
import { useForm } from '@mantine/form'
import TextInput from '@/components/textInput'
import Button from '@/components/button'
import Table from '../table'
import Image from 'next/image'

export default function CategoryTable({ data }: ClientsTableType) {

    const [loading, setLoading] = useState<boolean>(true)
    const [categories, setCategories] = useState(data)

    useEffect(() => {
        setCategories(data)
        setLoading(false)
    }, [data])


    const form = useForm({
        initialValues: {
            id: '',
            title: ''
        },

        validate: (values) => {
            return {
                title: !values.title ? 'نام دسته بندی را وارد کنید' : null
            }
        }
    })

    async function deletecategory(id) {
        try {
            const response = await deleteProductCategory(id)
            if (response.success) {
                showNotification({
                    title: 'عملیات موفق',
                    message: 'دسته بندی کالا / خدمات با موفقیت حذف شد',
                    color: 'green'
                })
                const index = categories.findIndex((item) => item.id === response.id)
                const newCategories = [...categories]
                newCategories.splice(index, 1)
                setCategories(newCategories)
            }
        } catch (err) {
            let message = null
            if (err.response.data.message == 'Cannot delete category with products') {
                message = 'شما نمی توانید دسته بندی دارای کالا / خدمات را حذف کنید'
            } else {
                message = 'حذف دسته بندی با مشکل مواجه شد'
            }
            showNotification({
                title: 'عملیات ناموفق',
                message: message,
                color: 'red'
            })
        }
    }

    const handleDelete = (id) => modals.openConfirmModal({
        title: 'حذف دسته بندی کالا / خدمات',
        children: (
            <Text size="sm">
                آیا از حذف این دسته بندی کالا / خدمات مطمئن هستید؟
            </Text>
        ),
        labels: { confirm: 'حذف', cancel: 'لغو' },
        onConfirm: () => deletecategory(id),
        confirmProps: { color: 'red' },
    })

    const [opened, setOpened] = useState<boolean>(false)

    async function handleEdit(values: typeof form.values) {
        try {
            const response = await updateProductCategory({
                id: values.id,
                title: values.title
            })
            showNotification({
                title: 'عملیات موفق',
                message: 'دسته بندی با موفقیت ویرایش شد',
                color: 'green'
            })
            setOpened(false)

            const index = categories.findIndex((item) => item.id === response.category.id)
            const newCategories = [...categories]
            newCategories[index] = { title: response.category.title, id: response.category.id }

            setCategories(newCategories)
            form.reset()
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'دسته بندی ویرایش نشد',
                color: 'red'
            })
        }
    }

    return (
        <>
            <Modal opened={opened} title="افزودن دسته بندی" onClose={() => setOpened(false)} size="lg">
                <form onSubmit={form.onSubmit(handleEdit)} className="w-full">
                    <TextInput
                        label="نام دسته بندی :"
                        placeholder="نام دسته بندی را وارد کنید"
                        {...form.getInputProps('title')}
                    />
                    <div className="flex w-full justify-end mt-4">
                        <Button type="submit">
                            ویرایش
                        </Button>
                    </div>
                </form>
            </Modal>
            <Table
                columns={[
                    { id: 'title', label: 'عنوان' },
                    { id: 'actions', label: 'عملیات' }
                ]}
                data={categories.map((category) => {
                    return {
                        title: category.title,
                        actions: (
                            <div className="col-span-1 text-center flex justify-center clients-table__actions">
                                <Tooltip
                                    withArrow
                                    classNames={{
                                        tooltip: '!text-11p',
                                    }}
                                    label="ویرایش">
                                    <button
                                        onClick={() => {
                                            form.setValues({ 'title': category.title, 'id': category.id })
                                            setOpened(true)
                                        }}
                                    >
                                        <FiEdit />
                                    </button>
                                </Tooltip>
                                <Tooltip
                                    withArrow
                                    classNames={{
                                        tooltip: '!bg-red-500 !text-white !text-11p',
                                    }}
                                    label="حذف">
                                    <button
                                        onClick={() => handleDelete(category.id)}
                                    >
                                        <RiDeleteBin6Line />
                                    </button>
                                </Tooltip>
                            </div>
                        )
                    }
                })}
            />
        </>
    )
}