'use client'
import { Select, Switch, Table, Tabs, Text, Timeline } from "@mantine/core";
import { IconGitBranch, IconGitCommit, IconGitPullRequest, IconMessageCircle, IconMessageDots, IconPhoto, IconSettings } from "@tabler/icons";
import { BiHistory } from "react-icons/bi";
import { GrNote, GrNotification } from "react-icons/gr";
import { SlUserFollowing } from "react-icons/sl";
import DashboardContent from "@/components/dashboardContent";
import { FaSadCry, FaUserEdit } from 'react-icons/fa'
import Search from "@/components/search";
import Note from "@/components/pages/customers/note";
import Reminder from "@/components/customers/peygiri";
import TeammatesProfileCard from '@/components/teammates/profile/crad'
import TeammatesProfileClients from '@/components/teammates/profile/clients'

export default function TeammateProfile() {
    return (
        <DashboardContent active_menu="teammates" breadcrumbTitle="پروفایل همکار">
            <div className="flex w-full">
                <div className="w-1/4 bg-white rounded-lg">
                    <div className="flex w-full flex-col px-2">
                        <div className="flex justify-center pt-4 flex-col items-center">
                            <FaUserEdit className="text-[3em]" />
                            <span className="mt-3">محمد هادی طاهری</span>
                            <span className="mt-2 text-sm">بازاریابی</span>
                        </div>
                        <div className="flex pb-3 mt-8 border-b">
                            <div className="w-1/2 border-l flex justify-center items-center flex-col">
                                <span>در حال پیگیری</span>
                                <span className="mt-3">7</span>
                            </div>
                            <div className="w-1/2 flex justify-center items-center flex-col">
                                <span>مشتریان</span>
                                <span className="mt-3">45</span>
                            </div>
                        </div>
                        <div className="flex justify-center py-3 border-b">
                            <Search />
                        </div>
                    </div>
                </div>
                <div className="w-3/4 mr-6 bg-white rounded-lg p-1">
                    <Tabs defaultValue="activity_history" className="my-3">
                        <Tabs.List className="mb-6">
                            <Tabs.Tab value="activity_history" icon={<BiHistory size={14} />}>تاریخچه فعالیت</Tabs.Tab>
                            <Tabs.Tab value="notes" icon={<GrNote size={14} />}>یادداشت ها</Tabs.Tab>
                            <Tabs.Tab value="follow" icon={<SlUserFollowing size={14} />}>پیگیری ها</Tabs.Tab>
                            <Tabs.Tab value="reminders" icon={<GrNotification size={14} />}>یادآوری</Tabs.Tab>
                            <Tabs.Tab value="move_data" icon={<FaSadCry size={14} />}>انتقال اطلاعات</Tabs.Tab>
                            <Tabs.Tab value="access" icon={<FaSadCry size={14} />}>دسترسی</Tabs.Tab>
                            <Tabs.Tab value="information" icon={<FaSadCry size={14} />}>اطللاعات کاربری</Tabs.Tab>
                        </Tabs.List>
                        <Tabs.Panel value="activity_history" className="px-3" pt="xs">
                            <div className="grid grid-cols-2 gap-4">
                                <div className="w-full">
                                    <TeammatesProfileCard title="مشتریان">
                                        <TeammatesProfileClients name="محمد هادی طاهری" status="peygiri" />
                                        <TeammatesProfileClients name="محمد هادی طاهری" status="vafadar" />
                                        <TeammatesProfileClients name="محمد هادی طاهری" status="belghove" />
                                        <TeammatesProfileClients name="محمد هادی طاهری" status="narazi" />
                                        <TeammatesProfileClients name="محمد هادی طاهری" status="razi" />
                                    </TeammatesProfileCard>
                                    <div className="mt-4">
                                        <TeammatesProfileCard title="فروش">
                                            <TeammatesProfileClients name="محمد هادی طاهری" status="peygiri" />
                                            <TeammatesProfileClients name="محمد هادی طاهری" status="vafadar" />
                                            <TeammatesProfileClients name="محمد هادی طاهری" status="belghove" />
                                            <TeammatesProfileClients name="محمد هادی طاهری" status="narazi" />
                                            <TeammatesProfileClients name="محمد هادی طاهری" status="razi" />
                                        </TeammatesProfileCard>
                                    </div>
                                </div>
                                <TeammatesProfileCard title="تاریخچه فعالیت">
                                    <Timeline active={1} bulletSize={24} lineWidth={2}>
                                        <Timeline.Item bullet={<FaSadCry size={12} />} title="ثبت مشتری">
                                            <Text color="dimmed" size="sm">شما یک مشتری جدید ایجاد کردید</Text>
                                            <Text size="xs" mt={4}>2 ساعت پیش</Text>
                                        </Timeline.Item>
                                        <Timeline.Item bullet={<FaSadCry size={12} />} title="پیگیری مشتری">
                                            <Text color="dimmed" size="sm">شما یک مشتری جدید ایجاد کردید</Text>
                                            <Text size="xs" mt={4}>4 ساعت پیش</Text>
                                        </Timeline.Item>
                                        <Timeline.Item bullet={<FaSadCry size={12} />} title="ثبت مشتری">
                                            <Text color="dimmed" size="sm">شما یک مشتری جدید ایجاد کردید</Text>
                                            <Text size="xs" mt={4}>2 ساعت پیش</Text>
                                        </Timeline.Item>
                                        <Timeline.Item bullet={<FaSadCry size={12} />} title="ثبت مشتری">
                                            <Text color="dimmed" size="sm">شما یک مشتری جدید ایجاد کردید</Text>
                                            <Text size="xs" mt={4}>2 ساعت پیش</Text>
                                        </Timeline.Item>
                                    </Timeline>
                                </TeammatesProfileCard>
                            </div>
                        </Tabs.Panel>
                        <Tabs.Panel value="notes" className="px-3" pt="xs">
                            <Timeline active={1} bulletSize={24} lineWidth={2}>
                                <Timeline.Item bullet={<FaSadCry size={12} />} title="ثبت مشتری">
                                    {/* <Note id="a" content='a' /> */}
                                </Timeline.Item>
                                <Timeline.Item bullet={<FaSadCry size={12} />} title="پیگیری مشتری">
                                    {/* <Note id="a" content='a' /> */}
                                </Timeline.Item>
                                <Timeline.Item bullet={<FaSadCry size={12} />} title="ثبت مشتری">
                                    {/* <Note id="a" content='a' /> */}
                                </Timeline.Item>
                                <Timeline.Item bullet={<FaSadCry size={12} />} title="ثبت مشتری">
                                    {/* <Note id="a" content='a' /> */}
                                </Timeline.Item>
                            </Timeline>
                        </Tabs.Panel>
                        <Tabs.Panel value="follow" className="px-3" pt="xs">
                            C
                        </Tabs.Panel>
                        <Tabs.Panel value="reminders" className="px-3" pt="xs">
                            <div className="flex w-full items-center justify-center mb-10 border-b pb-3">
                                <span className="ml-8">انتخاب مشتری:</span>
                                <Select
                                    multiple
                                    className="w-60"
                                    placeholder="انتخاب مشتری"
                                    searchable
                                    data={[
                                        { value: 'hadi', label: 'استاد بزرگوار شریف هادی' },
                                        { value: 'agha-ramtin', label: 'آقا رامتین' },
                                        { value: 'arash', label: 'آرش' },
                                        { value: 'mahdi', label: 'مهدی' },
                                    ]}
                                />
                            </div>
                            <div className="grid grid-cols-3 gap-4">
                                <Reminder />
                                <Reminder />
                                <Reminder />
                                <Reminder />
                            </div>
                        </Tabs.Panel>
                        <Tabs.Panel value="move_data" pt="xs">
                            E
                        </Tabs.Panel>
                        <Tabs.Panel value="access" className="px-3" pt="xs">
                            <Table withBorder>
                                <thead>
                                    <tr>
                                        <th className="w-[85%]">دسترسی</th>
                                        <th className="w-[15%]">وضعیت</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>ویرایش اطلاعات مشتریان</td>
                                        <td><Switch color="teal" /></td>
                                    </tr>
                                    <tr>
                                        <td>ویرایش اطلاعات مشتریان</td>
                                        <td><Switch color="teal" /></td>
                                    </tr>
                                    <tr>
                                        <td>ویرایش اطلاعات مشتریان</td>
                                        <td><Switch color="teal" /></td>
                                    </tr>
                                    <tr>
                                        <td>ویرایش اطلاعات مشتریان</td>
                                        <td><Switch color="teal" /></td>
                                    </tr>
                                    <tr>
                                        <td>ویرایش اطلاعات مشتریان</td>
                                        <td><Switch color="teal" /></td>
                                    </tr>
                                </tbody>
                            </Table>
                        </Tabs.Panel>
                        <Tabs.Panel value="information" pt="xs">
                            G
                        </Tabs.Panel>
                    </Tabs>
                </div>
            </div>
        </DashboardContent>
    )
}