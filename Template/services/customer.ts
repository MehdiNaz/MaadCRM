import { NewCustomerType } from "@/types/customer";
import { GetCustomersType, newFeedbackType, updateCustomerType } from "@/types/services/customer";
import { getCookie } from "cookies-next";
import axios from "utils/axios";
import { getLocalStorage } from "utils/helper";


export async function editCustomerNote({ description, note_id }) {
    const { data } = await axios.put('/customers/notes/edit/' + note_id, {
        description,
    })
    return data
}
export async function newCustomer({ first_name, last_name, phone, email, customfields, gender, birthdate, address, city_id, customer_referral_id }: NewCustomerType) {

    const body = {
        first_name,
        last_name,
        phone,
        email,
        customfields,
        gender,
        birthdate,
        address,
        city_id,
        customer_referral_id
    }

    if (!first_name) delete body.first_name
    if (!email) delete body.email
    if (!customfields) delete body.customfields
    if (!gender) delete body.gender
    if (!birthdate) delete body.birthdate
    if (!address) delete body.address
    if (!city_id) delete body.city_id
    if (!customer_referral_id) delete body.customer_referral_id

    const { data } = await axios.post('/customers/new', body)
    return data
}

export async function updateCustomer({ customer_id, first_name = null, last_name, phone, email = null, gender = 1, address = null, city_id = null, birthdate = null, customer_referral_id = null, customfields = null }) {

    const { data } = await axios.put('/customers/update', {
        customer_id,
        first_name,
        last_name,
        phone,
        email,
        gender,
        address,
        city_id,
        birthdate,
        customer_referral_id,
        customfields
    })
    return data
}

export async function deleteCustomerNote({ CustomerNoteId }) {
    const { data } = await axios.delete('/customers/notes/delete/' + CustomerNoteId)
    return data
}

export async function getAllCustomers({ search, state, gender, province, per_page, page }) {

    let body = {
        per_page,
        page,
        search: search,
        state: state,
        gender: gender
    }

    if (!state) delete body.state
    if (!gender) delete body.gender
    if (!search) delete body.search

    const { data } = await axios.post('/customers/list', body)
    return data

    // let response
    // const data = {} as GetCustomersType
    // if (state != '') {
    //     data.CustomerState = state
    // }
    // if (gender != '') {
    //     data.Gender = parseInt(gender)
    // }
    // if (province != '') {
    //     data.ProvinceId = province
    // }
    // if (search != '') {
    //     response = await axios.get('Customer/CustomerBySearchItem/' + search)
    // } else {
    //     response = await axios.post('Customer/CustomerByFilterItems', data)
    // }

    // if (response.status === 200) {
    //     return response.data.data
    // }
    // return null
}

export async function editPeygiri({ Description, Id }) {
    try {
        const response = await axios.put('CustomerPeyGiry/Update', {
            Id: Id,
            Description: Description,
        }, {
            headers: {
                'Authorization': 'Bearer ' + getLocalStorage('token')
            }
        })
        if (response.status === 200) {
            return response.data
        }
        return null
    } catch (err) {
        return err
    }
}

export async function deleteCustomerPeygiri({ Id }) {
    try {
        const response = await axios.post('CustomerPeyGiry/Delete', {
            Id: Id
        }, {
            headers: {
                'Authorization': 'Bearer ' + getLocalStorage('token')
            }
        })
        if (response.status === 200) {
            return response.data
        }
        return null
    } catch (err) {
        return err
    }
}

export async function addPeygiri({ CustomerId, DatePeyGiry, IdPeyGiryCategory }) {
    const newPeygiri = {
        CustomerId: CustomerId,
        DatePeyGiry: DatePeyGiry,
        IdPeyGiryCategory: IdPeyGiryCategory
    }

    if (DatePeyGiry == '' || DatePeyGiry == null) {
        delete newPeygiri.DatePeyGiry
    }

    const { data } = await axios.post('CustomerPeyGiry/Insert', newPeygiri)
    return data
}

export async function getPeygiris({ user_id }) {
    const { data } = await axios.get('/CustomerPeyGiry/AllCustomerPeyGiries/' + user_id)
    return data
}

export async function getCustomerByID({ id }) {
    const { data } = await axios.get('/customers/' + id)
    return data
}


export async function newCustomerNote({ customer_id, description }) {
    const { data } = await axios.post('/customers/notes/new', {
        customer_id: customer_id,
        description: description
    })
    return data
}


export async function getCustomerNotes({ customer_id }) {
    const { data } = await axios.get('/customers/notes/' + customer_id)
    return data
}

export async function deleteCustomer({ id }) {
    const { data } = await axios.delete('/customers/delete/' + id)
    return data
}

export async function newFeedback({ customer_id, feedback_category_id, feedback_user, feedback_product_id, description }: newFeedbackType) {
    const body = {
        customer_id,
        feedback_category_id,
        feedback_user,
        feedback_product_id,
        description
    }

    if (!feedback_user) delete body.feedback_user
    if (!feedback_product_id) delete body.feedback_product_id
    if (!description) delete body.description

    const { data } = await axios.post('/customers/feedback/new/' + customer_id, body)
    return data
}

export async function AllCustomerFeedbacks({ IdCustomer }) {
    const { data } = await axios.get('/customers/feedback/' + IdCustomer)
    return data
}