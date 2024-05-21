'use client'
import DashboardContent from '@/components/dashboardContent'
import { useRouter } from 'next/navigation'
import { useEffect } from 'react'

export default function Dashboard() {

    const router = useRouter()

    useEffect(() => {
        router.push('/customers')
    }, [])

    return (
        // <DashboardContent active_menu="dashboard" breadcrumbTitle="میز کار من">
        <div className="flex flex-col w-full mt-4">

        </div>
        // </DashboardContent>
    )
}