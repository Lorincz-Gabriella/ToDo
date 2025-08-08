import {useToDos} from "../hooks/useToDos";
import ToDoItem from "../components/ToDoItem";

export default function ToDoList ()
{
    const {
        todos,
        isLoading,
        isError,
        error  
    } = useToDos()
    
    if (isLoading)
    {
        return <div>Loading todos.....</div>
    }
    if(isError)
    {
        return <div className="error">Error has occured:{error.message}</div>
    }

    return(
        <ul className="todo-list">
            {todos?.map((todo) =>(
                <ToDoItem key={todo.id} todo={todo}/>
            )) }
        </ul>
    );
}
//todos? ha van mappali ha null nem csinal semmit
//map a lista minden tagjan elvegzi a fuggvenyt