import { ReferType } from "@/types/customer"
import { Autocomplete, Loader } from "@mantine/core"
import useRefer from "hooks/useRefer"
import { useEffect, useId, useState } from "react"

export default function Moarefs({ reset, onSubmit, defaultValue, ...props }: { reset?: boolean, onSubmit?: (id: string) => void, defaultValue?: string }) {

    const [loading, setLoading] = useState<boolean>(false)
    const [referSerach, setReferSearch] = useState<string>('')
    const refers = useRefer({ refer: referSerach })
    const [refersList, setrefersList] = useState<any>([{ label: 'یک شماره موبایل یا اسم را وارد کنید', value: '', disabled: true }])
    const [refersID, setrefersID] = useState<string[]>([])


    useEffect(() => {
        if (defaultValue) {
            setReferSearch(defaultValue)
        }
    }, [defaultValue])

    useEffect(() => {
        if (refers) {
            if (refers.length == 0 && referSerach.length > 0) {
                setrefersList([{ label: 'معرفی یافت نشد', value: '', disabled: true }])
                setLoading(false)
            }
            if (refers.length > 0) {
                setrefersList([])
                refers.map((refer: ReferType) => {
                    setrefersList((refers: ReferType[]) => [...refers, refer?.first_name ? refer.first_name + ' ' + refer.last_name + ' - ' + refer.phone : refer.last_name + ' - ' + refer.phone])
                })
                refers.map((refer: ReferType) => {
                    setrefersID((refersID: string[]) => [...refersID, refer.id])
                })
                setLoading(false)
            }
        }
    }, [refers])

    useEffect(() => {
        if (referSerach.length > 0) {
            setLoading(true)
        } else {
            setLoading(false)
        }
    }, [referSerach])


    useEffect(() => {
        if (reset) {
            setReferSearch('')
            setrefersList([{ label: 'یک شماره موبایل یا اسم را وارد کنید', value: '', disabled: true }])
        }
    }, [reset])

    const id = useId()
    return (
        <div className="grid grid-cols-12">
            <label htmlFor={id} className="col-span-3 text-sm">مشتری معرف :</label>
            <Autocomplete
                id={id}
                value={referSerach}
                className="col-span-9"
                placeholder="مشتری معرف"
                data={refersList}
                rightSection={loading ? <Loader size="1rem" /> : null}
                onChange={(e) => {
                    setReferSearch(e)
                }}
                onItemSubmit={(value) => {
                    if (onSubmit) {
                        onSubmit(refersID[refersList.indexOf(value.value)])
                    }
                }}
                {...props}
            />
        </div>
    )
}