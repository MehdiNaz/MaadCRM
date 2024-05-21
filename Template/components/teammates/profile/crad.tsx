import { FiMoreHorizontal } from 'react-icons/fi'
import { TeammateProfileCardTypes } from '../../../types/teammates'

export default function TeammatesProfileCard({ title, children, onClick }: TeammateProfileCardTypes) {

    return (
        <div className="w-full border border-[#CCCDCF] rounded-md">
            <div className="w-full flex justify-between items-center mb-4 border-b-2 border-third py-1 px-3">
                <h3 className='font-medium text-md'>{title}</h3>
                <button onClick={onClick} className="text-[#E2E1E1] rounded-md px-2 py-1">
                    {<FiMoreHorizontal fontSize={30} />}
                </button>
            </div>
            <div className="w-full py-1 px-3">
                {children}
            </div>
        </div>
    )

}