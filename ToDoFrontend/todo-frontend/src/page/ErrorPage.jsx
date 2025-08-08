import { useRouteError } from "react-router-dom"

export default function ErrorPage() { //export => mas fajlban is megtalalhato lesz 
    const error = useRouteError();
    console.log(error);


    //csak egy blokkot <> </> terithetek vissza 
    return (
        <div id="error-page" style={{ textAlign: "center", marginTop: "50px" }}>
            <h1>
                OOPs!
            </h1>
            <p>
                Sorry some error has happend!
            </p>
            <p>
                <i>
                    {error.statusText || error.message}
                </i>
            </p>
        </div>
    )
    //message jon a backendrol ,statustext (frontend)
}