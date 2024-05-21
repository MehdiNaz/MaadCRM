import Customters from "@/components/pages/customers";
import Content from "app/content";
import { Metadata } from "next";

export const metadata: Metadata = {
    title: "مشتریان",
}

export default function Page() {
    return (
        <Content breadcrumbTitle="مشتریان" active_menu='customers'>
            <Customters />
        </Content>
    )
}