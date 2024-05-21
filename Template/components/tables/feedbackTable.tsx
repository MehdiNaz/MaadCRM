'use client'
import { ClientsTableType } from '@/types/customComponents';
import { BsCartXFill } from 'react-icons/bs';
import TableTitle from './tableTitle';
import { GiNotebook, GiSellCard } from 'react-icons/gi'
import { HiRefresh } from 'react-icons/hi';
import { FiEdit } from 'react-icons/fi';
import { RiDeleteBin6Line } from 'react-icons/ri';
import './clientsTable.css'
import { Group, Loader, LoadingOverlay, Radio, Tooltip } from '@mantine/core';
import NewPeygiri from '../pages/customers/newPeygiri';
import { useEffect, useState } from 'react';
import NewNote from '../pages/customers/addNote';
import { useRouter } from 'next/navigation';
import Link from 'next/link';
import Modal from '../modal';
import { useForm } from '@mantine/form';
import TextInput from '../textInput';
import SelectBox from '../selectBox';
import Button from '../button';
import { numberToString } from 'utils/helper';
import { deleteFeedbackType, updateFeedbackcategory } from 'services/feedback';
import { showNotification } from '@mantine/notifications';
import { AiOutlineDislike, AiOutlineLike, AiOutlineLoading3Quarters, AiOutlineShoppingCart, AiOutlineUser } from 'react-icons/ai';
import { modals } from '@mantine/modals';
import { Text } from '@mantine/core'
import Table from './table';

