import Button from "@/components/button";
import MaadModal from "@/components/modal";
import SegmentedControl from "@/components/segmentedControl";
import Textarea from "@/components/textarea";
import { Select } from "@mantine/core";
import { useForm } from "@mantine/form";
import { showNotification } from "@mantine/notifications";
import { addPeygiri, newCustomerNote } from "services/customer";
import { Textarea as MantineTextarea } from "@mantine/core";
import SelectBox from "@/components/selectBox";
import { useState } from "react";

export default function NewNote({ opened, onClose, id, onSuccess }: {
    opened: boolean,
    onClose: () => void,
    id: string,
    onSuccess?: (response) => void
}) {

    const [loading, setLoading] = useState<boolean>(false)

    const form = useForm({
        initialValues: {
            description: '',
            type: '',
        },

        validate: {
            description: (value) => {
                if (!value) return 'توضیحات را وارد کنید'
            }
        }
    })


    async function submit(values: typeof form.values) {
        try {
            setLoading(true)
            const response = await newCustomerNote({
                description: values.description,
                customer_id: id,
            })

            showNotification({ message: 'یادداشت با موفقیت افزوده شد', title: 'عملیات موفق', color: 'green' })
            onSuccess && onSuccess(response)
            onClose()
            form.reset()
        } catch (err) {
            console.log(err);

            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در ثبت یادداشت',
                color: 'red'
            })
        } finally {
            setLoading(false)
        }
    }

    return (
        <MaadModal
            title="ثبت یادداشت"
            opened={opened}
            onClose={onClose}
            size="70%"
            loading={loading}
        >
            <form
                onSubmit={form.onSubmit((values) => submit(values))}
                className="w-full">
                <div className="grid grid-cols-1 gap-6 mt-4">
                    <div className="col-span-1 grid grid-cols-12">
                        <label htmlFor="description" className="col-span-3">توضیحات :</label>
                        <MantineTextarea
                            className="col-span-9"
                            placeholder="توضیحات"
                            minRows={4}
                            {...form.getInputProps('description')}
                        />
                    </div>
                </div>
                <div className="flex justify-end mt-8">
                    <Button
                        type="submit"
                        classNames={{
                            root: 'bg-[#2141A8] text-white',
                        }}
                    >
                        ثبت یادداشت
                    </Button>
                    <Button
                        onClick={() => {
                            form.reset()
                            onClose()
                        }}
                        className="mr-8"
                        classNames={{
                            root: 'bg-[#2141A8] text-white',
                        }}
                    >
                        انصراف
                    </Button>
                </div>
            </form>
        </MaadModal >
    )
}