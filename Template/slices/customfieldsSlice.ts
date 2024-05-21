import { getAllAttributes } from '@/services/customfields';
import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';

export const fetchFields = createAsyncThunk(
    'customfields/fetchFields',
    async () => {
        const response = await getAllAttributes()
        return response.fields
    })

export const customfieldsSlice = createSlice({
    name: 'customfields',
    initialState: {
        loading: true,
        fields: [],
    },
    reducers: {
        setFieldValueByID: (state, action) => {
            state.fields.map((field) => {
                if (field.id === action.payload.id) {
                    field.value = action.payload.value
                }
            })
        },
        resetFieldsValue: (state) => {
            state.fields.map((field) => {
                field.value = ''
            })
        },
        setFieldErrorByID: (state, action) => {
            state.fields.map((field) => {
                if (field.id === action.payload.id) {
                    field.error = action.payload.error
                }
            })
        },
        resetAllFields: (state) => {
            state.fields.map((field) => {
                field.value = ''
                field.error = ''
            })
        },
        setFields: (state, action) => {
            state.fields = action.payload
        }
    },
    extraReducers: (builder) => {
        /**
         * Get all customfields attributes
         */
        builder.addCase(fetchFields.pending, (state) => {
            state.loading = true
        })
        builder.addCase(fetchFields.fulfilled, (state, action) => {
            state.fields = action.payload
            state.loading = false
        })
    }
});

export const { setFieldValueByID, resetFieldsValue, setFieldErrorByID, resetAllFields, setFields } = customfieldsSlice.actions

export default customfieldsSlice.reducer