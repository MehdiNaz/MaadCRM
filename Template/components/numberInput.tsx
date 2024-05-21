'use client'
import { NumberInput } from "@mantine/core"
export default function InputNumber({ label, ...props }: {
    label?: string
    [key: string]: any
}) {

    return (
        <>
            {label && (
                <label className="grid grid-cols-12">
                    <span className="col-span-3 flex items-center text-sm">{label}</span>
                    <NumberInput
                        className={props.className + " col-span-9"}
                        {...props}
                    />
                </label>
            ) || (
                    <NumberInput
                        {...props}
                    />
                )}
        </>
    )

}