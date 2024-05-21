import { Checkbox, Drawer, LoadingOverlay, Modal, Skeleton, Switch, Text } from "@mantine/core";
import { useForm } from "@mantine/form";
import { useEffect, useState } from "react";
import Button from "@/components/button";
import TextInput from "@/components/textInput"
import { showNotification } from "@mantine/notifications";
import { DepartmentType } from "@/types/teammates";
import { FiEdit } from "react-icons/fi";
import { RiDeleteBin5Line, RiDeleteBinLine } from "react-icons/ri";
import { MdOutlineClear } from "react-icons/md";
import { deleteDepartment, editDepartment, getAllGroups } from "services/teammates";
import { modals } from "@mantine/modals";
import Image from "next/image";

export default function DepartmentsList({ opened, close }) {

    const [open, setOpen] = useState<boolean>(false)
    const [loading, setLoading] = useState<boolean>(true)
    const [groups, setGroups] = useState<DepartmentType[]>([])
    const [searchItems, setSearchItems] = useState<DepartmentType[]>([])
    const [search, setSearch] = useState<string>('')
    const [editOpedned, setEditOpedned] = useState<boolean>(false)
    const [showDeleted, setShowDeleted] = useState<boolean>(true)



    function handleClose() {
        if (close && typeof close == 'function') close()

        setSearch('')
        setEditOpedned(false)
    }

    async function getGroups() {
        try {
            const response = await getAllGroups()
            setGroups(response.departments)
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در دریافت اطلاعات دپارتمان ها',
                color: 'orange'
            })
        } finally {
            setLoading(false)
        }
    }


    useEffect(() => {
        setOpen(opened)
        setGroups([])
        setSearchItems([])
        setLoading(true)
        if (opened == true) getGroups()
    }, [opened])

    useEffect(() => {
        if (searchItems.length == 0) {
            setSearchItems(groups)
        }
    }, [searchItems, groups])


    const editForm = useForm({
        initialValues: {
            id: '',
            title: ''
        },
        validate: {
            title: (value) => {
                if (!value) return 'عنوان دپارتمان را وارد کنید'
            }
        }
    })

    async function handleEditDepartment(values: typeof editForm.values) {
        try {
            setLoading(true)
            const reposnse = await editDepartment({
                id: values.id,
                title: values.title
            })
            setEditOpedned(false)
            showNotification({
                title: 'عملیات موفق',
                message: 'دپارتمان با موفقیت ویرایش شد',
                color: 'green'
            })
            setGroups(groups.map((group: DepartmentType) => {
                if (group.id == values.id) {
                    group.title = values.title
                }
                return group
            }))
        } catch {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در ویرایش دپارتمان',
                color: 'red'
            })
            setGroups([{
                id: '', title: 'موردی یافت نشد'
            }])
        } finally {
            setLoading(false)
        }
    }

    async function deletedepartment(id: string) {
        try {
            const response = await deleteDepartment({
                id: id
            })
            showNotification({
                title: 'عملیات موفق',
                message: 'دپارتمان با موفقیت حذف شد',
                color: 'green'
            })
            setGroups(groups.filter((group: DepartmentType) => {
                return group.id != id
            }))
        } catch {
            showNotification({
                title: "عملیات ناموفق",
                message: 'خطا در حذف دپارتمان',
                color: 'red'
            })
        }
    }


    const openModal = (id: string) => modals.openConfirmModal({
        title: 'حذف دپارتمان',
        children: (
            <Text size="sm">
                آیا از حذف این دپارتمان مطمئن هستید؟
            </Text>
        ),
        labels: { confirm: 'حذف', cancel: 'لغو' },
        onConfirm: () => deletedepartment(id),
        confirmProps: { color: 'red' },
    })

    return (
        <>
            <Drawer opened={open} onClose={handleClose} title='دپارتمان ها'>
                <Modal size='lg' opened={editOpedned} title="ویرایش دپارتمان" onClose={() => setEditOpedned(false)}>
                    <form
                        onSubmit={editForm.onSubmit(handleEditDepartment)}
                        className="relative"
                    >
                        <LoadingOverlay visible={loading} />
                        <div className="w-full flex flex-col mt-4">
                            <TextInput
                                placeholder="عنوان دپارتمان"
                                label="عنوان دپارتمان :"
                                {...editForm.getInputProps('title')}
                            />
                            <div className="w-full mt-8 flex justify-end">
                                <Button type="submit">
                                    ویرایش
                                </Button>
                            </div>
                        </div>
                    </form>
                </Modal>
                <div className="w-full my-4">
                    <TextInput
                        placeholder="جستجو"
                        onChange={(e) => {
                            const value = e.target.value
                            setSearch(value)
                            const filteredGroups = groups.filter((group: DepartmentType) => {
                                return group.title.includes(value)
                            })
                            setSearchItems(filteredGroups)
                        }}
                        value={search}
                        rightSection={
                            search.length > 0 &&
                            <button
                                onClick={() => {
                                    setSearch('')
                                    setSearchItems(groups)
                                }}
                            >
                                <MdOutlineClear />
                            </button>
                        }
                    />
                    <div className="flex mt-4">
                        <Switch
                            label="نمایش حذف شده ها"
                            onChange={() => { setShowDeleted(!showDeleted) }}
                            checked={showDeleted}
                        />
                    </div>
                </div>
                <div className="flex flex-col border-t-2">
                    <div className="grid grid-cols-2 my-4">
                        <span className="text-center text-sm">عنوان</span>
                        <span className="text-center text-sm">عملیات</span>
                    </div>
                    <div className="grid grid-cols-1 gap-3">
                        {loading && groups.length == 0 && (
                            <>
                                <Skeleton height={30} radius="sm" />
                                <Skeleton height={30} radius="sm" />
                                <Skeleton height={30} radius="sm" />
                                <Skeleton height={30} radius="sm" />
                                <Skeleton height={30} radius="sm" />
                                <Skeleton height={30} radius="sm" />
                                <Skeleton height={30} radius="sm" />
                            </>
                        )}
                        {searchItems && searchItems.length > 0 && searchItems.map((department: DepartmentType, index) => (
                            <div key={index} className={`grid grid-cols-2 border rounded-md py-2 px-1 items-center ${department.status == 3 ? 'bg-red-100' : ''}`}>
                                <span className="text-center text-sm">
                                    {department.title}
                                </span>
                                <div className="text-center flex items-center justify-center">
                                    <button
                                        onClick={() => {
                                            setEditOpedned(true)
                                            editForm.setValues({
                                                id: department.id,
                                                title: department.title
                                            })
                                        }}
                                    >
                                        <FiEdit className="text-sm" />
                                    </button>
                                    <button
                                        onClick={() => {
                                            openModal(department.id)
                                        }}
                                        className="mr-3">
                                        <RiDeleteBinLine className="text-red-500" />
                                    </button>
                                </div>
                            </div>
                        ))}
                        {!loading && searchItems.length == 0 && (
                            <div className="w-full flex mt-4 justify-center flex-col items-center">
                                <Image
                                    src="/icons/department.svg"
                                    width={250}
                                    height={250}
                                    alt="empty"
                                />
                                <span>موردی یافت نشد</span>
                            </div>
                        )}
                    </div>
                </div>
            </Drawer>
        </>
    )
}
