import React from 'react';
import './App.css';
import LoginPage from './pages/LoginPage';
import { Route, BrowserRouter as Router, Routes, } from "react-router-dom";
import Dashboard from './pages/Dashboard';
import Product from './pages/Product';
import Invoice from './pages/Invoice';
import MeasureUnit from './pages/MeasureUnit';
import Customer from './pages/Customer';
import Sidebar from './shared/Sidebar';
import Main from './shared/Main';

function App() {
  return (
    <div className="App">
      <Router>
        <Routes>
          <Route path='/' element={<LoginPage />} />
          <Route element={<Main />}>
            <Route path='/dashboard' element={<Dashboard />} />
            <Route path='/products' element={<Product />} />
            <Route path='/invoices' element={<Invoice />} />
            <Route path='/units' element={<MeasureUnit />} />
            <Route path='/customers' element={<Customer />} />
          </Route>
        </Routes>
      </Router>

    </div>
  );
}

export default App;
