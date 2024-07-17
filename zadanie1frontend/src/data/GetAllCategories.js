import $ from 'jquery';

const getAllCategories = () => {
    const baseUrl = 'https://localhost:44373/api/Category/get-all';
    return $.get(baseUrl).then(response => {
        if (response.success && Array.isArray(response.data)) {
            return response.data.map(({ name }) => ({
                name
            }));
        } else {
            return [];
        }
    }).fail((jqXHR, textStatus, errorThrown) => {
        console.error("Could not fetch the data: ", textStatus, errorThrown);
        return [];
    });
};

export { getAllCategories };