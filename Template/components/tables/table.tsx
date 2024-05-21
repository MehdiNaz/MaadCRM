import TableTitle from "./tableTitle"
import { columnType, TableType } from '@/types/customComponents'
import { Skeleton } from "@mantine/core"
import { useEffect, useState } from "react"

export default function Table({ columns, data, fetched = false }: TableType) {

    const columnsLength = columns.length

    const [fetch, setFetched] = useState<boolean>(fetched)

    useEffect(() => {
        if (data.length > 0)
            setFetched(true)
    }, [data])


    return (
        <div className='w-full flex flex-col'>
            <div className={`grid grid-cols-${columnsLength} mb-3 gap-3`}>
                {fetch == false ?
                    <>
                        {columns.map((column, index) => {
                            return <Skeleton key={index} height={10} mt={6} width="100%" className='col-span-1' />
                        })}

                    </>
                    : (
                        <>
                            {columns.map((column, index) => {
                                return <div className="col-span-1 text-center" key={index}>
                                    <TableTitle key={index} title={column.label} />
                                </div>
                            })}
                        </>
                    )}
            </div>
            {fetch == false &&
                <div className="grid grid-cols-12">
                    <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                    <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                    <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                    <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                    <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                    <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                    <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                    <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                    <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                    <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                    <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                    <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                    <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                    <Skeleton height={48} mt={6} width="100%" className='col-span-12' />
                </div>
            }
            {data.map((item, index) => {
                return (
                    <div className={`col-span-12 grid grid-cols-${columnsLength} bg-white shadow-sm mb-2 py-3 items-center px-3 rounded-md`} key={index} >
                        {columns.map((column, index) => {
                            const className = column?.className ?? 'col-span-1'
                            let current = item[0]
                            return (
                                <div key={index} className={`${className} text-center`}>
                                    <span className="text-sm text-center">{item[column.id]}</span>
                                </div>
                            )
                        })}
                    </div>
                )
            })}
        </div >
    )
}