import Confirm from "@/components/pages/confirm";
import { Metadata } from "next";

export const metadata: Metadata = {
    title: 'تایید اطلاعات',
}

export default function Page() {
    return <Confirm />
}