import React, { Component } from 'react';

export class Accountlaunche extends Component {
    static displayName = Accountlaunche.name;

    constructor(props) {
        super(props);
        this.state = { Accountlaunches: [], loading: true };
        this.id = props.location.pathname.substring(16, props.location.pathname.length);
        debugger;
    }
  
    componentDidMount() {
        this.populateData();
    }

    static renderAccountlaunchesTable(Accountlaunches) {
        return (
            
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Type</th>
                        <th>Description</th>
                        <th>Value</th>
                    </tr>
                </thead>
                <tbody>
                    {Accountlaunches.map(Accountlaunche =>
                        <tr key={Accountlaunche.accountlauncheId}>
                            <td>{Accountlaunche.dtposted}</td>
                            <td>{Accountlaunche.trntype}</td> 
                            <td>{Accountlaunche.memo}</td>
                            <td>{Accountlaunche.trnamt}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Accountlaunche.renderAccountlaunchesTable(this.state.Accountlaunches);

        return (
            <div>
                <h1 id="tabelLabel" >Account information</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateData() {
        debugger;
        if (this.id != null) {
          
            const response = await fetch('api/Accountlaunche' + "/" + this.id);
            const data = await response.json();
            this.setState({ Accountlaunches: data, loading: false });
        } else {
            const response = await fetch('api/Accountlaunche');
            const data = await response.json();
            this.setState({ Accountlaunches: data, loading: false });

        }
     
    }
}
