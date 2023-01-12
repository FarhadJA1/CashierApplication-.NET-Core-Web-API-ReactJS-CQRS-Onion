import React from 'react';
import BasicTable from '../lib/BasicTable/Table'
import { useState, useEffect } from 'react';
import axios from 'axios';
import CreateCustomerModal from '../components/Customer/CreateCustomerModal';
import * as Yup from 'yup';

function Customer() {
  const url = 'https://localhost:44348';
  const [customers, setCustomers] = useState([]); 
  const [columns, setColumns] = useState<string[]>([]);
  const [id, setId] = useState(0);
  
  const inputTypesForUpdateModal={
    firstName:'First Name',
    lastName:'Last Name',
    phoneNumber:'Phone Number'
  }

  const formikValues={
    firstName:'',
    lastName:'',
    phoneNumber:''
  }

  const validation = {
    firstName:Yup.string()
    .max(20,'Firstname field must be less than 20 characters')
    .required('Firstname field is required'),
    lastName:Yup.string()
    .max(30,'Lastname field must be less than 30 characters')
    .required('Lastname field is required'),
    phoneNumber:Yup.string()
    .max(30,'Phone Number field must be less than 50 characters')
    .required('Phone Number field is required')
    .matches(/^\d+$/,'Phone Number field is not in correct format')
  }

  useEffect(() => {
    GetCustomers()
  }, [])

  function GetCustomers() {
    axios.get(`${url}/api/Customer`)
      .then(res => {
        setCustomers(res.data);
        setColumns(Object.keys(res.data[0]).slice(1, Object.keys(res.data[0]).length));
      })
  }


  function DeleteCustomer() {
    axios.delete(`${url}/api/Customer/${id}`)
      .then(res => {
        setId(0);
        GetCustomers();
      })
  }

 function CreateCustomer(values:any) {      
    axios.post(`${url}/api/Customer`, {
      name: values.firstName,
      surname: values.lastName,
      phoneNumber: values.phoneNumber
    })
    .then(res => {
       GetCustomers();  
    })
  }

  function UpdateCustomer(values:any) {
    debugger
      console.log(values);
      
  }


  return (
    <div className='col-10'>
      <div className='my-4 me-5' style={{display:'flex',justifyContent:'end'}}>
        <CreateCustomerModal createCustomer={CreateCustomer}/>
      </div>
      <BasicTable updateData={UpdateCustomer}  validation={validation} delete={DeleteCustomer} id={id} setId={setId} datas={customers} columns={columns} 
          inputTypes={inputTypesForUpdateModal} formikValues={formikValues}
      />
    </div>
  )
}

export default Customer
