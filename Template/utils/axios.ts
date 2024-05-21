import Axios from 'axios'
import { getCookie } from 'cookies-next'
const axios = Axios.create({
    baseURL: process.env.API_URL,
    headers: {
        'Content-Type': 'application/json',
    }
})

if (axios.defaults.headers.common['Authorization'] === undefined) {
    axios.defaults.headers.common['Authorization'] = `Bearer ${getCookie('token')}`
}

export default axios