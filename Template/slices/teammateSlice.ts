import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { getAllGroups, getAllTeammates } from "services/teammates";


export const fetchTeammates = createAsyncThunk(
    'teammates/fetchTeammates',
    async () => {
        const response = await getAllTeammates()
        return response
    }
)

export const fetchGroups = createAsyncThunk(
    'teammates/fetchGroups',
    async () => {
        const response = await getAllGroups()
        return response.departments
    }
)


const initialState = {
    filteredTeammates: [],
    teammates: [],
    loading: true,
    count: 0,
    groups: [],
    groupdLoading: false
} as any

const teammateReducer = createSlice({
    name: "teammate",
    initialState,
    reducers: {
        setTeammates(state, action) {
            state.teammates = action.payload
            state.filteredTeammates = action.payload
            state.count = action.payload.length
        },
        setTeammatesFilter(state, action) {
            state.filteredTeammates = action.payload
            state.count = action.payload.length
        },
        deleteTeammateById(state, action) {
            const newTeammates = state.teammates.filter((teammate: any) => teammate.id !== action.payload)
            state.teammates = newTeammates
            state.filteredTeammates = newTeammates
            state.count = newTeammates.length
        }
    },
    extraReducers: (builder) => {
        /**
         * Teammates
         */
        builder.addCase(fetchTeammates.pending, (state, action) => {
            state.loading = true
        })
        builder.addCase(fetchTeammates.fulfilled, (state, action) => {
            state.filteredTeammates = action.payload.teammates
            state.teammates = action.payload.teammates
            state.loading = false
            state.count = action.payload.teammates.length
        })
        /**
         * Teammate Groups
         */
        builder.addCase(fetchGroups.pending, (state, action) => {
            state.groupdLoading = true
        })
        builder.addCase(fetchGroups.fulfilled, (state, action) => {
            state.groups = action.payload
            state.groupdLoading = false
        })
    }
})

export const { setTeammates, setTeammatesFilter, deleteTeammateById } = teammateReducer.actions


export default teammateReducer.reducer