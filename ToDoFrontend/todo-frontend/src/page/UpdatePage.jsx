import { useQuery } from "@tanstack/react-query";
import { useParams,useNavigate } from "react-router-dom";
import { getToDoItemById} from "../api/todoApi"
import UpdateToDoForm from "../components/UpdateToDoForm";

//page nem form
export default function UpdatePage()
{
    const {todoId}=useParams();
    const navigate = useNavigate();
   
    const handleBack = () =>{
        navigate("/");
    } 

    const {
        data: todo,
        isLoading,
        isError,
        error
    } = useQuery({
        queryKey: ['todo',todoId],
        queryFn: () => getToDoItemById(todoId)
    }) 

      if (isLoading)
    {
        return <div>Loading todos.....</div>
    }
    if(isError)
    {
        return <div className="error">Error has occured:{error.message}</div>
    }

    return(
        <div className="container">
            <header>
                <h1>
                    Update Todo
                </h1>
                <button onClick={handleBack}>Back to the ToDo list</button>
            </header>
            <main>
                <UpdateToDoForm initialData={todo}/>               
            </main>
        </div>
    );
}