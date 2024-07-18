import {useEffect, useState} from 'react';
import {getAllCategories} from "../data/GetAllCategories.js";
import {getAllSubCategories} from "../data/GetAllSubCategories.js";
import {sendPostContactData} from "../data/SendPostData.js";
import {useNavigate} from 'react-router-dom';
import PropTypes from "prop-types";
import {sendPutContactData} from "../data/SendPutData.js";

export default function FormComponent({operation, initialData}) {
    const navigate = useNavigate();

    const [formData, setFormData] = useState({
        name: initialData?.name || '',
        surname: initialData?.surname || '',
        email: initialData?.email || '',
        password: initialData?.password || '',
        phoneNumber: initialData?.phoneNumber || '',
        birthday: initialData?.birthday || '',
        category: { name: initialData?.category?.name || '' },
        subCategory: { categoryName: initialData?.subCategory?.categoryName || '', name: initialData?.subCategory?.name || '' }
    });

    const [categories, setCategories] = useState([]);
    const [subCategories, setSubCategories] = useState([]);
    const [isSubCategoryInput, setIsSubCategoryInput] = useState(false);

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
                setIsSubCategoryInput(formData.category.name === "inny");
            });
        } else {
            setSubCategories([]);
            setIsSubCategoryInput(false);
        }
    }, [formData.category.name]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        if (name === 'categoryName') {
            setFormData(prevState => ({
                ...prevState,
                category: { name: value },
                subCategory: { categoryName: '', name: '' }
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
        if (operation === 'post'){
            sendPostContactData(formData, () => navigate('/home'));
        }else {
            sendPutContactData(formData, () => navigate('/home'));
        }
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
            {subCategories.length > 0 && (
                <div>
                    <label htmlFor="subCategoryName">SubCategory Name:</label>
                    <select id="subCategoryName" name="subCategoryName" value={formData.subCategory.name} onChange={handleChange}>
                        <option value="">Select a SubCategory</option>
                        {subCategories.map(subCategory => (
                            <option key={subCategory.name} value={subCategory.name}>{subCategory.name}</option>
                        ))}
                    </select>
                </div>
            )}
            {isSubCategoryInput && (
                <div>
                    <label htmlFor="subCategoryName">SubCategory Name:</label>
                    <input type="text" id="subCategoryName" name="subCategoryName" value={formData.subCategory.name} onChange={handleChange} />
                </div>
            )}
            <button type="submit">Submit</button>
        </form>
    );
}

FormComponent.propTypes = {
    operation: PropTypes.string.isRequired,
    initialData: PropTypes.object
};