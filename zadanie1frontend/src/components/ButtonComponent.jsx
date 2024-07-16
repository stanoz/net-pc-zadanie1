import PropTypes from 'prop-types';

export default function ButtonComponent({ children }) {
    return (
        <button>{children}</button>
    );
}

ButtonComponent.propTypes = {
    children: PropTypes.node.isRequired,
};