import React from 'react';
import ReactDOM from 'react-dom';
import './Header.css';

class Header extends React.Component{
    render() {
        return (
            <nav className="header">
                <h1 className="header__logo">Job Application</h1>
            </nav>
        );
    }

}
export default Header;
