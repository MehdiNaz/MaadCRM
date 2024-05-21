import { getProfile } from '@/services/account';
import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';

export const fetchUser = createAsyncThunk(
    'user/fetchUser', async () => {
        const response = await getProfile()
        return response.data
    })

export const userSlice = createSlice({
    name: 'user',
    initialState: {
        loading: true,
        first_name: '',
        last_name: '',
        phone: '',
        email: '',
        city_id: '',
        province_id: '',
        address: '',
        national_code: '',
        birthdate: '1384-01-21'
    },
    reducers: {
    },
    extraReducers: (builder) => {
        builder.addCase(fetchUser.fulfilled, (state, action) => {
            const { first_name, last_name, national_code, phone, email, city_id, province_id, address, birthdate } = action.payload
            state.first_name = first_name
            state.last_name = last_name
            state.phone = phone
            state.email = email
            state.city_id = city_id
            state.province_id = province_id
            state.address = address
            state.national_code = national_code
            state.birthdate = birthdate
            state.loading = false
        })

        builder.addCase(fetchUser.pending, (state, action) => {
            state.loading = true
        })

    }
});

export const { } = userSlice.actions;

export default userSlice.reducer;