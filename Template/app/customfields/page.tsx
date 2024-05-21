import CustomFields from "@/components/pages/customfields";
import { hasAccess } from "@/utils/helper";
import Content from "app/content";
import { Metadata } from "next";
import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export const metadata: Metadata = {
    title: 'فیلدهای سفارشی'
}

export default function Page() {
    const token = cookies().get('token').value
    const access = hasAccess({
        role: 'ADMIN',
        token: token
    })
    if (!access) {
        redirect('/customers')
    }

    return (
        <Content breadcrumbTitle='فیلدهای سفارشی' active_menu='settings' >
            <CustomFields />
        </Content>
    )
}