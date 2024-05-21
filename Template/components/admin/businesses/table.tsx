'use client'
import Table from "@/components/tables/table"
import { handleComma } from "@/utils/helper"
import { Tooltip } from "@mantine/core"
import Link from "next/link"
import { useEffect, useState } from "react"
import { FiEdit } from "react-icons/fi"
import { RiDeleteBin6Line } from "react-icons/ri"

export default function BusinessesTable({ data }) {

    const [businesses, setBusinesses] = useState(data)

    useEffect(() => {
        setBusinesses(data)
    }, [data])



    return (
        <>
            <Table
                columns={[
                    {
                        label: 'عنوان',
                        id: 'title'
                    },
                    {
                        label: 'شماره تماس',
                        id: 'phone'
                    },
                    {
                        label: 'تعداد مشتریان',
                        id: 'customers'
                    },
                    {
                        label: 'عملیات',
                        id: 'actions'
                    }
                ]}
                data={
                    businesses.map((business, index) => {
                        return {
                            title: <Link href={'/users/edit/' + business.id}>{business.user.first_name + ' ' + business.user.last_name}</Link>,
                            phone: business.user.phone,
                            customers: handleComma(business.customers) + ' نفر',
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
                                                href={`products/edit/${business.id}`}
                                            >
                                                <FiEdit size={16} />
                                            </Link>
                                        </Tooltip>
                                    </div>
                                    {/* <div className="flex">
                                        <Tooltip
                                            withArrow
                                            classNames={{
                                                tooltip: '!bg-red-500 !text-white !text-11p',
                                            }}
                                            label="حذف">
                                            <button
                                                onClick={() => { }}
                                            >
                                                <RiDeleteBin6Line size={16} />
                                            </button>
                                        </Tooltip>
                                    </div> */}
                                </div>
                            )
                        }
                    })
                }
            />
        </>
    )
}