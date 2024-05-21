import { getCookie } from "cookies-next";
import axios from "utils/axios";
import { getLocalStorage } from "utils/helper";

export async function setProfile({ first_name, last_name, email, gender, birthdate, address, city_id, activity, national_code }: {
    first_name: string,
    last_name: string,
    email?: string,
    gender?: number,
    birthdate?: string,
    address?: string,
    city_id?: number,
    activity?: string,
    national_code?: string | number
}) {

    const { data } = await axios.put('/users/update', {
        first_name,
        last_name,
        email,
        gender,
        birthdate,
        address,
        city_id,
        activity,
        national_code
    })
    return data
}