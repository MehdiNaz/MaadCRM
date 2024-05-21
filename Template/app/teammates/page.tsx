import Teammates from "@/components/pages/teammates";
import Content from "app/content";
import { Metadata } from "next";
import { cookies } from "next/headers";

export const metadata: Metadata = {
    title: 'همکاران',
}

export default function Page() {

    const token = cookies().get('token').value

    return (
        <Content breadcrumbTitle="همکاران" active_menu='teammates' header={null}>
            <Teammates token={token} />
        </Content>
    )
}