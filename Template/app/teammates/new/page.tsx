import NewTeammate from '@/components/pages/teammates/new'
import { hasAccess } from '@/utils/helper'
import Content from 'app/content'
import { Metadata } from 'next'
import { cookies } from 'next/headers'
import { redirect } from 'next/navigation'

export const metadata: Metadata = {
    title: 'همکار جدید'
}

export default function Page() {

    const token = cookies().get('token').value
    // const access = hasAccess({
    //     role: 'Users',
    //     token: token
    // })
    // if (!access) {
    //     redirect('/customers')
    // }

    return (
        <Content breadcrumbTitle="همکار جدید" active_menu='teammates'>
            <NewTeammate />
        </Content>
    )
}