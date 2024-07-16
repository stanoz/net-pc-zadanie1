import {getAllContacts} from "../data/GetAllData.js";

export default function ListComponent() {
    return (
        <>
            <ul>
                {getAllContacts.map(contact => )}
            </ul>
        </>
    );
}