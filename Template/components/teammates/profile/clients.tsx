import Image from 'next/image'
import { TeammateProfileClientType } from '../../../types/teammates'

export default function TeammatesProfileClients({ avatar, name, status }: TeammateProfileClientType) {

    const statuses =
    {
        'peygiri': 'border-[#7B2BCB] text-[#7B2BCB]',
        'vafadar': 'border-[#EEB41E] text-[#EEB41E]',
        'belghove': 'border-[#0B8500] text-[#0B8500]',
        'narazi': 'border-[#C81D1D] text-[#C81D1D]',
        'razi': 'border-[#0069F5] text-[#0069F5]',
    }

    const statusesText =
    {
        'peygiri': 'درحال پیگیری',
        'vafadar': 'وفادار',
        'belghove': 'بلغوه',
        'narazi': 'ناراضی',
        'razi': 'راضی',
    }

    return (
        <div className="w-full grid grid-cols-12 gap-3 border border-[#AEB2B7] rounded-md p-2 mb-4">
            <div className="col-span-3">
                {avatar && (
                    <div className="w-full flex items-center">
                        <Image src={avatar} width={40} height={40} alt='user' />
                    </div>
                ) || (
                        <div className="w-full flex items-center">
                            <Image src='/images/user-male.png' width={40} height={40} alt='user' />
                        </div>
                    )}
            </div>
            <div className="col-span-5 flex items-center">
                <span className='font-medium text-sm'>{name}</span>
            </div>
            <div className={`col-span-4 flex justify-center items-center text-center`}>
                <span className={`font-medium text-xs w-full ${statuses[status]} border ${statuses[status]} rounded-full px-2 py-1`}>{statusesText[status]}</span>
            </div>
        </div>
    )
}