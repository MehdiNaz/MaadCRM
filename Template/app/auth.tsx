import { getCookie } from "cookies-next"
import { redirect } from "next/navigation"

export default function Auth() {

    const cookie = getCookie('token')
    if (!cookie) {
        redirect('/login')
    }

    return null
}