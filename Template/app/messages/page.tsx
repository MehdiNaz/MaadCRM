import Messages from "@/components/pages/messages";
import Content from "app/content";
import { Metadata } from "next";

export const metadata: Metadata = {
    title: "پیام ها",
}

export default function Page() {
    return (
        <Content breadcrumbTitle="پیام ها" active_menu='messages'>
            <Messages />
        </Content>
    )
}