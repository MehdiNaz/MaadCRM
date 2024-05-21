import { newFactortype } from "@/types/services/foroush";
import axios from "utils/axios";

export async function newFactor({
    customer_id,
    payment_method,
    sale_date
}: newFactortype) {
    const { data } = await axios.post('/customers/sales/new/' + customer_id, {
        payment_method: payment_method,
        sale_date: sale_date
    })
    return data
}

export async function savePaymenst({ factor_id, pish_pardakht, takhfif_kol, tedad_aghsat = null, darsad_soud = null, payment_start_date = null, baze_pardakht = null, kole_soud = null }) {
    const body = {
        pish_pardakht,
        takhfif_kol,
        tedad_aghsat,
        darsad_soud,
        payment_start_date,
        baze_pardakht,
        kole_soud
    }
    const { data } = await axios.put('/customers/sales/update/' + factor_id, body)
    return data
}

export async function getAllFactors({ customer_id }: { customer_id: string }) {
    const { data } = await axios.get('/customers/sales/' + customer_id)
    return data
}