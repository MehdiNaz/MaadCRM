import { GrLocation } from "react-icons/gr";

export default function TeammatecardHome(props) {
    return (
        <div className="flex items-center text-sm">
            <GrLocation className="text-2xl ml-2" />
            <span>{props.location}</span>
        </div>
    )
}