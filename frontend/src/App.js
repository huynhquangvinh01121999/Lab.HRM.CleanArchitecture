import React from 'react'
import 'react-toastify/dist/ReactToastify.css';
import {
  BrowserRouter,
  Routes,
  Route,
  Link,
  Outlet
} from 'react-router-dom';
import Nav from "./app/layout/Nav"
import Login from './features/Components/Login'
import Home from './features/Components/Home'
import { ToastContainer } from 'react-toastify';

function App() {
  return (
    <>
      <Nav />
      <BrowserRouter>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/" element={<Home />} />
        </Routes>
      </BrowserRouter>
      <ToastContainer />
    </>
  )
}

export default App