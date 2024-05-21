'use client'
import { useEffect, useState } from "react";
import { getProvinceList } from "services/location";
import { Loader } from "@mantine/core";
import SelectBox from "../selectBox";
import { showNotification } from "@mantine/notifications";
import { ProvinceType } from "@/types/customComponents";

export default function Provinces({ onChange, ...props }: { onChange?: Function, label?: string, error?: any }) {

    const [provinces, setProvinces] = useState([])
    const [loading, setLoading] = useState<boolean>(true)

    async function getProvinces() {
        try {
            setLoading(true)
            const response = await getProvinceList()
            setProvinces([])
            response.provinces.map((item: ProvinceType) => {
                setProvinces(prev => [...prev, { value: item.id, label: item.name }])
            })
        } catch (e) {
            setProvinces([{
                label: 'استانی یافت نشد',
                value: '',
                disabled: true
            }])
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در دریافت اطلاعات استان ها',
                color: 'red'
            })
        } finally {
            setLoading(false)
        }
    }

    useEffect(() => {
        getProvinces()
    }, [])

    function handleOnChange(value) {
        if (onChange) {
            onChange(value)
        }
    }

    return (
        <SelectBox
            searchable
            label={props.label != '' || props.label != null ? 'استان' : ''}
            onChange={handleOnChange}
            placeholder='استان'
            icon={loading ? <Loader size={13} /> : null}
            disabled={loading}
            data={provinces}
            {...props}
        />
    )
}