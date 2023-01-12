import React from 'react'
import { useState, useEffect } from 'react';
import axios from 'axios';
import BasicTable from '../lib/BasicTable/Table';



function Invoice() {
  const url = 'https://localhost:44348';
  const [invoices, setInvoices] = useState([]);
  const [columns, setColumns] = useState<string[]>([]);
  const [id,setId] = useState(0);

  async function GetInvoices() {
    await axios.get(`${url}/api/Invoice`)
      .then(res => {
        setInvoices(res.data);        
        setColumns(Object.keys(res.data[0]).slice(1,Object.keys(res.data[0]).length));        
    })
  }
  function DeleteInvoice() {
    axios.delete(`${url}/api/Invoice/${id}`)
      .then(res => {
        setId(0)
        GetInvoices()        
    })
  }
  function UpdateInvoice(values:any) {
      console.log(values);
      
  }

  useEffect(() => {
    GetInvoices()
  }, [])
  return (
    <div className='col-10'>
      <BasicTable updateData={UpdateInvoice} validation={{}} formikValues={{}} inputTypes={{}} delete={DeleteInvoice} id={id} setId={setId} datas={invoices} columns={columns}/>
    </div>
  )
}

export default Invoice
