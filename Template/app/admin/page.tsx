import AdminContent from "@/components/adminContent"
import Bussinesses from "@/components/pages/admin/businesse"
import { decode_token, hasAccess } from "@/utils/helper"
import { Metadata } from "next"
import { cookies } from "next/headers"
import { redirect } from "next/navigation"

export const metadata: Metadata = {
    title: 'مدیریت کسب و کارها'
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
        <AdminContent breadcrumbTitle='کسب و کارها' active_menu='bussiness' hasAccess={access} token={token}>
            <Bussinesses />
        </AdminContent>
    )
}