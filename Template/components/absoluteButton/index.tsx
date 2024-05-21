import { Tooltip } from "@mantine/core"
import Link from "next/link"
import { useRouter } from "next/navigation"
import { FormEvent, useState } from "react"
import { AiOutlineTeam } from "react-icons/ai"
import { HiPlus } from "react-icons/hi"
import { IoMdClose } from "react-icons/io"
import { AbsoluteButtonProps } from "../../types/customComponents"
import './absoluteBox.css'

export default function AbsoluteButton({ actions }: { actions?: AbsoluteButtonProps[] }) {
    const [open, setOpen] = useState(false)
    const router = useRouter()

    function handleClick(e: FormEvent) {
        e.preventDefault()
        var absolute_menu = document.getElementById("absolute_menu")
        absolute_menu.classList.toggle("absolute-menu-box--active")
        setOpen(!open)
    }

    function redirectTo(link: string) {
        router.push(link)
    }

    return (
        <>
            <div className="fixed left-7 cursor-pointer bottom-4 text-white bg-[#1976d2] text-2xl p-3 rounded-full z-50" onClick={handleClick}>
                {
                    open ? <IoMdClose /> : <HiPlus />
                }
            </div>
            <div id="absolute_menu" className="absolute-menu-box fixed left-8 bottom-20 z-50">
                <ul className="flex flex-col-reverse">
                    {actions && actions.length > 0 && actions.map((action, index) => (
                        <Tooltip label={action.label} position="right" key={index}>
                            <li
                                key={action.label}
                                onClick={action.link ? () => redirectTo(action.link) : action.onClick}
                                className="bg-[#1976d2] text-white p-3 rounded-full text-2xl shadow-lg">
                                <div className="pointer-events-none">{action.icon}</div>
                            </li>
                        </Tooltip>
                    ))}
                    <Tooltip label="افزودن مشتری" position="right">
                        <Link href='/customers/new' className="bg-[#1976d2] text-white p-3 rounded-full text-2xl shadow-lg">
                            <div className="pointer-events-none"><AiOutlineTeam /></div>
                        </Link>
                    </Tooltip>
                </ul>
            </div>
        </>
    )
}