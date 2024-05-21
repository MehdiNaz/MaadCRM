'use client'

import DashboardContent from "@/components/dashboardContent";
import TableBox from "@/components/tables/tableBox";
import { Tabs } from "@mantine/core";

export default function TeammatesFeedback() {
    return (
        <DashboardContent breadcrumbTitle="بازخورد همکاران" active_menu="teammates">
            <Tabs defaultValue="gallery">
                <Tabs.List>
                    <Tabs.Tab value="gallery">بازخورد همکاران</Tabs.Tab>
                    <Tabs.Tab value="messages">کالا / خدمات</Tabs.Tab>
                    <Tabs.Tab value="settings">فرایند خرید</Tabs.Tab>
                </Tabs.List>

                <Tabs.Panel className="bg-white" value="gallery" pt="xs">
                    <TableBox
                        columns={[
                            { id: 'title', label: 'عنوان' },
                            { id: 'type', label: 'نوع فیلد' },
                        ]}
                        data={[
                            { title: 'مقطع تحصیلی', type: 'متنی' },
                            { title: 'مقطع تحصیلی', type: 'متنی' },
                            { title: 'مقطع تحصیلی', type: 'متنی' },
                        ]}
                    />
                </Tabs.Panel>

                <Tabs.Panel className="bg-white" value="messages" pt="xs">
                    Messages tab content
                </Tabs.Panel>

                <Tabs.Panel className="bg-white" value="settings" pt="xs">
                    Settings tab content
                </Tabs.Panel>
            </Tabs>
        </DashboardContent>
    )
}