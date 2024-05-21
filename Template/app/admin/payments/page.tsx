import AdminContent from "@/components/adminContent"
import { decode_token, hasAccess } from "@/utils/helper"
import { Metadata } from "next"
import { cookies } from "next/headers"
import { redirect } from "next/navigation"

export const metadata: Metadata = {
    title: 'پرداختی ها'
}
export default function Page() {

    const token = cookies().get('token').value
    const access = hasAccess({
        role: 'SUPERADMIN',
        token: token
    })
    if (!access) {
        redirect('/customers')
    }


    return (
        <AdminContent breadcrumbTitle='پرداختی ها' active_menu='payments' hasAccess={access} token={token}>
        </AdminContent>
    )
}