import Groups from '@/components/pages/contacts/groups'
import Content from 'app/content'
import { Metadata } from 'next'

export const metadata: Metadata = {
    title: 'گروه های مخاطبین',
}

export default function Page() {
    return (
        <Content breadcrumbTitle='گروه های مخاطبین' active_menu='contacts' header={null}>
            <Groups />
        </Content>
    )
}