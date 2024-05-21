import { FaSave } from "react-icons/fa";
import TableView from "../tableView";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "store/store";
import { useEffect } from "react";
import { fetchFactors } from "@/slices/customerSlice";
import { handleComma } from "@/utils/helper";

export default function Factors({ customer_id }) {

    const { laoding, factors } = useSelector((state: RootState) => state.customers)
    const dispatch = useDispatch<AppDispatch>()

    useEffect(() => {
        dispatch(fetchFactors({ customer_id }))
    }, [customer_id])

    return (
        <TableView
            columns={[
                { label: 'همکار', id: 'teammate' },
                { label: 'شماره فاکتور', id: 'invoice_number' },
                { label: 'تاریخ', id: 'date' },
                { label: 'نحوه پرداخت', id: 'pay_method' },
                { label: 'مبلغ کل', id: 'price' },
                // { label: 'عملیات', id: 'action' },
            ]}
            data={factors.map(factor => ({
                teammate: factor.user?.first_name ?? '' + ' ' + factor.user?.last_name,
                invoice_number: factor.order_number,
                date: new Date(factor.sale_date).toLocaleDateString('fa-IR'),
                pay_method: factor.payment_method == 1 ? 'نقدی' : 'اقساطی',
                price: handleComma(factor.pish_pardakht),
                action: <div className="flex justify-center">
                    <button className="btn btn-sm btn-outline-primary mx-1">
                        <FaSave />
                    </button>
                </div>
            }))
            }

        />
    )
}