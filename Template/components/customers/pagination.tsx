import Link from "next/link";
import { Pagination as MantinePagination } from "@mantine/core";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "store/store";
import { fetchCustomers, setPage } from "@/slices/customerSlice";
import { usePathname, useRouter, useSearchParams } from "next/navigation";
import { useCallback } from "react";

export default function Pagination({ }) {

    const router = useRouter()
    const searchParams = useSearchParams()
    const patchname = usePathname()

    const { total, page, per_page } = useSelector((state: RootState) => state.customers)
    const dispatch = useDispatch<AppDispatch>()


    const createQueryString = useCallback(
        (name: string, value: string) => {
            const params = new URLSearchParams(searchParams.toString())
            params.set(name, value)
            return params.toString()
        },
        [searchParams]
    )


    return <MantinePagination color="rgba(82, 16, 16, 1)" value={page}
        onChange={(value) => {
            dispatch(setPage(value))
            dispatch(fetchCustomers({ page: value }))
            router.push(patchname + '?' + createQueryString("page", value.toString()))
        }}
        total={
            Math.ceil(total / per_page)
        } />
}