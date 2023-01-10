import React from 'react'
import ContainerHeader from '../../lib/ContainerHeader/ContainerHeader'
import LoginInputs from './LoginInputs'

function LoginContainer() {
  return (
    <div className='login-container'>
      <div>
        <ContainerHeader text='Sign In'/>
        <LoginInputs/>
      </div>
    </div>
  )
}

export default LoginContainer
