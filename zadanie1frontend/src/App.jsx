import Header from "./components/Header.jsx";
import ContactsListComponent from "./components/ContactsListComponent.jsx";
import {Routes, Route, Navigate} from 'react-router-dom'
import ContactDetailsComponent from "./components/ContactDetailsComponent.jsx";
import AddContactComponent from "./components/AddContactComponent.jsx";
import EditContactComponent from "./components/EditContactComponent.jsx";
// Komponent w którym zdefiniowany jest routing.
function App() {

  return (
    <>
        <Header/>
        <Routes>
        <Route path="/home" element={<ContactsListComponent/>}/>
            <Route path="/" element={<Navigate replace to="/home" />} />
        <Route path='/details/:email' element={<ContactDetailsComponent/>}/>
        <Route path='/add' element={<AddContactComponent/>}/>
        <Route path='/edit/:email' element={<EditContactComponent/>}/>
        </Routes>
    </>
  )
}

export default App
