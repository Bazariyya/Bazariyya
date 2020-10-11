import React, { Component } from 'react';
import { DataTable } from '../../components/datatable/DataTable';
import { Column } from '../../components/column/Column';
import ProductService from '../service/ProductService';
import { AppInlineHeader } from '../../AppInlineHeader';
import { TabView, TabPanel } from '../../components/tabview/TabView';
import { LiveEditor } from '../liveeditor/LiveEditor';

export class DataTableGridLinesDemo extends Component {

    constructor(props) {
        super(props);

        this.state = {
            products: null
        };

        this.productService = new ProductService();
    }

    componentDidMount() {
        this.productService.getProductsSmall().then(data => this.setState({ products: data }));
    }

    render() {
        return (
            <div>
                <div className="content-section introduction">
                    <AppInlineHeader changelogText="dataTable">
                        <h1>DataTable <span>GridLines</span></h1>
                        <p>Adding <b>p-datatable-gridlines</b> displays borders between cells. Note: Some themes may always display gridlines by design.</p>
                    </AppInlineHeader>
                </div>

                <div className="content-section implementation">
                    <div className="card">
                        <DataTable value={this.state.products} header="Header" footer="Footer" className="p-datatable-gridlines">
                            <Column field="code" header="Code"></Column>
                            <Column field="name" header="Name"></Column>
                            <Column field="category" header="Category"></Column>
                            <Column field="quantity" header="Quantity"></Column>
                        </DataTable>
                    </div>
                </div>

                <DataTableGridLinesDemoDoc />
            </div>
        );
    }
}

export class DataTableGridLinesDemoDoc extends Component {

    constructor(props) {
        super(props);

        this.sources = {
            'class': {
                tabName: 'Class Source',
                content: `
import React, { Component } from 'react';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import ProductService from '../service/ProductService';

export class DataTableGridLinesDemo extends Component {

    constructor(props) {
        super(props);

        this.state = {
            products: null
        };

        this.productService = new ProductService();
    }

    componentDidMount() {
        this.productService.getProductsSmall().then(data => this.setState({ products: data }));
    }

    render() {
        return (
            <div>
                <div className="card">
                    <DataTable value={this.state.products} header="Header" footer="Footer" className="p-datatable-gridlines">
                        <Column field="code" header="Code"></Column>
                        <Column field="name" header="Name"></Column>
                        <Column field="category" header="Category"></Column>
                        <Column field="quantity" header="Quantity"></Column>
                    </DataTable>
                </div>
            </div>
        );
    }
}
                `
            },
            'hooks': {
                tabName: 'Hooks Source',
                content: `

                `
            },
            'ts': {
                tabName: 'TS Source',
                content: `

                `
            }
        }
    }

    shouldComponentUpdate() {
        return false;
    }

    render() {
        return (
            <div className="content-section documentation">
                <TabView>
                    <TabPanel header="Source">
                        <LiveEditor name="DataTableFilterDemo" sources={this.sources} service="CarService" data="cars-large" />
                    </TabPanel>
                </TabView>
            </div>
        )
    }
}
