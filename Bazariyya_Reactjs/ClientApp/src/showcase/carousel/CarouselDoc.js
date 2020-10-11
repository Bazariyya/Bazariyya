import React, { Component } from 'react';
import { TabView, TabPanel } from '../../components/tabview/TabView';
import { CodeHighlight } from '../codehighlight/CodeHighlight';
import { LiveEditor } from '../liveeditor/LiveEditor';

export class CarouselDoc extends Component {

    constructor(props) {
        super(props);

        this.sources = {
            'class': {
                tabName: 'Class Source',
                content: `
import React, { Component } from 'react';
import { Carousel } from 'primereact/carousel';
import { Button } from 'primereact/button';
import ProductService from '../service/ProductService';
import './CarouselDemo.scss';

export class CarouselDemo extends Component {

    constructor(props) {
        super(props);

        this.state = {
            products: null
        };

        this.responsiveOptions = [
            {
                breakpoint: '1024px',
                numVisible: 3,
                numScroll: 3
            },
            {
                breakpoint: '600px',
                numVisible: 2,
                numScroll: 2
            },
            {
                breakpoint: '480px',
                numVisible: 1,
                numScroll: 1
            }
        ];

        this.productService = new ProductService();
        this.productTemplate = this.productTemplate.bind(this);
    }

    componentDidMount() {
        this.productService.getProductsSmall().then(data => this.setState({ products: data.slice(0,9) }));
    }

    productTemplate(product) {
        return (
            <div className="product-item">
                <div className="product-item-content">
                    <div className="p-mb-3">
                        <img src={\`showcase/demo/images/product/\${product.image}\`} alt={product.name} className="product-image" />
                    </div>
                    <div>
                        <h4 className="p-mb-1">{product.name}</h4>
                        <h6 className="p-mt-0 p-mb-3">\${product.price}</h6>
                        <span className={\`product-badge status-\${product.inventoryStatus.toLowerCase()}\`}>{product.inventoryStatus}</span>
                        <div className="car-buttons p-mt-5">
                            <Button icon="pi pi-search" className="p-button p-button-rounded p-mr-2" />
                            <Button icon="pi pi-star" className="p-button-success p-button-rounded p-mr-2" />
                            <Button icon="pi pi-cog" className="p-button-help p-button-rounded" />
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    render() {
        return (
            <div className="carousel-demo">
                <div className="card">
                    <Carousel value={this.state.products} numVisible={3} numScroll={3} responsiveOptions={this.responsiveOptions}
                        itemTemplate={this.productTemplate} header={<h5>Basic</h5>} />
                </div>

                <div className="card">
                    <Carousel value={this.state.products} numVisible={3} numScroll={1} responsiveOptions={this.responsiveOptions} className="custom-carousel" circular
                        autoplayInterval={3000} itemTemplate={this.productTemplate} header={<h5>Circular, AutoPlay, 3 Items per Page and Scroll by 1</h5>} />
                </div>

                <div className="card">
                    <Carousel value={this.state.products} numVisible={1} numScroll={1} orientation="vertical" verticalViewPortHeight="352px"
                        itemTemplate={this.productTemplate} header={<h5>Vertical</h5>} style={{maxWidth: '400px', marginTop: '2em'}} />
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
import React, { useState, useEffect } from 'react';
import {Carousel} from 'primereact/carousel';
import {CarService} from '../service/CarService';
import {Button} from 'primereact/button';

const CarouselDemo = () => {
    const [cars, setCars] = useState([]);
    const carservice = new CarService();
    const responsiveOptions = [
        {
            breakpoint: '1024px',
            numVisible: 3,
            numScroll: 3
        },
        {
            breakpoint: '768px',
            numVisible: 2,
            numScroll: 2
        },
        {
            breakpoint: '560px',
            numVisible: 1,
            numScroll: 1
        }
    ];

    useEffect(() => {
        carservice.getCarsSmall().then(data => setCars(data));
    }, []); // eslint-disable-line react-hooks/exhaustive-deps

    const carTemplate = (car) => {
        return (
            <div className="car-details">
                <div className="p-grid p-nogutter">
                    <div className="p-col-12">
                        <img src={\`showcase/demo/images/car/\${car.brand}.png\`} srcSet="https://www.primefaces.org/wp-content/uploads/2020/05/placeholder.png" alt={car.brand} />
                    </div>
                    <div className="p-col-12 car-data">
                        <div className="car-title">{car.brand}</div>
                        <div className="car-subtitle">{car.year} | {car.color}</div>

                        <div className="car-buttons">
                            <Button icon="pi pi-search" className="p-button-secondary" />
                            <Button icon="pi pi-star" className="p-button-secondary" />
                            <Button icon="pi pi-cog" className="p-button-secondary" />
                        </div>
                    </div>
                </div>
            </div>
        );
    };

    const basicHeader = <h2>Basic</h2>;
    const customHeader = <h2>Circular, AutoPlay, 3 Items per Page and Scroll by 1</h2>
    const verticalHeader = <h2>Vertical</h2>

    return (
        <div className="carousel-demo">
            <Carousel value={cars} itemTemplate={carTemplate} numVisible={4} numScroll={3}
                header={basicHeader} responsiveOptions={responsiveOptions}></Carousel>

            <Carousel value={cars} itemTemplate={carTemplate} numVisible={3} numScroll={1} className="custom-carousel"
                responsiveOptions={responsiveOptions} header={customHeader} circular autoplayInterval={3000}></Carousel>

            <Carousel value={cars} itemTemplate={carTemplate} orientation="vertical" style={{maxWidth: '400px', marginTop: '2em'}}
                numVisible={1} numScroll={1} verticalViewPortHeight="330px" header={verticalHeader}></Carousel>
        </div>
    );
}
                `
            },
            'ts': {
                tabName: 'TS Source',
                content: `
import React, { useState, useEffect } from 'react';
import {Carousel} from 'primereact/carousel';
import {CarService} from '../service/CarService';
import {Button} from 'primereact/button';

const CarouselDemo = () => {
    const [cars, setCars] = useState<any>([]);
    const carservice = new CarService();
    const responsiveOptions = [
        {
            breakpoint: '1024px',
            numVisible: 3,
            numScroll: 3
        },
        {
            breakpoint: '768px',
            numVisible: 2,
            numScroll: 2
        },
        {
            breakpoint: '560px',
            numVisible: 1,
            numScroll: 1
        }
    ];

    useEffect(() => {
        carservice.getCarsSmall().then(data => setCars(data));
    }, []); // eslint-disable-line react-hooks/exhaustive-deps

    const carTemplate = (car: { brand: string, year: string, color: string }) => {
        return (
            <div className="car-details">
                <div className="p-grid p-nogutter">
                    <div className="p-col-12">
                        <img src={\`showcase/demo/images/car/\${car.brand}.png\`} srcSet="https://www.primefaces.org/wp-content/uploads/2020/05/placeholder.png" alt={car.brand} />
                    </div>
                    <div className="p-col-12 car-data">
                        <div className="car-title">{car.brand}</div>
                        <div className="car-subtitle">{car.year} | {car.color}</div>

                        <div className="car-buttons">
                            <Button icon="pi pi-search" className="p-button-secondary" />
                            <Button icon="pi pi-star" className="p-button-secondary" />
                            <Button icon="pi pi-cog" className="p-button-secondary" />
                        </div>
                    </div>
                </div>
            </div>
        );
    };

    const basicHeader = <h2>Basic</h2>;
    const customHeader = <h2>Circular, AutoPlay, 3 Items per Page and Scroll by 1</h2>
    const verticalHeader = <h2>Vertical</h2>

    return (
        <div className="carousel-demo">
            <Carousel value={cars} itemTemplate={carTemplate} numVisible={4} numScroll={3}
                header={basicHeader} responsiveOptions={responsiveOptions}></Carousel>

            <Carousel value={cars} itemTemplate={carTemplate} numVisible={3} numScroll={1} className="custom-carousel"
                responsiveOptions={responsiveOptions} header={customHeader} circular autoplayInterval={3000}></Carousel>

            <Carousel value={cars} itemTemplate={carTemplate} orientation="vertical" style={{maxWidth: '400px', marginTop: '2em'}}
                numVisible={1} numScroll={1} verticalViewPortHeight="330px" header={verticalHeader}></Carousel>
        </div>
    );
}
                `
            }
        }

        this.extFiles = {
            'index.css': `
.carousel-demo .p-carousel .p-carousel-content .p-carousel-item .car-details > .p-grid {
    border: 1px solid #b3c2ca;
    border-radius: 3px;
    margin: 0.3em;
    text-align: center;
    padding: 2em 0 2.25em 0;
}
.carousel-demo .p-carousel .p-carousel-content .p-carousel-item .car-data .car-title {
    font-weight: 700;
    font-size: 20px;
    margin-top: 24px;
}
.carousel-demo .p-carousel .p-carousel-content .p-carousel-item .car-data .car-subtitle {
    margin: 0.25em 0 2em 0;
}
.carousel-demo .p-carousel .p-carousel-content .p-carousel-item .car-data button {
    margin-left: 0.5em;
}
.carousel-demo .p-carousel .p-carousel-content .p-carousel-item .car-data button:first-child {
    margin-left: 0;
}
.carousel-demo .p-carousel.custom-carousel .p-carousel-dot-icon {
    width: 16px !important;
    height: 16px !important;
    border-radius: 50%;
}
.carousel-demo .p-carousel.p-carousel-horizontal .p-carousel-content .p-carousel-item.p-carousel-item-start .car-details > .p-grid {
    margin-left: 0.6em;
}
.carousel-demo .p-carousel.p-carousel-horizontal .p-carousel-content .p-carousel-item.p-carousel-item-end .car-details > .p-grid {
    margin-right: 0.6em;
}
            `
        }
    }

