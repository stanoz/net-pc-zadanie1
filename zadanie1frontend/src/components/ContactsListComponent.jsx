import {useState, useEffect} from "react";
import ContactComponent from "./ContactComponent.jsx";
import {getAllContacts} from "../data/GetAllData.js";

export default function ContactsListComponent() {
    const [contacts, setContacts] = useState([]);

    useEffect(() => {
        refreshContacts();
    }, []);

    const refreshContacts = () => {
        getAllContacts().then(data => {
            setContacts(data);
        });
    };

    useEffect(() => {
        getAllContacts().then(data => {
            setContacts(data);
        });
    }, []);

    return (
        <>
            {contacts ? (
                <ul>
                    {contacts.map((contact) => <ContactComponent key={contact.email} {...contact} onDelete={refreshContacts} />)}
                </ul>
            ) : (
                <p>No contacts found!</p>
            )}
        </>
    );
}