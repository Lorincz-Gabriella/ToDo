import AddToDoForm from "../components/AddToDoForm";
import ToDoList from "../components/ToDoList";
import {useUIStore} from '../store/useUIStore';

export default function HomePage(){

    const {
            isAddToDoFormVisible,
            toggleToDoForm
        }=useUIStore();


    return(
        <div className="container">
            <header>
                <h1>
                    ToDoWeb
                </h1>
                <button onClick={toggleToDoForm} >
                        {isAddToDoFormVisible ? "Cancel" :"Add new ToDO"}
                </button>
            </header>
            {isAddToDoFormVisible && <AddToDoForm/>} 
            <main>
                <ToDoList/>
            </main>
        </div>
    );
}