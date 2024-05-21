'use client'
import { ClientsTableType } from '@/types/customComponents';
import { FiEdit } from 'react-icons/fi';
import { RiDeleteBin6Line } from 'react-icons/ri';
import './clientsTable.css'
import { Text, Tooltip } from '@mantine/core';
import { useEffect, useState } from 'react';
import { useRouter } from 'next/navigation';
import { useForm } from '@mantine/form';
import TextInput from '../textInput';
import Button from '../button';
import Modal from '../modal';
import { deletePeygiriCategory, editPeygiriCategory } from 'services/peygiri';
import { showNotification } from '@mantine/notifications';
import TableTitle from './tableTitle';
import { modals } from '@mantine/modals';
import Table from './table';

export default function PeygirisTable({ data }: ClientsTableType) {

    const [loading, setLoading] = useState<boolean>(false)

    const [peygiriCategories, setPeygiriCategories] = useState(data)
    const [openedmodal, setOpenedModal] = useState<boolean>(false)

    const editPeygiri = useForm({
        initialValues: {
            Id: '',
            Kind: ''
        },

        validate: (values) => {
            return {
                Kind: values.Kind.length < 3 ? 'نام پیگیری باید بیشتر از 3 کاراکتر باشد' : null,
            }
        },
    })


    async function handleEdit(values: typeof editPeygiri.values) {
        try {
            const response = await editPeygiriCategory({
                id: values.Id,
                title: values.Kind
            })
            if (response) {
                showNotification({
                    title: 'پیگیری ویرایش شد',
                    message: 'پیگیری مورد نظر با موفقیت ویرایش شد',
                    color: 'teal',
                })

                const newPeygiriCategories = peygiriCategories.map((peygiri) => {
                    if (peygiri.id === values.Id) {
                        return {
                            id: values.Id,
                            title: values.Kind
                        }
                    }
                    return peygiri
                }
                )
                setPeygiriCategories(newPeygiriCategories)
                setOpenedModal(false)
            }
        } catch (err) {
            showNotification({
                title: 'خطا در ویرایش پیگیری',
                message: 'مشکلی در ویرایش پیگیری پیش آمده است',
                color: 'red',
            })
        }
    }


    useEffect(() => {
        setPeygiriCategories(data)
    }, [data])


    async function deletepeygiritype(id) {
        try {
            setLoading(true)
            const response = await deletePeygiriCategory({ Id: id })
            showNotification({
                title: 'پیگیری حذف شد',
                message: 'پیگیری مورد نظر با موفقیت حذف شد',
                color: 'green',
            })
            const newPeygiriCategories = peygiriCategories.filter((peygiri) => peygiri.id !== id)
            setPeygiriCategories(newPeygiriCategories)
        } catch (err) {
            showNotification({
                title: 'خطا در حذف پیگیری',
                message: 'مشکلی در حذف پیگیری پیش آمده است',
                color: 'red',
            })
        } finally {
            setLoading(false)
        }
    }


    const handleDelete = (id) => modals.openConfirmModal({
        title: 'خذف بازخورد',
        children: (
            <>
                <Text size="sm">
                    آیا از حذف نوع پیگیری مطمئن هستید؟
                </Text>
            </>
        ),
        labels: { confirm: 'حذف', cancel: 'لغو' },
        onConfirm: () => deletepeygiritype(id),
        confirmProps: { color: 'red' },
    })


    useEffect(() => {
        console.log('peygiriCategories', peygiriCategories);

    }, [peygiriCategories])

    return (
        <>
            <Modal
                opened={openedmodal}
                onClose={() => setOpenedModal(false)}
                title='ویرایش پیگیری'
                size='lg'
            >
                <form
                    onSubmit={editPeygiri.onSubmit((values) => handleEdit(values))}
                >
                    <TextInput
                        label='نام پیگیری'
                        placeholder='نام پیگیری'
                        {...editPeygiri.getInputProps('Kind')}
                    />
                    <div className="flex justify-end mt-8">
                        <Button type="submit">
                            ثبت
                        </Button>
                    </div>
                </form>
            </Modal>
            <Table
                columns={[
                    { id: 'type', label: 'نوع پیگیری' },
                    { id: 'action', label: 'عملیات' }
                ]}
                data={peygiriCategories.map((peygiri, index) => {
                    return {
                        type: peygiri.title,
                        action: <div className="col-span-1 text-center flex justify-center clients-table__actions">
                            <Tooltip
                                withArrow
                                classNames={{
                                    tooltip: '!text-11p',
                                }}
                                label="ویرایش">
                                <button
                                    onClick={() => {
                                        setOpenedModal(true)
                                        editPeygiri.setValues({ Kind: peygiri.title, Id: peygiri.id })
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
                                    onClick={() => {
                                        handleDelete(peygiri.id)
                                    }}
                                >
                                    <RiDeleteBin6Line />
                                </button>
                            </Tooltip>
                        </div>
                    }
                })}
            />
            {/* <div className='w-full flex flex-col'>
                <div className="grid grid-cols-2 mb-3">
                    <div className="col-span-1 text-center">
                        <TableTitle title="نوع پیگیری" />
                    </div>
                    <div className="col-span-1 text-center">
                        <TableTitle title="عملیات" />
                    </div>
                </div>
                <div className="grid grid-cols-2">
                    {peygiriCategories.map((peygiri, index) => {
                        return (
                            <div key={index}
                                className="col-span-2 grid grid-cols-2 bg-white shadow-sm mb-2 py-3 items-center px-3 rounded-md">
                                <div className="col-span-1 text-center">
                                    <span className="text-sm font-medium">{peygiri.title}</span>
                                </div>
                                <div className="col-span-1 text-center flex justify-center clients-table__actions">
                                    <Tooltip
                                        withArrow
                                        classNames={{
                                            tooltip: '!text-11p',
                                        }}
                                        label="ویرایش">
                                        <button
                                            onClick={() => {
                                                setOpenedModal(true)
                                                editPeygiri.setValues({ Kind: peygiri.title, Id: peygiri.id })
                                                console.log(editPeygiri.values);

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
                                            onClick={() => { }}
                                        >
                                            <RiDeleteBin6Line />
                                        </button>
                                    </Tooltip>
                                </div>
                            </div>
                        )
                    })
                    }
                </div>
            </div> */}
        </>
    )
}