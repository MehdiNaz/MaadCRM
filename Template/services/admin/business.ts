import axios from "@/utils/axios";

export async function getAll() {
    const { data } = await axios.get("/admin/businesses");
    return data;
}