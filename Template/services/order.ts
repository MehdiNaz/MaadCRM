import { InsertOrderType } from "@/types/services/order";
import axios from "utils/axios";

export async function insertOrder({ FactorId, product_id, price, quantity }: InsertOrderType) {
    const { data } = await axios.post('/customers/sales/add/' + FactorId, {
        product_id,
        price,
        quantity
    })
    return data
}

export async function deleteOrder({ id }) {
    const { data } = await axios.delete('/customers/sales/remove/' + id)
    return data
}