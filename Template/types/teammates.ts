export type TeammateProfileCardTypes = {
    title: string;
    children: any;
    onClick?: () => void;
}

export type TeammateProfileClientType = {
    avatar?: string;
    name: string;
    status: string;
}

export type TeammatesProfileSalesType = {
    logo?: string;
    title: string;
    teacher: string;
}

export type DepartmentType = {
    title: string
    id: string
    status?: number
}

export type TeammateType = {
    id: string
    name: string
    family?: string
    phoneNo: string
    groupTitle: string
    address: string
    email: string
    hidden?: boolean
    permission?: number
    first_name?: string
    last_name?: string
    phone?: string
    department?: DepartmentType
}

export type TeammateCardProps = {
    name: string
    category: string
    location?: string
    email: string
    address: string
    id?: string
    phone?: string
    hidden?: boolean
}