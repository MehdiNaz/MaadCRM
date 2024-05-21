import EditCustomer from "@/components/pages/customers/edit";
import Content from "app/content";
import { Metadata } from "next";

export const metadata: Metadata = {
    title: 'ویرایش مشتری'
}

export default function Page({ params: { id } }) {
    return (
        <Content breadcrumbTitle='ویرایش مشتری' active_menu='customers'>
            <EditCustomer id={id} />
        </Content>
    )
}