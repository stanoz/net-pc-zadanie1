import $ from 'jquery';

function deleteContactByEmail(email) {
    const baseUrl = 'https://localhost:44373/api/Contact/delete-contact-';
    const urlWithParam = `${baseUrl}${encodeURIComponent(email)}`;

    return $.ajax({
        url: urlWithParam,
        type: 'DELETE',
        success: function(response) {
            if (response.success && response.data) {
                return response.data;
            } else {
                return {};
            }
        },
        error: function(jqXHR, textStatus, errorThrown) {
            console.error("Error deleting contact: ", textStatus, errorThrown);
            return {};
        }
    });
}

export { deleteContactByEmail };