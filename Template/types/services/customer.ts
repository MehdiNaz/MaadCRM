export type updateCustomerType = {
    Id: string,
    FirstName?: string,
    LastName: string,
    BirthDayDate?: string,
    Gender?: number,
    PhoneNumbers: Array<string>,
    CustomersAddresses?: Array<string>,
    CustomerPeyGiries?: Array<string>,
    CustomerNotes?: Array<string>,
    EmailAddresses?: Array<string>,
    CityId?: string,
    CustomerMoarefId?: string
    AttributesValue?: Array<any>
}

export type GetCustomersType = {
    CustomerState?: number
    Gender?: number
    ProvinceId?: string
}

export type newFeedbackType = {
    customer_id: string
    feedback_category_id: string
    feedback_user?: string
    feedback_product_id?: string
    description?: string
}