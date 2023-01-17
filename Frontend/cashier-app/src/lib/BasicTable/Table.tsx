import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import DetailsModal from '../Modals/DetailsModal';
import BarcodeGenerator from '../../shared/BarcodeGenerator';
import DeleteModal from '../Modals/DeleteModal';
import UpdateModal from '../Modals/UpdateModal';
import { IFormikValue } from '../../pages/Customer';

function SplitStringInCondition(str: string) {
  return str.split(/(?=[A-Z])/).join(' ');
}

type BasicTableProps = {
  columns: string[],
  datas: Array<any>,
  id:number,
  setId:(id:number)=>void
  delete:()=>void

  inputTypes:object,
  formikValues:IFormikValue,
  validation:object,
  updateData:(values:any)=>void

}


export default function BasicTable(props: BasicTableProps) {
  let thKey = 0;
  let tdKey = 0;
  
  let count = 1;
  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell align='center'>#</TableCell>
            {props.columns.map(column => {
              if (column !== 'details') {
                return <TableCell sx={{height: '60px'}} key={thKey++} align='center'>{column[0].toUpperCase() +
                  SplitStringInCondition(column.slice(1))}</TableCell>
              }
            })}
            <TableCell align='center'>
              Settings
            </TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {props.datas.map((data) => (
            <TableRow
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
              key={data.id}
            >
              <TableCell sx={{height: '60px'}} align='center'>
                {count++}
              </TableCell>
              {
                Object.entries(data).slice(1).map((a: any) => {
                  if (a[0] !== 'details') {
                    return a[0] === 'barcode'
                      ?
                      <TableCell sx={{height: '60px', padding: 0}} key={tdKey++} align='center'>
                        <BarcodeGenerator width={1} height={20} fontSize={12} data={a[1]} />
                      </TableCell>
                      :
                      <TableCell sx={{height: '60px'}} key={tdKey++} align='center'>
                        {a[1]}
                      </TableCell>
                  }
                }
                )
              }
              <TableCell sx={{height: '60px'}} style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }} height={200} align='center'>
                {Object.keys(data).includes('details') || Object.keys(data).includes('barcode') ? <DetailsModal datas={props.datas} /> : ""}
                <DeleteModal delete={props.delete} setId={props.setId} id={data.id}/>
                <UpdateModal updateData={props.updateData} validation={props.validation} inputTypes={props.inputTypes} formikValues={props.formikValues}/>
              </TableCell>
            </TableRow>

          ))}

        </TableBody>
      </Table>
    </TableContainer>

  );
}