export enum CustomerState {
    Belghoveh = 'بالقوه',
    Belfel = 'بالفعل',
    Razy = 'راضی',
    NaRazy = 'ناراضی',
    DarHalePeyGiry = 'در حال پیگیری',
    Vafadar = 'وفادار',
}

export enum CustomerStateNumber {
    Belghoveh = 1,
    Belfel = 2,
    Razy = 3,
    NaRazy = 4,
    DarHalePeyGiry = 5,
    Vafadar = 6,
}

export interface ReferType {
    idCustomer: string
    name?: string
    phoneNumber?: string
    first_name?: string
    last_name?: string
    phone?: string
    id?: string
}

export type AttributesValueType = {
    FilePath?: string
    ValueString?: string
    ValueBool?: boolean
    ValueDate?: string
    ValueNumber?: number
    IdAttributeOption: string
}

export type NewCustomerType = {
    FirstName?: string,
    LastName?: string,
    BirthDayDate?: string,
    Gender?: number,
    PhoneNumbers?: string
    CustomersAddresses?: string[]
    CustomerPeyGiries?: string[]
    CustomerNotes?: string[]
    EmailAddresses?: string
    CustomersAddress?: string
    CityId?: string
    CustomerMoarefId?: string
    AttributesValue?: AttributesValueType[]
    first_name?: string | null
    last_name?: string
    phone?: string
    customfields?: any | null
    gender?: number | null
    birthdate?: string | null
    address?: string | null
    city_id?: number | null
    email?: string | null
    customer_referral_id?: string | null
}