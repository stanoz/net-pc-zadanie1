import {Link, useParams} from "react-router-dom";
import FormComponent from "./FormComponent.jsx";
import {useEffect, useState} from "react";
import {getContactDetailsByEmail} from "../data/GetContactDetails.js";
// Komponent wyświetla komponent wyświetlający formularz do edcyji kontatku oraz link do głównej strony
export default function EditContactComponent(){
    const {email} = useParams();

    const [contactDetails, setContactDetails] = useState(null)

    useEffect(() => {
        getContactDetailsByEmail(email).then(response => {
            if (response){
                setContactDetails(response);
            }
        });
    }, [email]);
    return (
        <>
            <p>Edit Contact</p>
            {contactDetails && <FormComponent operation='put' initialData={contactDetails}/>}
            <Link to='/home'>Home</Link>
        </>
    );
}