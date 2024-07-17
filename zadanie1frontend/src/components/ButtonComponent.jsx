import PropTypes from 'prop-types';

export default function ButtonComponent({ children, onClick }) {
    return (
        <button onClick={onClick}>{children}</button>
    );
}

ButtonComponent.propTypes = {
    children: PropTypes.node.isRequired,
    onClick: PropTypes.func,
};