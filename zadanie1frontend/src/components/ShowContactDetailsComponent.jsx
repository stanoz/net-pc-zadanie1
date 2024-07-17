import PropTypes from "prop-types";

export default function ShowContactDetailsComponent({name, surname, email, category, password, phoneNumber, birthday}){
    return (
        <>
            <p>{name}</p>
            <p>{surname}</p>
            <p>{email}</p>
            <p>{category.name}</p>
            <p>{password}</p>
            <p>{phoneNumber}</p>
            <p>{birthday}</p>
        </>
    );
}

ShowContactDetailsComponent.propTypes = {
    name: PropTypes.string.isRequired,
    surname: PropTypes.string.isRequired,
    email: PropTypes.string.isRequired,
    category: PropTypes.shape({
        name: PropTypes.string.isRequired
    }).isRequired,
    password: PropTypes.string.isRequired,
    phoneNumber: PropTypes.string.isRequired,
    birthday: PropTypes.string.isRequired,
};