import foroushReducer from "slices/foroushSlice"
import userSlice from "slices/userSlice"
import customerReducer from "slices/customerSlice"
import teammateReducer from "slices/teammateSlice"
import customfieldsSlice from "slices/customfieldsSlice"
import { configureStore } from "@reduxjs/toolkit"


export const store = configureStore({
    reducer: {
        customers: customerReducer,
        teammates: teammateReducer,
        foroush: foroushReducer,
        user: userSlice,
        customfields: customfieldsSlice
    }
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch