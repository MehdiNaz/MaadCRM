import { getAllFactors } from "@/services/foroush";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { getAllCustomers } from "services/customer";
import { getAllCustomerFeedbacks } from "services/feedback";

import { store } from "../store/store"

export const fetchCustomers = createAsyncThunk(
    'customer/fetchCustomers',
    async ({ search, state, gender, province, per_page, page = 1 }: { search?: string, state?: number, gender?: number, province?: string, per_page?: number, page?: number }) => {
        const response = await getAllCustomers({ search, state, gender, province, per_page: store.getState().customers.per_page, page })
        return response
    })

export const fetchFeedbacks = createAsyncThunk(
    'customer/fetchFeedbacks',
    async ({ id }: { id: string }) => {
        const response = await getAllCustomerFeedbacks({ id: id })
        return response
    })

export const fetchFactors = createAsyncThunk(
    'customer/fetchFactors',
    async ({ customer_id }: { customer_id: string }) => {
        const response = await getAllFactors({ customer_id })
        return response
    })


const initialState = {
    //basics
    customers: [],
    feedbacks: [],
    loading: false,
    fetch: false,
    per_page: 20,
    page: 1,
    total_pages: 0,

    //states
    belFelCount: 0,
    belghovehCount: 0,
    darHalePeyGiryCount: 0,
    naRazyCount: 0,
    razyCount: 0,
    vafadarCount: 0,
    total: 0,

    //customer fasctors
    factors: []
} as any

const customerReducer = createSlice({
    name: "customer",
    initialState,
    reducers: {
        setBelghovehCount: (state, action) => {
            state.belghovehCount = action.payload
        },
        setBelFelCount: (state, action) => {
            state.belFelCount = action.payload
        },
        setRazyCount: (state, action) => {
            state.razyCount = action.payload
        },
        setNaRazyCount: (state, action) => {
            state.naRazyCount = action.payload
        },
        setDarHalePeyGiryCount: (state, action) => {
            state.darHalePeyGiryCount = action.payload
        },
        setVafadarCount: (state, action) => {
            state.vafadarCount = action.payload
        },
        setCount: (state, action) => {
            state.all = action.payload
        },
        setAllCustomers: (state, action) => {
            state.customers = action.payload
            state.total = action.payload.length
        },
        setLoading: (state, action) => {
            state.customers = []
            state.loading = action.payload
        },
        setPage: (state, action) => {
            state.page = action.payload
        }
    },
    extraReducers: (builder) => {
        builder.addCase(fetchCustomers.fulfilled, (state, action) => {
            state.fetch = false
            state.loading = false
            state.customers = []
            state.customers.push(...action.payload.customers)
            state.total = action.payload.customers_count.toString()
            state.belFelCount = action.payload.states[2].toString()
            state.belghovehCount = action.payload.states[1].toString()
            state.darHalePeyGiryCount = action.payload.states[5].toString()
            state.naRazyCount = action.payload.states[4].toString()
            state.razyCount = action.payload.states[3].toString()
            state.vafadarCount = action.payload.states[6].toString()
            state.fetch = true
            state.total_pages = action.payload.customers_count / state.per_page
        })
        builder.addCase(fetchCustomers.pending, (state, action) => {
            state.loading = true
        })
        builder.addCase(fetchFeedbacks.pending, (state, action) => {
            state.loading = true
        })
        builder.addCase(fetchFeedbacks.fulfilled, (state, action) => {
            state.loading = false
            state.feedbacks = []
            console.log(action.payload);

            state.feedbacks.push(...action.payload)
        })

        //Factors
        builder.addCase(fetchFactors.pending, (state, action) => {
            state.loading = true
        })
        builder.addCase(fetchFactors.fulfilled, (state, action) => {
            state.loading = false
            state.factors = []
            state.factors.push(...action.payload.factors.rows)
        })
    }
})

export const { setBelFelCount, setBelghovehCount, setDarHalePeyGiryCount, setNaRazyCount, setRazyCount, setVafadarCount, setCount, setAllCustomers, setLoading, setPage } = customerReducer.actions


export default customerReducer.reducer