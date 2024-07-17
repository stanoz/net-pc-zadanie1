import $ from 'jquery';

const getAllSubCategories = () => {
    const baseUrl = 'https://localhost:44373/api/SubCategory/get-all';
    return $.get(baseUrl).then(response => {
        if (response.success && Array.isArray(response.data)) {
            return response.data.map(subCategory => ({
                [subCategory.categoryName]: subCategory.name
            }));
        } else {
            return [];
        }
    }).fail((jqXHR, textStatus, errorThrown) => {
        console.error("Could not fetch the data: ", textStatus, errorThrown);
        return [];
    });
};

export { getAllSubCategories };