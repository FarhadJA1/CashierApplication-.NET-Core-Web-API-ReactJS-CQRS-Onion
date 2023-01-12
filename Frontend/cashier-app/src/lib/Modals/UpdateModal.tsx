import { TextField } from '@mui/material';
import React from 'react'
import { useFormik } from 'formik';
import * as Yup from 'yup';

type UpdateModalProps = {
    inputTypes: object,
    formikValues: object,
    validation: any,
    updateData: (values: any) => void
}

function UpdateModal(props: UpdateModalProps) {
    let updateModalCount = 1;
    const formik = useFormik({
        initialValues: props.formikValues,
        validationSchema: Yup.object(props.validation)
        ,
        onSubmit: (values): void => {
            props.updateData(values);
            // values.firstName='';
            // values.lastName='';
            // values.phoneNumber='';
        }
    })


    return (
        <div className='update-modal'>
            <button type="button" className="btn btn-outline-warning" data-bs-toggle="modal" data-bs-target={`#updateModal${updateModalCount}`}>
                Update
            </button>

            <div className="modal fade" id={`updateModal${updateModalCount}`} tabIndex={-1} aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id="exampleModalLabel">Update</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <form onSubmit={formik.handleSubmit}>
                            <div className="modal-body">
                                {Object.entries(props.inputTypes).map((input, index) => {
                                    return <TextField sx={{ width: '70%' }} id={`outlined-basic ${input[0]}`}
                                        className='mt-2'
                                        label={`${input[1]}`} variant="outlined"
                                        name={`${input[0]}`}
                                        key={`${input[0]}`}
                                        onChange={formik.handleChange}
                                        value={Object.keys(formik.values)[input[index]]}
                                    />
                                })}
                            </div>
                            <div className="modal-footer">
                                <button type="submit" className="btn btn-outline-warning" data-bs-dismiss="modal">Update</button>
                                <button type="button" className="btn btn-outline-secondary" data-bs-dismiss="modal">Go back</button>
                            </div>
                        </form>

                    </div>
                </div>
            </div>
        </div>

    )
}

export default UpdateModal
