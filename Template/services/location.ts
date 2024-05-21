import axios from "utils/axios";

export async function getProvinceList() {
    const { data } = await axios.get('/zone/provinces')
    return data
}

export async function getCitiesList() {
    const { data } = await axios.get('/City/AllCities')
    return data
}

export async function getCityByProvinceId(provinceId: string) {
    const { data } = await axios.get(`/zone/cities/${provinceId}`)
    return data
}
