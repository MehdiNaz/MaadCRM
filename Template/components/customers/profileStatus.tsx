import { CustomerState } from "@/types/customer";
import { FiSmile } from "react-icons/fi";
import { CustomerProfileStatusType } from "../../types/clients";

export default function CustomerProfileStatus({ type }: any) {

    const states = {
        1: 'بالقوه',
        2: 'بالفعل',
        3: 'راضی',
        4: 'ناراضی',
        5: 'در حال پیگیری',
        6: 'وفادار',
    }

    return (
        <div className="flex">
            <div className="flex items-center">
                <FiSmile className="ml-2" /> {states[type]}
            </div>
        </div>
    );
}