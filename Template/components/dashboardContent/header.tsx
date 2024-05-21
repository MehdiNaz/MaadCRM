import Divider from '@/components/divider'
import DashboardTitle from './title'


export default function Header({ title, children }) {
    return (
        <div className="w-full mt-4 mb-8">
            <div className="flex items-center">
                <DashboardTitle title={title} />
                {children && (
                    <div className='mr-auto'>
                        {children}
                    </div>
                )}
            </div>
            <div className="w-full my-3">
                <Divider />
            </div>
        </div>
    )
}