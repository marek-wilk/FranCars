import React from 'react'
import { Link } from 'react-router-dom';
import { NavItem, NavLink} from 'reactstrap';

const NavLogin = (props) => {
    const {id, setId} = props
    const logout = async () => {
      await fetch('http://localhost:18350/auth/logout', {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        credentials: 'include'
      })
      setId(0)
    }
    if(id === 0) {
      return (    
      <ul className="navbar-nav flex-grow">
        <NavItem>
          <NavLink tag={Link} className="text-dark" to="/login">Login</NavLink>
        </NavItem>
        <NavItem>
          <NavLink tag={Link} className="text-dark" to="/register">Register</NavLink>
        </NavItem>
      </ul>
      )} 
    else {
      console.log(`id: ${id}`)
    return (
      <ul className="navbar-nav flex-grow">
        <NavItem>
          <NavLink tag={Link} className="text-dark" to={`/cart/${id}`}>Your Cart</NavLink>
        </NavItem>
        <NavItem>
          <NavLink tag={Link} className="text-dark" to="/login" onClick={logout}>Logout</NavLink>
        </NavItem>
      </ul>
    )
  }
}
export default NavLogin;