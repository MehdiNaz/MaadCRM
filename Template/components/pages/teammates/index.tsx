'use client'

import { LoadingOverlay, Menu, Select, Skeleton, Switch, Text, Textarea } from "@mantine/core"
import SearchInput from "@/components/searchInput"
import { use, useEffect, useReducer, useState } from "react"
import { BiEdit, BiFace } from "react-icons/bi"
import { FiActivity, FiAlertOctagon, FiAward, FiSettings } from "react-icons/fi"
import Card from "@/components/card"
import DashboardContent from '@/components/dashboardContent'
import TeammateCard from '@/components/teammateCard/teammatecard'
import Button from "@/components/button"
import { useRouter } from "next/navigation"
import TextInput from "@/components/textInput"
import FileUploader from "@/components/fileUploader"
import Modal from "@/components/modal"
import Drawer from "@/components/drawer"
import Link from "next/link"
import { DateInput } from "mantine-datepicker-jalali"
import { useForm } from "@mantine/form"
import { showNotification } from "@mantine/notifications"
import { deleteTeammate, insertGroup } from "services/teammates"
import DepartmentsList from "@/components/teammates/departments/list"
import { useDispatch, useSelector } from "react-redux"
import { AppDispatch, RootState } from "store/store"
import { deleteTeammateById, fetchTeammates, setTeammates, setTeammatesFilter } from "slices/teammateSlice"
import { TeammateType } from "@/types/teammates"
import { MdOutlineClear } from "react-icons/md"
import { modals } from "@mantine/modals"
import { HiUserCircle } from "react-icons/hi"
import { IoIosMore } from "react-icons/io"
import TeammatecardPhone from "@/components/teammateCard/phone"
import TeammatecardEmail from "@/components/teammateCard/email"
import TeammatecardAddress from "@/components/teammateCard/address"
import { RiDeleteBin6Line } from "react-icons/ri"
import Image from "next/image"
import { IconMessageCircle, IconPhoto, IconSettings } from "@tabler/icons"
import AccessList from "@/components/teammates/acces"
import { hasAccess } from "@/utils/helper"
import Header from "@/components/dashboardContent/header"


const initialState = {
    teammates: [],
    loading: true
}

function reducer(state, action) {
    switch (state.type) {
        case 'setTeammates':
            return { ...state, teammates: action.payload }
        case 'clearTeammates':
            return { ...state, teammates: [] }
        case 'loaded':
            return { ...state, loading: false }
        default:
            throw new Error();
    }
}



