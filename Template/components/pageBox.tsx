import { DashboardBoxType } from "@/types/customComponents";
import { Head } from "./form";

export default function PageBox(
    { title, children }: DashboardBoxType
) {
    return (
        <div className="w-full bg-white shadow-sm rounded-b-md pt-3 border-t-4 border-primary ">
            <div className="border-b px-6 pb-3">
                <Head title={title} />
            </div>
            <div className="px-6 w-full py-4">
                {children}
            </div>
        </div>
    )
}