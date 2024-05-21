'use client'
import { useEffect, useState } from "react"
import DashboardContent from "@/components/dashboardContent"
import TextInput from '@/components/textInput'
import Button from '@/components/button'
import AbsoluteButton from "@/components/absoluteButton"
import { AiOutlineUsergroupAdd } from "react-icons/ai"
import Modal from "@/components/modal"
import { useForm } from "@mantine/form"
import { getAllGroups, newGroup } from "services/contact"
import { showNotification } from "@mantine/notifications"
import GroupsTable from "@/components/tables/contacts/groups"
import Header from "@/components/dashboardContent/header"
import Image from "next/image"
import { useSelector } from "react-redux"

export default function Groups() {

    const [opened, setOpened] = useState<boolean>(false)
    const [groupOpened, setGroupOpened] = useState<boolean>(false)
    const [groups, setGroups] = useState<Array<any>>([])
    const [loading, setLoading] = useState<boolean>(true)

    const actions = [
        {
            label: 'ایجاد گروه',
            icon: <AiOutlineUsergroupAdd />,
            onClick: () => setGroupOpened(true)
        }
    ]

    async function getContactGroups() {
        try {
            const response = await getAllGroups()
            setGroups(response.groups)
            setLoading(false)

        } catch {
            showNotification({
                title: 'خطا',
                message: 'خطا در دریافت اطلاعات مخاطبین',
                color: 'red'
            })
        }
    }

    useEffect(() => {
        getContactGroups()
    }, [opened])


    const groupForm = useForm({
        initialValues: {
            title: '',
            description: ''
        },
        validate: {
            title: (value) => {
                if (value.length < 3) {
                    return 'عنوان گروه باید حداقل 3 کاراکتر باشد'
                }
            },
        }
    })

    async function handleCreateGroup(values: typeof groupForm.values) {
        try {
            const response = await newGroup({
                title: values.title,
            })
            showNotification({
                title: 'گروه جدید',
                message: 'گروه جدید با موفقیت ایجاد شد',
                color: 'green',
            })
            getContactGroups()
            groupForm.reset()
            setGroupOpened(false)
        } catch (error) {
            showNotification({
                title: 'گروه جدید',
                message: 'خطا در ایجاد گروه جدید',
                color: 'red',
            })
        }
    }

    return (
        <>
            <Header title="گروه های مخاطبین">
                <div className="flex">
                    <Button
                        onClick={() => setGroupOpened(true)}
                    >
                        ایجاد گروه
                    </Button>
                </div>
            </Header>
            <AbsoluteButton actions={actions} />
            <Modal
                opened={groupOpened}
                onClose={() => setGroupOpened(false)}
                title="ایجاد گروه"
                size='lg'
            >
                <div className="w-full flex flex-col">
                    <form onSubmit={groupForm.onSubmit(handleCreateGroup)}>
                        <TextInput
                            placeholder="نام گروه"
                            label="نام گروه :"
                            {...groupForm.getInputProps('title')}
                        />
                        <Button type="submit" className="mt-8 text-sm">
                            افزودن گروه
                        </Button>
                    </form>
                </div>
            </Modal>
            {loading == false && groups && groups.length === 0 && (
                <div className="w-full flex justify-center items-center flex-col">
                    <Image
                        src='/icons/group.svg'
                        width={400}
                        height={400}
                        alt="contact not found"
                    />
                    <span className="text-md my-8">اولین گروه مخاطب خود را ایجاد کنید</span>
                </div>
            )}
            <div className="w-full my-10">
                <GroupsTable
                    data={groups}
                />
            </div>
        </>
    )
}