import axios from "utils/axios";

export async function newPeygiriCategory({
    title
}: {
    title: string
}) {
    const { data } = await axios.post('/peygiri/new', {
        title: title
    })
    return data
}

export async function getAllPeygiriCategory() {
    const { data } = await axios.get('/peygiri/list')
    return data
}

export async function editPeygiriCategory({ id, title }: { id: string, title: string }) {
    const { data } = await axios.post('/peygiri/edit/' + id, {
        title: title,
    })
    return data
}

export async function deletePeygiriCategory({ Id }: { Id: string }) {
    const { data } = await axios.delete('/peygiri/delete/' + Id)
    return data
}