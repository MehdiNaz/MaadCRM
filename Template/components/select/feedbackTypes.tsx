'use client'
import { Loader } from "@mantine/core";
import { showNotification } from "@mantine/notifications";
import { useEffect, useReducer, useState } from "react";
import { getFeedbackCategories } from "services/feedback";
import SelectBox from "../selectBox";

const initialState = {
    types: [],
    loading: true,
}

function reducer(state, action) {
    switch (action.type) {
        case 'setTypes':
            return {
                ...state,
                types: action.payload,
                loading: false
            }
        case 'setLoading':
            return {
                ...state,
                loading: action.payload
            }
        case 'noData':
            return {
                ...state,
                types: [{
                    label: 'موردی یافت نشد',
                    value: '',
                    disabled: true
                }],
                loading: false
            }
        case 'clear':
            return {
                ...state,
                types: [],
                loading: true
            }
        default:
            return state
    }
}

export default function FeedbackTypes({ feedbackType, ...props }) {
    const [state, dispatch] = useReducer(reducer, initialState)

    const [type, setType] = useState(feedbackType)

    async function getFeedBackTypes() {
        try {
            const response = await getFeedbackCategories()
            dispatch({ type: 'setTypes', payload: response.feedbacks })
        } catch {
            dispatch({ type: 'setLoading', payload: false })
            showNotification({
                title: 'خطا',
                message: 'خطایی در دریافت اطلاعات رخ داد',
                color: 'red'
            })
        }
    }

    useEffect(() => {
        getFeedBackTypes()
    }, [])


    useEffect(() => {
        setType(feedbackType)
        let newData = []
        if (state.types.length > 0) {
            state.types.map((item) => {
                if (item.typeFeedback = type) {
                    newData.push(item)
                }
            })
            if (newData.length > 0) {
                dispatch({ type: 'clear' })
                dispatch({ type: 'setTypes', payload: newData })
            } else {
                dispatch({ type: 'noData' })
            }
        }
    }, [feedbackType])

    return (
        <SelectBox
            icon={state.loading ? <Loader size={13} /> : null}
            disabled={state.loading}
            placeholder="نوع بازخورد"
            data={state.types && state.types.length > 0 ? state.types.map((type: any) => ({
                label: type.positive_or_negative == false ? type.title + ' - منفی' : type.title + ' - مثبت',
                value: type.id
            })) : []}
            {...props}
        />
    )
} 