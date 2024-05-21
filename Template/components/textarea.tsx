'use client'
import { TextareaProps } from "@mantine/core";
import { Textarea as TextareaComponent } from "@mantine/core";

export default function Textarea(
    { label, ...props }: TextareaProps
) {
    if (label) {
        return (
            <div className="grid grid-cols-12">
                <span className="col-span-12 my-2 text-sm">{label}</span>
                <TextareaComponent
                    {...props}
                    className="col-span-12"
                />
            </div>
        )
    } else {
        return (
            <TextareaComponent
                {...props}
            />
        )
    }
}
