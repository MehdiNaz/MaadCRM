import { useForm } from '@mantine/form'
import { useRouter } from 'next/navigation'
import { useEffect, useRef } from 'react'
import { BiSearch } from 'react-icons/bi'
import { useDispatch, useSelector } from 'react-redux'
import { fetchCustomers } from 'slices/customerSlice'

export default function Search() {
    const router = useRouter()
    const dispatch = useDispatch()
    const searchRef = useRef<HTMLInputElement>(null)

    const form = useForm({
        initialValues: {
            search: ''
        }
    })

    function submit(values: typeof form.values) {
        if (values.search) {
            dispatch(fetchCustomers({
                search: values.search
            }) as any)
            router.push(`customers/?s=${values.search}`)
        }
    }


    return (
        <form
            onSubmit={form.onSubmit(submit)}
            className='bg-[#D1DFEA] rounded-full flex items-center px-4 w-full'>
            <input
                autoComplete='off'
                type="text"
                ref={searchRef}
                id="search"
                placeholder="جستجو"
                name="s"
                className="rounded-full bg-[#D1DFEA] px-2 text-[#000] placeholder:text-[#7F9EB8] py-2 w-full"
                {...form.getInputProps('search')}
            />
            <button type='submit'><BiSearch fontSize={20} color="#375B75" /></button>
        </form >
    )
}