import React from 'react'
import Sidebar from './Sidebar'
import { Outlet } from "react-router-dom";

function Main() {
    return (
        <div className="container-fluid">
            <div className='row'>
                <Sidebar />
                <Outlet />
            </div>
        </div>        
    )
}

export default Main
