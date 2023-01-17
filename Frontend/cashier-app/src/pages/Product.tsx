import React from 'react'
import { useState, useEffect } from 'react';
import axios from 'axios';
import BasicTable from '../lib/BasicTable/Table';
import BarcodeGenerator from '../shared/BarcodeGenerator';
import { IFormikValue } from './Customer';

function Product() {
  const url = 'https://localhost:44348';
  const [products, setProducts] = useState([]);
  const [columns, setColumns] = useState<string[]>([]);
  const [id,setId] = useState(0);


  const formikValues:IFormikValue={
    firstName:'',
    lastName:'',
    phoneNumber:''
  }

  async function GetProducts() {
    await axios.get(`${url}/api/Product`)
      .then(res => {        
        setProducts(res.data);        
        setColumns(Object.keys(res.data[0]).slice(1,Object.keys(res.data[0]).length));        
    })
  }

  async function DeleteProduct() {
    await axios.delete(`${url}/api/MeasureUnit/${id}`)
      .then(res => {
        setId(0)
        GetProducts()        
    })
  }

  function UpdateProduct(values: any) {
    console.log(values);

  }

  useEffect(() => {
    GetProducts()
  }, [])
  return (
    <div className='col-10'>
      <BasicTable updateData={UpdateProduct} validation={{}} formikValues={formikValues} inputTypes={{}} delete={DeleteProduct} id={id} setId={setId} datas={products} columns={columns}/>
    </div>
  )
}


export default Product
