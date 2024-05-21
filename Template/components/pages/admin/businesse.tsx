'use client'
import BusinessesTable from "@/components/admin/businesses/table";
import { getAll } from "@/services/admin/business";
import { useEffect, useState } from "react";

export default function Bussinesses() {

    const [businesses, setBusinesses] = useState([])

    async function getBusinesses() {
        const response = await getAll()
        setBusinesses(response.businesses)
    }

    useEffect(() => {
        getBusinesses()
    })

    return (
        <BusinessesTable data={businesses} />
    )
}