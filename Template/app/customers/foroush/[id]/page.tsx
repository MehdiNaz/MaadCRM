import Foroush from "@/components/pages/customers/foroush";
import { getCustomerByID } from "@/services/customer";
import axios from "@/utils/axios";
import Content from "app/content";
import { Metadata } from "next";
import { cookies } from "next/headers";
import { notFound } from 'next/navigation'

export const metadata: Metadata = {
    title: 'ثبت فروش'
}

async function getData(id) {
    try {

        const nextCookies = cookies()
        const token = nextCookies.get('token').value

        const request = await fetch(`${process.env.API_URL}/customers/${id}`, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
        const data = await request.json()

        return data.customer.customer
    } catch (err) {
        return null
    }
}

export default async function Page({ params: { id } }) {
    const data = await getData(id)
    if (!data) notFound()

    const name = data?.first_name ? data.first_name + ' ' + data.last_name : data.last_name
    return (
        <Content breadcrumbTitle={`ثبت فروش برای ${name}`} active_menu='customers' divider={false}>
            <Foroush id={id} data={data} />
        </Content>
    )
}