import PropTypes from "prop-types";

export default function ContactComponent({name, surname, email, phoneNumber}){
    return (
        <li>
            <h3>{name}</h3>
            <h3>{surname}</h3>
            <p>{email}</p>
            <p>{phoneNumber}</p>
        </li>
    );
}

ContactComponent.propTypes = {
    name: PropTypes.string.isRequired,
    surname: PropTypes.string.isRequired,
    email: PropTypes.string.isRequired,
    phoneNumber: PropTypes.string.isRequired,
};