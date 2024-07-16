import {useState, useEffect} from "react";
import ContactComponent from "./ContactComponent.jsx";
import {getAllContacts} from "../data/GetAllData.js";

export default function ContactsListComponent() {
    const [contacts, setContacts] = useState([]);

    useEffect(() => {
        getAllContacts().then(data => {
            setContacts(data);
        });
    }, []);

    return (
        <>
            <ul>
                {contacts.map((contact) => <ContactComponent key={contact.email} {...contact} />)}
            </ul>
        </>
    );
}