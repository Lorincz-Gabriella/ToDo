import { useToDos } from '../hooks/useToDos';
import { useNavigate } from 'react-router-dom';

export default function ToDoItem({todo})
{
    const navigate = useNavigate();

    const{
        deleteToDoItem,
        isDeleting,
    }=useToDos()

    const handleUpdate = () => {
        navigate(`/todos/${todo.id}`);
    }

    return(
        <li className="todo-item">
            <div>
                <h4>
                    {todo.name}
                </h4>
                <p>
                    {todo.description||"None"}
                </p>
                <small>
                    Status: {todo.status}
                </small>
            </div>
            <button onClick={()=>deleteToDoItem(todo.id)} disabled={isDeleting}>
            </button>
            <button onClick={handleUpdate}>Update</button>
        </li>
    )
}