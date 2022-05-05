import React from 'react'
import {MainContext,useContext} from '../context'

function ThemeSwitcher() {
    const switchTheme = () => {
        setTheme(theme === 'light' ? 'dark' : 'light')
      }
      const {theme,setTheme}=useContext(MainContext)
  return (
    <div>
      <button onClick={switchTheme}>Switch theme</button>

    </div>
  )
}

export default ThemeSwitcher