'use client'
import { Select, Switch, Table, Tabs, Timeline, Text, Skeleton, Loader, Tooltip, Checkbox, Center } from "@mantine/core";
import Button from "@/components/button";
import { BiHistory } from "react-icons/bi";
import { GrNote, GrNotification } from "react-icons/gr";
import { SlUserFollowing } from "react-icons/sl";
import DashboardContent from "@/components/dashboardContent";
import { FaCheckCircle, FaCopy, FaEye, FaLocationArrow, FaMailBulk, FaPhone, FaSadCry, FaSave, FaUserEdit } from 'react-icons/fa'
import Search from "@/components/search";
import Note from "@/components/pages/customers/note";
import Reminder from "@/components/customers/peygiri";
import CustomerProfileStatus from '@/components/customers/profileStatus'
import ClientType from '@/components/customers/clientType'
import './profile.css'
import TableView from "@/components/tableView";
import { AllCustomerFeedbacks, getCustomerByID, getCustomerNotes, getPeygiris } from "services/customer";
import { useEffect, useState } from "react";
import TeammatesProfileCard from "@/components/teammates/profile/crad";
import TeammatesProfileClients from "@/components/teammates/profile/clients";
import NoItem from "@/components/noItem";
import NewFeedback from './newFeedback'
import NewPeygiri from "./newPeygiri";
import NewNote from "./addNote";
import PageBox from "@/components/pageBox";
import { showNotification } from "@mantine/notifications";
import { AiOutlineDislike, AiOutlineEdit } from "react-icons/ai";
import Link from "next/link";
import { useDispatch } from "react-redux";
import Peygiri from "@/components/customers/peygiri";
import { FieldType } from "@/types/customfields";
import TextInput from "@/components/textInput";
import DateInput from "@/components/DateInput";
import AbsoluteButton from "@/components/absoluteButton";
import Factors from "@/components/customers/factors";

