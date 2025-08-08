import { useToDos } from '../hooks/useToDos';
import { useState } from "react";
import { useUIStore } from '../store/useUIStore';


export default function AddToDoForm() {
    const [title, setTitle] = useState("");
    const [description,setDescription] = useState("");
    const [deadLine,setDeadline] = useState("");
    const [importance,setImportance] = useState("");

    const {
        toggleToDoForm
    }=useUIStore();
 
    const {
        addToDoItem,
        isAdding
    } = useToDos();

    const handleSubmit = (e) => {
        e.preventDefault();

        const selectedDate=new Date(deadLine);
        const now=new Date();
        if(selectedDate<now)
        {
            alert("The deadline must be in future");
            return;
        }

        addToDoItem({ 
            title,
            description,
            deadLine,
            importance
        }, {
            onSuccess: () =>{
                toggleToDoForm();
                setTitle("");
                setDescription("");
                setDeadline("");
                setImportance("");
            }
        });
    }

    return (
        <form onSubmit={handleSubmit} className='addForm'>
            <h3> New Todo</h3>

            <input type='text' value={title}
                onChange={(e) => setTitle(e.target.value)}
                placeholder='title'
                disabled={isAdding} 
            />

            <textarea
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                placeholder='description'
                disabled={isAdding}
            />

            <input
                type='date'
                value={deadLine}
                onChange={(e) => setDeadline(e.target.value)}
                disabled={isAdding}
            />

            <select
                value={importance}
                onChange={(e) => setImportance(e.target.value)}
                disabled={isAdding}
            >
                <option value="0">Not important</option>
                <option value="1">Slightly important</option>
                <option value="2">Important</option>
                <option value="3">Urgent</option>
            </select>    

            <button type='submit' disabled={isAdding} >
                {isAdding ? "Saving..." : "Add"}
            </button>    
        </form>
    )
}