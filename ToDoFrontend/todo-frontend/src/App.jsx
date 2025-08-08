import { createBrowserRouter, RouterProvider } from "react-router-dom"
import HomePage from "./page/HomePage"
import ErrorPage from "./page/errorPage"
import  UpdatePage from "./page/UpdatePage"

const router=createBrowserRouter(
  [
    {
      path : "/",
      element : <HomePage/>,
      errorElement : <ErrorPage/>
    },
    {
      path : "/todos/:todoId",
      element : < UpdatePage/>,
      errorElement : <ErrorPage/>
    }
  ]
)

function App() {
  return (
    <RouterProvider router={router} />
  )
}

export default App
//[] lista
//{} 
//() functionok vegere ,meghivhato