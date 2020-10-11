import React, { Component } from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';
import { Ripple } from '../ripple/Ripple';

export class LastPageLink extends Component {

    static defaultProps = {
        disabled: false,
        onClick: null
    }

    static propTypes = {
        disabled: PropTypes.bool,
        onClick: PropTypes.func
    }

    render() {
        let className = classNames('p-paginator-last p-paginator-element p-link', {'p-disabled': this.props.disabled});

        return (
            <button type="button" className={className} onClick={this.props.onClick} disabled={this.props.disabled}>
                <span className="p-paginator-icon pi pi-angle-double-right"></span>
                <Ripple />
            </button>
        );
    }
}
