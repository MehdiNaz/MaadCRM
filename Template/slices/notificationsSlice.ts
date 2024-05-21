import { createSlice } from '@reduxjs/toolkit'

export const notificationsSlice = createSlice({
    name: 'notifications',
    initialState: {
        notifications_count: 0
    },
    reducers: {
        setNotificationsCount: (state, action) => {
            state.notifications_count = action.payload
        }
    },
})

export const { setNotificationsCount } = notificationsSlice.actions

export default notificationsSlice.reducer