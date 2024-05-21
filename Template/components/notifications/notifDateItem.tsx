import { useEffect, useState } from "react"

export default function NotifDateItem({ onClick, text, select }) {

    const [selected, setSelected] = useState<boolean>(false)
    useEffect(() => {
        setSelected(select)
    }, [select])

    function handleClick() {
        onClick && onClick()
    }

    return (
        <div
            onClick={handleClick}
            className={`${selected ? 'bg-gray-800' : 'bg-gray-500'} text-white rounded-md text-center py-2 text-sm cursor-pointer`}>
            {text}
        </div>
    )
}