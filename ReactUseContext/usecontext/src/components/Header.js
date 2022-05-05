import React from 'react'
import {MainContext,useContext} from '../context';

function Header() {
    const {theme}=useContext(MainContext)
  return (
    <div>
        Current theme={theme}
    </div>
  )
}

export default Header