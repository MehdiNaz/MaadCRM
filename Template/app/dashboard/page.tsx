import Dashboard from '@/components/pages/dashboard'
import Content from 'app/content'
import { Metadata } from 'next'
import { redirect } from 'next/navigation'

export const metadata: Metadata = {
    title: 'میز کار من',
}

export default function Page() {

    redirect('/customers')

    return (
        <Content breadcrumbTitle='میز کار من' active_menu='dashboard'>
            <Dashboard />
        </Content>
    )
}