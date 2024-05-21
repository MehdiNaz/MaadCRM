import Products from "@/components/pages/products";
import Content from "app/content";
import { Metadata } from "next";

export const metadata: Metadata = {
    title: 'لیست کالا / خدمات'
}
export default function Page() {
    return (
        <Content breadcrumbTitle="لیست کالا / خدمات" active_menu='products' header={null}>
            <Products />
        </Content>
    )
}