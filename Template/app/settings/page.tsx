import Settings from "@/components/pages/settings";
import Content from "app/content";
import { Metadata } from "next";

export const metadata: Metadata = {
    title: 'تنظیمات',
}

export default function Page() {
    return (
        <Content breadcrumbTitle="تنظیمات" active_menu='settings'>
            <Settings />
        </Content>
    )
}