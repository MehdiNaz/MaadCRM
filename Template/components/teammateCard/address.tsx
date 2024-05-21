import { AiOutlineHome } from "react-icons/ai";

export default function TeammatecardAddress(props) {
    return (
        <div className="flex items-center text-sm">
            <AiOutlineHome className="text-2xl ml-4" />
            <span>{props.address}</span>
        </div>
    )
}