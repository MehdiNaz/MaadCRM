'use client'
import { TableBoxType } from '@/types/customComponents';
import { Skeleton, Table } from '@mantine/core';
import { useEffect, useState } from 'react';

export default function TableView({ data, columns, striped }: TableBoxType) {
    const columnsCount = columns.length



    const [fetch, setFetched] = useState<boolean>(false)

    useEffect(() => {
        if (data.length > 0)
            setFetched(true)
    }, [data])

    return (
        <div className="w-full">
            <div className="hidden">
                <div className="grid-cols-6"></div>
            </div>
            <div className={`grid grid-cols-` + columnsCount + ` gap-4 border-2 ${fetch ? 'border-borderColor' : ''} rounded-md mb-4 py-2`}>
                {fetch == false && columns.map((column, index) => (
                    <Skeleton key={index} height={20} width="100%" className='col-span-1' />
                ))}
                {fetch && columns.map((column, index) => (
                    <div key={index} className="text-center">
                        <span className="text-md font-bold">{column.label}</span>
                    </div>
                ))}
            </div>
            <div className="w-full">
                {fetch == false && (
                    <>
                        <Skeleton height={35} width="100%" className='col-span-1 mb-4' />
                        <Skeleton height={35} width="100%" className='col-span-1 mb-4' />
                        <Skeleton height={35} width="100%" className='col-span-1 mb-4' />
                        <Skeleton height={35} width="100%" className='col-span-1 mb-4' />
                        <Skeleton height={35} width="100%" className='col-span-1 mb-4' />
                        <Skeleton height={35} width="100%" className='col-span-1 mb-4' />
                    </>
                )}
                {data && data.map((item, index) => (
                    <div key={index} className={`grid grid-cols-` + columnsCount + ` gap-4 rounded-md mb-4 py-2 border border-borderColor`}>
                        {columns.map((column, index) => (
                            <div key={index} className="flex items-center justify-center">
                                <span className="text-sm">{item[column.id]}</span>
                            </div>
                        ))}
                    </div>
                ))}
            </div>
        </div>
    );
}