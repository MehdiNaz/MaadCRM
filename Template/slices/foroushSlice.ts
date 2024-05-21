import { createSlice } from '@reduxjs/toolkit';

export const foroushSlice = createSlice({
    name: 'foroush',
    initialState: {
        total: 0,
    },
    reducers: {
        setTotal: (state, action) => {
            state.total = action.payload;
        }
    },
});

export const { setTotal } = foroushSlice.actions;

export default foroushSlice.reducer;