export default function CustomerProfile({ id }) {

    const [peygiris, setPeygiris] = useState([])
    const [notes, setNotes] = useState([])
    const [feedbacks, setFeedbacks] = useState([])
    const [customer, setCustomer] = useState<any>({})
    const [isLoading, setLoading] = useState(true)
    const [feedbackOpened, setFeedbackOpened] = useState(false)
    const [perygiriOpened, setPeygiriOpened] = useState(false)
    const [noteOpened, setNoteOpened] = useState(false)

    const [activeTab, setActiveTab] = useState<string | null>('notes');


    const dispatch = useDispatch()

    async function getCustomerPeygiris() {
        const response = await getPeygiris({ user_id: id })
        setPeygiris(response.data)
        setLoaders({ ...loaders, peygiris: false })
    }

    const [fetched, setFetched] = useState({
        notes: false,
        peygiris: false,
        feedback: false,
        factors: false
    })

    const [loaders, setLoaders] = useState({
        user: true,
        notes: true,
        peygiris: true,
        feedback: true,
        factors: true
    })

    useEffect(() => {
        getCustomer()
    }, [])

    async function getCustomerFeedbacks() {
        try {
            const response = await AllCustomerFeedbacks({ IdCustomer: id })
            if (response.success) {
                setFeedbacks(response.data)
                setLoaders({ ...loaders, feedback: false })
            }
        } catch {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در دریافت بازخوردها',
                color: 'red'
            })
        }
    }

    useEffect(() => {
        if (activeTab === 'peygiri' && !fetched.peygiris) {
            getCustomerPeygiris()
            setFetched({ ...fetched, peygiris: true })
        }
        if (activeTab === 'notes' && !fetched.notes) {
            getAllCustomerNotes()
            setFetched({ ...fetched, notes: true })
        }
        if (activeTab === 'feedbacks' && !fetched.feedback) {
            getCustomerFeedbacks()
            setFetched({ ...fetched, feedback: true })
        }
        if (activeTab === 'orders' && !fetched.factors) {
            setLoaders({ ...loaders, factors: false })
            setFetched({ ...fetched, factors: true })
        }
    }, [activeTab])


    const [attributes, setAttributes] = useState([])

    async function getCustomer() {
        const response = await getCustomerByID({ id: id })
        setLoaders((prev) => ({ ...prev, user: false }))
        setCustomer(response.customer.customer)
        setAttributes(response.attributes)
        setLoading(false)
    }


    async function getAllCustomerNotes() {
        const response = await getCustomerNotes({ customer_id: id })
        if (response.success) {
            response.notes.map((item) => {
                const user_first_name = item.user.first_name ? item.user.first_name : ''
                const user_last_name = item.user.last_name ? item.user.last_name : ''
                const user_name = user_first_name + ' ' + user_last_name
                setNotes((prev) => [...prev, { id: item.id, name: user_name, description: item.description, createDate: item.createdAt }])
            })
            setLoaders({ ...loaders, notes: false })
        }
    }
    const actions = [
        {
            icon: <FaEye />,
            onClick: () => { setFeedbackOpened(true) },
            label: 'ثبت بازخورد'
        },
        {
            icon: <FaSadCry />,
            onClick: () => { setPeygiriOpened(true) },
            label: 'ثبت پیگیری'
        },
        {
            icon: <FaSave />,
            onClick: () => { setNoteOpened(true) },
            label: 'ثبت یادداشت'
        }
    ]

    const customerMoaref = customer.customer_referral ? <Link href={'/customers/profile/' + customer.customer_referral.id}>{customer.customer_referral.last_name}</Link> : 'ندارد'

    return (
        <>
            <AbsoluteButton actions={actions} />
            {<NewFeedback opened={feedbackOpened} onClose={() => { setFeedbackOpened(false) }} id={id} />}
            {<NewPeygiri
                onSuccess={(response) => {
                    setPeygiris([...peygiris, {
                        id: response.id,
                        dateCreated: response.dateCreated,
                        namePeyGiryCategory: response.namePeyGiryCategory,
                        nameUser: response.nameUser
                    }])
                }}
                opened={perygiriOpened}
                onClose={() => { setPeygiriOpened(false) }} id={id}
            />
            }
            {<NewNote opened={noteOpened} onClose={() => { setNoteOpened(false) }} id={id} onSuccess={(response) => { setNotes([...notes, { id: response.id, name: response.user?.first_name + ' ' + response.user?.last_name, description: response.description, createDate: response.createdAt }]) }} />}
            <div className="flex w-full">
                <div className="w-1/4">
                    <div className="flex w-full flex-col px-2 bg-white rounded-lg">
                        <div className="flex justify-center pt-4 flex-col items-center">
                            <Link href={'/customers/edit/' + id}>
                                <FaUserEdit className="text-[3em]" />
                            </Link>
                            <div className="mt-3">
                                {
                                    isLoading ? <Skeleton width={100} height={10} mb="xl" /> : customer.first_name ? customer.first_name + ' ' + customer.last_name : customer.last_name
                                }
                            </div>
                        </div>
                        <div className="my-4 px-2">
                            {isLoading ? <Skeleton width={100} height={10} mb="xl" /> : <CustomerProfileStatus type={customer.state} />}
                        </div>
                        <div className="mb-4 px-2">
                            <div className="flex items-center">
                                <span>مشتری معرف : </span>
                                <div className="mr-3">
                                    {isLoading ? <Skeleton width={100} height={10} /> : customerMoaref}
                                </div>
                            </div>
                        </div>
                        <div className="flex justify-center mx-4 border-b pb-3">
                            {/* <Search /> */}
                        </div>
                        {/* <div className="flex justify-center my-2 border-b pb-3">
                            <Button
                                disabled
                                variant="outline"
                                color="dark"
                                classNames={{
                                    label: 'text-black border-black'
                                }}
                            >
                                ارسال پیام
                            </Button>
                        </div> */}
                        <div className="my-4 flex justify-around">
                            {isLoading ? (
                                <Skeleton width={100} height={34} />
                            ) : (
                                <Link href={'/customers/foroush/' + id}>
                                    <Button
                                        disabled={isLoading}
                                        color={'green'}
                                        className="!font-medium"
                                    >
                                        ثبت فروش
                                    </Button>
                                </Link>
                            )}
                            {/* <Button
                                disabled
                                color={'red'}
                                className="!font-medium"
                            >
                                انصراف از خرید
                            </Button> */}
                        </div>
                    </div>
                    <div className="w-full mt-2">
                        <PageBox title="اطلاعات پایه">
                            <div className="w-full border border-[#DADEE3] rounded-md">
                                <div className="grid grid-cols-6 py-4">
                                    <div className="col-span-1 items-center flex justify-center">
                                        <a href={'tel:' + customer.phone}>
                                            <FaPhone />
                                        </a>
                                    </div>
                                    <div className="col-span-4 flex items-center justify-center text-sm">
                                        <a href={'tel:' + customer.phone}>
                                            {customer.phone}
                                        </a>
                                    </div>
                                    <div className="col-span-1 flex justify-around">
                                        <button
                                            onClick={() => {
                                                navigator.clipboard.writeText(customer.phone)
                                                showNotification({
                                                    title: 'شماره تلفن کپی شد',
                                                    message: customer.phone,
                                                    color: 'teal',
                                                    icon: <FaCheckCircle />,
                                                    autoClose: 2000,
                                                })
                                            }}
                                        >
                                            <FaCopy />
                                        </button>
                                    </div>
                                </div>
                            </div>
                            {customer.email && (
                                <div className="w-full border border-[#DADEE3] rounded-md mt-4">
                                    <div className="grid grid-cols-6 py-4">
                                        <div className="col-span-1 items-center flex justify-center text-sm">
                                            <a href={'mailto:' + customer.email}>
                                                <FaMailBulk />
                                            </a>
                                        </div>
                                        <div className="col-span-4 flex items-center justify-center">
                                            <a className="text-sm" href={'mailto:' + customer.email}>
                                                {customer.email ?? 'ندارد'}
                                            </a>
                                        </div>
                                        <div className="col-span-1 flex justify-around">
                                            {customer.email && (
                                                <button
                                                    onClick={() => {
                                                        navigator.clipboard.writeText(customer.email)
                                                        showNotification({
                                                            title: 'آدرس ایمیل کپی شد',
                                                            message: customer.email,
                                                            color: 'teal',
                                                            icon: <FaCheckCircle />,
                                                            autoClose: 2000,
                                                        })
                                                    }}
                                                >
                                                    <FaCopy />
                                                </button>
                                            )}
                                        </div>
                                    </div>
                                </div>
                            )}
                            {customer.address && (
                                <div className="w-full border border-[#DADEE3] rounded-md mt-4">
                                    <div className="grid grid-cols-6 py-4">
                                        <div className="col-span-1 items-center flex justify-center">
                                            <FaLocationArrow />
                                        </div>
                                        <div className="col-span-4 flex items-center justify-center text-xs">
                                            {customer.address ?? 'ندارد'}
                                        </div>
                                        <div className="col-span-1 flex justify-around">
                                            {customer.address && (
                                                <button
                                                    onClick={() => {
                                                        navigator.clipboard.writeText(customer.address)
                                                        showNotification({
                                                            title: 'آدرس کپی شد',
                                                            message: "آدرس : " + customer.address,
                                                            color: 'teal',
                                                            icon: <FaCheckCircle />,
                                                            autoClose: 2000,
                                                        })
                                                    }}
                                                >
                                                    <FaCopy />
                                                </button>
                                            )}
                                        </div>
                                    </div>
                                </div>
                            )}
                        </PageBox>
                    </div>
                    <div className="w-full mt-2">
                        <PageBox title="اطلاعات تکمیلی">
                            {loaders.user && (
                                <Center>
                                    <Loader size={25} />
                                </Center>
                            )}
                            {attributes && attributes.length > 0 ? (
                                <>
                                    {attributes.map((attribute: FieldType, index) => {
                                        return (
                                            <div key={index}>
                                                {attribute.inputType == 1 && (
                                                    <>
                                                        <span className="text-sm my-3 block">{attribute.label}</span>
                                                        <TextInput
                                                            value={attribute.attributeOptions[0]?.value[0]?.valueString}
                                                            disabled
                                                        />
                                                    </>
                                                )}
                                                {attribute.inputType == 2 && (
                                                    <>
                                                        <span className="text-sm my-3 block">{attribute.label}</span>
                                                        <TextInput
                                                            value={attribute.attributeOptions[0]?.value[0]?.valueString}
                                                            disabled
                                                        />
                                                    </>
                                                )}
                                                {attribute.inputType == 3 && (
                                                    <>
                                                        <span className="text-sm my-3 block">{attribute.label}</span>
                                                        <DateInput
                                                            disabled={true}
                                                            value={attribute.attributeOptions[0]?.value[0]?.valueDate}
                                                        />
                                                    </>
                                                )}
                                                {attribute.inputType == 5 && (
                                                    <div className="mt-4">
                                                        <span className="text-sm my-4 block">{attribute.label}</span>
                                                        <div className="w-full grid grid-cols-2 gap-5">
                                                            {attribute.attributeOptions.map((option, index) => {
                                                                return (
                                                                    <div className="col-span-1" key={index}>
                                                                        <span>{option.value.length > 1 && option?.title}</span>
                                                                        <Checkbox label={option.title} checked={option.value.length > 1 && option?.value[0]?.valueBoolean} disabled />
                                                                    </div>
                                                                )
                                                            })}
                                                        </div>
                                                    </div>
                                                )}
                                            </div>
                                        )
                                    })}
                                </>
                            ) : (
                                <></>
                            )}
                        </PageBox>
                    </div>
                </div>
                <div className="w-3/4 mr-6 bg-white rounded-lg p-1">
                    <Tabs defaultValue="notes" value={activeTab} onTabChange={setActiveTab} className="my-3">
                        <Tabs.List className="mb-6">
                            {/* <Tabs.Tab value="activity" icon={<BiHistory />}>تاریخچه</Tabs.Tab> */}
                            <Tabs.Tab value="notes" icon={<GrNote />}>یادداشت ها</Tabs.Tab>
                            <Tabs.Tab value="peygiri" icon={<GrNotification />}>پیگیری ها</Tabs.Tab>
                            <Tabs.Tab value="feedbacks" icon={<BiHistory />}>بازخوردها</Tabs.Tab>
                            <Tabs.Tab value="orders" icon={<FaSave />}>سوابق خرید</Tabs.Tab>
                            {/* <Tabs.Tab value="access" disabled icon={<FaSave />}>مستندات</Tabs.Tab> */}
                            {/* <Tabs.Tab value="information" icon={<FaSave />}>اطللاعات کاربری</Tabs.Tab> */}
                        </Tabs.List>
                        <Tabs.Panel value="activity" className="px-3" pt="xs">
                            <div className="w-full flex flex-col justify-between border py-4 px-2 rounded-md">
                                <div className="user-type-boxes">
                                    <ClientType type="balghav" />
                                    <ClientType type="peygiri" />
                                    <ClientType type="belfel" />
                                    <ClientType type="narazi" />
                                    <ClientType type="vafadar" />
                                </div>
                                <div className="grid grid-cols-2 gap-4 mt-8">
                                    <div className="w-full">
                                        <TeammatesProfileCard title="بازخورد ها">
                                            <TeammatesProfileClients name="محمد هادی طاهری" status="peygiri" />
                                            <TeammatesProfileClients name="محمد هادی طاهری" status="vafadar" />
                                            <TeammatesProfileClients name="محمد هادی طاهری" status="belghove" />
                                            <TeammatesProfileClients name="محمد هادی طاهری" status="narazi" />
                                            <TeammatesProfileClients name="محمد هادی طاهری" status="razi" />
                                        </TeammatesProfileCard>
                                        <div className="mt-4">
                                            <TeammatesProfileCard title="پیگیری ها">
                                                <TeammatesProfileClients name="محمد هادی طاهری" status="peygiri" />
                                                <TeammatesProfileClients name="محمد هادی طاهری" status="vafadar" />
                                                <TeammatesProfileClients name="محمد هادی طاهری" status="belghove" />
                                                <TeammatesProfileClients name="محمد هادی طاهری" status="narazi" />
                                                <TeammatesProfileClients name="محمد هادی طاهری" status="razi" />
                                            </TeammatesProfileCard>
                                        </div>
                                    </div>
                                    <div className="hidden">
                                        <TeammatesProfileCard title="تاریخچه فعالیت" >
                                            <Timeline active={1} bulletSize={24} lineWidth={2}>
                                                <Timeline.Item bullet={<FaSadCry size={12} />} title="ثبت مشتری">
                                                    <Text color="dimmed" size="sm">شما یک مشتری جدید ایجاد کردید</Text>
                                                    <Text size="xs" mt={4}>2 ساعت پیش</Text>
                                                </Timeline.Item>
                                                <Timeline.Item bullet={<FaSadCry size={12} />} title="پیگیری مشتری">
                                                    <Text color="dimmed" size="sm">شما یک مشتری جدید ایجاد کردید</Text>
                                                    <Text size="xs" mt={4}>4 ساعت پیش</Text>
                                                </Timeline.Item>
                                                <Timeline.Item bullet={<FaSadCry size={12} />} title="ثبت مشتری">
                                                    <Text color="dimmed" size="sm">شما یک مشتری جدید ایجاد کردید</Text>
                                                    <Text size="xs" mt={4}>2 ساعت پیش</Text>
                                                </Timeline.Item>
                                                <Timeline.Item bullet={<FaSadCry size={12} />} title="ثبت مشتری">
                                                    <Text color="dimmed" size="sm">شما یک مشتری جدید ایجاد کردید</Text>
                                                    <Text size="xs" mt={4}>2 ساعت پیش</Text>
                                                </Timeline.Item>
                                            </Timeline>
                                        </TeammatesProfileCard>
                                    </div>
                                </div>
                            </div>
                        </Tabs.Panel>
                        <Tabs.Panel value="notes" className="px-3" pt="xs">
                            <Timeline active={1} bulletSize={24} lineWidth={2}>
                                <div className="w-full flex justify-end mb-4">
                                    <Button
                                        onClick={() => {
                                            setNoteOpened(true)
                                        }}
                                        size="xs"
                                    >
                                        ثبت یادداشت
                                    </Button>
                                </div>
                                {loaders.notes == true && (
                                    <div className="flex w-full justify-center">
                                        <Loader />
                                    </div>
                                )}
                                {notes.length == 0 && loaders.notes == false && (
                                    <NoItem />
                                )}
                                {notes.length > 0 && notes.map((note, index) => (
                                    <Timeline.Item key={index} bullet={< FaSave />}>
                                        <Note
                                            key={index}
                                            name={note.name}
                                            creationDate={note.createDate}
                                            id={note.id}
                                            content={note.description} />
                                    </Timeline.Item>
                                ))}
                            </Timeline>
                        </Tabs.Panel>
                        <Tabs.Panel value="feedbacks" className="px-3" pt="xs">
                            <div className="w-full">
                                {loaders.feedback == true && (
                                    <div className="flex w-full justify-center">
                                        <Loader />
                                    </div>
                                )}
                                {feedbacks.length === 0 && loaders.feedback == false && (
                                    <NoItem />
                                )}
                                {feedbacks.length > 0 && (
                                    <TableView
                                        columns={[
                                            { label: 'نوع', id: 'type' },
                                            { label: 'منفی / مثبت', id: 'positiveNegative' },
                                            { label: 'کاربر', id: 'user' },
                                            { label: 'برای', id: 'for' },
                                        ]}
                                        data={
                                            feedbacks.length > 0 && feedbacks.map((feedback, index) => {
                                                return {
                                                    type: 'بازخورد منفی همکار',
                                                    positiveNegative: <p className='text-center flex items-center justify-center'>
                                                        <div className='mx-2'><AiOutlineDislike className='text-red-500' /></div>
                                                        <div className="text-sm font-medium text-red-500">منفی</div>
                                                    </p>,
                                                    user: feedback.userFullName ? feedback.userFullName : 'ندارد',
                                                    for: 'همکار'
                                                }
                                            })
                                        }
                                    />
                                )}
                            </div>
                        </Tabs.Panel>
                        <Tabs.Panel value="peygiri" className="px-3" pt="xs">
                            <div className="w-full flex justify-end mb-4">
                                <Button
                                    onClick={() => {
                                        setPeygiriOpened(true)
                                    }}
                                    size="xs"
                                >
                                    ثبت پیگیری
                                </Button>
                            </div>
                            {loaders.peygiris == true && (
                                <div className="flex w-full justify-center">
                                    <Loader />
                                </div>
                            )}
                            {peygiris.length === 0 && loaders.peygiris == false && (
                                <NoItem />
                            )}
                            {peygiris.length > 0 && (
                                <div className="grid col-span-1 md:col-span-2 xl:grid-cols-3 2xl:grid-cols-4 gap-4">
                                    {peygiris.map((peygiri, index) => (
                                        <Peygiri key={index}
                                            id={peygiri.customerPeyGiryId}
                                            description={peygiri.description}
                                            namePeyGiryCategory={peygiri.namePeyGiryCategory}
                                            dateCreated={peygiri.dateCreated}
                                            nameUser={peygiri.nameUser}
                                        />
                                    ))}
                                </div>
                            )}
                        </Tabs.Panel>
                        <Tabs.Panel value="orders" pt="xs" className="px-4">
                            {loaders.factors == false && (
                                <Factors customer_id={id} />
                            )}
                        </Tabs.Panel>
                    </Tabs>
                </div>
            </div>
        </>
        // </DashboardContent >
    )
}
