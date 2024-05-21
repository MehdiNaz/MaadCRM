'use client'

import { Select, SelectProps } from "@mantine/core"

export default function SelectBox({ label, ...props }: { label?: string } & SelectProps) {
    if (label) {
        return (
            <div className="grid grid-cols-12">
                <span className="col-span-3 flex items-center text-sm">{label}</span>
                <Select
                    data={props.data}
                    className="col-span-9"
                    {...props}
                />
            </div>
        )
    } else {
        return (
            <Select
                data={props.data}
                {...props}
            />
        )
    }
}