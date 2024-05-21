import DashboardContent from "@/components/dashboardContent";
import { cookies } from "next/headers";

export default function Content({ children, ...props }) {

    const token = cookies().get('token').value

    return (
        <DashboardContent token={token} {...props}>
            {children}
        </DashboardContent>
    )
}