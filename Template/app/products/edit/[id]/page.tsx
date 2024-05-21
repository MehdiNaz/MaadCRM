import EditProduct from '@/components/pages/products/edit'
import Content from 'app/content'
import { Metadata } from 'next'

export const metadata: Metadata = {
    title: 'ویرایش محصول'
}

export default function Page({ params: { id } }) {
    return (
        <Content breadcrumbTitle="ویرایش / خدمات" active_menu='products' header={null}>
            <EditProduct productID={id} />
        </Content>
    )
}