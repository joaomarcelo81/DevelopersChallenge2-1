import React, { Component } from 'react';
import axios from 'axios'
export class Statement extends Component {
    constructor(props) {
        super(props);
        this.state = {
            file: null
        };
        this.onFormSubmit = this.onFormSubmit.bind(this);
        this.onChange = this.onChange.bind(this);
    }
    onFormSubmit(e) {
        e.preventDefault();
        const formData = new FormData();
        formData.append('myImage', this.state.file);
        const config = {
            headers: {
                'content-type': 'multipart/form-data'
            }
        };
        axios.post("/UploadOFX", formData, config)
            .then((response) => {
                alert("The file is successfully uploaded");
                window.location.href = '/';
            }).catch((error) => {
            });
    }
    onChange(e) {
        this.setState({ file: e.target.files[0] });
    }

    render() {
        return (            
         
            <form onSubmit={this.onFormSubmit}>
                <h1 id="tabelLabel" >Upload OFX File </h1>
                <p>Accounts information.</p>  
                <input type="file" name="file" onChange={this.onChange} />
                <button type="submit">Upload</button>
            </form>
        )
    }
}
