import FeedbackSettings from "@/components/pages/settings/feedback";
import Content from "app/content";
import { Metadata } from "next";

export const metadata: Metadata = {
    title: 'تنظیمات بازخورد'
}

export default function Page() {
    return (
        <Content breadcrumbTitle='تنظیمات بازخورد' active_menu='settings' header={null}>
            <FeedbackSettings />
        </Content>
    )

}