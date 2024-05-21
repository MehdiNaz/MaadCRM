'use client'
import Button from "@/components/button";
import { handleComma } from "@/utils/helper";
import moment from "moment";
import { useRouter } from "next/navigation";
import { useEffect, useState } from "react";

export default function AghsatList({ data, customer_id }) {


    const [payments, setPeymants] = useState([])

    useEffect(() => {
        setPeymants(data)
    }, [data])

    const router = useRouter()

    return (
        <div className="w-full">
            <div className="w-full grid grid-cols-2 border-b my-2 text-center pb-3">
                <div className="col-span-1">
                    مبلغ (تومان)
                </div>
                <div className="col-span-1">
                    سر رسید پرداخت
                </div>
            </div>
            {payments && payments.length > 0 && payments.map((item, index) => {
                let date = new Date(item.payment_date).toLocaleDateString('fa-IR')
                date = date.replace(/\//g, '-');
                return (
                    <div key={index} className="w-full grid grid-cols-2 text-center mt-4 even:bg-gray-50 rounded-md p-2 mb-2">
                        <div className="col-span-1">
                            <p className="relative">
                                <span className="absolute right-3 border rounded-full flex justify-center items-center w-8 h-8">
                                    {index + 1}
                                </span>
                                <span>
                                    {handleComma(item.payment_price)}
                                </span>
                            </p>
                        </div>
                        <div className="col-span-1">
                            {
                                date
                            }
                        </div>
                    </div>
                )
            })
            }
            <div className="mt-8">
                <Button
                    onClick={() => {
                        router.push(`/customers/profile/${customer_id}`)
                    }}
                >
                    ثبت نهایی فاکتور
                </Button>
            </div>
        </div>
    )
}