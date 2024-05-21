export enum AttributeInputTypeId {
    TextBox = 1,
    Number = 2,
    Date = 3,
    File = 4,
    SelectBox = 5,
    MultiSelect = 6,
}

export enum AttributeTypeId {
    Customer = 1,
    Contacts = 2,
    Teammate = 3
}

export type FieldType = {
    Label?: string
    label?: string
    IsRequired?: boolean
    AttributeInputTypeId?: AttributeInputTypeId
    idAttributeInputType?: any
    AttributeTypeId?: AttributeTypeId
    id?: string
    isRequired?: any
    idAttributeType?: number
    Options?: any[]
    value?: any
    attributeOptions?: any[]
    inputType?: number
    error?: boolean
    title?: string
    type?: number
    options?: any[]
    required?: boolean
}

export type AttributeValueType = {
    FilePath?: string
    ValueString: string
    ValueBool?: boolean
    ValueDate?: string
    ValueNumber?: number
    IdAttributeOption: string
}