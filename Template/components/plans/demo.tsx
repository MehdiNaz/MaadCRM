import { showNotification } from "@mantine/notifications";

export default function DemoPlan() {
    return (
        <div className="w-1/2 mx-4 bg-second rounded-lg p-4">
            <span className='text-2xl font-bold text-center block'>پلن دمو</span>
            <div className="flex flex-col">
                <ul className='plan-attributes'>
                    <li>15 روز استفاده رایگان</li>
                    <li>نهایت 5 کاربر</li>
                </ul>
            </div>
            <button
                onClick={(e) => {
                    e.preventDefault()
                    showNotification({
                        title: 'انتخاب پلن',
                        message: 'پلن مورد نظر شما انتخاب شد',
                        color: 'green'
                    })
                    setTimeout(() => {
                        window.location.href = '/customers'

                    }, 2000);
                }}
                className='bg-primary px-8 py-2 text-white rounded-lg mx-auto mt-8 block'>انتخاب</button>
        </div>
    )
}