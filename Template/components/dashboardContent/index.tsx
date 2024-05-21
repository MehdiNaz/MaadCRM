'use client'

import DashboardTopBar from './topBar'
import DashboardSidebar from './sidebar'
import './style.css'
import DashboardTitle from './title'
import { Dashboard } from '@/types/dashboard'
import AbsoluteButton from '../absoluteButton'
import Divider from '@/components/divider'
import { useEffect } from 'react'
import { useRouter } from 'next/navigation'

export default function DashboardContent({ breadcrumbTitle, active_menu, children, actions = true, divider = true, header = true, hasAccess, token }: Dashboard) {

    const router = useRouter()
    useEffect(() => {
        if (hasAccess === false) {
            router.push('/customers')
        }
    }, [hasAccess])

    return (
        <div className="page">
            {actions != null && <AbsoluteButton actions={actions} />}
            <div className="fixed right-0 top-0 sidebar sidebar--close w-[220px] overflow-y-auto h-full">
                <DashboardSidebar active={active_menu} token={token} />
            </div>
            <div className="content pb-4 large-content lg:mr-[220px] py-8 lg:pl-4 px-4 lg:pr-0">
                <div className="w-full bg-second px-8 rounded-lg min-h-screen pb-11">
                    <DashboardTopBar breadcrumbTitle={breadcrumbTitle} />
                    <div className="w-full">
                        {header != null && (
                            <div className="w-full mt-4 mb-8">
                                <div className="flex justify-between">
                                    <DashboardTitle title={breadcrumbTitle} />
                                    {header && (
                                        <>
                                            {header}
                                        </>
                                    )}
                                </div>
                                {divider && header != null && (
                                    <div className="w-full my-3">
                                        <Divider />
                                    </div>
                                )}
                            </div>
                        )}
                        {children}
                    </div>
                </div>
            </div>
        </div>
    )
}