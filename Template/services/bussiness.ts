import axios from "utils/axios";

export async function getAllUsers() {
    const { data } = await axios.get('/users/get')
    return data
}