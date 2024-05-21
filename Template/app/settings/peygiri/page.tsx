import PeygiriSettings from "@/components/pages/settings/peygiri";
import Content from "app/content";
import { Metadata } from "next";

export const metadata: Metadata = {
    title: 'تنظیمات پیگیری'
}

export default function Page() {
    return (
        <Content breadcrumbTitle='تنظیمات پیگیری' active_menu='settings' header={null}>
            <PeygiriSettings />
        </Content>
    )
}