import { Box } from '@mui/material'
import Button from '@mui/material/Button'
import TextField from '@mui/material/TextField'
import React from 'react'
import { Link } from 'react-router-dom'

function LoginInputs() {
  return (
    <Box
            component="form"
            noValidate
            autoComplete="off"
            sx={{ height: '50%' }}
        >
            <div className='login-inputs-area'>
                <div className='login-inputs'>
                    <TextField sx={{ width: 1, }}  label="Username or Email" variant="outlined" />
                    <TextField type={'password'} className='password-input' sx={{ width: 1, }}  label="Password" variant="outlined" />
                    <div className='login-buttons-area'>
                        <Button variant="outlined" color="success">Sign In</Button>
                        {/* <Link className='link-button' to={'/register'}>
                            <Button variant="outlined" color="info">Sign Up</Button>                           
                        </Link>                         */}
                    </div>
                </div>
            </div>
        </Box>
  )
}

export default LoginInputs
