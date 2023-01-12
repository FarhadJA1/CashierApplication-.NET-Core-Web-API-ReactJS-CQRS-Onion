import React from 'react'
import { useState, useEffect } from 'react';
import axios from 'axios';
import BasicTable from '../lib/BasicTable/Table';

function MeasureUnit() {
  const url = 'https://localhost:44348';
  const [units, setUnits] = useState([]);
  const [columns, setColumns] = useState<string[]>([]);
  const [id, setId] = useState(0);

  const inputTypesForUpdateModal = {
    name: 'Unit of Measurement',
  }

  function GetUnits() {
    axios.get(`${url}/api/MeasureUnit`)
      .then(res => {
        setUnits(res.data);
        setColumns(Object.keys(res.data[0]).slice(1, Object.keys(res.data[0]).length));
      })
  }


  function DeleteMeasureUnit() {
    axios.delete(`${url}/api/MeasureUnit/${id}`)
      .then(res => {
        setId(0)
        GetUnits()
      })
  }
  function UpdateUnit(values: any) {
    console.log(values);

  }

  useEffect(() => {
    GetUnits()
  }, [])
  return (
    <div className='col-10'>
      <BasicTable updateData={UpdateUnit} validation={{}} formikValues={{}} inputTypes={inputTypesForUpdateModal} delete={DeleteMeasureUnit} id={id} setId={setId} datas={units} columns={columns} />
    </div>
  )
}

export default MeasureUnit
