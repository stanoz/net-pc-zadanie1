// funkcja uderza w endpoint do edycji kontaktu o podanym adresie email, kontakt z
// nowymi danymi jest przesyłany w formacie json
const sendPutContactData = async (formData, onSuccess) => {
    const baseUrl = 'https://localhost:44373/api/Contact/edit-contact-';
    const urlWithParam = `${baseUrl}${encodeURIComponent(formData.email)}`;
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
        const response = await fetch(urlWithParam, {
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
        onSuccess();
    } catch (error) {
        console.error('Error:', error);
    }
};

export { sendPutContactData };