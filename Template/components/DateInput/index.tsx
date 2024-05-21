import { DateInputType } from "@/types/customComponents"
import { validDate } from "@/utils/helper"
import { ReactNode, useEffect, useId, useRef, useState } from "react"

export default function DateInput({ label, onChange, error, reset, value, disabled = false }: DateInputType) {

    const id = useId()

    const dayRef = useRef<HTMLInputElement>()
    const monthRef = useRef<HTMLInputElement>()
    const yearRef = useRef<HTMLInputElement>()

    const [day, setDay] = useState<string>('')
    const [month, setMonth] = useState<string>('')
    const [year, setYear] = useState<string>('')

    const [rerender, setRerender] = useState<boolean>(false)

    useEffect(() => {
        if (value) {
            let date = value.split('-')
            setYear(date[0])
            setMonth(date[1])
            setDay(date[2])
            yearRef.current.value = date[0]
            monthRef.current.value = date[1]
            dayRef.current.value = date[2]
        }
    }, [value])

    useEffect(() => {
        setRerender(rerender => !rerender)
    }, [reset])

    useEffect(() => {
        dayRef.current.value = ''
        monthRef.current.value = ''
        yearRef.current.value = ''
    }, [rerender])

    useEffect(() => {
        if (dayRef.current === document.activeElement) {
            if (day.length === 2) {
                monthRef.current.focus()
            }
        }
        if (monthRef.current === document.activeElement) {
            if (month.length === 2) {
                yearRef.current.focus()
            }
        }
    }, [day, month])

    function renderSlash() {
        return <span className="text-gray-500 col-span-1 flex justify-center">/</span>
    }

    function handleChanges(day, month, year) {
        const date = `${year}-${month}-${day}`
        if (onChange) {
            if (date === '--') {
                onChange('')
            } else {
                onChange(date)
            }
        }
    }

    return (
        <div className="w-full grid grid-cols-12">
            {label && (
                <label className="col-span-3 flex items-center text-sm" htmlFor={id}>{label}</label>
            )}
            <div className={`grid grid-cols-11 ${label ? 'col-span-9' : 'col-span-12'}`}>
                <div className="grid grid-cols-12 col-span-12 border border-[#ced4da] rounded-[0.25rem] py-1 items-center justify-center">
                    <input
                        id={id}
                        ref={dayRef}
                        className="col-span-3 text-center text-sm"
                        type="text"
                        placeholder="روز (01)"
                        maxLength={2}
                        onChange={(e) => {
                            const value = e.target.value
                            setDay(value)
                            handleChanges(value, month, year)
                        }}
                        disabled={disabled}
                    />
                    {renderSlash()}
                    <input
                        ref={monthRef}
                        className="col-span-3 text-center text-sm"
                        type="text"
                        placeholder="ماه (10)"
                        maxLength={2}
                        onChange={(e) => {
                            const value = e.target.value
                            setMonth(value)
                            handleChanges(day, value, year)
                        }}
                        disabled={disabled}
                    />
                    {renderSlash()}
                    <input
                        ref={yearRef}
                        className="col-span-3 text-center text-sm"
                        type="text"
                        placeholder="سال (1384)"
                        maxLength={4}
                        onChange={(e) => {
                            let value = e.target.value
                            setYear(value)
                            handleChanges(day, month, value)
                        }}
                        disabled={disabled}
                    />
                </div>
            </div>
            {error && error != '' && <span className={`${label ? 'col-span-9 col-start-4' : 'col-span-12'} mt-2 text-red-500 text-xs`}>{error}</span>}
        </div>
    )
}