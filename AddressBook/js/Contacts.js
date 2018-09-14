import React, { Component } from "react";

export default class ContactsList extends React.Component {
    constructor(props) {
        super(props);

        this.state = { contacts: [] };
    }

    componentDidMount() {
        this.ContactsList();
    }

    ContactsList() {
        fetch('/api/contacts')
            .then(({ results }) => this.setState({ contacts: results }));
    }

    render() {
        const contacts = this.state.contact.map((item, i) => (
            <div>
                <h1>{item.id}</h1>
                <span>{item.firstname}, {item.lastname}</span>
            </div>
        ));

        ReactDOM.render(
            <ContactsList />, document.querySelector('#app'));
    }
}