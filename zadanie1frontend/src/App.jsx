// import './App.css'
import Header from "./components/Header.jsx";
import ContactsListComponent from "./components/ContactsListComponent.jsx";
import {Routes, Route, Navigate} from 'react-router-dom'

function App() {

  return (
    <>
        <Header/>
        <Routes>
        <Route path="/home" element={<ContactsListComponent/>}/>
            <Route path="/" element={<Navigate replace to="/home" />} />
        </Routes>
    </>
  )
}

export default App
