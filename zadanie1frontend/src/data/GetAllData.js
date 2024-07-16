import $ from 'jquery';

const getAllContacts = () => {
    const baseUrl = 'https://localhost:44373/api/Contact/get-all';
    return $.get(baseUrl).then(response => {
        // Check if the response is successful and contains data
        if (response.success && Array.isArray(response.data)) {
            // Transform the data to only include relevant fields
            return response.data.map(({ name, surname, email, phoneNumber }) => ({
                name,
                surname,
                email,
                phoneNumber
            }));
        } else {
            // Handle cases where the response does not contain the expected data
            console.error("Unexpected response format or unsuccessful response");
            return [];
        }
    }).fail((jqXHR, textStatus, errorThrown) => {
        console.error("Could not fetch the data: ", textStatus, errorThrown);
        return [];
    });
};

export { getAllContacts };