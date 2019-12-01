import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor (props) {
    super(props);
    this.state = { contacts: [], loading: true };

    fetch('api/contact')
      .then(response => response.json())
      .then(data => {
        this.setState({ contacts: data, loading: false });
      });

  }

  static renderContactsTable (contacts) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>ID</th>
            <th>Active Record</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Email</th>
            <th>Home Phone</th>
            <th>Work Phone</th>
            <th>Cell Phone</th>
          </tr>
        </thead>
        <tbody>
          {contacts.map(contact =>
            <tr key={contact.contactID}>
              <td>{contact.contactID}</td>
              <td>{contact.isActiveRecord}</td>
              <td>{contact.firstName}</td>
              <td>{contact.lastName}</td>
              <td>{contact.email}</td>
              <td>{contact.homePhone}</td>
              <td>{contact.workPhone}</td>
              <td>{contact.cellPhone}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderContactsTable(this.state.contacts);

    return (
      <div>
        <h1>Contact Get All</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}
