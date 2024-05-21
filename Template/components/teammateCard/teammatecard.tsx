import { HiUserCircle } from 'react-icons/hi'
import { IoIosMore } from 'react-icons/io'
import TeammatecardAddress from './address'
import TeammatecardEmail from './email'
import TeammatecardHome from './home'
import TeammatecardPhone from './phone'
import Button from '../button'
import { RiDeleteBin6Line } from 'react-icons/ri'
import { BiEdit } from 'react-icons/bi'
import { MdEditNote } from 'react-icons/md'
import Link from 'next/link'
import { TeammateCardProps } from '@/types/teammates'

export default function TeammateCard({ name, category, location, email, address, id, phone, hidden }: TeammateCardProps) {
    return (
        <div className={`w-full bg-white rounded-lg overflow-hidden${hidden ? ' hidden' : ''}`}>
            <div className="w-full flex border-b pb-3 py-2 px-3">
                <div className="flex border-l pl-3">
                    <HiUserCircle className='text-4xl' />
                </div>
                <div className="flex items-center mr-3">
                    <span className='ml-6'>{name}</span>
                    <span className='text-sm text-gray-700'>{category}</span>
                </div>
                <div className="flex mr-auto items-center text-2xl text-gray-600">
                    <IoIosMore />
                </div>
            </div>
            <div className="grid grid-cols-2 mt-4 py-2 px-3 gap-4">
                <div className="flex items-center">
                    <TeammatecardPhone phone={phone} />
                </div>
                {/* <div className="flex items-center">
                    <TeammatecardHome location={location} />
                </div> */}
                <div className="flex items-center">
                    <TeammatecardEmail email={email} />
                </div>
            </div>
            <div className="w-full mt-2 mb-4 px-3">
                <TeammatecardAddress address={address} />
            </div>
            <div className="w-full justify-between items-center flex mt-6 border-t py-2 px-3">
                {/* <div className="flex items-center">
                    <button className="bg-primary text-[10px] text-white rounded-md px-3 py-1">
                        ارسال پیام
                    </button>
                    <button className="text-[10px] bg-[#7F9EB8] text-white rounded-md mr-3 px-3 py-1">
                        میز کار
                    </button>
                </div> */}
                <div className="grid gap-2 grid-cols-2 mr-auto">
                    <Link href={`/teammates/edit/${id}`}>
                        <BiEdit className='text-gray-700 text-xl' />
                    </Link>
                    {/* <MdEditNote className='text-gray-700 text-xl' /> */}
                    <RiDeleteBin6Line className='text-red-700 text-xl' />
                </div>
            </div>
        </div>
    )
}