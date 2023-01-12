import { type } from '@testing-library/user-event/dist/type';
import React ,{useState} from 'react'
import Barcode, { BarcodeProps } from 'react-barcode';

type BarcodeGeneratorProps= Omit<BarcodeProps, 'value'> & {
    data:string
}
function BarcodeGenerator({data, width = 1, height = 50, ...rest}:BarcodeGeneratorProps) {
   
  return (
    <div>
      <Barcode {...rest} width={width} height={height} value={data}/>
    </div>
  )
}

export default BarcodeGenerator
