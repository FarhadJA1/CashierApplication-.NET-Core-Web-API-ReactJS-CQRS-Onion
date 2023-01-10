import React from 'react'
import { Link } from 'react-router-dom'
import '../shared/Sidebar.css'
function Sidebar() {
    return (
        <div className='sidebar col-2'>
            <ul className='navigation'>
                <Link className='navigation-link' to={'/dashboard'}>
                    <li className='navigation-item'>
                        <p>Dashboard</p>
                    </li>
                </Link>
                <Link className='navigation-link' to={'/customers'}>
                    <li className='navigation-item'>
                        <p>Customers</p>
                    </li>
                </Link>
                <Link className='navigation-link' to={'/invoices'}>
                    <li className='navigation-item'>
                        <p>Invoices</p>
                    </li>
                </Link>
                <Link className='navigation-link' to={'/units'}>
                    <li className='navigation-item'>
                        <p>Units of measurement</p>
                    </li>
                </Link>
                <Link className='navigation-link' to={'/products'}>
                    <li className='navigation-item'>
                        <p>Products</p>
                    </li>
                </Link>
            </ul>
        </div>
    )
}

export default Sidebar
