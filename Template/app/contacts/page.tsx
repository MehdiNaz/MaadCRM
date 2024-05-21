import Contacts from '@/components/pages/contacts'
import Content from 'app/content'
import { Metadata } from 'next'

export const metadata: Metadata = {
    title: 'مخاطبین',
}

export default function Page() {
    return (
        <Content breadcrumbTitle="مخاطبین" active_menu='contacts' header={null}>
            <Contacts />
        </Content>
    )
}