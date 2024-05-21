import DateInput from "@/components/DateInput"
import MultiSelect from "@/components/multiSelect"
import InputNumber from "@/components/numberInput"
import SelectBox from "@/components/selectBox"
import TextInput from "@/components/textInput"
import { fetchFields, setFieldValueByID } from "@/slices/customfieldsSlice"
import { FieldType } from "@/types/customfields"
import { convertDateToPerisan } from "@/utils/helper"
import { Skeleton } from "@mantine/core"
import { useEffect, useState } from "react"
import { useDispatch, useSelector } from "react-redux"
import { AppDispatch, RootState } from "store/store"

export default function NewCustomerFields({ attributes, fetched }: { attributes?: any, fetched?: any }) {

    const { loading, fields } = useSelector((state: RootState) => state.customfields)

    const dispatch = useDispatch<AppDispatch>()

    useEffect(() => {
        dispatch(fetchFields())
    }, [])


    const [customerAttributes, setCustomerAttributes] = useState<any[]>(attributes)

    useEffect(() => {
        if (attributes == null || attributes.length == 0) return
        setCustomerAttributes(attributes)
    }, [attributes])

    useEffect(() => {
        if (!customerAttributes || customerAttributes.length == 0) return
        let selected_options = []
        customerAttributes.map((value) => {
            fields.map((field) => {
                if (value.field_id === field.id) {
                    if (field.type == 1) {
                        dispatch(setFieldValueByID({
                            id: value.field_id,
                            value: value.text_value
                        }))
                    }

                    if (field.type == 2) {
                        dispatch(setFieldValueByID({
                            id: value.field_id,
                            value: value.int_value
                        }))
                    }

                    if (field.type == 3) {
                        dispatch(setFieldValueByID({
                            id: value.field_id,
                            value: convertDateToPerisan(value.date_value)
                        }))
                    }

                    if (field.type == 5) {
                        const option_id = value.option_id
                        dispatch(setFieldValueByID({
                            id: value.field_id,
                            value: option_id
                        }))
                    }

                    if (field.type == 6) {
                        if (value.bool_value) {
                            const field_key = selected_options.findIndex((item) => item.field_id == value.field_id)
                            if (field_key == -1) {
                                selected_options.push({
                                    field_id: value.field_id,
                                    selected: [value.option_id]
                                })
                            } else {
                                selected_options[field_key].selected.push(value.option_id)
                            }
                        }
                    }
                }
            })
        })
        selected_options.map((item) => {
            dispatch(setFieldValueByID({
                id: item.field_id,
                value: item.selected
            }))
        })

    }, [customerAttributes])

    return (
        <>
            {loading == true ? (
                <div className="w-full grid grid-cols-2 gap-5">
                    <div className="col-span-1 grid grid-cols-12 gap-8 items-center">
                        <Skeleton height={35} className="col-span-3" />
                        <Skeleton height={35} className="col-span-9" />
                    </div>
                    <div className="col-span-1 grid grid-cols-12 gap-8 items-center">
                        <Skeleton height={35} className="col-span-3" />
                        <Skeleton height={35} className="col-span-9" />
                    </div>
                    <div className="col-span-1 grid grid-cols-12 gap-8 items-center">
                        <Skeleton height={35} className="col-span-3" />
                        <Skeleton height={35} className="col-span-9" />
                    </div>
                    <div className="col-span-1 grid grid-cols-12 gap-8 items-center">
                        <Skeleton height={35} className="col-span-3" />
                        <Skeleton height={35} className="col-span-9" />
                    </div>

                    <div className="col-span-1 grid grid-cols-12 gap-8 items-center">
                        <Skeleton height={35} className="col-span-3" />
                        <Skeleton height={35} className="col-span-9" />
                    </div>
                    <div className="col-span-1 grid grid-cols-12 gap-8 items-center">
                        <Skeleton height={35} className="col-span-3" />
                        <Skeleton height={35} className="col-span-9" />
                    </div>
                    <div className="col-span-1 grid grid-cols-12 gap-8 items-center">
                        <Skeleton height={35} className="col-span-3" />
                        <Skeleton height={35} className="col-span-9" />
                    </div>
                </div>
            ) : (
                <>
                    <div className="w-full grid grid-cols-2 gap-8">
                        {fields && fields.length > 0 && fields.map((field: FieldType, index: any) => (
                            <div key={index} id={field.id} className="grid grid-cols-12">
                                <div className="col-span-12">
                                    {field.type == 1 && (
                                        <TextInput
                                            error={field.error && 'فیلد ' + field.title + ' اجباری است'}
                                            label={field.title}
                                            placeholder={field.title}
                                            value={field.value}
                                            onChange={(event) => {
                                                dispatch(setFieldValueByID({
                                                    id: field.id,
                                                    value: event.target.value
                                                }))
                                            }}
                                        />
                                    )}
                                    {field.type == 2 && (
                                        <InputNumber
                                            error={field.error && 'فیلد ' + field.title + ' اجباری است'}
                                            label={field.title}
                                            placeholder={field.title}
                                            value={field.value}
                                            onChange={(value) => {
                                                dispatch(setFieldValueByID({
                                                    id: field.id,
                                                    value: value
                                                }))
                                            }}
                                        />
                                    )}
                                    {field.type == 3 && (
                                        <DateInput
                                            label={field.title}
                                            error={field.error && 'لطفا یک تاریخ معتبر وارد کنید'}
                                            value={field.value != '' ? field.value : ''}
                                            onChange={(value) => {
                                                dispatch(setFieldValueByID({
                                                    id: field.id,
                                                    value: value
                                                }))
                                            }}
                                        />
                                    )}
                                    {field.type == 5 && (
                                        <div className="w-full">
                                            <SelectBox
                                                label={field.title}
                                                placeholder={field.title}
                                                searchable
                                                data={field.options && field.options.length > 0 ? field.options.map((option) => ({
                                                    label: option.title,
                                                    value: option.id
                                                })) : []}
                                                error={field.error && 'لطفا یک گزینه انتخاب کنید'}
                                                value={field.value}
                                                onChange={(value) => {
                                                    dispatch(setFieldValueByID({
                                                        id: field.id,
                                                        value: value
                                                    }))
                                                }}
                                            />
                                        </div>
                                    )}
                                    {field.type == 6 && (
                                        <div>
                                            <MultiSelect
                                                label={field.title}
                                                placeholder={field.title}
                                                data={field.options && field.options.length > 0 ? field.options.map((option) => ({
                                                    label: option.title,
                                                    value: option.id
                                                })) : []}
                                                error={field.error && 'لطفا یک گزینه انتخاب کنید'}
                                                value={field.value ? field.value : []}
                                                onChange={(value) => {
                                                    dispatch(setFieldValueByID({
                                                        id: field.id,
                                                        value: value
                                                    }))
                                                }}
                                            />
                                        </div>
                                    )}
                                </div>
                            </div>
                        ))}
                    </div>
                </>
            )}
        </>
    )
}