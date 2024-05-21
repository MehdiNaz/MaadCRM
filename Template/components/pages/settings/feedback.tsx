'use client'
import DashboardContent from "@/components/dashboardContent"
import SearchInput from "@/components/searchInput"
import FeedbackTable from "@/components/tables/feedbackTable"
import { AiOutlinePlusCircle, AiOutlineUserAdd, AiOutlineUsergroupAdd } from "react-icons/ai"
import Modal from "@/components/modal"
import { useEffect, useState } from "react"
import { useForm } from "@mantine/form"
import TextInput from "@/components/textInput"
import Button from "@/components/button"
import Divider from '@/components/divider'
import { Group, Radio } from "@mantine/core"
import SelectBox from "@/components/selectBox"
import { getFeedbackCategories, newFeedbackCategory } from "services/feedback"
import { showNotification } from "@mantine/notifications"
import Image from "next/image"
import Header from "@/components/dashboardContent/header"

export default function FeedbackSettings() {

    const [loading, setLoading] = useState<boolean>(true)
    const [openedmodal, setOpenedModal] = useState<boolean>(false)

    const [feedbackTypes, setFeedbackTypes] = useState([])

    const form = useForm({
        initialValues: {
            title: '',
            possetiveNegative: 'false',
            typeFeedback: '1',
        },

        validate: (values) => {
            return {
                title: values.title.length < 3 ? 'نام نوع بازخورد باید بیشتر از 3 کاراکتر باشد' : null,

            }
        },
    })

    async function handleSubmit(values: typeof form.values) {
        try {
            const possetiveNegative = values.possetiveNegative === 'true' ? true : false
            const response = await newFeedbackCategory({
                title: values.title,
                feedback_for: values.typeFeedback,
                description: '',
                positive_or_negative: possetiveNegative,
            })
            if (response.success) {
                setOpenedModal(false)
                showNotification({
                    title: 'عملیات موفق',
                    message: 'نوع بازخورد جدید با موفقیت ثبت شد',
                    color: 'green',
                })
                setFeedbackTypes(feedbacks => [...feedbacks, {
                    id: response.new_feedback.id,
                    title: response.new_feedback.title,
                    feedback_for: parseInt(response.new_feedback.feedback_for),
                    positive_or_negative: response.new_feedback.positive_or_negative,
                }])
                form.reset()
            }
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'مشکلی در ثبت نوع بازخورد جدید پیش آمده است',
                color: 'red',
            })
        }
    }

    useEffect(() => {
        async function getFeedbackTypes() {
            try {
                const response = await getFeedbackCategories()
                setFeedbackTypes(response.feedbacks)
                form.reset()
            } catch (err) {
                showNotification({
                    title: 'عملیات موفق',
                    message: 'نوع بازخورد جدید با موفقیت ثبت شد',
                    color: 'green'
                })
            } finally {
                setLoading(false)
            }
        }
        getFeedbackTypes()
    }, [])


    return (
        <>
            <Modal
                opened={openedmodal}
                onClose={() => setOpenedModal(false)}
                title='نوع بازخورد جدید'
                size='lg'
            >
                <form
                    onSubmit={form.onSubmit((values) => { handleSubmit(values) })}
                >
                    <div className="w-full flex flex-col">
                        <div className="w-full mb-8">
                            <Radio.Group
                                label="بازخورد برای :"
                                {...form.getInputProps('typeFeedback')}
                            >
                                <Group mt="xs">
                                    <Radio checked value="1" label="همکار" />
                                    <Radio value="2" label="کالا / خدمات" />
                                    <Radio value="3" label="فرآیند خرید" />
                                </Group>
                            </Radio.Group>
                        </div>
                        <TextInput
                            label='عنوان بازخورد :'
                            placeholder='عنوان بازخورد'
                            {...form.getInputProps('title')}
                        />
                        <div className="w-full mt-8">
                            <Radio.Group
                                label="منفی یا مثبت بودن :"
                                withAsterisk
                                {...form.getInputProps('possetiveNegative')}
                            >
                                <Group mt="xs">
                                    <Radio value={'false'} label="منفی" />
                                    <Radio value={'true'} label="مثبت" />
                                </Group>
                            </Radio.Group>
                        </div>
                    </div>
                    <div className="flex justify-end mt-8">
                        <Button type="submit">
                            ثبت
                        </Button>
                    </div>
                </form>
            </Modal>
            <Header title='تنظیمات بارخوردها'>
                <Button onClick={() => setOpenedModal(true)}>
                    نوع جدید
                </Button>
            </Header>
            <div className="w-full mt-8">

                {!loading && feedbackTypes.length === 0 ? (
                    <div className="w-full flex justify-center">
                        <div className="mt-8">
                            <Image
                                src='/icons/feedback.svg'
                                width={500}
                                height={500}
                                alt='feedback'
                            />
                            <div className="flex flex-col">
                                <span className="mt-4 text-lg leading-8">هیچ نوع بازخوردی شما تعریف نکرده اید! بیا یکی با هم ایجاد کنیم</span>
                                <div className="w-full flex justify-center items-center mt-8">
                                    <Button
                                        onClick={() => setOpenedModal(true)}
                                    >
                                        ایجاد نوع جدید
                                    </Button>
                                </div>
                            </div>
                        </div>
                    </div>
                ) : (
                    <FeedbackTable
                        onSuccess={(response) => {
                            const index = feedbackTypes.findIndex((item) => item.id === response.id)
                            const newFeedbackTypes = [...feedbackTypes]
                            newFeedbackTypes[index] = response
                            setFeedbackTypes(newFeedbackTypes)
                        }}
                        data={feedbackTypes}
                        onDelete={(id: string) => setFeedbackTypes(feedbacks => feedbacks.filter((item) => item.id !== id))}
                    />
                )}

            </div>
            {/* </DashboardContent> */}
        </>
    )
}