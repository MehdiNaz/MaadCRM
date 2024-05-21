'use client'

import Button from "@/components/button"
import DashboardContent from "@/components/dashboardContent"
import DateInput from "@/components/DateInput"
import InputNumber from "@/components/numberInput"
import PageBox from "@/components/pageBox"
import ProductsSelect from "@/components/products/productsSelect"
import SelectBox from "@/components/selectBox"
import AghsatList from "@/components/tables/foroush/aghsatList"
import FactorProducts from "@/components/tables/foroush/products"
import Textarea from "@/components/textarea"
import TextInput from "@/components/textInput"
import { ProductType } from "@/types/product"
import { Group, Loader, LoadingOverlay, Radio } from "@mantine/core"
import { useForm } from "@mantine/form"
import { showNotification } from "@mantine/notifications"
import moment from "moment"
import { useRouter } from "next/navigation"
import { useEffect, useState } from "react"
import { useSelector } from "react-redux"
import { newFactor, savePaymenst } from "services/foroush"
import { insertOrder } from "services/order"
import { getProductByID } from "services/products"
import { RootState } from "store/store"
import { convertPerisnaNumbersToEnglishNumbers, convertToUTC, disableInputsandButtons, handleComma, removeComma } from "utils/helper"

export default function Foroush({ id, data }) {

    const [visible, setVisible] = useState<boolean>(false)
    const [step, setStep] = useState<number>(1)
    const [showAghsat, setShowAghsat] = useState<boolean>(false)
    const [orders, setOrders] = useState([])
    const [product, setProduct] = useState<ProductType>(null)
    const [payments, setPeymants] = useState([])
    const [totalPrice, setTotalPrice] = useState(0)


    const router = useRouter()

    const foroush = useSelector((state: RootState) => state.foroush)


    const currentDate = moment().format('YYYY-MM-DD')
    const step1Form = useForm({
        initialValues: {
            id: '',
            DatePay: currentDate,
            PaymentMethod: '1'
        },
        validate: {
            // DatePay: (value) => {
            //     if (!value) return 'تاریخ فاکتور را وارد کنید'
            // },
        }

    })

    const step2Form = useForm({
        initialValues: {
            productId: '',
            count: 1,
            price: '0',
            discount: '0'
        },

        validate: {
            productId: (value) => {
                if (!value) return 'کالا را انتخاب کنید'
            },
            count: (value) => {
                if (!value) return 'تعداد را وارد کنید'
            },
            price: (value) => {
                if (!value) return 'قیمت را وارد کنید'
            }
        }
    })


    const step3Form = useForm({
        initialValues: {
            idFactor: step1Form.values.id,
            amount: totalPrice,
            discount: '0',
            amountTotal: 0,
            paymentMethod: step1Form.values.PaymentMethod,
            tedadeAghsat: 0,
            bazeyeZamany: 30,
            darSadeSoud: 0,
            pishPardakht: '',
            mablagheKoleSoud: '0',
            shoroAghsat: '',
            datePay: step1Form.values.DatePay
        },

        validate: {
        }
    })

    async function submitStep1(values: typeof step1Form.values) {
        try {
            setVisible(true)
            const response = await newFactor({
                sale_date: values.DatePay,
                payment_method: parseInt(values.PaymentMethod),
                customer_id: id,
            })

            step1Form.setValues({ 'id': response.sale.id })
            setStep(2)
            showNotification({
                title: 'عملیات موفق',
                message: 'فاکتور با موفقیت ایجاد شد',
                color: 'green'
            })
        } catch (e) {
            showNotification({
                title: 'خطا در ایجاد فاکتور',
                message: e.message,
                color: 'red'
            })
        } finally {
            setVisible(false)
        }
    }

    async function submitStep2(values: typeof step2Form.values) {
        try {
            setVisible(true)
            let discount = values.discount ? parseInt(removeComma(values.discount)) : 0
            let priceTotal = parseInt(removeComma(values.price)) * values.count - discount
            const response = await insertOrder({
                FactorId: step1Form.values.id,
                product_id: values.productId,
                quantity: values.count,
                price: parseInt(removeComma(values.price)),
            })
            setOrders(orders => [...orders, {
                id: response.items.id,
                name: product.title,
                count: values.count,
                price: parseInt(removeComma(values.price)),
                discount: values.discount != '' ? parseInt(removeComma(values.discount)) : 0,
                total: priceTotal
            }])
            showNotification({
                title: 'عملیات موفق',
                message: 'سفارش با موفقیت ثبت شد',
                color: 'green'
            })
            step2Form.reset()
        } catch (e) {
            showNotification({
                title: 'خطا در ایجاد فاکتور',
                message: e.message,
                color: 'red'
            })
        } finally {
            setVisible(false)
        }
    }

    async function submitStep3(values: typeof step3Form.values) {
        try {

            let totalPrice = 0
            orders.map((order) => {
                totalPrice = (totalPrice + order.price * order.count - order.discount)
            })

            const discount = values.discount ? parseInt(removeComma(values.discount)) : 0
            const mablagheKoleSoud = values.mablagheKoleSoud ? parseInt(removeComma(values.mablagheKoleSoud)) : 0
            const amountTotal = (totalPrice - discount + mablagheKoleSoud)

            const response = await savePaymenst({
                factor_id: step1Form.values.id,
                pish_pardakht: parseInt(removeComma(values.pishPardakht)),
                takhfif_kol: discount,
                tedad_aghsat: step1Form.values.PaymentMethod == '2' ? values.tedadeAghsat : null,
                darsad_soud: step1Form.values.PaymentMethod == '2' ? values.darSadeSoud : null,
                payment_start_date: step1Form.values.PaymentMethod == '2' ? values.shoroAghsat : null,
                baze_pardakht: step1Form.values.PaymentMethod == '2' ? values.bazeyeZamany : null,
                kole_soud: step1Form.values.PaymentMethod == '2' ? mablagheKoleSoud : null
            })

            if (response.success && values.tedadeAghsat > 0) {
                setShowAghsat(true)
                setPeymants(response.factor.aghsat)
            } else {
                disableInputsandButtons()
                showNotification({
                    title: 'عملیات موفق',
                    message: 'فاکتور با موفقیت ثبت شد',
                    color: 'green'
                })
                router.push('/customers/profile/' + id)
            }
        } catch {
            showNotification({
                title: 'عملیات ناموفق',
                message: 'خطا در ثبت فاکتور',
                color: 'red'
            })
        }
    }

    useEffect(() => {
        if (step2Form.values.productId === '') return
        const price = handleComma(product?.price)
        step2Form.setValues({
            'price': price
        })
    }, [product])


    const [loading, setLoading] = useState<boolean>(false)

    const { total } = useSelector((state: RootState) => state.foroush)


    const name = data?.name ?? ''

    return (
        // <DashboardContent breadcrumbTitle={'ثبت فروش برای : ' + name} active_menu="customers" divider={false} >
        <div className="w-full">
            {step === 1 && (
                <PageBox title="فاکتور">
                    <form
                        onSubmit={step1Form.onSubmit(submitStep1)}
                        className="relative">
                        <LoadingOverlay visible={visible} />
                        <div className="w-full grid grid-cols-1">
                            {/* <div className="col-span-1">
                                    <div className="col-span-1 grid grid-cols-12">
                                        <div className="col-span-3 text-sm items-center flex">تاریخ فاکتور :</div>
                                        <div className="col-span-9">
                                            <Datepicker
                                                footer={(moment, setValue) => {
                                                    return (
                                                        <>
                                                            <div
                                                                onClick={() => {
                                                                    if (setValue) setValue(moment());
                                                                }}
                                                            >
                                                                امروز
                                                            </div>
                                                        </>
                                                    );
                                                }}
                                                disabled={false}
                                                format={'YYYY-MM-DD'}
                                                input={<input placeholder="تاریخ فاکتور" />}
                                                lang={'fa'}
                                                loading={false}
                                                modeTheme={'light'}
                                                theme='blue'
                                                adjustPosition={'auto'}
                                                onChange={(val: any) => {
                                                    const value = convertToUTC(val._d)
                                                    step1Form.setValues({ 'DatePay': value })
                                                }}
                                            />
                                            {step1Form.errors.DatePay && (
                                                <span className="text-red-500 text-xs mt-1">
                                                    {step1Form.errors.DatePay}
                                                </span>
                                            )}
                                        </div>
                                    </div>
                                </div> */}
                            <div className="col-span-1 flex justify-center">
                                <Radio.Group
                                    {...step1Form.getInputProps('PaymentMethod')}
                                >
                                    <Group
                                        mt="xs">
                                        <Radio value="1" label="تسویه نقدی" />
                                        <Radio value="2" label="تسویه غیرنقدی" />
                                    </Group>
                                </Radio.Group>
                            </div>
                        </div>
                        <div className="w-full flex justify-end mt-8">
                            <Button type="submit">
                                ساخت فاکتور
                            </Button>
                        </div>
                    </form>
                </PageBox>
            )}
            {step === 2 && (
                <div className="w-full mt-8">
                    <PageBox title="ثبت فروش">
                        <LoadingOverlay visible={visible} />
                        <form
                            onSubmit={step2Form.onSubmit(submitStep2)}
                            className="w-full grid grid-cols-4 gap-8">
                            <div className="col-span-1">
                                <ProductsSelect
                                    clearable
                                    leftI
                                    label="کالا / خدمات :"
                                    {...step2Form.getInputProps('productId')}
                                    icon={loading ? <Loader size={13} /> : ''}
                                    disabled={loading}
                                    onChange={async (id) => {
                                        try {
                                            setLoading(true)
                                            if (typeof id === 'string') {
                                                const response = await getProductByID(id)
                                                setProduct(response.product)
                                                step2Form.setValues({
                                                    'productId': id
                                                })
                                            } else {
                                                step2Form.setValues({
                                                    'productId': ''
                                                })
                                            }
                                        } catch (err) {
                                            showNotification({
                                                title: 'خطا در دریافت اطلاعات کالا',
                                                message: err.message,
                                                color: 'red'
                                            })
                                        } finally {
                                            setLoading(false)
                                        }
                                    }}
                                />
                            </div>
                            <div className="col-span-1">
                                <InputNumber
                                    {...step2Form.getInputProps('count')}
                                    label="تعداد :"
                                    min={1}
                                />
                            </div>
                            <div className="col-span-1">
                                <TextInput
                                    placeholder="قیمت به تومان"
                                    {...step2Form.getInputProps('price')}
                                    onChange={(e) => {
                                        const value = handleComma(e.target.value)
                                        step2Form.setValues({ 'price': value })
                                    }}
                                    label="قیمت :"
                                />
                            </div>
                            {/* <div className="col-span-1">
                                    <TextInput
                                        placeholder="تخفیف به تومان"
                                        {...step2Form.getInputProps('discount')}
                                        onChange={(e) => {
                                            const value = handleComma(e.target.value)
                                            step2Form.setValues({ 'discount': value })
                                        }}
                                        label="تخفیف :"
                                    />
                                </div> */}
                            <div className="col-span-4 flex justify-end">
                                <Button type="submit">
                                    افزودن به فاکتور
                                </Button>
                            </div>
                        </form>
                        <form
                            onSubmit={(e) => {
                                e.preventDefault()
                                step3Form.setValues({ 'pishPardakht': handleComma(total) })
                                setStep(3)
                                showNotification({
                                    title: 'عملیات موفق',
                                    message: 'محصولات با موفقیت به فاکتور اضافه شدند',
                                    color: 'green'
                                })
                            }}
                            className="w-full mt-8 border rounded-md p-3">
                            <FactorProducts
                                onRemove={(id) => {
                                    const newOrders = orders.filter((order) => order.id !== id)
                                    setOrders(newOrders)
                                }
                                }
                                data={orders} />
                            <div className="flex justify-end mt-8">
                                <Button type="submit">
                                    تایید
                                </Button>
                            </div>
                        </form>
                    </PageBox>
                </div>
            )}
            {step === 3 && (
                <div className="w-full mt-8">
                    <PageBox title='جزئیات فروش'>
                        <form
                            onSubmit={step3Form.onSubmit(submitStep3)}
                        >
                            <div className="grid grid-cols-3 gap-8">
                                <div className="col-span-1">
                                    <TextInput
                                        placeholder={step1Form.values.PaymentMethod == '2' ? 'پیش پرداخت' : 'مبلغ پرداختی'}
                                        {...step3Form.getInputProps('pishPardakht')}
                                        onChange={(e) => {
                                            const value = handleComma(e.target.value)
                                            step3Form.setValues({ 'pishPardakht': value })
                                        }}
                                        label="مبلغ پرداختی :"
                                    />
                                </div>
                                <div className="col-span-1">
                                    <TextInput
                                        placeholder="تخفیف کل"
                                        {...step3Form.getInputProps('discount')}
                                        onChange={(e) => {
                                            const value = handleComma(e.target.value)
                                            step3Form.setValues({ 'discount': value })
                                        }}
                                        label="تخفیف کل :"
                                    />
                                </div>
                                {step1Form.values.PaymentMethod === '2' && (
                                    <>
                                        <div className="col-span-1">
                                            <InputNumber
                                                label="تعداد اقساط"
                                                placeholder="تعداد اقساط"
                                                min={1}
                                                max={100}
                                                {...step3Form.getInputProps('tedadeAghsat')}
                                            />
                                        </div>
                                        <div className="col-span-1">
                                            <InputNumber
                                                placeholder="بازه زمانی پرداخت (به ماه)"
                                                label="بازه زمانی پرداخت :"
                                                {...step3Form.getInputProps('bazeyeZamany')}
                                            />
                                        </div>
                                        <div className="col-span-1">
                                            <InputNumber
                                                label="درصد سود"
                                                placeholder="درصد سود"
                                                min={1}
                                                max={100}
                                                {...step3Form.getInputProps('darSadeSoud')}
                                            />
                                        </div>
                                        <div className="col-span-1 hidden">
                                            <DateInput
                                                label="تاریخ شروع پرداخت :"
                                            />
                                        </div>
                                        <div className="col-span-1 hidden">
                                            <TextInput
                                                label="مبلغ کل سود"
                                                placeholder="مبلغ کل سود"
                                                {...step3Form.getInputProps('mablagheKoleSoud')}
                                                onChange={(e) => {
                                                    const value = handleComma(e.target.value)
                                                    step3Form.setValues({ 'mablagheKoleSoud': value })
                                                }}
                                            />
                                        </div>
                                    </>
                                )}
                            </div>
                            <div className="flex mt-8 justify-end">
                                <Button type="submit">
                                    محاسبه
                                </Button>
                            </div>
                        </form>
                    </PageBox>
                </div>
            )}
            {showAghsat && (
                <div className="w-full mt-8">
                    <PageBox title="لیست پرداخت ها">
                        <form>
                            <AghsatList data={payments} customer_id={id} />
                            {/* <div className="w-full justify-end mt-8 flex">
                                    <Button type="submit">
                                        ثبت اقساط
                                    </Button>
                                </div> */}
                        </form>
                    </PageBox>
                </div>
            )}
            {/* <div className="w-full mt-8">
                    <PageBox title="مستندات">
                        <div className="grid grid-cols-2 gap-8">
                            <div className="col-span-1">
                                <Textarea
                                    placeholder="توضیحات"
                                />
                            </div>
                            <div className="col-span-1">
                            </div>
                        </div>
                        <div className="w-full flex justify-end mt-8">
                            <Button type="submit">
                                ثبت فروش
                            </Button>
                        </div>
                    </PageBox>
                </div> */}
        </div>
        // </DashboardContent >
    )
}
