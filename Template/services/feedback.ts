import axios from "utils/axios";

export async function newFeedbackCategory({ feedback_for, description, title, positive_or_negative }) {
    const { data } = await axios.post('/feedback/new', {
        feedback_for: feedback_for,
        description: description,
        title: title,
        positive_or_negative: positive_or_negative
    })
    return data
}

export async function updateFeedbackcategory({ feedback_id, feedback_for, description, title, positive_or_negative }) {
    const { data } = await axios.post('/feedback/edit', {
        feedback_id: feedback_id,
        feedback_for: feedback_for,
        description: description,
        title: title,
        positive_or_negative: positive_or_negative
    })
    return data
}

export async function getFeedbackCategories() {
    const { data } = await axios.get('/feedback/list')
    return data
}

export async function deleteFeedbackType({ id }: { id: string }) {
    const { data } = await axios.post('/feedback/delete', {
        feedback_id: id
    })
    return data
}

export async function getAllCustomerFeedbacks({ id }) {
    const { data } = await axios.get('/customers/feedback/' + id)
    return data
}