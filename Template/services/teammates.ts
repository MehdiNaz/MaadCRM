import { InsertTeammateParams } from "@/types/services/teammates";
import axios from "utils/axios";

export async function insertTeammate({ first_name, last_name, email, phone, department_id, national_code, gender }: InsertTeammateParams) {
    const body = {
        first_name,
        last_name,
        email,
        phone,
        department_id,
        national_code,
        gender
    }

    if (!email) delete body.email
    if (!gender) delete body.gender
    if (!national_code) delete body.national_code

    const { data } = await axios.post('/teammates/new', body)
    return data
}

export async function insertGroup({ title }: { title: string }) {
    const { data } = await axios.post('teammates/departments/new', { title })
    return data
}

export async function getAllGroups() {
    const { data } = await axios.get('/teammates/departments/list')
    return data
}

export async function editDepartment({ id, title }: { id: string, title: string }) {
    const { data } = await axios.put('/teammates/departments/edit/' + id, {
        title
    })
    return data
}

export async function deleteDepartment({ id }) {
    const { data } = await axios.delete('teammate/DeleteGroup', {
        data: {
            id
        }
    })
    return data
}

export async function getAllTeammates() {
    const { data } = await axios.get('teammates/list')
    return data
}

export async function deleteTeammate({ id }) {
    const { data } = await axios.delete('teammate/delete', { data: { id } })
    return data
}

export async function getTeammateById({ id }) {
    const { data } = await axios.get('/teammates/' + id)
    return data
}

export async function editTeammate({ id, first_name, last_name, phone, email, address, national_code, gender, department_id, city_id }) {
    const body = {
        id,
        first_name,
        last_name,
        phone,
        email,
        address,
        national_code,
        gender,
        department_id,
        city_id
    }

    if (!email) delete body.email
    if (!gender) delete body.gender
    if (!national_code) delete body.national_code
    if (!address) delete body.address
    if (!city_id) delete body.city_id


    const { data } = await axios.put('/teammates/edit/' + id, body)
    return data
}


export async function ChangeUserPermisstion({ id, Permission }) {
    const { data } = await axios.post('/teammate/ChangePermission', {
        id,
        Permission
    })
    return data
}