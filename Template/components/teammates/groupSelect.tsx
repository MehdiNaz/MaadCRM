import { Loader } from "@mantine/core";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { fetchGroups } from "slices/teammateSlice";
import { AppDispatch, RootState } from "store/store";
import SelectBox from "../selectBox";

export default function GroupSelect({ ...props }) {

    const dispatch = useDispatch<AppDispatch>()
    const { groups, groupdLoading } = useSelector((state: RootState) => state.teammates)

    useEffect(() => {
        dispatch(fetchGroups())
    }, [dispatch])

    return (
        <SelectBox
            label='دپارتمان :'
            searchable
            placeholder='دپارتمان'
            data={groups && groups.length > 0 ? groups.map((group) => ({ value: group.id, label: group.title })) : []}
            icon={groupdLoading && <Loader size={13} />}
            {...props}
        />
    )
}