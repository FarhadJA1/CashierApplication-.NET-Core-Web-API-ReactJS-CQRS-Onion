import React from 'react'
import '../ContainerHeader/ContainerHeader.css'

type ContainerHeaderProps={
    text:string,
}

function ContainerHeader(props:ContainerHeaderProps) {
  return (
    <div>
      <h1 className='container-header'>{props.text}</h1>
    </div>
  )
}

export default ContainerHeader
