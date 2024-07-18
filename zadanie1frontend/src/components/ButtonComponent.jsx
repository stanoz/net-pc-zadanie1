import PropTypes from 'prop-types';
// Komponent służący jako przycisk, przyjmuje operację obłsugującą kliknięcie
export default function ButtonComponent({ children, onClick }) {
    return (
        <button onClick={onClick}>{children}</button>
    );
}

ButtonComponent.propTypes = {
    children: PropTypes.node.isRequired,
    onClick: PropTypes.func,
};