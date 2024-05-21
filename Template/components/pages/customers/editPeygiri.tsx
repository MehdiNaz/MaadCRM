'use client'
import MaadButton from "@/components/button";
import MaadModal from "@/components/modal";
import SegmentedControl from "@/components/segmentedControl";
import SelectBox from "@/components/selectBox";
import Textarea from "@/components/textarea";
import TextInput from "@/components/textInput";
import { Box, Center, Modal, MultiSelect, Select } from "@mantine/core";
import { useForm } from "@mantine/form";
import { showNotification } from "@mantine/notifications";
import { useState } from "react";
import { IoMan, IoWomanSharp } from "react-icons/io5";
import { editPeygiri } from "services/customer";

export default function EditPeygiri({ opened, onClose, id, description, callBack }: {
    opened: boolean,
    onClose: () => void,
    id: string,
    description: string,
    callBack: (newContent: string) => void
}) {


    const form = useForm({
        initialValues: {
            description: description,
            type: '',
        },

        validate: {
            description: (value) => {
                if (!value) return 'توضیحات را وارد کنید'
            }
        }
    })

    async function submit(values: typeof form.values) {
        const response = await editPeygiri({
            Description: values.description,
            Id: id,
        })

        if (response) {
            showNotification({ message: 'پیگیری با موفقیت ویرایش شد', title: 'عملیات موفق', color: 'green' })
            onClose()
            callBack(values.description)
            form.setFieldValue('description', values.description)
        }
    }

    return (
        <MaadModal
            title="ویرایش پیگیری"
            opened={opened}
            onClose={onClose}
            size="70%"
        >
            <form
                onSubmit={form.onSubmit((values) => submit(values))}
                className="w-full">
                {/* <div className="w-[50%] mx-auto">
                    <SegmentedControl
                        onChange={(value: string) => console.log(value)}
                    />
                </div> */}
                <div className="grid grid-cols-12 gap-6 mt-4">
                    <div className="grid grid-cols-12 col-span-6 items-center">
                        <span className="col-span-3">نوع پیگیری :</span>
                        <Select
                            className="col-span-9"
                            placeholder="انتخاب کنید"
                            data={[
                                { label: 'عادی', value: '1' },
                                { label: 'معمولی', value: '2' },
                                { label: 'زیاد', value: '3' },
                            ]}
                        />
                    </div>
                </div>
                <div className="col-span-12 grid grid-cols-1">
                    <div className="mt-4">
                        <Textarea
                            minRows={5}
                            label="توضیحات :"
                            {...form.getInputProps('description')}
                        />
                    </div>

                    <div className="flex justify-end mt-8">
                        <MaadButton
                            type="submit"
                            classNames={{
                                root: 'bg-[#2141A8] text-white',
                            }}
                        >
                            ویرایش پیگیری
                        </MaadButton>
                        <MaadButton
                            onClick={() => onClose()}
                            className="mr-8"
                            classNames={{
                                root: 'bg-[#2141A8] text-white',
                            }}
                        >
                            انصراف
                        </MaadButton>
                    </div>
                </div>
            </form>
        </MaadModal >
    )
}