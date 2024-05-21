import Faq from '@/components/pages/faq'
import { Metadata } from 'next'

export const metadata: Metadata = {
    title: 'پرسش و پاسخ'
}

export default function Page() {
    return <Faq />
}