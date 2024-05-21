'use client'
import { ClientsTableType } from '@/types/customComponents';
import { BsCartXFill } from 'react-icons/bs';
import TableTitle from './tableTitle';
import { GiNotebook, GiSellCard } from 'react-icons/gi'
import { HiRefresh } from 'react-icons/hi';
import { FiEdit } from 'react-icons/fi';
import { RiDeleteBin6Line } from 'react-icons/ri';
import './clientsTable.css'
import { LoadingOverlay, Skeleton, Text, Tooltip } from '@mantine/core';
import NewPeygiri from '../pages/customers/newPeygiri';
import { useEffect, useState } from 'react';
import NewNote from '../pages/customers/addNote';
import { useRouter } from 'next/navigation';
import Link from 'next/link';
import { modals } from '@mantine/modals';
import { showNotification } from '@mantine/notifications';
import { deleteCustomer } from 'services/customer';
import { useDispatch, useSelector } from 'react-redux';
import { AppDispatch, RootState } from 'store/store';
import NewFeedback from '../pages/customers/newFeedback';
import { setCount, setAllCustomers, setBelghovehCount, setDarHalePeyGiryCount, setBelFelCount, setRazyCount, setNaRazyCount, setVafadarCount } from 'slices/customerSlice';
import { CustomerState } from '@/types/customer';
import Pagination from '../customers/pagination';

