import { TextField } from '@mui/material'
import React from 'react'
import { useFormik } from 'formik';
import * as Yup from 'yup';


type CreateCustomerProps={
    createCustomer:(values:any)=>void;    
}

function CreateCustomerModal(props:CreateCustomerProps) {
    const formik = useFormik<{firstName:string,lastName:string,phoneNumber:string}>({
        initialValues:{
          firstName:"",
          lastName:"",
          phoneNumber:""
        },
        validationSchema:Yup.object({
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
        })
        ,
        onSubmit:(values):void=>{
            props.createCustomer(values);
            values.firstName='';
            values.lastName='';
            values.phoneNumber='';
        }
        
        
      })
      
    
    return (
        <div className='create-modal'>
            <button type="button" className="btn btn-outline-success" data-bs-toggle="modal" data-bs-target='#createModal'>
                Create
            </button>

            <div className="modal fade" id='createModal' tabIndex={-1} aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id="exampleModalLabel">Create</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <form onSubmit={formik.handleSubmit}>
                        <div className="modal-body">                            
                                <div style={{ justifyContent: 'center' }} className="row ms-1">
                                    <TextField sx={{ width: '70%' }} id="outlined-basic firstName" label="Name" variant="outlined"
                                        name='firstName'
                                        onChange={formik.handleChange}
                                        value={formik.values.firstName}
                                    />
                                    {formik.errors.firstName ? <p className='text-danger text-center'>{formik.errors.firstName}</p>:null}
                                </div>
                                <div style={{ justifyContent: 'center' }} className="row my-3 ms-1">
                                    <TextField sx={{ width: '70%' }} id="outlined-basic lastfirstName" label="Surname" variant="outlined"
                                        name='lastName'
                                        onChange={formik.handleChange}
                                        value={formik.values.lastName}
                                    />
                                    {formik.errors.lastName ? <p className='text-danger text-center'>{formik.errors.lastName}</p>:null}

                                </div>
                                <div style={{ justifyContent: 'center' }} className="row ms-1">
                                    <TextField sx={{ width: '70%' }} id="outlined-basic phoneNumber" label="Phone Number" variant="outlined"
                                        name='phoneNumber'
                                        onChange={formik.handleChange}
                                        value={formik.values.phoneNumber}
                                        
                                    />
                                    {formik.errors.phoneNumber ? <p className='text-danger text-center'>{formik.errors.phoneNumber}</p>:null}
                                </div>                          

                        </div>
                        <div className="modal-footer">
                            {Object.keys(formik.errors).length === 0 
                            ? 
                            <button type="submit" className="btn btn-outline-success" data-bs-dismiss="modal">Create</button>
                            :
                            <button type="submit" className="btn btn-outline-success">Create</button>
                            }
                            
                            <button type="button" className="btn btn-outline-secondary" data-bs-dismiss="modal">Cancel</button>
                        </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default CreateCustomerModal
