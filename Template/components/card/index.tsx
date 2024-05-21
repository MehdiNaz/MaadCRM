import { Skeleton } from '@mantine/core'
import { IconType } from '../../types/customComponents'
import './card.css'

export default function Card({ icon, title, description, active }: IconType) {
    return (
        <div className={`card relative${active ? ' card--active' : ''}`}>
            <div className='relative flex bg-white rounded-lg shadow-md p-3 flex-col hover:scale-105 duration-100 cursor-pointer'>
                <div className="flex text-xl">
                    {icon}
                </div>
                <div className="flex mt-2 justify-center text-[2.4em] font-bold mb-2">
                    {title ? title : <Skeleton width={100} height={30} />}
                </div>
                <div className="flex justify-center text-gray-700">
                    {description}
                </div>
            </div>
        </div>
    )
}