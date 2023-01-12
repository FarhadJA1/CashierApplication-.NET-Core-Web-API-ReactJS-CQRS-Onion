import React from 'react'
import '../../assets/style/components/details-modal.css'

type DetailsModalProps = {
    datas: Array<any>
}

function DetailsModal(props: DetailsModalProps) {
    let count = 1;
    let modalKey = 0;
    
    return (
        <div className='details-modal'>
            <button type="button" className="btn btn-outline-info" data-bs-toggle="modal" data-bs-target={`#detailsModal${count}`}>
                Details
            </button>

            <div className="modal fade" id={`detailsModal${count}`} tabIndex={-1} aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id="exampleModalLabel">Details</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                            {props.datas.map(data =>{
                                return Object.entries(data).slice(1).map((a: any) => {
                                    if (a[0] !== 'id') {
                                        return <p key={modalKey++}>{count++} - {a[1]}</p>
                                    }
                                })
                            })}
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-outline-primary" data-bs-dismiss="modal">Go back</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    )
}

export default DetailsModal
