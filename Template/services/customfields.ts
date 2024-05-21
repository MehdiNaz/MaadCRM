import { FieldType } from "@/types/customfields";
import { InsertAttributeParams } from "@/types/services/customfields";
import axios from "utils/axios";

export async function InsertAttribute({ title, required, type, options = null }) {
    const body = {
        title,
        required,
        type,
        options
    }

    if (!options) delete body.options

    const { data } = await axios.post('/customfields/new', body)
    return data
}


export async function getAllAttributes() {
    const { data } = await axios.get('/customfields/list?field_for=1')
    return data
}

export async function updateAttribute({ id, title, required, type }: InsertAttributeParams) {
    const { data } = await axios.put('/customfields/edit/' + id, {
        title,
        required,
        type
    })
    return data
}

export async function deleteAttribute(Id: string) {
    const { data } = await axios.delete(`/customfields/delete/${Id}`)
    return data
}

export async function InsertAttributeOption({ Title, IdAttribute }) {
    const { data } = await axios.post('AttributeOption/Insert', {
        Title,
        IdAttribute,
        DisplayOrder: 1
    })
    return data
}

export async function updateAttributeOption({ Id, Title }) {
    const { data } = await axios.put('AttributeOption/Update', {
        Id,
        Title,
        DisplayOrder: 1
    })
    return data
}

export async function deleteAttributeOption(Id: string) {
    const { data } = await axios.delete(`AttributeOption/Delete/${Id}`)
    return data
}