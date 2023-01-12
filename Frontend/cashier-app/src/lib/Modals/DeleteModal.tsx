import React from 'react'

type DeleteModalProps={
    setId:(id:number)=>void
    delete:()=>void
    id:number
}

function DeleteModal(props:DeleteModalProps) {    
  return (
    <div className='delete-modal mx-1'>
            <button onClick={()=>props.setId(props.id)}  type="button" className="btn btn-outline-danger" data-bs-toggle="modal" data-bs-target={`#deleteModal${props.id}`}>
                Delete
            </button>

            <div className="modal fade" id={`deleteModal${props.id}`} tabIndex={-1} aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id="exampleModalLabel">Details</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                            <h6>Are you sure to permanently delete this data?</h6>                            
                        </div>
                        <div className="modal-footer">
                            <button onClick={()=>props.delete()} type="button" className="btn btn-outline-danger" data-bs-dismiss="modal">Delete</button>
                            <button type="button" className="btn btn-outline-secondary" data-bs-dismiss="modal">Cancel</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
  )
}

export default DeleteModal
