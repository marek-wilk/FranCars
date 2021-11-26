import React, { useState, useEffect } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Vehicles from './components/Vehicles';
import Details from './components/Details';
import Login from './components/Login'
import Register from './components/Register';
import AuthContext from  './components/AuthContext'
import Cart from './components/Cart'

import './custom.css'

const App = () => {
  const [id, setId] = useState(0);
    
  useEffect(() => {
    (
      async() => {
        const response = await fetch('http://localhost:18350/auth/user', {
        headers: {'Content-Type': 'application/json'},
        credentials: 'include'
      })
      const content = await response.json()
      if(typeof content.id === 'undefined') {
        setId(0)
        console.log(`I fired: ${id}`)
      } else {
        setId(content.id)
      }
    }
    )()
  })

  return (
    <AuthContext.Provider value={id}>
      <Layout setId={() => setId()}>
        <Route exact path='/'>
          <Vehicles />
        </Route>
        <Route path='/details/:id'>
          <Details id={id}/>
        </Route>
        <Route path='/login' >
          <Login setId={() => setId()}/>
        </Route>
        <Route path='/register'>
          <Register />
        </Route>
        <Route path="/cart/:id">
          <Cart />
        </Route>
      </Layout>
    </AuthContext.Provider>
  );
}

export default App;