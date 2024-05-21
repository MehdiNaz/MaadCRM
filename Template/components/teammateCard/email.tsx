import { HiOutlineMail } from "react-icons/hi";

export default function TeammatecardEmail(props) {
    return (
        <div className="flex items-center text-sm">
            <HiOutlineMail className="text-2xl ml-2" />
            <span className="text-sm break-all">{props.email}</span>
        </div>
    )
}