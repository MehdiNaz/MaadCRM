import Tickets from "@/components/pages/tickets";
import { Metadata } from "next";

export const metadata: Metadata = {
    title: 'درخواست های پشتیبانی'
}

export default function Page() {
    return <Tickets />
}