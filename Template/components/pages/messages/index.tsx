'use client'

import DashboardContent from '@/components/dashboardContent'
import { Input, Textarea, Select, Radio } from '@mantine/core'
import { useEffect, useState } from 'react'
import Button from '@/components/button'
import Modal from '@/components/modal'

export default function Messages() {

    const [newMessage, setNewMessage] = useState<boolean>(true)
    const [sendTiming, setSendTiming] = useState<boolean>(false)

    return (
        <>
            <Modal
                size="lg"
                opened={newMessage}
                onClose={() => setNewMessage(!newMessage)}
                title="ارسال پیام"
            >
                <div className="grid grid-cols-1 gap-4">
                    <div className="col-span-1 grid grid-cols-12">
                        <span className="col-span-3 flex items-center">موضوع :</span>
                        <Input
                            classNames={{
                                wrapper: 'col-span-9',
                            }}
                            placeholder="موضوع"
                        />
                    </div>
                    <div className="col-span-1 grid grid-cols-12">
                        <span className="col-span-3 flex items-start">متن پیام :</span>
                        <Textarea
                            className="col-span-9"
                            placeholder="متن پیام"
                        />
                    </div>
                    <div className="col-span-1 grid grid-cols-12">
                        <span className="col-span-3 flex items-center">آرشیو پیام‌ها :</span>
                        <Select
                            className="col-span-9"
                            searchable
                            placeholder="انتخاب کنید"
                            data={[
                                { label: 'آرشیو 1', value: 'آرشیو 1' },
                                { label: 'آرشیو 2', value: 'آرشیو 2' },
                                { label: 'آرشیو 3', value: 'آرشیو 3' },
                            ]}
                        />
                    </div>
                    <div className="col-span-1 grid grid-cols-12">
                        <span className="col-span-3 flex items-center">زمان بندی ارسال :</span>
                        <div className="col-span-9 grid gap-4 grid-cols-2">
                            <Radio.Group
                                name="sendingTime"
                                onChange={(e) => {
                                    if (e === 'timing') {
                                        setSendTiming(true)
                                    } else {
                                        setSendTiming(false)
                                    }
                                }}
                            >
                                <Radio
                                    value="now"
                                    label="هم اکنون"
                                />
                                <Radio
                                    value="timing"
                                    label="زمانی دیگر"
                                />
                            </Radio.Group>
                        </div>
                    </div>
                    {sendTiming && (
                        <div className="col-span-1 grid grid-cols-12">
                            <span className="col-span-3 flex items-center">زمان ارسال :</span>
                            <Input
                                classNames={{
                                    wrapper: 'col-span-9',
                                }}
                                placeholder="زمان ارسال"
                            />
                        </div>
                    )}
                </div>
                <div className="flex w-full mt-5 items-start justify-center">
                    <Button>
                        انصراف
                    </Button>
                    <Button className="mx-3">
                        تایید
                    </Button>
                </div>
            </Modal>

        </>
    )
}