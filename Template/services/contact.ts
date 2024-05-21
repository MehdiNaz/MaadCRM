import { ContactType } from "@/types/services/contact";
import axios from "utils/axios";

export async function newContact({ group_id, first_name = null, last_name, phone, email, job_title }) {
    const body = {
        group_id,
        first_name,
        last_name,
        phone,
        email,
        job_title
    }

    if (!email) delete body.email
    if (!first_name) delete body.first_name
    if (!job_title) delete body.job_title


    const { data } = await axios.post('/contacts/new', body)
    return data
}


export async function getAllGroups() {
    const { data } = await axios.get('/contacts/group/list')
    return data
}

export async function getAllContacts() {

    const { data } = await axios.get('/contacts/list')
    return data
}

export async function newGroup({ title }: { title: string }) {
    const { data } = await axios.post('/contacts/group/new', {
        title: title
    })
    return data
}

export async function updateContact({ id, group_id, first_name = null, last_name, phone, email = null, job_title = null }) {
    const body = {
        group_id,
        first_name,
        last_name,
        phone,
        email,
        job_title
    }

    if (!email) delete body.email
    if (!first_name) delete body.first_name
    if (!job_title) delete body.job_title

    const { data } = await axios.put('/contacts/edit/' + id, body)
    return data
}

export async function deleteContact({ idContact }: { idContact: string }) {
    const { data } = await axios.delete(`/contacts/delete/${idContact}`)
    return data
}

export async function updateContactGroup({ id, title }) {
    const { data } = await axios.put('contacts/group/edit/' + id, {
        title
    })

    return data
}


export async function deleteGroup({ id }) {
    const { data } = await axios.delete('/contacts/group/delete/' + id)
    return data
}
