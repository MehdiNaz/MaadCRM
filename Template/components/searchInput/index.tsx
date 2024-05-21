import { useState } from "react";
import Input from "../textInput";
import { BiSearch } from "react-icons/bi"

export default function SearchInput({ onSubmit, onChange }: { onSubmit?: any, onChange?: any }) {
    const [value, setValue] = useState<string>('')
    return (
        <>
            <form
                className="flex relative overflow-hidden rounded-md" onSubmit={(e) => {
                    e.preventDefault()
                    if (onSubmit) onSubmit(value)
                }}>
                <input
                    type="text"
                    value={value}
                    onChange={(e) => {
                        setValue(e.target.value)
                        if (onChange) onChange(e.target.value)
                    }}
                    name="serach" placeholder="جستجو" className="border-0 shadow-sm w-64 pl-9 px-4 py-2" />
                <button type="submit" className="absolute left-0 top-0 w-8 text-white bg-primary h-full flex justify-center items-center">
                    <BiSearch />
                </button>
            </form>
        </>
    )
}
