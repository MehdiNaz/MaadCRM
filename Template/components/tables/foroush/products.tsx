'use client'
import { ClientsTableType } from '@/types/customComponents';
import '../clientsTable.css'
import { useEffect, useState } from 'react';
import TableTitle from '../tableTitle';
import { IoMdRemoveCircleOutline } from 'react-icons/io';
import { handleComma } from 'utils/helper';
import { showNotification } from '@mantine/notifications';
import { deleteOrder } from 'services/order';
import { AppDispatch, RootState } from 'store/store';
import { useDispatch, useSelector } from 'react-redux';
import { setTotal } from 'slices/foroushSlice'

export default function FactorProducts({ data, onRemove }: ClientsTableType) {


    const dispatch = useDispatch<AppDispatch>()

    const [products, setProducts] = useState(data)
    useEffect(() => {
        setProducts(data)
    }, [data])


    async function deleteorder(id) {
        try {
            const response = await deleteOrder({ id: id })
            const newProducts = products.filter((product) => product.id !== id)
            setProducts(newProducts)
            onRemove(id)
            showNotification({
                title: 'موفق',
                message: 'کالا با موفقیت حذف شد',
                color: 'green',
            })
        } catch (err) {
            showNotification({
                title: 'خطا',
                message: 'مشکلی در حذف کالا به وجود آمده است',
                color: 'red',
            })
        }
    }


    return (
        <>
            <div className='w-full flex flex-col'>
                <div className="grid grid-cols-12 mb-3 border-b-2 pb-2">
                    <div className="col-span-4 text-center">
                        <span className="text-sm font-medium">کالا / خدمات</span>
                    </div>
                    <div className="col-span-1 text-center">
                        <span className="text-sm font-medium">تعداد</span>
                    </div>
                    <div className="col-span-3 text-center">
                        <span className="text-sm font-medium">قیمت</span>
                    </div>
                    {/* <div className="col-span-2 text-center">
                        <span className="text-sm font-medium">تخفیف</span>
                    </div> */}
                    <div className="col-span-4 text-end ml-24">
                        <span className="text-sm font-medium">جمع کل</span>
                    </div>
                </div>
                <div className="grid grid-cols-1">
                    {products && products.length > 0 && products.map((product, index) => {
                        let totalPrice = products.map((item) => {
                            return item.total
                        }).reduce((a, b) => a + b, 0)
                        dispatch(setTotal(totalPrice))
                        return (
                            <div className="grid grid-cols-12 bg-white shadow-sm mb-2 py-3 items-center px-3 rounded-md border"
                                key={index}>
                                <div className="col-span-4 text-center">
                                    <span className="text-sm font-medium">
                                        {product.name}
                                    </span>
                                </div>
                                <div className="col-span-1 text-center">
                                    <span className="text-sm font-medium">
                                        {product.count}
                                    </span>
                                </div>
                                <div className="col-span-3 text-center">
                                    <span className="text-sm font-medium">
                                        {handleComma(product.price)}
                                    </span>
                                </div>
                                {/* <div className="col-span-2 text-center">
                                    <span className="text-sm font-medium">
                                        {
                                            handleComma(product.discount)
                                        }
                                    </span>
                                </div> */}
                                <div className="col-span-4 text-center">
                                    <p className='flex items-center justify-end'>
                                        <span className="text-sm font-medium ml-20">
                                            {handleComma(product.total)}
                                        </span>
                                        <button
                                            onClick={(e) => {
                                                e.preventDefault()
                                                deleteorder(product.id)
                                            }}
                                        >
                                            <IoMdRemoveCircleOutline />
                                        </button>
                                    </p>
                                </div>
                            </div>
                        )
                    })}
                    <div className="w-full flex justify-end mt-4">
                        <p className='border-t flex justify-between pt-3'>
                            <span className='ml-16'>جمع کل :</span>
                            <span>
                                {
                                    handleComma(
                                        products.map((item) => {
                                            return item.total
                                        }).reduce((a, b) => a + b, 0)
                                    )}
                            </span>
                        </p>
                    </div>
                </div>
            </div>
        </>
    )
}