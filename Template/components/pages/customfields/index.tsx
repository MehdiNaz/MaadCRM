'use client';
import DashbordContent from '@/components/dashboardContent';
import { Tabs, Switch, Radio, SegmentedControl, LoadingOverlay, Text, Checkbox, Dialog } from '@mantine/core';
import { Head } from '@/components/form';
import { useEffect, useState } from 'react';
import TextInput from '@/components/textInput';
import Button from '@/components/button';
import { FaCheck, FaEdit, FaPlus, FaTrash } from 'react-icons/fa';
import { AttributeInputTypeId, FieldType } from '@/types/customfields';
import { useForm } from '@mantine/form';
import { deleteAttribute, deleteAttributeOption, getAllAttributes, InsertAttribute, InsertAttributeOption, updateAttribute, updateAttributeOption } from 'services/customfields';
import { showNotification } from '@mantine/notifications';
import Table from '@/components/tables/table';
import InputNumber from '@/components/numberInput';
import Modal from '@/components/modal';
import { randomId } from '@mantine/hooks';
import { BiEdit } from 'react-icons/bi';
import { TiDeleteOutline, TiTick } from 'react-icons/ti';
import { modals } from '@mantine/modals';
import Image from 'next/image';
import DateInput from '@/components/DateInput';
import Textarea from '@/components/textarea';
import SelectBox from '@/components/selectBox';
import MultiSelect from '@/components/multiSelect';
import { current } from '@reduxjs/toolkit';
import { hasAccess } from '@/utils/helper';

