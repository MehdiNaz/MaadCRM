'use client'

import { useEffect, useState } from 'react'
import { Stepper, Select, NumberInput, Tooltip } from '@mantine/core'
import { BsCheck2Circle } from 'react-icons/bs'
import { RiUserSettingsLine } from 'react-icons/ri'
import { FiSettings } from 'react-icons/fi'
import { BiLogOutCircle } from 'react-icons/bi'
import { AiFillCheckCircle } from 'react-icons/ai'
import './plan.css'
import Swal from 'sweetalert2'
import { getAll } from 'services/plan'
import DemoPlan from '@/components/plans/demo'
import { plan } from '@/types/services/plan'
import { showNotification } from '@mantine/notifications'

export default function Plans() {
    const [plans, setPlans] = useState<Array<plan>>([])

    async function getAllPlans() {
        const response = await getAll()
        await setPlans(response)
    }

    useEffect(() => {
        getAllPlans()
    }, [])

    const [active, setActive] = useState(2)

    const [data, setData] = useState({
        fullname: "",
        codeMelli: "",
        birthDay: "",
        gender: "",
        job: "",
        email: "",
        state: "",
        city: "",
        address: ""
    })
    const [temmate, setTemmate] = useState(3)

    function handleSubmit(e) {
    }

    function handleChangeTemmates(val) {
        setTemmate(val)
        if (temmate == 49) {
            Swal.fire({
                title: 'تماس با تیم فروش',
                text: 'لطفا جهت سفارش پلن مورد نظر خود با تیم فروش تماس بگیرید',
                confirmButtonText: '<a href="tel:09906747192">تماس با تیم فروش</a>',
                confirmButtonColor: '#2141A8',
                footer: '<a href="tel:09906747192">تماس با تیم فروش - 09906747192</a>'
            }
            )
        }
    }
    return (
        <div className="w-full flex-col bg-primary flex justify-center items-center min-h-screen">
            <div className="w-[70%] mt-6 border-b bg-white rounded-t-lg py-8 px-8">
                <Stepper active={active} completedIcon={<AiFillCheckCircle fontSize={25} />}>
                    <Stepper.Step icon={<BsCheck2Circle size={18} />} label="احراز هویت" />
                    <Stepper.Step icon={<RiUserSettingsLine size={18} />} label="اطلاعات کاربری" />
                    <Stepper.Step icon={<FiSettings size={18} />} label="انتخاب پلن" />
                    <Stepper.Step icon={<BiLogOutCircle size={20} />} label="پایان" />
                </Stepper>
            </div>
            <div className="w-[70%] bg-white rounded-b-lg p-8">
                <div className="flex justify-around">
                    <DemoPlan />
                    <Tooltip label="به زودی" position="bottom" withArrow>
                        <div className="w-1/2 mx-4 bg-second rounded-lg p-4 cursor-not-allowed">
                            <span className='text-2xl font-bold text-center block'>پلن سفارشی</span>
                            <div className="flex flex-col justify-center w-full">
                                <div className="flex flex-col w-full justify-center  px-10">
                                    <label className='flex mt-8 mb-4 w-full justify-center'>
                                        <div className="w-1/3">
                                            <span className='text-lg font-medium leading-8 ml-2'>تعداد ماه :</span>
                                        </div>
                                        <div className="w-2/3">
                                            <Select
                                                disabled
                                                clearable
                                                data={[
                                                    { label: '1 ماه', value: '30' },
                                                    { label: '3 ماه', value: '60' },
                                                    { label: '6 ماه', value: '180' },
                                                    { label: '9 ماه', value: '270' },
                                                    { label: '12 ماه', value: '365' },
                                                ]}
                                                placeholder="انتخاب کنید"
                                            />
                                        </div>
                                    </label>
                                    <label className='flex mb-8 w-full justify-center'>
                                        <div className="w-1/3">
                                            <span className='text-lg font-medium leading-8 ml-2'>تعداد همکار :</span>
                                        </div>
                                        <div className="w-2/3">
                                            <NumberInput
                                                disabled
                                                min={3}
                                                defaultValue={3}
                                                placeholder="تعداد همکار"
                                                withAsterisk
                                                onChange={handleChangeTemmates}
                                            />
                                        </div>
                                    </label>
                                    <div className="flex justify-center mb-8">
                                        <div className="price">
                                            <span className='text-8xl font-bold'>90</span>
                                            <span>,</span>
                                            <span>000</span>
                                            <span className='mx-2'>تومان</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <button
                                disabled
                                onClick={(e) => {
                                    e.preventDefault()
                                    showNotification({
                                        title: 'پلن سفارشی',
                                        message: 'پلن مورد نظر شما انتخاب شد',
                                        color: 'green'
                                    })
                                    setTimeout(() => {
                                        window.location.href = 'dashboard'

                                    }, 2000);
                                }}
                                className='bg-primary px-8 py-2 text-white rounded-lg mx-auto block mt-auto'>انتخاب</button>
                        </div>
                    </Tooltip>
                </div>
            </div>
        </div>
    )
}