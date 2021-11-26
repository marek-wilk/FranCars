import React, { useState, useEffect } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Vehicles from './components/Vehicles';
import Details from './components/Details';
import Login from './components/Login'
import Register from './components/Register';
import AuthContext from  './components/AuthContext'

import './custom.css'

const App = () => {
  const [email, setEmail] = useState('');
    
  useEffect(() => {
    (
      async() => {
        const response = await fetch('http://localhost:18350/auth/user', {
        headers: {'Content-Type': 'application/json'},
        credentials: 'include'
      })
      const content = await response.json()
      if(typeof content.email === 'undefined') {
        setEmail('')
      } else {
        setEmail(content.email)
      }
    }
    )()
  })

  return (
    <AuthContext.Provider value={email}>
      <Layout>
        <Route exact path='/'>
          <Vehicles />
        </Route>
        <Route path='/details/:id'>
          <Details />
        </Route>
        <Route path='/login'>
          <Login />
        </Route>
        <Route path='/register'>
          <Register />
        </Route>
      </Layout>
    </AuthContext.Provider>
  );
}

export default App;