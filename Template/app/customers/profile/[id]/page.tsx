import CustomerProfile from "@/components/pages/customers/profile";
import Content from "app/content";
import { Metadata } from "next";

export const metadata: Metadata = {
    title: 'پروفایل مشتری',
}

export default function Page({ params: { id } }) {
    return (
        <Content breadcrumbTitle='پروفایل مشتری' active_menu='customers' actions={null}>
            <CustomerProfile id={id} />
        </Content>
    )
}