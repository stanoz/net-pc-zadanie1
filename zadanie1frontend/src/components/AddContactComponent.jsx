import {Link} from "react-router-dom";
import FormComponent from "./FormComponent.jsx";
// Komponent wyświetla komponent formularza do dodania kontaktu oraz link do powrotu na stronę główną
export default function AddContactComponent(){
    return (
        <>
            <p>Add New Contact</p>
            <FormComponent operation='post'/>
            <Link to='/home'>Home</Link>
        </>
    );
}