export default function Teammates({ token }) {

    const router = useRouter()

    const [loader, setLoader] = useState<boolean>(false)
    const [newGroupOpen, setNewGroupOpen] = useState<boolean>(false)
    const [newDepartment, setNewDepartment] = useState<boolean>(false)
    const [filterOpened, setFilterOpend] = useState<boolean>(false)

    const [departmentsList, setDepartmentsList] = useState<boolean>(false)

    const groupForm = useForm({
        initialValues: {
            name: '',
        },

        validate: {
            name: (value) => {
                if (!value) {
                    return 'نام گروه را وارد کنید'
                }
            }
        }
    })

    async function submitGroup(values: typeof groupForm.values) {
        try {
            setLoader(true)
            const response = await insertGroup({ title: values.name })
            if (response.success) {
                showNotification({
                    title: 'عملیات موفق',
                    message: 'دپارتمان با موفقیت ایجاد شد',
                    color: 'green',
                })
                setNewDepartment(false)
                groupForm.reset()
            }
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'مشکلی در ایجاد دپارتمان به وجود آمده است',
                color: 'red',
            })
        } finally {
            setLoader(false)
        }
    }

    const [state, dispatchState] = useReducer(reducer, initialState)

    const dispatch = useDispatch<AppDispatch>()

    const { teammates, loading, filteredTeammates, count } = useSelector((state: RootState) => state.teammates)

    useEffect(() => {
        dispatch(fetchTeammates())
    }, [dispatch])


    const [search, setSearch] = useState<string>('')

    useEffect(() => {
        const newFilter = filteredTeammates && filteredTeammates.length > 0 && filteredTeammates.filter((teammate: TeammateType) => {
            return teammate.first_name.includes(search) || teammate.last_name.includes(search)
        })
        if (search === '') {
            dispatch(setTeammatesFilter(teammates))
        } else {
            dispatch(setTeammatesFilter(newFilter))
        }
    }, [search])

    async function deleteteammate(id: string) {
        try {
            const response = await deleteTeammate({ id: id })
            showNotification({
                title: 'عملیات موفق',
                message: 'کاربر باموفقیت حذف شد',
                color: 'green'
            })
            dispatch(deleteTeammateById(id))
        } catch {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'مشکلی در حذف کاربر به وجود آمده است',
                color: 'red'
            })
        } finally {

        }
    }

    const openModal = (id) => modals.openConfirmModal({
        title: 'حذف کاربر',
        children: (
            <Text size="sm">
                آیا از حذف این کاربر مطمئن هستید؟
            </Text>
        ),
        labels: { confirm: 'حذف', cancel: 'لغو' },
        onConfirm: () => deleteteammate(id),
        confirmProps: { color: 'red' },
    })

    const [accessOpen, setAccessOpen] = useState<boolean>(false)
    const [currentUser, setCurrentUser] = useState({
        id: '',
        permission: 1
    })

    // const access = hasAccess({ role: 'Company', token: token })
    const access = true


    return (
        <>
            <Header title="همکاران" >
                <div className="flex">
                    {access === true && (
                        <Link href='/teammates/new'>
                            <Button
                                classNames={{
                                    root: '!bg-primary !font-medium'
                                }}
                                size='xs'
                            >
                                ایجاد همکار
                            </Button>
                        </Link>
                    )}
                    {access === true && (
                        <Button
                            className="mr-3"
                            classNames={{
                                root: '!bg-primary !font-medium'
                            }}
                            size='xs'
                            onClick={() => {
                                setNewDepartment(true)
                            }}
                        >
                            ایجاد دپارتمان
                        </Button>
                    )}
                    {access === true && (
                        <Button
                            className="mr-3"
                            size='xs'
                            onClick={() => {
                                setDepartmentsList(true)
                            }}
                        >
                            لیست دپارتمان ها
                        </Button>
                    )}
                </div>
            </Header>
            <AccessList
                opened={accessOpen}
                onClose={() => setAccessOpen(false)}
                id={currentUser.id}
                permission={currentUser.permission}
            />
            {/* {departmentsList && ( */}
            <DepartmentsList
                opened={departmentsList}
                close={() => setDepartmentsList(false)}
            />
            {/* )} */}
            {filterOpened && (
                <>
                    <Drawer
                        opened={filterOpened}
                        position="right"
                        onClose={() => setFilterOpend(false)}
                        title="فیلتر همکاران"
                        padding="xl"
                        size="md"
                        classNames={{
                            header: "border-b-2 border-primary pb-2 mb-8 z-50",
                        }}
                    >
                        <form className="grid gap-4 grid-cols-1 relative pb-16">
                            <div className="col-span-4">
                                <Select
                                    clearable
                                    className="w-full"
                                    placeholder="وضعیت مشتری"
                                    searchable
                                    data={[
                                        { value: '1', label: 'راضی' },
                                        { value: '2', label: 'ناراضی' },
                                    ]}
                                    name="type"
                                />
                            </div>
                            <div className="col-span-4">
                                <TextInput
                                    placeholder="شماره تماس"
                                    name="phone"
                                />
                            </div>
                            <div className="col-span-4">
                                <Select
                                    clearable
                                    className="w-full"
                                    placeholder="انتخاب محصول"
                                    searchable
                                    data={[
                                        { value: '1', label: 'محصول شماره یک' },
                                        { value: '2', label: 'محصول شماره دو' },
                                    ]}
                                    name="product"
                                />
                            </div>
                            <div className="col-span-4">
                                <Select
                                    clearable
                                    className="w-full"
                                    placeholder="وضعیت مشتری"
                                    searchable
                                    data={[
                                        { value: '1', label: 'راضی' },
                                        { value: '2', label: 'ناراضی' },
                                    ]}
                                />
                            </div>
                            <div className="col-span-4">
                                <TextInput
                                    placeholder="شماره تماس"
                                />
                            </div>
                            <div className="col-span-4">
                                <Select
                                    clearable
                                    className="w-full"
                                    placeholder="انتخاب محصول"
                                    searchable
                                    data={[
                                        { value: '1', label: 'محصول شماره یک' },
                                        { value: '2', label: 'محصول شماره دو' },
                                    ]}
                                />
                            </div>
                            <div className="col-span-4">
                                <Select
                                    clearable
                                    className="w-full"
                                    placeholder="وضعیت مشتری"
                                    searchable
                                    data={[
                                        { value: '1', label: 'راضی' },
                                        { value: '2', label: 'ناراضی' },
                                    ]}
                                />
                            </div>
                            <div className="col-span-4">
                                <TextInput
                                    placeholder="شماره تماس"
                                />
                            </div>
                            <div className="col-span-4">
                                <Select
                                    clearable
                                    className="w-full"
                                    placeholder="انتخاب محصول"
                                    searchable
                                    data={[
                                        { value: '1', label: 'محصول شماره یک' },
                                        { value: '2', label: 'محصول شماره دو' },
                                    ]}
                                />
                            </div>
                            <div className="col-span-4 border px-7 py-4 rounded-md mt-10">
                                <h3 className="text-md font-medium -mt-7 bg-white w-max">بازه زمانی:</h3>
                                <div className="grid grid-cols-12 mt-4">
                                    <div className="col-span-5">
                                        <DateInput
                                            placeholder="از تاریخ"
                                            locale="fa"
                                            firstDayOfWeek={6}
                                            weekendDays={[5]}
                                            name="fromDate"
                                        />
                                    </div>
                                    <div className="col-span-2 grid items-center justify-center">
                                        <span>تا</span>
                                    </div>
                                    <div className="col-span-5">
                                        <DateInput
                                            placeholder="تا تاریخ"
                                            locale="fa"
                                            firstDayOfWeek={6}
                                            weekendDays={[5]}
                                            name="toDate"
                                        />
                                    </div>
                                </div>
                                <div className="grid grid-cols-12 mt-4 gap-5">
                                    <div className="col-span-4 w-full text-center">
                                        <Link href="#">
                                            <span className="text-sm text-center">هفته جاری</span>
                                        </Link>
                                    </div>
                                    <div className="col-span-4 w-full text-center">
                                        <Link href="#">
                                            <span className="text-sm text-center">ماه اخیر</span>
                                        </Link>
                                    </div>
                                    <div className="col-span-4 w-full text-center">
                                        <Link href="#">
                                            <span className="text-sm text-center">3 ماه اخیر</span>
                                        </Link>
                                    </div>
                                    <div className="col-span-4 w-full text-center">
                                        <Link href="#">
                                            <span className="text-sm text-center">6 ماه اخیر</span>
                                        </Link>
                                    </div>
                                    <div className="col-span-4 w-full text-center">
                                        <Link href="#">
                                            <span className="text-sm text-center">سال جاری</span>
                                        </Link>
                                    </div>
                                    <div className="col-span-4 w-full text-center">
                                        <Link href="#">
                                            <span className="text-sm text-center">از ابتدا تا کنون</span>
                                        </Link>
                                    </div>
                                </div>
                            </div>
                            <div className="absolute bottom-0 left-0 right-0 mx-auto flex justify-center">
                                <Button type="submit" className="w-full text-center block">اعمال فیلتر</Button>
                            </div>
                        </form>
                    </Drawer>
                </>
            )}
            <Modal
                opened={newGroupOpen}
                onClose={() => setNewGroupOpen(false)}
                title="ایجاد گروه"
                size='40%'
                classNames={{
                    header: 'mb-8 border-b-2 border-primary'
                }}
            >
                <div className="grid grid-cols-1 gap-4">
                    <div className="col-span-12">
                        <TextInput
                            variant="default"
                            label="نام گروه :"
                            placeholder="نام گروه"
                        />
                    </div>
                    <div className="col-span-12 grid grid-cols-12">
                        <span className="col-span-3">توضیحات :</span>
                        <Textarea
                            placeholder="توضیحات"
                            className="col-span-9"
                        />
                    </div>
                    <div className="col-span-12 grid grid-cols-12">
                        <span className="col-span-3">تصویر :</span>
                        <div className="col-span-9">
                            <FileUploader />
                        </div>
                    </div>
                    <div className="col-span-12 flex justify-between items-center mt-4">
                        <div className="flex">
                            <Switch
                                color='green'
                                label="فعال"
                                defaultChecked
                            />
                        </div>
                        <div className="flex">
                            <Button
                                onClick={() => {
                                    setNewGroupOpen(false)
                                }}
                            >
                                انصراف
                            </Button>
                            <Button
                                className="mr-4"
                            >
                                ذخیره
                            </Button>
                        </div>
                    </div>
                </div>
            </Modal>
            <Modal
                opened={newDepartment} onClose={() => setNewDepartment(false)} title="ایجاد دپارتمان" size='40%'
            >
                <form
                    onSubmit={groupForm.onSubmit(submitGroup)}
                    className="grid grid-cols-1 gap-4">
                    <LoadingOverlay visible={loader} />
                    <div className="col-span-12">
                        <TextInput
                            label="نام دپارتمان :"
                            placeholder="نام دپارتمان"
                            {...groupForm.getInputProps('name')}
                        />
                    </div>
                    <div className="col-span-12 mt-4">
                        <div className="flex justify-end">
                            <Button
                                onClick={() => {
                                    setNewDepartment(false)
                                }}
                            >
                                انصراف
                            </Button>
                            <Button type="submit" className="mr-4">
                                ذخیره
                            </Button>
                        </div>
                    </div>
                </form>
            </Modal>
            <div className="w-full hidden grid-cols-4 border-b pb-3">
                <TextInput
                    placeholder="جستجو"
                    value={search}
                    onChange={(e) => { setSearch(e.target.value) }}
                    rightSection={search.length > 0 &&
                        <button onClick={() => setSearch('')}>
                            <MdOutlineClear />
                        </button>
                    }
                />
            </div>
            <div className="w-full mt-12">
                {loading && (
                    <div className="w-full grid 2xl:grid-cols-4 lg:grid-cols-3 md:grid-cols-2 gap-4">
                        <Skeleton height={200} radius="md" />
                        <Skeleton height={200} radius="md" />
                        <Skeleton height={200} radius="md" />
                        <Skeleton height={200} radius="md" />
                        <Skeleton height={200} radius="md" />
                        <Skeleton height={200} radius="md" />
                        <Skeleton height={200} radius="md" />
                    </div>
                )}
                {count == 0 && !loading && (
                    <div className="w-full flex justify-center items-center flex-col">
                        <Image src="/icons/teammate.svg" width={450} height={450} alt="teammate" />
                        <span className="text-md">کاربری پیدا نشد</span>
                    </div>
                )}
                <div className="w-full grid 2xl:grid-cols-4 lg:grid-cols-3 md:grid-cols-2 gap-4">
                    {!loading && filteredTeammates && filteredTeammates.length > 0 && filteredTeammates.map((teammate: TeammateType) => {
                        return (
                            <div className="w-full bg-white rounded-lg overflow-hidden" key={teammate.id}>
                                <div className="w-full flex border-b pb-3 py-2 px-3">
                                    <div className="flex border-l pl-3 ">
                                        <HiUserCircle className='text-4xl' />
                                    </div>
                                    <div className="flex items-center mr-3">
                                        <span className='ml-6'>{
                                            teammate?.first_name ? teammate.first_name + ' ' + teammate.last_name : teammate.last_name
                                        }</span>
                                        <span className='text-sm text-gray-700'>{teammate?.department?.title}</span>
                                    </div>
                                    <Menu shadow="md" width={200}>
                                        <Menu.Target>
                                            <div className="flex mr-auto items-center text-2xl cursor-pointer">
                                                <IoIosMore />
                                            </div>
                                        </Menu.Target>
                                        <Menu.Dropdown>
                                            {/* <Menu.Label>تنظیمات</Menu.Label> */}
                                            <Menu.Item
                                                icon={<FiSettings />}
                                                onClick={() => {
                                                    setCurrentUser(current => {
                                                        return {
                                                            ...current,
                                                            id: teammate.id,
                                                            permission: teammate.permission,
                                                        }
                                                    })
                                                    setAccessOpen(true)
                                                }}
                                            >سطح دسترسی</Menu.Item>
                                            <Menu.Item
                                                onClick={() => {
                                                    router.push(`/teammates/edit/${teammate.id}`)
                                                }}
                                                icon={<BiEdit />}
                                            >ویرایش</Menu.Item>
                                            <Menu.Item
                                                color={'red'}
                                                icon={<RiDeleteBin6Line />}
                                                onClick={() => { openModal(teammate.id) }}
                                            >حذف</Menu.Item>
                                        </Menu.Dropdown>
                                    </Menu>
                                </div>
                                <div className="grid grid-cols-1 mt-4 py-2 px-3 gap-4">
                                    <div className="flex items-center">
                                        <TeammatecardPhone phone={teammate.phone} />
                                    </div>
                                    <div className="flex items-center">
                                        <TeammatecardEmail email={teammate.email || 'ایمیلی ثبت نشده'} />
                                    </div>
                                </div>
                                <div className="w-full mt-2 mb-4 px-3">
                                    <TeammatecardAddress address={teammate.address || 'آدرسی ثبت نشده'} />
                                </div>
                                <div className="w-full justify-between items-center flex mt-6 border-t py-2 px-3">
                                    <div className="grid gap-2 grid-cols-2 mr-auto">
                                        <Link href={`/teammates/edit/${teammate.id}`}>
                                            <BiEdit className='text-gray-700 text-xl' />
                                        </Link>
                                        <button
                                            onClick={() => { openModal(teammate.id) }}
                                        >
                                            <RiDeleteBin6Line className='text-red-700 text-xl' />
                                        </button>
                                    </div>
                                </div>
                            </div>
                        )
                    })}
                    {/*filteredTeammates.length == 0 && !loading && (
                        <div className="w-full flex justify-center items-center flex-col">
                            <Image src="/icons/teammate.svg" width={450} height={450} alt="teammate" />
                            <span className="text-md">کاربری پیدا نشد</span>
                        </div>
                    )*/}
                </div>
            </div>
        </>
    )
}