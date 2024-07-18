const sendPostContactData = async (formData) => {
    const baseUrl = 'https://localhost:44373/api/Contact/add-contact';
    const dataToSend = {
        "Name": formData.name,
        "Surname": formData.surname,
        "Email": formData.email,
        "Password": formData.password,
        "PhoneNumber": formData.phoneNumber,
        "Birthday": formData.birthday,
        "Category": {
            "Name": formData.category.name
        },
        "SubCategory": {
            "CategoryName": formData.subCategory.categoryName,
            "Name": formData.subCategory.name
        }
    };

    dataToSend.SubCategory.CategoryName = formData.category.name;

    try {
        const response = await fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(dataToSend),
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data = await response.json();
        console.log('Success:', data);
    } catch (error) {
        console.error('Error:', error);
    }
};

export { sendPostContactData };