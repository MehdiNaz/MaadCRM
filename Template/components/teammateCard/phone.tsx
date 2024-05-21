import { AiOutlinePhone } from "react-icons/ai";

export default function TeammatecardPhone(props) {
    return (
        <div className="flex items-center text-sm">
            <AiOutlinePhone className="text-2xl ml-2" />
            <span className="text-sm">{props.phone}</span>
        </div>
    )
}