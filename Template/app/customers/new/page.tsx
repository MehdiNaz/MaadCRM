import NewCustomer from "@/components/pages/customers/new";
import Content from "app/content";
import { Metadata } from "next";

export const metadata: Metadata = {
    title: 'مشتری جدید'
}

export default function Page() {
    return (
        <Content breadcrumbTitle='مشتری جدید' active_menu='customers'>
            <NewCustomer />
        </Content>
    )
}