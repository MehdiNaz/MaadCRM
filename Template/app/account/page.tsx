import Account from "@/components/pages/account";
import Contacts from '@/components/pages/contacts'
import Content from 'app/content'
import { Metadata } from 'next'

export const metadata: Metadata = {
    title: 'حساب من',
}

export default function Page() {
    return (
        <Content breadcrumbTitle="اطلاعات کاربری" header={null}>
            <Account />
        </Content>
    )
}