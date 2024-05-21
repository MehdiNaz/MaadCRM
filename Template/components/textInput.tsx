'use client'
import { TextInput as Input } from "@mantine/core"
import { TextInputType } from '@/types/customComponents'
import { convertPerisnaNumbersToEnglishNumbers } from "@/utils/helper"
import { useId } from "react"

export default function TextInput({ label, id, className, ...props }: TextInputType) {

    const labelID: string = useId()

    return (
        <>
            {label && (
                <div className="grid grid-cols-12">
                    <div className="col-span-3 flex items-center">
                        <label htmlFor={labelID ?? id}>
                            <span className="w-max text-sm">{label}</span>
                        </label>
                    </div>
                    <Input
                        {...props}
                        id={id ?? labelID}
                        className={className + " col-span-9"}
                        onChange={(event) => {
                            event.target.value = convertPerisnaNumbersToEnglishNumbers(event.target.value)
                            if (props.onChange) {
                                props.onChange(event)
                            }
                        }}
                    />
                </div>
            ) || (
                    <div className="w-full">
                        <Input
                            {...props}
                        />
                    </div>
                )}
        </>
    )

}