    shouldComponentUpdate() {
        return false;
    }

    render() {
        return (
            <div className="content-section documentation">
                <TabView>
                    <TabPanel header="Documentation">
                        <h5>Import</h5>
<CodeHighlight lang="js">
{`
import { Carousel } from 'primereact/carousel';
`}
</CodeHighlight>

                        <h5>Getting Started</h5>
                        <p>Carousel requires a collection of items as its value along with a template to render each item.</p>

<CodeHighlight>
{`
<Carousel value={this.state.products} itemTemplate={this.itemTemplate}></Carousel>
`}
</CodeHighlight>

<CodeHighlight lang="js">
{`
itemTemplate(car) {
    // return content;
}
`}
</CodeHighlight>

                        <h5>Items per page and Scroll Items</h5>
                        <p>Number of items per page is defined using the <i>numVisible</i> property whereas number of items to scroll is defined with the <i>numScroll</i> property.</p>
<CodeHighlight>
{`
<Carousel value={this.state.products} itemTemplate={this.itemTemplate} numVisible={3} numScroll={1}></Carousel>
`}
</CodeHighlight>

                        <h5>Responsive</h5>
                        <p>For responsive design, <i>numVisible</i> and <i>numScroll</i> can be defined using the <i>responsiveOptions</i> property that should be an array of
            objects whose breakpoint defines the max-width to apply the settings.</p>
<CodeHighlight>
{`
<Carousel value={this.state.products} itemTemplate={this.itemTemplate} numVisible={3} numScroll={1} responsiveOptions={responsiveOptions}></Carousel>
`}
</CodeHighlight>

<CodeHighlight lang="js">
{`
const responsiveOptions = [
    {
        breakpoint: '1024px',
        numVisible: 3,
        numScroll: 3
    },
    {
        breakpoint: '768px',
        numVisible: 2,
        numScroll: 2
    },
    {
        breakpoint: '560px',
        numVisible: 1,
        numScroll: 1
    }
];
`}
</CodeHighlight>

                        <h5>Header and Footer</h5>
                        <p>Custom content projection is available using the <i>header</i> and <i>footer</i> properties.</p>
<CodeHighlight>
{`
<Carousel value={this.state.products} itemTemplate={this.itemTemplate} header={<h1>Header</h1>}></Carousel>
`}
</CodeHighlight>

                        <h5>Orientation</h5>
                        <p>Default layout of the Carousel is horizontal, other possible option is the vertical mode that is configured with the <i>orientation</i> property.</p>
<CodeHighlight>
{`
<Carousel value={this.state.products} itemTemplate={this.itemTemplate} orientation="vertical"></Carousel>
`}
</CodeHighlight>

                        <h5>AutoPlay and Circular</h5>
                        <p>When <i>autoplayInterval</i> is defined in milliseconds, items are scrolled automatically. In addition, for infinite scrolling <i>circular</i> property needs to be enabled. Note that in autoplay mode, circular is enabled by default.</p>

                        <h5>Controlled vs Uncontrolled</h5>
                        <p>In controlled mode, <i>page</i> and <i>onPageChange</i> properties need to be defined to control the first visible item.</p>

<CodeHighlight>
{`
<Carousel value={this.state.products} itemTemplate={this.itemTemplate} page={this.state.page} onPageChange={(e) => this.setState({page: e.page})}></Carousel>
`}
</CodeHighlight>

                        <h5>Uncontrolled</h5>
                        <p>In uncontrolled mode, no additional properties are required. Initial page can be provided using the <i>page</i> property in uncontrolled mode however it is evaluated at initial rendering and ignored in further updates. If you programmatically
                need to update the first visible item index, prefer to use the component as controlled.</p>

<CodeHighlight>
{`
<Carousel value={this.state.products} itemTemplate={this.itemTemplate}></Carousel>
`}
</CodeHighlight>

                        <h5>Properties</h5>
                        <div className="doc-tablewrapper">
                            <table className="doc-table">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>Type</th>
                                        <th>Default</th>
                                        <th>Description</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>id</td>
                                        <td>string</td>
                                        <td>null</td>
                                        <td>Unique identifier of the element.</td>
                                    </tr>
                                    <tr>
                                        <td>value</td>
                                        <td>array</td>
                                        <td>null</td>
                                        <td>An array of objects to display.</td>
                                    </tr>
                                    <tr>
                                        <td>page</td>
                                        <td>number</td>
                                        <td>null</td>
                                        <td>Index of the first item.</td>
                                    </tr>
                                    <tr>
                                        <td>header</td>
                                        <td>any</td>
                                        <td>null</td>
                                        <td>Label of header.</td>
                                    </tr>
                                    <tr>
                                        <td>footer</td>
                                        <td>any</td>
                                        <td>null</td>
                                        <td>Label of footer.</td>
                                    </tr>
                                    <tr>
                                        <td>style</td>
                                        <td>string</td>
                                        <td>null</td>
                                        <td>Inline style of the component.</td>
                                    </tr>
                                    <tr>
                                        <td>className</td>
                                        <td>string</td>
                                        <td>null</td>
                                        <td>Style class of the component.</td>
                                    </tr>
                                    <tr>
                                        <td>itemTemplate</td>
                                        <td>function</td>
                                        <td>null</td>
                                        <td>Function that gets an item in the value and returns the content for it.</td>
                                    </tr>
                                    <tr>
                                        <td>circular</td>
                                        <td>boolean</td>
                                        <td>false</td>
                                        <td>Defines if scrolling would be infinite.</td>
                                    </tr>
                                    <tr>
                                        <td>autoplayInterval</td>
                                        <td>number</td>
                                        <td>null</td>
                                        <td>Time in milliseconds to scroll items automatically.</td>
                                    </tr>
                                    <tr>
                                        <td>numVisible</td>
                                        <td>number</td>
                                        <td>1</td>
                                        <td>Number of items per page.</td>
                                    </tr>
                                    <tr>
                                        <td>numScroll</td>
                                        <td>number</td>
                                        <td>1</td>
                                        <td>Number of items to scroll.</td>
                                    </tr>
                                    <tr>
                                        <td>responsiveOptions</td>
                                        <td>any</td>
                                        <td>null</td>
                                        <td>An array of options for responsive design.</td>
                                    </tr>
                                    <tr>
                                        <td>orientation</td>
                                        <td>string</td>
                                        <td>horizontal</td>
                                        <td>Specifies the layout of the component, valid values are "horizontal" and "vertical".</td>
                                    </tr>
                                    <tr>
                                        <td>verticalViewPortHeight</td>
                                        <td>string</td>
                                        <td>300px</td>
                                        <td>Height of the viewport in vertical layout.</td>
                                    </tr>
                                    <tr>
                                        <td>contentClassName</td>
                                        <td>string</td>
                                        <td>null</td>
                                        <td>Style class of main content.</td>
                                    </tr>
                                    <tr>
                                        <td>containerClassName</td>
                                        <td>string</td>
                                        <td>null</td>
                                        <td>Style class of the viewport container.</td>
                                    </tr>
                                    <tr>
                                        <td>indicatorsContentClassName</td>
                                        <td>string</td>
                                        <td>null</td>
                                        <td>Style class of the paginator items.</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                        <h5>Events</h5>
                        <div className="doc-tablewrapper">
                            <table className="doc-table">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>Parameters</th>
                                        <th>Description</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>onPageChange</td>
                                        <td>event.page = Value of the new page.</td>
                                        <td>Callback to invoke after scroll.</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                        <h5>Styling</h5>
                        <p>Following is the list of structural style classes</p>
                        <div className="doc-tablewrapper">
                            <table className="doc-table">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>Element</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>p-carousel</td>
                                        <td>Container element.</td>
                                    </tr>
                                    <tr>
                                        <td>p-carousel-header</td>
                                        <td>Header section.</td>
                                    </tr>
                                    <tr>
                                        <td>p-carousel-footer</td>
                                        <td>Footer section.</td>
                                    </tr>
                                    <tr>
                                        <td>p-carousel-content</td>
                                        <td>Main content element. It contains the container of the viewport.</td>
                                    </tr>
                                    <tr>
                                        <td>p-carousel-container</td>
                                        <td>Container of the viewport. It contains navigation buttons and viewport.</td>
                                    </tr>
                                    <tr>
                                        <td>p-carousel-items-content</td>
                                        <td>Viewport.</td>
                                    </tr>
                                    <tr>
                                        <td>p-carousel-indicators</td>
                                        <td>Container of the indicators.</td>
                                    </tr>
                                    <tr>
                                        <td>p-carousel-indicator</td>
                                        <td>Indicator element.</td>
                                    </tr>
                                </tbody>
                            </table>

                            <h5>Dependencies</h5>
                            <p>None.</p>
                        </div>

                    </TabPanel>

                    <TabPanel header="Source">
                        <LiveEditor name="CarouselDemo" sources={this.sources} service="CarService" data="cars-small" extFiles={this.extFiles} />
<CodeHighlight lang="scss">
{`
.carousel-demo {
    .product-item {
        .product-item-content {
            border: 1px solid var(--surface-d);
            border-radius: 3px;
            margin: .3rem;
            text-align: center;
            padding: 2rem 0;
        }

        .product-image {
            width: 50%;
            box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23)
        }
    }
}
`}
</CodeHighlight>
                    </TabPanel>
                </TabView>
            </div>
        );
    }
}
