import { ModalProps, SelectProps, TextInputProps } from "@mantine/core"
import React, { ReactElement, ReactNode } from "react"

export type ButtonProps = {
    classNames?: Object
    className?: any
    onClick?: any
    children?: React.ReactNode,
    type?: 'button' | 'submit' | 'reset' | 'button'
    size?: 'xs' | 'sm' | 'md' | 'lg' | 'xl'
    icon?: any
}

export type AbsoluteButtonProps = {
    label: string
    onClick?: () => void
    icon?: any,
    link?: string
}

export type IconType = {
    icon?: ReactElement
    title: string
    description?: string
    active?: boolean
}

export type columnType = {
    label: string,
    id: string,
    className?: string
}
export type TableBoxType = {
    columns: Array<columnType>,
    data: Array<any>,
    striped?: boolean,
}

export interface MaadModalType extends ModalProps {
    title: string
    children?: any
    onClose: () => void
    open?: boolean
    size?: 'xs' | 'sm' | 'md' | 'lg' | 'xl' | any
    className?: string
    classNames?: Object
    fullScreen?: boolean
    loading?: boolean
}

export type DashboardBoxType = {
    title: string
    children?: any
}

export type ClientsTableType = {
    data: Array<any>,
    onSuccess?: (response) => void
    onRemove?: (response) => void
    onDelete?: Function
}

export interface TextInputType extends TextInputProps {
    getInputProps?: any
    ref?: any
    onChange?: any
}

export interface SelectPropstype {
    label: string
    provinceID?: string
}

export type DateInputType = {
    label?: string
    onChange?: Function
    error?: string | ReactNode
    reset?: boolean
    value?: string
    defaultDay?: string
    defaultMonth?: string
    defaultYear?: string
    disabled?: boolean
}

export type CitiesType = {
    idCity: string
    cityName: string
    idProvince: string
    provinceName: string
    displayOrder?: number
}

export type ProvinceType = {
    idProvince?: string
    provinceName?: string
    id?: string
    name?: string
}

export type TableType = {
    columns: columnType[]
    data: any[]
    fetched?: boolean
}