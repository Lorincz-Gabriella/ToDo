import axios from "axios"

const API_URL = "http://localhost:7295/api";
const apiClient = axios.create({
    baseURL:API_URL,
    headers:{
        "Content-Type":"application/Json",
    },
});

export const getAllToDoItems = async () => {
    const response = await apiClient.get("/todos");
    return response.data;
}

export const getToDoItemById = async (id) => {
    const response = await apiClient.get(`/todos/${id}`); //interpolarizalas ``
    return response.data;
}

export const deleteToDo = async (id) => {
    const response = await apiClient.delete(`/todos/${id}`);
    return response.data;
}

export const updateToDo = async ({id,...updateToDo}) => {
    const response = await apiClient.patch(`/todos/${id}`,updateToDo)
    return response.data;
}

export const addToDoToDB = async (createToDo) => {
    const response = await apiClient.post(`/todos`,createToDo);
    return response.data;
}