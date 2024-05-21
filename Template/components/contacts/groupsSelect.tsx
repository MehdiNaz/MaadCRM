'use client'
import { Loader, Select } from "@mantine/core";
import { useEffect, useReducer, useState } from "react";
import { getAllGroups } from "services/contact";


const initialState = {
    groups: [],
    value: '',
    loading: true
}

function reducer(state, action) {
    switch (action.type) {
        case 'setGroups':
            return { ...state, groups: action.payload }
        case 'clearGroups':
            return { ...state, groups: [] }
        case 'noGroup':
            return { ...state, groups: [{ value: '', label: 'گروهی وجود ندارد', disabled: true }] }
        case 'setValue':
            return { ...state, value: action.payload }
        case 'loaded':
            return { ...state, loading: false }
        default:
            throw new Error();
    }
}

export default function GroupsSelect({ defaultValue, ...props }: { defaultValue?: string }) {

    const [state, dispatch] = useReducer(reducer, initialState)

    useEffect(() => {
        dispatch({ type: 'setValue', payload: defaultValue })
    }, [defaultValue])

    useEffect(() => {
        async function getContactGroups() {
            const response = await getAllGroups()
            if (response.groups.length > 0) {
                dispatch({ type: 'clearGroups' })
                response.groups.map((item) => {
                    dispatch({ type: 'setGroups', payload: [...state.groups, { value: item.id, label: item.title, selected: true }] })
                })
                dispatch({ type: 'loaded' })
            } else {
                dispatch({ type: 'noGroup' })
            }
        }
        getContactGroups()
    }, [])

    return (
        <>
            <Select
                clearable
                data={state.groups}
                placeholder="انتخاب کنید"
                searchable
                icon={state.loading && <Loader size={13} />}
                defaultValue={defaultValue}
            />
        </>
    )
}