export default function CustomFields() {

    const [loading, setLoading] = useState<boolean>(false)
    const [fetched, setFetched] = useState<boolean>(false)

    const [fields, setFields] = useState<FieldType[]>([])
    const [AttributeInputTypeId, setAttributeInputTypeId] = useState<AttributeInputTypeId>(1)

    const [editMode, setEditMode] = useState<boolean>(false)

    async function getAlllAttributeFields() {
        try {
            setLoading(true)
            const response = await getAllAttributes()
            setFields(response.fields)
            setFetched(true)
        } catch (err) {
            showNotification({
                message: 'خطا در دریافت اطلاعات',
                color: 'red'
            })
        } finally {
            setLoading(false)
        }
    }

    useEffect(() => {
        getAlllAttributeFields()
    }, [])

    const [currentField, setCurrentField] = useState<FieldType>({
        type: 1,
        required: false,
        title: 'عنوان فیلد',
        options: [
            {
                title: 'گزینه یک',
                id: randomId(),
                new: true,
                selected: false
            },
            {
                title: 'گزینه دو',
                id: randomId(),
                new: true,
                selected: false
            },
            {
                title: 'گزینه سه',
                id: randomId(),
                new: true,
                selected: false
            },
            {
                title: 'گزینه چهار',
                id: randomId(),
                new: true,
                selected: false
            }
        ],
        value: ''
    })

    const form = useForm({
        initialValues: {
            title: '',
            required: false,
            type: 1,
        },
        validate: {
            title: (value) => {
                if (value.length < 2) {
                    return 'حداقل 2 کاراکتر وارد کنید'
                }
            },
        }

    })
    const [insertLoading, setInsertLoading] = useState<boolean>(false)


    function clearCurrentField() {
        setCurrentField({
            ...currentField,
            type: 3,
            required: false,
            title: 'عنوان فیلد',
            options: [
                {
                    title: 'گزینه یک',
                    id: randomId()
                },
                {
                    title: 'گزینه دو',
                    id: randomId()
                },
                {
                    title: 'گزینه سه',
                    id: randomId()
                },
                {
                    title: 'گزینه چهار',
                    id: randomId()
                }
            ],
            value: ''
        })
        form.setValues({
            title: '',
            required: false,
            type: 3,
        })
    }

    async function submitForm(values: typeof form.values) {
        try {
            if (editMode) {
                showNotification({
                    title: 'عملیات موفق',
                    message: 'فیلد باموفقیت ویرایش شد',
                    color: 'green'
                })
                setEditMode(false)
                clearCurrentField()
                return
            }
            setInsertLoading(true)
            let response = null

            if (AttributeInputTypeId == 5 || AttributeInputTypeId == 6) {
                let options = []
                currentField.options.map((option, index) => {
                    options[index] = {
                        title: option.title,
                    }
                })

                response = await InsertAttribute({
                    title: currentField.title,
                    required: currentField.required,
                    type: currentField.type,
                    options: options
                })
            } else {
                let options = [{
                    Title: currentField.title,
                    DisplayOrder: 1
                }]
                response = await InsertAttribute({
                    title: currentField.title,
                    required: currentField.required,
                    type: currentField.type,
                    options: null
                })
            }
            showNotification({
                title: 'عملیات موفق',
                message: 'فیلد سفارشی باموفقیت ایجاد شد',
                color: 'green'
            })
            setFields((fields) => [...fields, response.new_field])
            setCurrentField({
                ...currentField,
                type: 3,
                required: false,
                title: 'عنوان فیلد',
                options: [
                    {
                        title: 'گزینه یک',
                        id: randomId()
                    },
                    {
                        title: 'گزینه دو',
                        id: randomId()
                    },
                    {
                        title: 'گزینه سه',
                        id: randomId()
                    },
                    {
                        title: 'گزینه چهار',
                        id: randomId()
                    }
                ],
                value: ''
            })
            form.setValues({
                title: '',
                required: false,
                type: 3,
            })
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در ایجاد فیلد سفارشی',
                color: 'red'
            })
        } finally {
            setInsertLoading(false)
        }
    }

    const fieldsLabels = {
        1: 'کادر متنی',
        2: 'کادر عددی',
        3: 'تاریخ',
        4: 'فایل',
        5: 'تک انتخابی',
        6: 'چند انتخابی',
    }


    const [EditFieldOpened, setEditFieldOpened] = useState<boolean>(false)
    const editFieldForm = useForm({
        initialValues: {
            title: '',
            Id: '',
            required: false,
            idAttributeType: 0,
            type: 0
        },
        validate: {
            title: (value) => {
                if (!value) return 'لطفا عنوان را وارد کنید'
            }
        }
    })
    async function handleEditField(values: typeof editFieldForm.values) {
        try {
            setLoading(true)
            const response = await updateAttribute({
                id: values.Id,
                title: values.title,
                required: values.required,
                // AttributeTypeId: 1,
                type: values.type
            })
            showNotification({
                title: 'عملیات موفق',
                message: 'فیلد باموفقیت ویرایش شد',
                color: 'green'
            })
            setEditFieldOpened(false)
            setEditMode(false)

            fields.map((field) => {
                if (field.id == values.Id) {
                    field.title = values.title
                    field.required = values.required
                    field.idAttributeType = values.idAttributeType
                    field.idAttributeInputType = values.type
                    setFields(fields)
                }
            })

            setCurrentField({
                ...currentField,
                type: 3,
                required: false,
                title: 'عنوان فیلد',
                options: [
                    {
                        title: 'گزینه یک',
                        id: randomId()
                    },
                    {
                        title: 'گزینه دو',
                        id: randomId()
                    },
                    {
                        title: 'گزینه سه',
                        id: randomId()
                    },
                    {
                        title: 'گزینه چهار',
                        id: randomId()
                    }
                ],
                value: ''
            })
            form.setValues({
                title: '',
                required: false,
            })
        } catch {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در ویرایش فیلد',
                color: 'red'
            })
        } finally {
            setLoading(false)
        }
    }

    function handleAddRadioField() {
        setCurrentField({
            ...currentField,
            options: [
                ...currentField.options,
                {
                    title: 'عنوان گزینه',
                    id: randomId(),
                    editMode: editMode,
                    new: true
                }
            ]
        })
    }

    async function deletefield(id: string) {
        try {
            const response = await deleteAttribute(id)
            if (response.success) {
                showNotification({
                    title: 'عملیات موفق',
                    message: 'فیلد با موفقیت حذف شد',
                    color: 'green'
                })
            }
            setFields(fields.filter((field) => field.id != id))
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در حذف فیلد',
                color: 'red'
            })
        }
    }

    const openDeleteModal = (id: string) => modals.openConfirmModal({
        title: 'حذف فیلد',
        children: (
            <Text size="sm">
                آیا از حذف این فیلد مطمئن هستید؟
            </Text>
        ),
        labels: { confirm: 'حذف', cancel: 'لغو' },
        onConfirm: () => deletefield(id),
        confirmProps: { color: 'red' },
    })

    async function deleteattributeOption(id: string) {
        try {
            const response = await deleteAttributeOption(id)
            if (response.valid) {
                showNotification({
                    title: 'عملیات موفق',
                    message: 'گزینه با موفقیت حذف شد',
                    color: 'green'
                })
                setCurrentField(current => {
                    return {
                        ...current,
                        Options: current.options.filter((item) => item.id != id)
                    }
                })
            }
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در حذف گزینه',
                color: 'red'
            })
        }
    }

    const openDeleteAttributeOption = (id: string) => modals.openConfirmModal({
        title: 'حذف فیلد',
        children: (
            <Text size="sm">
                آیا از حذف این گزینه مطمئن هستید؟
            </Text>
        ),
        labels: { confirm: 'حذف', cancel: 'لغو' },
        onConfirm: () => deleteattributeOption(id),
        confirmProps: { color: 'red' },
    })

    const [dialogOpened, setDialogOpened] = useState<boolean>(false)


    useEffect(() => {
        currentField.options.map((item) => {
            if (item.editing) {
                const parent = document.getElementById(item.id)
                const element = parent.querySelector('input')
                if (element?.getAttribute('data-selcted') == 'true') return
                element?.focus()
                element?.select()
                element.setAttribute('data-selcted', 'true')
            }
        })
    }, [currentField.options])

    return (
        <>
            <Modal size='lg' opened={EditFieldOpened} onClose={() => setEditFieldOpened(false)} title="ویرایش فیلد">
                <form
                    onSubmit={editFieldForm.onSubmit(handleEditField)}
                >
                    <LoadingOverlay visible={loading} />
                    <div className="grid grid-cols-1 gap-6">
                        <TextInput
                            placeholder='عنوان فیلد'
                            {...editFieldForm.getInputProps('title')}
                        />
                        <Switch
                            label='اجباری'
                            checked={editFieldForm.values.required}
                            {...editFieldForm.getInputProps('isRequired')}
                        />
                    </div>
                    <div className="w-full flex justify-end mt-4">
                        <Button type="submit">
                            ویرایش
                        </Button>
                    </div>
                </form>
            </Modal>
            {/* <DashbordContent
                hasAccess={hasAccess('Company')}
                active_menu="settings" breadcrumbTitle="فیلد های سفارشی" divider={false}> */}
            <Tabs defaultValue="customers" variant="outline" >
                <Tabs.List>
                    <Tabs.Tab value="customers">ثبت مشتری</Tabs.Tab>
                    {/* <Tabs.Tab value="contacts">دفترچه تلفن</Tabs.Tab> */}
                    {/* <Tabs.Tab value="teammates">ثبت همکار</Tabs.Tab> */}
                </Tabs.List>

                <Tabs.Panel value="customers" pt="xs">
                    <div>
                        <form onSubmit={form.onSubmit(submitForm)} className="w-full">
                            <div className="bg-white rounded-b-md px-8 py-5 border-t-4 border-primary shadow-sm relative" id='settings'>
                                <LoadingOverlay visible={insertLoading} />
                                <div className="w-full">
                                    <div className="mb-8 border-b pb-2">
                                        <Head title='نوع فیلد و تنظیمات آن' />
                                    </div>
                                    <SegmentedControl
                                        value={AttributeInputTypeId.toString() as string}
                                        size='lg'
                                        classNames={{
                                            root: '!w-full',
                                        }}
                                        onChange={(value) => {
                                            setAttributeInputTypeId(parseInt(value))
                                            setCurrentField(current => {
                                                return {
                                                    ...current,
                                                    required: false,
                                                    // title: 'عنوان فیلد',
                                                    type: parseInt(value)
                                                }
                                            })
                                        }
                                        }
                                        data={[
                                            { label: 'کادر متنی', value: '1' },
                                            { label: 'کادر عددی', value: '2' },
                                            { label: 'تاریخ', value: '3' },
                                            // { label: 'فایل', value: '4' },
                                            { label: 'تک انتخابی', value: '5' },
                                            { label: 'چند انتخابی', value: '6' },
                                        ]}
                                    />
                                    <div className="w-full mt-12 ">
                                        <div className="mb-8 border-b pb-2">
                                            <Head title='تنظیمات فیلد' />
                                        </div>
                                        <div className="grid grid-cols-4 gap-8">
                                            <div className="col-span-2">
                                                <TextInput
                                                    label='عنوان فیلد'
                                                    placeholder='مثال : کد ملی'
                                                    {...form.getInputProps('title')}
                                                    onKeyDown={(e) => {
                                                        if (e.keyCode == 13) {
                                                            e.preventDefault()
                                                            return
                                                        }
                                                    }}
                                                    onChange={(e) => {
                                                        const value = e.target.value
                                                        form.setValues({ title: value })
                                                        editFieldForm.setValues({
                                                            'title': value
                                                        })
                                                        setCurrentField({ ...currentField, title: value })
                                                    }}
                                                />
                                            </div>
                                            <div className="flex items-center">
                                                <Switch
                                                    color='green'
                                                    label="اجباری کردن این فیلد"
                                                    onChange={(e) => {
                                                        const value = e.target.checked
                                                        setCurrentField({ ...currentField, required: value })
                                                        editFieldForm.setValues({
                                                            'required': value
                                                        })
                                                    }}
                                                />
                                            </div>
                                        </div>
                                        {AttributeInputTypeId == 5 || AttributeInputTypeId == 6 ? (
                                            <div className="col-span-2 grid grid-cols-2 gap-4">
                                                <div className="col-span-2 flex mt-8 pt-14 border-t-2">
                                                    <Radio.Group className='w-full' value={''} onChange={(value) => { setCurrentField({ ...currentField, value: '' }) }}>
                                                        <div className="grid grid-cols-4 gap-16">
                                                            {currentField.options && currentField.options.length > 0 && currentField.options.map((option, index) => {
                                                                return (
                                                                    <div className='relative mx-4 col-span-1 flex flex-col' key={index} id={option.id}>
                                                                        {!option.editing && (
                                                                            <span>{option.title}</span>
                                                                        )}
                                                                        {option.editing && (
                                                                            <TextInput
                                                                                rightSection={
                                                                                    <span
                                                                                        onClick={async (e) => {
                                                                                            e.preventDefault()
                                                                                            if (editMode) {
                                                                                                try {
                                                                                                    const attributeId = editFieldForm.values.Id
                                                                                                    if (option.new) {
                                                                                                        const response = await InsertAttributeOption({
                                                                                                            IdAttribute: attributeId,
                                                                                                            Title: option.title,
                                                                                                        })
                                                                                                        showNotification({
                                                                                                            title: 'عملیات موفق',
                                                                                                            message: 'گزینه با موفقیت ایجاد شد',
                                                                                                            color: 'green'
                                                                                                        })
                                                                                                    } else {
                                                                                                        const response = await updateAttributeOption({
                                                                                                            Id: option.id,
                                                                                                            Title: option.title,
                                                                                                        })
                                                                                                        showNotification({
                                                                                                            title: 'عملیات موفق',
                                                                                                            message: 'گزینه با موفقیت ویرایش شد',
                                                                                                            color: 'green'
                                                                                                        })
                                                                                                    }
                                                                                                    setCurrentField(current => {
                                                                                                        return {
                                                                                                            ...current,
                                                                                                            options: current.options.map((item) => {
                                                                                                                if (item.id == option.id) {
                                                                                                                    return {
                                                                                                                        ...item,
                                                                                                                        editing: false
                                                                                                                    }
                                                                                                                }
                                                                                                                return item
                                                                                                            })
                                                                                                        }
                                                                                                    })
                                                                                                } catch (err) {
                                                                                                    if (option.new) {
                                                                                                        showNotification({
                                                                                                            title: 'عملیات ناموفق',
                                                                                                            message: 'خطا در ایجاد گزینه',
                                                                                                            color: 'red'
                                                                                                        })
                                                                                                    } else {
                                                                                                        showNotification({
                                                                                                            title: 'عملیات ناموفق',
                                                                                                            message: 'خطا در ویرایش گزینه',
                                                                                                            color: 'red'
                                                                                                        })
                                                                                                    }
                                                                                                }
                                                                                            } else {
                                                                                                setCurrentField(current => {
                                                                                                    return {
                                                                                                        ...current,
                                                                                                        options: current.options.map((item) => {
                                                                                                            if (item.id == option.id) {
                                                                                                                return {
                                                                                                                    ...item,
                                                                                                                    editing: false
                                                                                                                }
                                                                                                            }
                                                                                                            return item
                                                                                                        })
                                                                                                    }
                                                                                                })
                                                                                            }
                                                                                        }}
                                                                                        className='text-green-500 cursor-pointer border-r'>
                                                                                        <TiTick />
                                                                                    </span>
                                                                                }
                                                                                className='w-full'
                                                                                placeholder='عنوان گزینه'
                                                                                value={option.title}
                                                                                onKeyDown={(e) => {
                                                                                    if (e.keyCode == 13) {
                                                                                        e.preventDefault()
                                                                                        setCurrentField(current => {
                                                                                            return {
                                                                                                ...current,
                                                                                                options: current.options.map((item) => {
                                                                                                    if (item.id == option.id) {
                                                                                                        return {
                                                                                                            ...item,
                                                                                                            editing: false
                                                                                                        }
                                                                                                    }
                                                                                                    return item
                                                                                                })
                                                                                            }
                                                                                        })
                                                                                    }
                                                                                }}
                                                                                onChange={(e) => {
                                                                                    const value = e.target.value
                                                                                    setCurrentField(current => {
                                                                                        return {
                                                                                            ...current,
                                                                                            options: current.options.map((item) => {
                                                                                                if (item.id == option.id) {
                                                                                                    return {
                                                                                                        ...item,
                                                                                                        title: value
                                                                                                    }
                                                                                                }
                                                                                                return item
                                                                                            })
                                                                                        }
                                                                                    })
                                                                                }
                                                                                }
                                                                            />
                                                                        )}
                                                                        <span
                                                                            onClick={(e) => {
                                                                                e.preventDefault()
                                                                                if (option.new) {
                                                                                    setCurrentField(current => {
                                                                                        return {
                                                                                            ...current,
                                                                                            options: current.options.filter((item) => item.id != option.id)
                                                                                        }
                                                                                    })
                                                                                } else {
                                                                                    openDeleteAttributeOption(option.id)
                                                                                }

                                                                            }}
                                                                            className='mr-3 absolute -top-6 -right-4 text-red-600 cursor-pointer'>
                                                                            <TiDeleteOutline />
                                                                        </span>
                                                                        <span
                                                                            onClick={(e) => {
                                                                                e.preventDefault()
                                                                                setCurrentField(current => {
                                                                                    return {
                                                                                        ...current,
                                                                                        options: current.options.map((item) => {
                                                                                            if (item.id == option.id) {
                                                                                                return {
                                                                                                    ...item,
                                                                                                    editing: !item.editing
                                                                                                }
                                                                                            }
                                                                                            return item
                                                                                        })
                                                                                    }
                                                                                })
                                                                            }}
                                                                            className='mr-3 absolute -top-6 right-2 text-sm cursor-pointer'>
                                                                            <BiEdit />
                                                                        </span>
                                                                    </div>
                                                                )
                                                            })}
                                                            {currentField.options && currentField.options.length == 0 && (
                                                                <div className="col-span-4 flex justify-center items-center">
                                                                    <span className='text-gray-400'>هیچ گزینه ای وجود ندارد</span>
                                                                </div>
                                                            )}
                                                        </div>
                                                    </Radio.Group>
                                                </div>
                                                <div className="w-full mt-8 mb-4">
                                                    <Button
                                                        onClick={() => handleAddRadioField()}
                                                    >
                                                        افزودن گزینه
                                                    </Button>
                                                </div>
                                            </div>
                                        ) : null}
                                    </div>
                                    <div className="flex justify-end">
                                        {editMode ? (
                                            <Button
                                                type="button"
                                                className='mt-8 text-sm'
                                                onClick={(e) => {
                                                    e.preventDefault()
                                                    handleEditField(editFieldForm.values)
                                                }}
                                            >
                                                اعمال تغییرات
                                            </Button>
                                        ) : (
                                            <Button type="submit" className='mt-8 text-sm'>
                                                ذخیره و افزودن
                                            </Button>
                                        )}
                                    </div>
                                </div>
                            </div>
                        </form>
                        <div id="preview" className='w-full bg-white mt-5 rounded-b-md px-8 py-5 border-t-4 border-primary shadow-sm'>
                            <div className="mb-8 border-b pb-2">
                                <Head title='پیش نمایش' />
                            </div>
                            {AttributeInputTypeId == 1 && (
                                <div className="w-full grid grid-cols-2">
                                    <TextInput
                                        label={currentField.title != '' ? currentField.title : 'عنوان فیلد'}
                                        placeholder={currentField.title}
                                        withAsterisk
                                    />
                                </div>
                            )}
                            {AttributeInputTypeId == 2 && (
                                <div className="w-full grid grid-cols-2">
                                    <InputNumber
                                        label={currentField.title != '' ? currentField.title : 'عنوان فیلد'}
                                        placeholder={currentField.title}
                                        withAsterisk
                                    />
                                </div>
                            )}
                            {AttributeInputTypeId == 3 && (
                                <div className="w-full grid grid-cols-2 gap-8">
                                    <DateInput
                                        label={currentField.title != '' ? currentField.title : 'عنوان فیلد'}
                                    />
                                </div>
                            )}
                            {AttributeInputTypeId == 5 && (
                                <div className='grid grid-cols-2'>
                                    <div className="col-span">
                                        <SelectBox
                                            searchable
                                            label={currentField.title != '' ? currentField.title : 'عنوان فیلد'}
                                            placeholder={currentField.title}
                                            data={currentField.options.map((item) => {
                                                return {
                                                    label: item.title,
                                                    value: item.id
                                                }
                                            })}
                                        />
                                    </div>
                                    {currentField.options && currentField.options.length == 0 && (
                                        <div className="col-span-4 flex justify-center items-center">
                                            <span className='text-gray-400'>هیچ گزینه ای وجود ندارد</span>
                                        </div>
                                    )}
                                </div>
                            )}
                            {AttributeInputTypeId == 6 && (
                                <div className='grid grid-cols-2'>
                                    <div className="col-span">
                                        <MultiSelect
                                            label={currentField.title != '' ? currentField.title : 'عنوان فیلد'}
                                            placeholder={currentField.title}
                                            data={currentField.options.map((item) => {
                                                return {
                                                    label: item.title,
                                                    value: item.id
                                                }
                                            })}
                                        />
                                    </div>
                                    {currentField.options && currentField.options.length == 0 && (
                                        <div className="col-span-4 flex justify-center items-center">
                                            <span className='text-gray-400'>هیچ گزینه ای وجود ندارد</span>
                                        </div>
                                    )}
                                </div>
                            )}
                        </div>
                        <div id="preview" className='w-full mt-8 rounded-b-md px-8 py-5 border-t-4 border-primary'>
                            <div className="mb-8">
                                <Head title='فیلد های این فرم' />
                            </div>
                            {fetched && fields && fields.length == 0 ? (
                                <div className="col-span-4 flex justify-center items-center flex-col">
                                    <Image
                                        src='/icons/customfield-field.svg'
                                        width={450}
                                        height={450}
                                        alt="field not found"
                                    />
                                    <span className='text-md mt-4'>فیلدی پیدا نشد</span>
                                </div>
                            ) : (
                                <Table
                                    columns={[
                                        { id: 'title', label: 'عنوان' },
                                        { id: 'type', label: 'نوع فیلد' },
                                        { id: 'required', label: 'ضروری' },
                                        { id: 'action', label: 'عملیات' },
                                    ]}
                                    data={
                                        fields.map((field) => {
                                            return {
                                                title: field.title,
                                                type: fieldsLabels[field.type] ?? '',
                                                required: field.required ? 'بله' : 'خیر',
                                                action: <div className='flex justify-center items-center'>
                                                    <button
                                                        className='mx-3'
                                                        onClick={() => {
                                                            window.scrollTo({ top: 0, behavior: 'smooth' })
                                                            setEditMode(true)
                                                            setCurrentField(current => {
                                                                return {
                                                                    ...current,
                                                                    title: field.title,
                                                                    options: field.options.map((option) => {
                                                                        return {
                                                                            title: option.title,
                                                                            id: option.id
                                                                        }
                                                                    }),
                                                                }
                                                            })
                                                            setAttributeInputTypeId(field.type)
                                                            form.setValues({
                                                                'title': field.title
                                                            })
                                                            editFieldForm.setValues({
                                                                'title': field.title,
                                                                'Id': field.id,
                                                                'required': field.required,
                                                                'type': field.type,
                                                                'idAttributeType': field.idAttributeType
                                                            })
                                                            document.getElementById('settings').scrollIntoView()
                                                        }
                                                        }
                                                    >
                                                        <FaEdit />
                                                    </button>
                                                    <button onClick={() => { openDeleteModal(field.id) }}>
                                                        <FaTrash />
                                                    </button>
                                                </div>
                                            }
                                        })
                                    }
                                />
                            )}
                        </div>
                    </div>
                </Tabs.Panel>
            </Tabs >
            <Dialog position={{ bottom: 20, left: 20 }} opened={dialogOpened} withCloseButton onClose={() => { setDialogOpened(!dialogOpened) }} size="lg" radius="md">
                <Text size='sm'>
                    شما در حال ویرایش فیلد {currentField.title} هستید
                </Text>
            </Dialog>
            {/* </DashbordContent > */}
        </>
    )
}