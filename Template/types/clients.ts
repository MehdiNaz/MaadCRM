export enum CustomersState {
    BELGHOVEH = 'بالقوه',
    BELFEL = 'بالفل',
    RAZI = 'راضي',
    NARAZI = 'ناراضی',
    DARHALPEYGIRI = 'در حال پیگیری',
    VAFADAR = 'وفادار',
}

export type CustomerProfileStatusType = {
    status: string;
}

export type ClientProfileType = {
    type: string;
}