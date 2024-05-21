import { plan } from "@/types/services/plan";
import axios from "utils/axios";


/**
 * Get all plans
 * 
 */

export async function getAll(): Promise<plan[]> {
    try {
        const response = await axios.get('plan/AllPlans')
        if (response.status === 200) {
            return response.data
        }
        return []
    } catch (error) {
        return error
    }
}