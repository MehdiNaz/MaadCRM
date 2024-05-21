export type Dashboard = {
    breadcrumbTitle?: string;
    active_menu?: string;
    children: any;
    actions?: any;
    divider?: boolean
    header?: any
    hasAccess?: boolean
    token?: any
}

export type SidebarType = {
    link: string,
    title: string,
    icon: any,
    id: string,
    disabled?: boolean
    hasAccess?: boolean
    children?: any
}