import { TicketItemType } from "../../types/tickets"

export default function TicketItem({
    id,
    title,
    when,
    status,
}: TicketItemType) {

    const statusesColor = {
        "paygiri": "border-[#1C3FAA]",
        "takmil": "border-[#2FA94A]",
        "end": "border-[#BF113B]",
    }

    return (
        <div className={`w-full bg-white shadow-lg rounded-md p-3 border-b-2 ${statusesColor[status]}`}>
            <div className="flex justify-between items-center pb-3">
                <span className="text-gray-800 text-md font-bold">{title}</span>
                <span className="text-gray-600 font-light text-xs">{when}</span>
            </div>
        </div>
    )

}