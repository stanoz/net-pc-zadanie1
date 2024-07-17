import PropTypes from "prop-types";
import ButtonComponent from "./ButtonComponent.jsx";
import {Link} from "react-router-dom"
import {deleteContactByEmail} from "../data/DeleteContact.js";

export default function ContactComponent({name, surname, email, phoneNumber, category, onDelete}){
    const handleDelete = () => {
        deleteContactByEmail(email).then(() => {
            onDelete();
        });
    }

    return (
        <li>
            <p>{name}</p>
            <p>{surname}</p>
            <p>{email}</p>
            <p>{phoneNumber}</p>
            <p>{category}</p>
            <Link to={`/details/${email}`}>Show details</Link>
            {/*<Link to='/edit'>Edit</Link>*/}
            <ButtonComponent onClick={handleDelete}>Delete</ButtonComponent>
        </li>
    );
}

ContactComponent.propTypes = {
    name: PropTypes.string.isRequired,
    surname: PropTypes.string.isRequired,
    email: PropTypes.string.isRequired,
    phoneNumber: PropTypes.string.isRequired,
    category: PropTypes.string.isRequired,
    onDelete: PropTypes.func,
};