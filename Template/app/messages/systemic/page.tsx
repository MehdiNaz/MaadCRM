import Systemic from "@/components/pages/messages/systemic";
import Content from "app/content";
import { Metadata } from "next";

export const metadata: Metadata = {
    title: 'پیام های سیستمی'
}

export default function Page() {
    return (
        <Content breadcrumbTitle='پیام های سیستمی' active_menu='messages'>
            <Systemic />
        </Content>
    )
}