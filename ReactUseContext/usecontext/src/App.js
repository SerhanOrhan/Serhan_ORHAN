import {useEffect, useState} from 'react';
import Header from './components/Header';
import Footer from './components/Footer';
import {MainContext} from './context';

function App() {
  const [theme, setTheme]=useState('light')

  useEffect(()=>{
    document.body.className=theme
  },[theme])
  const data={
    theme,
    setTheme
  }
  return (
    <MainContext.Provider value={data} className="App">
      <Header/>
      <Footer/>
    </MainContext.Provider>
  );
}

export default App;
