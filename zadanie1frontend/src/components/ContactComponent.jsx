import PropTypes from "prop-types";
import ButtonComponent from "./ButtonComponent.jsx";
import {Link} from "react-router-dom"

export default function ContactComponent({name, surname, email, phoneNumber}){
    return (
        <li>
            <p>{name}</p>
            <p>{surname}</p>
            <p>{email}</p>
            <p>{phoneNumber}</p>
            {/*<Link to='/details'>Show details</Link>*/}
            {/*<Link to='/edit'>Edit</Link>*/}
            <ButtonComponent>Delete</ButtonComponent>
        </li>
    );
}

ContactComponent.propTypes = {
    name: PropTypes.string.isRequired,
    surname: PropTypes.string.isRequired,
    email: PropTypes.string.isRequired,
    phoneNumber: PropTypes.string.isRequired,
};