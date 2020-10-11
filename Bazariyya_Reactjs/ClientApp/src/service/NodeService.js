import axios from 'axios';

export class NodeService {
    
    getTreeTableNodes() {
        return axios.get('showcase/demo/data/treetablenodes.json')
                .then(res => res.data.root);
    }

    getTreeNodes() {
        return axios.get('showcase/demo/data/treenodes.json')
                .then(res => res.data.root);
    }
}