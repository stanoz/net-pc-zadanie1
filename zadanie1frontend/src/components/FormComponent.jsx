import {useEffect, useState} from 'react';
import {getAllCategories} from "../data/GetAllCategories.js";
import {getAllSubCategories} from "../data/GetAllSubCategories.js";

export default function FormComponent() {
    const [formData, setFormData] = useState({
        name: '',
        surname: '',
        email: '',
        password: '',
        phoneNumber: '',
        birthday: '',
        category: { name: '' },
        subCategory: { categoryName: '', name: '' }
    });

    const [categories, setCategories] = useState([]);
    const [subCategories, setSubCategories] = useState([]);

    useEffect(() => {
        getAllCategories().then(data => {
            setCategories(data);
        });
    }, []);

    useEffect(() => {
        if (formData.category.name) {
            getAllSubCategories().then(data => {
                const filteredSubCategories = data.filter(subCategory => Object.keys(subCategory)[0] === formData.category.name);
                setSubCategories(filteredSubCategories.map(subCategory => ({ name: subCategory[formData.category.name] })));
            });
        }
    }, [formData.category.name]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        if (name === 'categoryName') {
            setFormData(prevState => ({
                ...prevState,
                category: { name: value },
                subCategory: { categoryName: '', name: '' } // Reset subCategory when category changes
            }));
        } else if (name === 'subCategoryName') {
            setFormData(prevState => ({
                ...prevState,
                subCategory: { ...prevState.subCategory, name: value }
            }));
        } else {
            setFormData(prevState => ({
                ...prevState,
                [name]: value
            }));
        }
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log('Form data submitted:', formData);
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label htmlFor="name">Name:</label>
                <input type="text" id="name" name="name" value={formData.name} onChange={handleChange} />
            </div>
            <div>
                <label htmlFor="surname">Surname:</label>
                <input type="text" id="surname" name="surname" value={formData.surname} onChange={handleChange} />
            </div>
            <div>
                <label htmlFor="email">Email:</label>
                <input type="email" id="email" name="email" value={formData.email} onChange={handleChange} />
            </div>
            <div>
                <label htmlFor="password">Password:</label>
                <input type="password" id="password" name="password" value={formData.password} onChange={handleChange} />
            </div>
            <div>
                <label htmlFor="phoneNumber">Phone Number:</label>
                <input type="text" id="phoneNumber" name="phoneNumber" value={formData.phoneNumber} onChange={handleChange} />
            </div>
            <div>
                <label htmlFor="birthday">Birthday:</label>
                <input type="date" id="birthday" name="birthday" value={formData.birthday} onChange={handleChange} />
            </div>
            <div>
                <label htmlFor="categoryName">Category Name:</label>
                <select id="categoryName" name="categoryName" value={formData.category.name} onChange={handleChange}>
                    <option value="">Select a Category</option>
                    {categories.map(category => (
                        <option key={category.name} value={category.name}>{category.name}</option>
                    ))}
                </select>
            </div>
            <div>
                <label htmlFor="subCategoryName">SubCategory Name:</label>
                <select id="subCategoryName" name="subCategoryName" value={formData.subCategory.name}
                        onChange={handleChange}>
                    <option value="">Select a SubCategory</option>
                    {subCategories.map(subCategory => (
                        <option key={subCategory.name} value={subCategory.name}>{subCategory.name}</option>
                    ))}
                </select>
            </div>
            <button type="submit">Submit</button>
        </form>
    );
}