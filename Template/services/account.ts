import axios from "@/utils/axios";

export async function getProfile() {
    const { data } = await axios.get('/account/profile')
    return data
}