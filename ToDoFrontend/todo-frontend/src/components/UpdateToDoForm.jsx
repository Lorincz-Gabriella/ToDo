import { useNavigate } from 'react-router-dom';
import { useToDos} from '../hooks/useToDos';
import { useState } from "react";

export default function UpdateToDoForm({ initialData }) {
    console.log(initialData);
    const [title, setTitle] = useState(initialData.name);
    const [description, setDescription] = useState(initialData.description || "");
    const [deadLine, setDeadline] = useState(initialData.deadLine ? new Date(initialData.deadLine).toISOString().split('T')[0] : "");
    const [importance, setImportance] = useState(initialData.importance);
    const [status, setStatus] = useState(initialData.status);

     const navigate = useNavigate();

    const {
        updateToDoItem,
        isUpdating
    } = useToDos();

    const handleSubmit = (e) => {
        e.preventDefault();

        const updatedToDo={
            id:initialData.id,
            title,
            description,
            deadLine:deadLine? new Date(deadLine) : null,
            importance,
            status
        }

        const selectedDate = new Date(deadLine);
        const now = new Date();
        if (selectedDate < now) {
            alert("The deadline must be in future");
            return;
        }

        updateToDoItem(
            updatedToDo
        , {
            onSuccess: () => {
                navigate("/");
            }
        });
    }

    return (
        <form onSubmit={handleSubmit} className='updateForm'>
            <h3> Update Todo</h3>

            <input type='text' value={title}
                onChange={(e) => setTitle(e.target.value)}
                placeholder='title'
                disabled={isUpdating}
            />

            <textarea
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                placeholder='description'
                disabled={isUpdating}
            />

            <input
                type='date'
                value={deadLine}
                onChange={(e) => setDeadline(e.target.value)}
                disabled={isUpdating}
            />

            <select
                value={importance}
                onChange={(e) => setImportance(e.target.value)}
                disabled={isUpdating}
            >
                <option value="0">Not important</option>
                <option value="1">Slightly important</option>
                <option value="2">Important</option>
                <option value="3">Urgent</option>
            </select>

            <select
                value={importance}
                onChange={(e) => setImportance(e.target.value)}
                disabled={isUpdating}
            >
                <option value="0">ToDo</option>
                <option value="1">InProgress</option>
                <option value="2">Done</option>
            </select>

            <button type='submit' disabled={isUpdating} >
                {isUpdating ? "Updating..." : "Update"}
            </button>
        </form>
    )
}