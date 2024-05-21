import axios from "@/utils/axios";

export async function LoginWithPhone({ phone }: { phone: string }) {
    const { data } = await axios.post('/users/sendOTP', { phone: phone });
    return data
}

export async function Verify({ phone, otp }: { phone: string, otp: string }) {
    const { data } = await axios.post('/users/verifyOTP', { phone, otp });
    return data
}