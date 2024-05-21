'use client'
import { Loader, SelectProps } from "@mantine/core";
import { useEffect, useState } from "react";
import { getAllActiveProducts } from "services/products";
import SelectBox from "../selectBox";

export default function ProductsSelect({ ...props }) {

    const [data, setData] = useState<Array<any>>([])

    const [loading, setLoading] = useState<boolean>(true)

    async function getProdcust() {
        try {
            const response = await getAllActiveProducts()
            if (response.success && response.products.length > 0) {
                const data = response.products.map((item: any) => {
                    return {
                        label: item.title,
                        value: item.id
                    }
                })
                setData(data)
            } else {
                setData([{
                    label: 'محصولی یافت نشد',
                    value: '',
                    disabled: true
                }])
            }
        } catch (e) {
            setData([])
        } finally {
            setLoading(false)
        }
    }
    useEffect(() => {
        getProdcust()
    }, [])

    return (
        <SelectBox
            searchable
            data={data}
            placeholder="جستجوی محصول"
            icon={loading && <Loader size={13} />}
            disabled={loading}
            {...props}
        />
    )
}