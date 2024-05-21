import { useEffect } from "react"
import { useDispatch, useSelector } from "react-redux"
import { fetchFeedbacks } from "slices/customerSlice"
import { AppDispatch, RootState } from "store/store"

export default function AllFeedbacks({ id }) {

    const dispatch = useDispatch<AppDispatch>()
    const { feedbacks } = useSelector((state: RootState) => state.customers)

    useEffect(() => {
        dispatch(fetchFeedbacks({ id: id }))
    }, [])

    return (
        <div className="w-full flex flex-col">
            {feedbacks.map((feedback) => {
                <div className="w-full">
                    {feedback.Id}
                </div>
            })}
        </div>
    )
}