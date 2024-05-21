import { newCategory } from "@/services/products";
import { LoadingOverlay } from "@mantine/core";
import { useForm } from "@mantine/form";
import { showNotification } from "@mantine/notifications";
import { useEffect, useState } from "react";
import Button from "../button";
import Modal from "../modal";
import TextInput from "../textInput";

export default function NewProductCategory({ opened, onClose, onSuccess }: { opened: boolean, onClose: () => void, onSuccess?: Function }) {

    const [open, setOpen] = useState<boolean>(opened)
    const [loading, setLoading] = useState<boolean>(false)

    useEffect(() => {
        setOpen(opened)
    }, [opened])

    const form = useForm({
        initialValues: {
            title: ''
        },

        validate: (values) => {
            return {
                title: !values.title ? 'نام دسته بندی را وارد کنید' : null
            }
        }
    })
    async function handleNewCategory(values: typeof form.values) {
        try {
            setLoading(true)
            const response = await newCategory(values.title)
            if (response.success) {
                if (onClose) onClose()
                setOpen(false)
                showNotification({
                    title: 'عملیات موفق',
                    message: 'دسته بندی جدید با موفقیت افزوده شد',
                    color: 'green',
                })
                form.reset()
                if (onSuccess) onSuccess({
                    id: response.category.id,
                    title: values.title
                })
            }
        } catch (err) {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'دسته بندی جدید افزوده نشد',
                color: 'red',
            })
        } finally {
            setLoading(false)
        }
    }

    return (
        <Modal
            title="افزودن دسته بندی"
            opened={open}
            onClose={() => {
                setOpen(false)
                if (onClose) onClose()
            }}
            size="lg">
            <form
                onSubmit={form.onSubmit(handleNewCategory)}
                className="w-full relative">
                <LoadingOverlay visible={loading} />
                <TextInput
                    label="نام دسته بندی :"
                    placeholder="نام دسته بندی را وارد کنید"
                    {...form.getInputProps('title')}
                />
                <div className="flex w-full justify-end mt-4">
                    <Button type="submit">
                        افزودن
                    </Button>
                </div>
            </form>
        </Modal>
    )
}