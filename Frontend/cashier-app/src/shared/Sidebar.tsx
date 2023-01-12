import React from 'react'
import { Link } from 'react-router-dom'
import '../shared/Sidebar.css'
import AccessibilityNewIcon from '@mui/icons-material/AccessibilityNew';
import ReceiptOutlinedIcon from '@mui/icons-material/ReceiptOutlined';
import ScaleOutlinedIcon from '@mui/icons-material/ScaleOutlined';
import CategoryOutlinedIcon from '@mui/icons-material/CategoryOutlined';
import BarChartOutlinedIcon from '@mui/icons-material/BarChartOutlined';
function Sidebar() {
    return (
        <div className='sidebar col-2'>
            <ul className='navigation'>
                <Link className='navigation-link' to={'/dashboard'}>                    
                    <li className='navigation-item'>
                        <BarChartOutlinedIcon/>
                        <span>Dashboard</span>
                    </li>
                </Link>
                <Link className='navigation-link' to={'/customers'}>
                    <li className='navigation-item'>
                        <AccessibilityNewIcon/>
                        <span>Customers</span>
                    </li>
                </Link>
                <Link className='navigation-link' to={'/invoices'}>
                    <li className='navigation-item'>
                        <ReceiptOutlinedIcon/>
                        <span>Invoices</span>
                    </li>
                </Link>
                <Link className='navigation-link' to={'/units'}>
                    <li className='navigation-item'>
                        <ScaleOutlinedIcon/>
                        <span>Units of measurement</span>
                    </li>
                </Link>
                <Link className='navigation-link' to={'/products'}>
                    <li className='navigation-item'>
                        <CategoryOutlinedIcon/>
                        <span>Products</span>
                    </li>
                </Link>
            </ul>
        </div>
    )
}

export default Sidebar
