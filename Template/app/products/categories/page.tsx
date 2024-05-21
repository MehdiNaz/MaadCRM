import ProductCategories from '@/components/pages/products/categories'
import Content from 'app/content'
import { Metadata } from 'next'

export const metadata: Metadata = {
    title: 'لیست دسته بندی کالا / خدمات'
}

export default function Page() {
    return (
        <Content breadcrumbTitle='لیست دسته بندی کالا / خدمات' active_menu='products' header={null}>
            <ProductCategories />
        </Content>
    )
}