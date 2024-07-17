import {Link} from "react-router-dom";
import {useParams} from "react-router-dom";
import {useState, useEffect} from "react";
import {getContactDetailsByEmail} from "../data/GetContactDetails.js";
import ShowContactDetailsComponent from "./ShowContactDetailsComponent.jsx";

export default function ContactDetailsComponent(){
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
            {contactDetails ? (
                <div>
                    <ShowContactDetailsComponent {...contactDetails}/>
                    <Link to='/home'>Home</Link>
                </div>
            ) : (
                <div>
                <p>Loading contact details...</p>
                <Link to='/home'>Home</Link>
                </div>
            )}
        </>
    );
}