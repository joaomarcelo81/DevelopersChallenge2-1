import React, { Component } from 'react';
//import { CommonActions } from '@react-navigation/native';

export class BankStatementData extends Component {
    static displayName = BankStatementData.name;

    constructor(props) {
        super(props);
        this.state = { bankStatementDatas: [], loading: true, id: "" };
  
      

    }

    componentDidMount() {
        this.populateWeatherData();
    }
 
    shoot() {
        debugger;
        alert('teste');
    }

    handleItemDeleted(i) {
        alert(i);
    }
    static renderbankStatementDatasTable(bankStatementDatas) {
        var context = this;
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Ofx</th>
                        <th>Code</th>
                        <th>Severity</th>
                        <th>Language</th>
                        <th>Trnuid</th>
                        <th>Curdef</th>
                        <th>Bankid</th>
                        <th>Acctid</th>
                        <th>Accttype</th>
                        <th>Dtasof</th>
                        <th>Balamt</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {bankStatementDatas.map(bankStatementData =>
                        <tr key={bankStatementData.bankStatementId}>
                            <td>{bankStatementData.dataserver}</td>
                            <td>{bankStatementData.ofx}</td>
                            <td>{bankStatementData.code}</td>
                            <td>{bankStatementData.severity}</td>
                            <td>{bankStatementData.language}</td>
                            <td>{bankStatementData.trnuid}</td>
                            <td>{bankStatementData.curdef}</td>
                            <td>{bankStatementData.bankid}</td>
                            <td>{bankStatementData.acctid}</td>
                            <td>{bankStatementData.accttype}</td>
                            <td>{bankStatementData.dtasof}</td>
                            <td>{bankStatementData.balamt}</td>
                            <td>
                                <button className="btn btn-primary" onClick={() => {
                                    window.location.href = '/Accountlaunche/' + bankStatementData.bankStatementId       
                                    //CommonActions.navigate('Accountlaunche', {id: bankStatementData.bankStatementId});
                                }}>
                                    Details
                                </button>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
            
        );
    }
     //<button onClick={this.deleteRow.bind(this, id)}>Details</button>
    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : BankStatementData.renderbankStatementDatasTable(this.state.bankStatementDatas);

        return (
            <div>
                <h1 id="tabelLabel" >Account information</h1>
                <p>Accounts information.</p>               
                {contents}
            </div>
        );
    }


    async populateWeatherData() {
        const response = await fetch('api/BankStatement');
        const data = await response.json();
        this.setState({ bankStatementDatas: data, loading: false });
    }
    
}
