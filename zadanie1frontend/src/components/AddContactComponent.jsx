import {Link} from "react-router-dom";
import FormComponent from "./FormComponent.jsx";

export default function AddContactComponent(){
    return (
        <>
            <p>Add New Contact</p>
            <Link to='/home'>Home</Link>
            <FormComponent/>
        </>
    );
}