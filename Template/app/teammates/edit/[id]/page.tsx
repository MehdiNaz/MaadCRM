import EditTeammate from "@/components/pages/teammates/edit";
import { hasAccess } from "@/utils/helper";
import Content from "app/content";
import { Metadata } from "next";
import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export const metadata: Metadata = {
    title: 'ویرایش همکار'
}

export default function Page({ params: { id } }) {
    const token = cookies().get('token').value
    // const access = hasAccess({
    //     role: 'Users',
    //     token: token
    // })
    // if (!access) {
    //     redirect('/customers')
    // }

    return (
        <Content breadcrumbTitle='ویرایش همکار' active_menu='teammates'>
            <EditTeammate id={id} />
        </Content>
    )
}