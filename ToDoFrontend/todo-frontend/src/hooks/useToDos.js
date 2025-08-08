import { useQuery, useQueryClient, useMutation, Query } from "@tanstack/react-query"
import { getAllToDoItems, addToDoToDB, updateToDo,deleteToDo,getToDoItemById} from "../api/todoApi"

//hook use al kezdodik fuggveny
export const useToDos = () => { //hook
    const client = useQueryClient();
    const {
        data: todos,
        isLoading,
        isError,
        error
    } = useQuery({
        queryKey: ['todos'],
        queryFn: getAllToDoItems
    }) 

    const { mutate: addToDoItem, isPending: isAdding } = useMutation({
        mutationFn: addToDoToDB,
        onSuccess: () => {
            client.invalidateQueries({
                queryKey: ['todos']
            });
        }
    });

    const { mutate: updateToDoItem, isPending: isUpdating } = useMutation({
        mutationFn: updateToDo,
        onSuccess: (data,variables) => {
            client.invalidateQueries({
                queryKey: ['todos']
            });
            client.invalidateQueries({
                queryKey: ['todos',variables.id]
            })
        }
    });

    const { mutate: deleteToDoItem, isPending: isDeleting } = useMutation({
        mutationFn: deleteToDo,
        onSuccess: () => {
            client.invalidateQueries({
                queryKey: ['todos']
            });
        }
    });

    return {
        todos,
        isLoading,
        isError,
        error,
        deleteToDoItem,
        isDeleting,
        updateToDoItem,
        isUpdating,
        addToDoItem,
        isAdding
    }
}

//mutation => post,patch,delete
//query => get (lekereshez)
//function kicsi betu(Camel case),komponens(pl function ToDo) nagy betu 
//kontansak amik nem valtoznak (nagy betuk)