'use client'
import { Slider } from "@mantine/core"
import DashboardContent from "@/components/dashboardContent"
import SettingCard from "@/components/settings/card"
import { HiOutlineKey } from "react-icons/hi"
import { RiMessage2Line, RiSurveyLine, RiPencilRulerLine } from "react-icons/ri"
import { IoNotificationsOutline } from "react-icons/io5"
import { BsBoxSeam } from "react-icons/bs"
import { TbReport, TbFileInvoice, TbMessage2 } from 'react-icons/tb'
import { VscFeedback } from "react-icons/vsc"
import { FiRefreshCcw } from "react-icons/fi"
import { MdOutlineContacts } from "react-icons/md"
import { AiOutlineMail } from "react-icons/ai"

export default function Settings() {
    return (
        <>
            {/* <DashboardContent breadcrumbTitle='تنظیمات' active_menu='settings'> */}
            {/* <div className="w-full mb-10 flex items-center justify-center">
                    <span className="ml-4">تنظیمات انجام شده: </span>
                    <Slider className="w-96" value={60} labelAlwaysOn />
                </div> */}
            <div className="grid grid-cols-5 gap-4">
                {/* <SettingCard link='/clients' title='تنظیمات مشتریان' /> */}
                {/* <SettingCard link='/clients' title='تنظیمات همکاران' /> */}
                {/* <SettingCard link='/clients' disabled title='تنظیمات دسترسی' icon={<HiOutlineKey />} /> */}
                <SettingCard link='/messages/systemic' title='تنظیمات پیام های سیستمی' icon={<RiMessage2Line />} />
                {/* <SettingCard link='/clients' disabled title='تنظیمات اعلانات' icon={<IoNotificationsOutline />} /> */}
                {/* <SettingCard link='/products/' title='ثبت کالا یا خدمات' icon={<BsBoxSeam />} /> */}
                {/* <SettingCard link='/clients' disabled title='تنظیمات فرم نظرسنجی' icon={<RiSurveyLine />} /> */}
                <SettingCard link='/settings/feedback' title='تنظیمات بازخورد' icon={<VscFeedback />} />
                <SettingCard link='/settings/peygiri' title='تنظیمات پیگیری' icon={<VscFeedback />} />
                <SettingCard link='/customfields' title='فیلد های سفارشی' icon={<RiPencilRulerLine />} />
                {/* <SettingCard link='/clients' disabled title='تنظیمات فاکتور' icon={<TbFileInvoice />} /> */}
            </div>
            {/* </DashboardContent> */}
        </>
    )
}