import Login from "@/components/pages/login";
import { hasAccess } from "@/utils/helper";
import { Metadata } from "next";
import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export const metadata: Metadata = {
    title: 'ورود به حساب کاربری',
}

export default async function Page() {

    const token = cookies().get('token')?.value

    if (token) {
        redirect('/customers')
    }
    return <Login />
}