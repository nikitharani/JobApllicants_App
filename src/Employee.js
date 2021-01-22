import React, { Component } from 'react';
import {Table} from 'react-bootstrap';
import {Button,ButtonToolbar} from 'react-bootstrap';
import {AddEmpModal} from './AddEmpModal';

export class Employee extends Component {
    constructor(props) {
        super(props);
        this.state = { emps: [],addModalShow:false }//check
    }
    refreshList() {
        // fetch(process.env.REACT_APP_API + 'Employee')
        fetch("https://localhost:44394/api/Employee")
            .then(response => response.json())
            .then(data => {
                this.setState({ emps: data });
            });
    }

    componentDidMount() {
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    render() {
        // const { emps } = this.state;
        const {emps}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        return (
            <div className="mt-5 d-flex justify-content-left">
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>FirstName</th>
                            <th>LastName</th>

                        </tr>
                    </thead>
                    <tbody>
                        {emps.map(emp =>
                            <tr key={emp.Id}>
                                <td>{emp.Id}</td>
                                <td>{emp.FirstName}</td>
                                <td>{emp.LastName}</td>

                                

                                

                            </tr>)}
                    </tbody>

                </Table>
                 <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                    Add Employee</Button>

                    <AddEmpModal show={this.state.addModalShow}
                    onHide={addModalClose}/>
                </ButtonToolbar> 
                  
            </div >
        )
    }
}