export default function FeedbackTable({ data, onDelete }: ClientsTableType) {

    const [loading, setLoading] = useState<boolean>(false)

    const [feedbackTypes, setFeedbackTypes] = useState(data)

    useEffect(() => {
        setFeedbackTypes(data)
    }, [data])

    useEffect(() => {
        setFeedbackTypes(data)
    }, [data])


    const [openedmodal, setOpenedModal] = useState<boolean>(false)

    const form = useForm({
        initialValues: {
            id: '',
            name: '',
            positiveNegative: '',
            typeFeedback: '0',
        },

        validate: (values) => {
            return {
                name: values.name.length < 3 ? 'نام نوع بازخورد باید بیشتر از 3 کاراکتر باشد' : null,

            }
        },
    })

    async function handleEdit(values: typeof form.values) {
        try {
            setLoading(true)
            const positiveNegative = values.positiveNegative === 'true' ? 0 : 1
            const response = await updateFeedbackcategory({
                feedback_id: values.id,
                feedback_for: parseInt(values.typeFeedback),
                description: '',
                title: values.name,
                positive_or_negative: positiveNegative,
            })
            showNotification({
                title: 'عملیات موفق',
                message: 'نوع بازخورد با موفقیت ویرایش شد',
                color: 'green',
            })
            setOpenedModal(false)
            const newFeedbackTypes = [...data]
            const index = newFeedbackTypes.findIndex((item) => item.id === values.id)
            newFeedbackTypes[index] = response.feedback
            setFeedbackTypes(newFeedbackTypes)
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'مشکلی در ویرایش نوع بازخورد پیش آمده است',
                color: 'red',
            })
        } finally {
            setLoading(false)
        }
    }

    function EditType() {
        return (
            <Modal
                opened={openedmodal}
                onClose={() => setOpenedModal(false)}
                title='ویرایش بازخورد'
                size='lg'
                loading={loading}
            >
                <form
                    onSubmit={form.onSubmit((values) => { handleEdit(values) })}
                >
                    <div className="w-full flex flex-col">
                        <div className="w-full mb-8">
                            <Radio.Group
                                label="بازخورد برای :"
                                {...form.getInputProps('typeFeedback')}
                            >
                                <Group mt="xs">
                                    <Radio value="1" label="همکار" />
                                    <Radio value="2" label="کالا / خدمات" />
                                    <Radio value="3" label="فرآیند خرید" />
                                </Group>
                            </Radio.Group>
                        </div>
                        <TextInput
                            label='نام نوع بازخورد :'
                            placeholder='نام نوع بازخورد'
                            {...form.getInputProps('name')}
                        />
                        <div className="w-full mt-8">
                            <Radio.Group
                                label="منفی یا مثبت بودن :"
                                withAsterisk
                                {...form.getInputProps('positiveNegative')}
                            >
                                <Group mt="xs">
                                    <Radio value={'true'} label="منفی" />
                                    <Radio value={'false'} label="مثبت" />
                                </Group>
                            </Radio.Group>
                        </div>
                    </div>
                    <div className="flex justify-end mt-8">
                        <Button type="submit">
                            ویرایش
                        </Button>
                    </div>
                </form>
            </Modal>
        )
    }

    async function deleteFeddbackType(id) {
        try {
            const response = await deleteFeedbackType({
                id: id
            })
            if (response) {
                showNotification({
                    title: 'عملیات موفق',
                    message: 'نوع بازخورد با موفقیت حذف شد',
                    color: 'green',
                })
                const newFeedbackTypes = feedbackTypes.filter((item) => item.id !== id)
                setFeedbackTypes(newFeedbackTypes)
                onDelete(id)
            }
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'مشکلی در حذف نوع بازخورد پیش آمده است',
                color: 'red',
            })
        }
    }

    const handleDelete = (id) => modals.openConfirmModal({
        title: 'خذف بازخورد',
        children: (
            <>
                <Text size="sm">
                    آیا از حذف این کالا / خدمات مطمئن هستید؟
                </Text>
            </>
        ),
        labels: { confirm: 'حذف', cancel: 'لغو' },
        onConfirm: () => deleteFeddbackType(id),
        confirmProps: { color: 'red' },
    })

    return (
        <>
            {EditType()}
            <Table
                columns={[
                    { id: "type", label: 'نوع بازخورد' },
                    { id: "positiveNegative", label: 'منفی / مثبت' },
                    { id: "for", label: 'برای' },
                    { id: "action", label: 'عملیات' },
                ]}
                data={feedbackTypes.map((feedback, index) => {
                    return {
                        type: feedback?.title ?? '',
                        positiveNegative: feedback.positive_or_negative == 1 ? (
                            <p className='text-center flex items-center justify-center'>
                                <span className='mx-2'><AiOutlineLike className='text-green-500' /></span>
                                <span className="text-sm font-medium text-green-500">مثبت</span>
                            </p>
                        ) : (
                            <p className='text-center flex items-center justify-center'>
                                <span className='mx-2'><AiOutlineDislike className='text-red-500' /></span>
                                <span className="text-sm font-medium text-red-500">منفی</span>
                            </p>
                        ),
                        for: feedback.feedback_for === 1 ? (
                            <p className='text-center flex items-center justify-center'>
                                <span className='mx-2'><AiOutlineUser /></span>
                                <span className="text-sm font-medium">همکار</span>
                            </p>
                        ) : feedback.feedback_for === 2 ? (
                            <p className='text-center flex items-center justify-center'>
                                <span className='mx-2'><AiOutlineShoppingCart /></span>
                                <span className="text-sm font-medium">کالا / خدمات</span>
                            </p>
                        ) : (
                            <p className='text-center flex items-center justify-center'>
                                <span className='mx-2'><AiOutlineShoppingCart /></span>
                                <span className="text-sm font-medium">فرآیند خرید</span>
                            </p>
                        ),
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
                                        const positiveNegative = feedback.positive_or_negative == 0 ? 'true' : 'false'
                                        form.setValues({
                                            id: feedback.id,
                                            name: feedback.title,
                                            positiveNegative: positiveNegative,
                                            typeFeedback: feedback.feedback_for.toString(),
                                        })
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
                                    onClick={() => handleDelete(feedback.id)}
                                >
                                    <RiDeleteBin6Line />
                                </button>
                            </Tooltip>
                        </div >

                    }
                })}
            />
        </>
    )
}