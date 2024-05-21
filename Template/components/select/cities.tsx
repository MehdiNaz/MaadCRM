'use client'
import { CitiesType } from "@/types/customComponents";
import { Loader, SelectProps } from "@mantine/core";
import { useId } from "@mantine/hooks";
import { showNotification } from "@mantine/notifications";
import { useEffect, useState } from "react";
import { getCityByProvinceId } from "services/location";
import SelectBox from "../selectBox";

export default function Cities({ provinceID, onChange, defaultCity, ...props }: { provinceID?: string, onChange: Function, disabled?: boolean, defaultCity?: string, label?: string }) {

    const [cities, setCities] = useState([])
    const [loading, setLoading] = useState<boolean>(true)
    const [province, setProvince] = useState<string>(provinceID)

    const [fetched, setFetched] = useState<boolean>(false)

    async function getCities() {
        try {
            if (!province || province === '' || province === 'undefined') {
                return
            }
            const response = await getCityByProvinceId(provinceID)

            if (response.cities.length > 0) {
                setCities([])
                response.cities.map((item) => {
                    setCities(cities => [...cities, { value: item.id, label: item.name }])
                })
            } else {
                setCities([{
                    label: 'شهری یافت نشد',
                    value: '',
                    disabled: true
                }])
            }
        } catch (e) {
            if (provinceID === '') {
                return
            }
            showNotification({
                title: 'خطا',
                message: 'خطایی در دریافت اطلاعات شهرها رخ داده است',
                color: 'red',
            })
            setCities([{
                label: 'شهری یافت نشد',
                value: '',
                disabled: true
            }])
        } finally {
            setLoading(false)
            setFetched(true)
        }
    }

    useEffect(() => {
        setLoading(true)
        setProvince(provinceID)
    }, [provinceID])

    useEffect(() => {
        setLoading(true)
        getCities()
    }, [province])

    return (
        <SelectBox
            defaultValue={defaultCity}
            onChange={(e) => onChange(e)}
            searchable
            label={props.label != '' || props.label != null ? 'شهر' : ''}
            icon={fetched == true && loading == true ? <Loader size={13} /> : null}
            disabled={loading}
            placeholder='شهر'
            data={cities}
            {...props}
        />
    )
}