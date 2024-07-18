import $ from 'jquery';
//funkcja uderza w endpoint w celu pobrania listy wszyskich kontaktów. Każdy kontakt zawiera w sobie ogólne dane.
const getAllContacts = () => {
    const baseUrl = 'https://localhost:44373/api/Contact/get-all';
    return $.get(baseUrl).then(response => {
        if (response.success && Array.isArray(response.data)) {
            return response.data.map(({ name, surname, email, phoneNumber, category }) => ({
                name,
                surname,
                email,
                phoneNumber,
                category : category.name
            }));
        } else {
            return [];
        }
    }).fail((jqXHR, textStatus, errorThrown) => {
        console.error("Could not fetch the data: ", textStatus, errorThrown);
        return [];
    });
};

export { getAllContacts };