import { ChangeUserPermisstion } from "@/services/teammates";
import { getLocalStorage } from "@/utils/helper";
import { Group, LoadingOverlay, Switch } from "@mantine/core";
import { showNotification } from "@mantine/notifications";
import { useEffect, useState } from "react";
import Button from "../button";
import Modal from "../modal";

export default function AccessList({ opened, onClose, id, permission = 1 }) {

    const [open, setOpen] = useState(opened)

    useEffect(() => {
        setOpen(opened)
    }, [opened])

    function close() {
        if (onClose) onClose()
        setOpen(false)
    }


    const [value, setValue] = useState([permission.toString()])
    const [loading, setLoading] = useState(false)


    useEffect(() => {
        setValue([permission.toString()])
    }, [permission])

    async function save(value: string[]) {
        if (value.length > 1) {
            try {
                setLoading(true)
                const last = value[value.length - 1]
                setValue([last])
                const response = await ChangeUserPermisstion({
                    id: id,
                    Permission: parseInt(last)
                })
                if (response.valid) {
                    showNotification({
                        title: 'عملیات موفق',
                        message: 'دسترسی ها با موفقیت ثبت شد',
                        color: 'green',
                    })
                }
            } catch {
                showNotification({
                    title: 'عملیات ناموفق',
                    message: 'در انتخاب دسترسی ها خطایی رخ داده است',
                    color: 'red',
                })
            } finally {
                setLoading(false)
            }
        }

    }

    return (
        <Modal centered opened={open} onClose={() => close()} title="تنظیمات دسترسی" size='lg'>
            <LoadingOverlay transitionDuration={200} visible={loading} />
            <div className="w-full">
                <Switch.Group
                    value={value}
                    onChange={(value) => {
                        save(value)
                    }}
                >
                    <div className="w-full mb-8">
                        <Switch color={'green'} value="1" label="ویرایش و مشاهده اطلاعات مشتریان مربوط به خود همکار" />
                    </div>
                    <div className="w-full mb-8">
                        <Switch color={'green'} value="2" label="ویرایش و مشاهده کل مشتریان سازمان" />
                    </div>
                    <div className="w-full">
                        <Switch color={'green'} value="3" label="ویرایش و مشاهده کل مشتریان دپارتمانی که عضو هست" />
                    </div>
                </Switch.Group>
                <div className="flex justify-end mt-8">
                    <Button
                        onClick={() => close()}
                    >
                        انصراف
                    </Button>
                </div>
            </div>
        </Modal>
    )
}