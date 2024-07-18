import {useState, useEffect} from "react";
import ContactComponent from "./ContactComponent.jsx";
import {getAllContacts} from "../data/GetAllData.js";
import {Link} from "react-router-dom";
// Komponent wyświetla komponent służący do wyświetlania ogólnych danych o kontakcie oraz
// link do doadania nowego kontaktu
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
                <>
                    <ul>
                        {contacts.map((contact) => <ContactComponent key={contact.email} {...contact}
                                                                     onDelete={refreshContacts}/>)}
                    </ul>
                    <Link to='/add'>Add new contact</Link>
                </>
            ) : (
                <>
                    <p>No contacts found!</p>
                    <Link to='/add'>Add new contact</Link>
                </>
            )}
        </>
    );
}