export default function ClientsTable({ data = [] }: ClientsTableType) {

    const { belghovehCount, darHalePeyGiryCount, belFelCount, razyCount, naRazyCount, vafadarCount, allCount, total_pages } = useSelector((state: RootState) => state.customers)

    const [loading, setLoading] = useState<boolean>(false)
    const [peygiri, setPeygiri] = useState<boolean>(false)
    const [note, setNote] = useState<boolean>(false)
    const [feedback, setFeedback] = useState<boolean>(false)
    const [id, setId] = useState<string>('')

    const [customers, setCustomers] = useState<Array<any>>(data)


    useEffect(() => {
        setCustomers(data)
    }, [data])


    async function deletecustomer(id) {
        try {
            setLoading(true)
            const response = await deleteCustomer({ id: id })
            if (response.success) {
                showNotification({
                    title: 'عملیات موفق',
                    message: "مشتری مورد نظر شما با موفقیت حذف شد",
                    color: 'green'
                })

                const newCustomers = customers.filter((customer) => customer.id !== id)

                newCustomers.map((customer) => {
                    switch (customer.customerStateType) {
                        case 1: dispatch(setBelghovehCount(belghovehCount == 0 ? 0 : belghovehCount - 1))
                        case 2: dispatch(setBelFelCount(belFelCount == 0 ? 0 : belFelCount - 1))
                        case 3: dispatch(setRazyCount(razyCount == 0 ? 0 : razyCount - 1))
                        case 4: dispatch(setNaRazyCount(naRazyCount == 0 ? 0 : naRazyCount - 1))
                        case 5: dispatch(setDarHalePeyGiryCount(darHalePeyGiryCount == 0 ? 0 : darHalePeyGiryCount - 1))
                        case 6: dispatch(setVafadarCount(vafadarCount == 0 ? 0 : vafadarCount - 1))
                    }
                })
                setCustomers(newCustomers)
                dispatch(setAllCustomers(newCustomers))
            }
        } catch (err) {
            console.log(err);
            showNotification({
                title: "عملیات ناموفق",
                message: 'حذف مشتری انجام نشد',
                color: "red"
            })
        } finally {
            setLoading(false)
        }
    }


    const openModal = (id) => modals.openConfirmModal({
        title: 'حذف مشتری',
        children: (
            <Text size="sm">
                آیا از حذف این مشتری مطمئن هستید؟
            </Text>
        ),
        labels: { confirm: 'حذف', cancel: 'لغو' },
        onConfirm: () => deletecustomer(id),
        confirmProps: { color: 'red' },
    })

    const dispatch = useDispatch<AppDispatch>()


    const customerStatus = (status: number): string => {
        switch (status) {
            case 1: return CustomerState.Belghoveh
            case 2: return CustomerState.Belfel
            case 3: return CustomerState.Razy
            case 4: return CustomerState.NaRazy
            case 5: return CustomerState.DarHalePeyGiry
            case 6: return CustomerState.Vafadar
            default: return CustomerState.Belghoveh
        }
    }

    const [page, setPage] = useState<number>(1)


    return (
        <div className='w-full flex flex-col relative'>
            <LoadingOverlay visible={loading} />
            <div className="grid grid-cols-12 mb-3">
                {customers.length == 0 ?
                    <>
                        <Skeleton height={10} mt={6} width="100%" className='col-span-2' />
                        <Skeleton height={10} mt={6} width="100%" className='col-span-2' />
                        <Skeleton height={10} mt={6} width="100%" className='col-span-3' />
                        <Skeleton height={10} mt={6} width="100%" className='col-span-2' />
                        <Skeleton height={10} mt={6} width="100%" className='col-span-3' />
                    </>
                    : (
                        <>
                            <div className="col-span-2 text-center">
                                <TableTitle title="نام و نام خانوادگی" />
                            </div>
                            <div className="col-span-2 text-center">
                                <TableTitle title="شماره تماس" />
                            </div>
                            <div className="col-span-3 text-center">
                                <TableTitle title="ایمیل" />
                            </div>
                            <div className="col-span-2 text-center">
                                <TableTitle title="وضعیت" />
                            </div>
                            <div className="col-span-3 text-center">
                                <TableTitle title="عملیات" />
                            </div>
                        </>
                    )}
            </div>
            <div
                className="grid grid-cols-12">
                <NewPeygiri
                    onSuccess={null}
                    opened={peygiri}
                    id={id}
                    onClose={() => setPeygiri(false)}
                />
                <NewNote
                    opened={note}
                    onClose={() => setNote(false)}
                    id={id}
                />
                <NewFeedback
                    opened={feedback}
                    onClose={() => setFeedback(false)}
                    id={id}
                />
                {customers.length == 0 &&
                    <>
                        <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                        <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                        <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                        <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                        <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                        <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                        <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                    </>
                }
                {customers.map((customer, index) => {
                    return (
                        <div key={index}
                            className="col-span-12 grid grid-cols-12 bg-white shadow-sm mb-2 py-3 items-center px-3 rounded-md">
                            <div className="col-span-2 text-center">
                                <Link href={`/customers/profile/${customer.id}`}>
                                    <span className="text-sm font-medium">{
                                        customer.first_name ? customer.first_name + ' ' + customer.last_name : customer.last_name
                                    }</span>
                                </Link>
                            </div>
                            <div className="col-span-2 text-center">
                                <span className="text-sm font-medium">{customer.phone}</span>
                            </div>
                            <div className="col-span-3 text-center">
                                <span className="text-sm font-medium">
                                    {customer.email ? customer.email : 'ندارد'}
                                </span>
                            </div>
                            <div className="col-span-2 text-center">
                                <span className="text-sm font-medium">{customerStatus(customer.state)}</span>
                            </div>
                            <div className="col-span-3 text-center flex justify-center clients-table__actions text-2xl">
                                <Tooltip
                                    withArrow
                                    classNames={{
                                        tooltip: '!text-11p',
                                    }}
                                    label="ثبت فروش">
                                    <button>
                                        <Link href={'customers/foroush/' + customer.id}>
                                            <GiSellCard />
                                        </Link>
                                    </button>
                                </Tooltip>
                                <Tooltip
                                    withArrow
                                    classNames={{
                                        tooltip: '!text-11p',
                                    }}
                                    label="ثبت بازخورد">
                                    <button
                                        onClick={() => {
                                            setId(customer.id)
                                            setFeedback(true)
                                        }}
                                    >
                                        <GiSellCard />
                                    </button>
                                </Tooltip>
                                <Tooltip
                                    withArrow
                                    classNames={{
                                        tooltip: '!text-11p',
                                    }}
                                    label="ثبت یادداشت">
                                    <button
                                        onClick={
                                            () => {
                                                setId(customer.id)
                                                setNote(true)
                                            }
                                        }
                                    >
                                        <GiNotebook />
                                    </button>
                                </Tooltip>
                                <Tooltip
                                    withArrow
                                    classNames={{
                                        tooltip: '!text-11p',
                                    }}
                                    label="ثبت پیگیری">
                                    <button
                                        onClick={
                                            () => {
                                                setId(customer.id)
                                                setPeygiri(true)
                                            }
                                        }
                                    >
                                        <HiRefresh />
                                    </button>
                                </Tooltip>
                                <Tooltip
                                    withArrow
                                    classNames={{
                                        tooltip: '!text-11p',
                                    }}
                                    label="ویرایش">
                                    <Link href={'customers/edit/' + customer.id}>
                                        <FiEdit />
                                    </Link>
                                </Tooltip>
                                <Tooltip
                                    withArrow
                                    classNames={{
                                        tooltip: '!bg-red-500 !text-white !text-11p',
                                    }}
                                    label="حذف">
                                    <button
                                        onClick={
                                            () => {
                                                openModal(customer.id)
                                            }
                                        }
                                    >
                                        <RiDeleteBin6Line />
                                    </button>
                                </Tooltip>
                            </div>
                        </div>
                    )
                })}
            </div>
            {total_pages > 1 && (
                <div className="mt-4">
                    <Pagination />
                </div>
            )}
        </div>
    );
}