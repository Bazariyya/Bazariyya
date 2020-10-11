import React, { Component } from 'react';
import { InputText } from '../inputtext/InputText';
export class TopPanel extends Component {

    constructor(props) {
        super(props);
        this.state = {
            value1: ''
        };
    }

    render() {
        return (
            <div className="top-panel">
                <div className="header">
                    <div className="logo">
                        <a id="logo" href="https://localhost:44377" className = "logo-content" title="Bazariyya">
                            <img class="logo-c" src="https://cdn.dsmcdn.com/web/logo/ty-logo.svg">
                            </img>
                        </a>
                    </div>

                    <div className = "search">
                        <span className="p-input-icon-left">
                            <i className="pi pi-search" />
                            <InputText value={this.state.value1} onChange={(e) => this.setState({ value1: e.target.value })} placeholder="Search" />
                        </span>
                    </div>
                </div>
            </div>
        )
    }
}


