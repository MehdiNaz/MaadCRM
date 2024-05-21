import NewProduct from '@/components/pages/products/new'
import Content from 'app/content'
import { Metadata } from 'next'

export const metadata: Metadata = {
    title: 'کالا / خدمات جدید'
}

export default function Page() {
    return (
        <Content breadcrumbTitle="ایجاد کالا / خدمت" active_menu='products' header={null}>
            <NewProduct />
        </Content>
    )
}