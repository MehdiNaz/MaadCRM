'use client'
import { Tooltip } from "@mantine/core"
import Image from "next/image"
import { useState } from "react"
import { AiOutlineDelete } from "react-icons/ai"
import { BiEditAlt } from "react-icons/bi"
import { BsChevronDoubleDown, BsChevronDoubleUp } from "react-icons/bs"

export default function TableItem(props) {


    const [open, setOpen] = useState(false)

    function handleClick(e) {
        e.preventDefault()
        let more_box = e.target.parentElement.parentElement.parentElement.querySelector('.more-box')
        more_box.classList.toggle('hidden')
        setOpen(!open)
    }

    return (
        <div className="bg-white shadow-sm rounded-lg flex py-2 mt-4 flex-col">
            <div className="flex w-full items-center">
                <div className="w-1/12 text-center">
                    <Image alt="user" src={'/images/contact.png'} width={50} height={50} className="mx-auto" />
                </div>
                <div className="w-2/12 text-center text-sm">{props.name}</div>
                <div className="w-1/12 text-center text-sm">{props.phone}</div>
                <div className="w-2/12 text-center text-sm">
                    <a href={`mailto:${props.email}`}>
                        {props.email}
                    </a>
                </div>
                {/* <div className="w-5/12 text-center text-sm leading-6">
                    {props.address}
                </div> */}
                <div className="w-1/12 flex justify-center" onClick={handleClick}>
                    <Tooltip label="ویرایش" color='gray'>
                        <button className="ml-2">
                            <BiEditAlt />
                        </button>
                    </Tooltip>
                    <Tooltip label="حذف" color='red'>
                        <button>
                            <AiOutlineDelete className="ml-2 hover:text-rose-700" />
                        </button>
                    </Tooltip>
                    <button>
                        {open ? <BsChevronDoubleUp className="pointer-events-none" /> : <BsChevronDoubleDown className="pointer-events-none" />}
                    </button>
                </div>
            </div>
            <div className="more-box px-4 pt-6 hidden">
                <div className="flex w-full">
                    {props.children}
                </div>
            </div>
        </div>
    )
}