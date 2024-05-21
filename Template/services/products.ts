import axios from "utils/axios";

export async function newCategory(title: string) {
    const { data } = await axios.post('/products/category/new', {
        title
    })
    return data
}


export async function getAllCategories() {
    const { data } = await axios.get('/products/category/list')
    return data
}

export async function insertProduct({ title, price, category_id }) {
    const { data } = await axios.post('/products/new', {
        title,
        price,
        category_id
    })

    return data
}

export async function updateProduct({ id, title, price, category_id }) {
    const { data } = await axios.put('/products/edit/' + id, {
        title,
        price,
        category_id
    })
    return data
}


export async function getAllproducts() {
    const { data } = await axios.get('/products/list')
    return data
}

export async function getAllActiveProducts() {
    const { data } = await axios.get('/products/list')
    return data
}

export async function getProductByID(id) {
    const { data } = await axios.get('/products/get/' + id)
    return data
}

export async function deleteProduct(id) {
    const { data } = await axios.delete('/products/delete/' + id)
    return data
}

export async function updateProductCategory({ id, title }) {
    const { data } = await axios.put('/products/category/edit/' + id, {
        title
    })
    return data
}

export async function deleteProductCategory(id) {
    const { data } = await axios.delete('/products/category/delete/' + id)
    return data
}