import $ from 'jquery';
// funkcja uderza w endpoint w celu pobrania szczegółowych danych o kontakcie o podanym adresie email
function getContactDetailsByEmail(email) {
    const baseUrl = 'https://localhost:44373/api/Contact/get-contact-';
    const urlWithParam = `${baseUrl}${encodeURIComponent(email)}`;

    return $.get(urlWithParam).then(response => {
        if (response.success && response.data) {
            return response.data;
        } else {
            return {};
        }
    }).fail((jqXHR, textStatus, errorThrown) => {
        console.error("Error fetching contact details: ", textStatus, errorThrown);
        return {};
    });
}

export { getContactDetailsByEmail };