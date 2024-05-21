import { ReferType } from "@/types/customer";
import { showNotification } from "@mantine/notifications";
import { useEffect, useState } from "react";
import axios from "utils/axios";

export default function useRefer({ refer }): Array<ReferType> {

    const [customer, setCustomer] = useState<Array<ReferType>>([])

    async function getAllRefers() {
        return new Promise(async (resolve, reject) => {
            if (refer === '' || !refer || refer.length == 1) {
                return resolve([])
            }
            const response = await axios.post('/customers/search', {
                search: refer
            })
            if (response.data.success) {
                resolve(response.data.customers)
            } else {
                reject('No refer found')
            }
        })
    }

    useEffect(() => {
        if (refer == '' || refer == null) {
            return
        }
        getAllRefers()
            .then((res: ReferType[]) => {
                setCustomer(res)
            }).catch(() => {
                setCustomer([])
            })
    }, [refer])

    return customer

}
