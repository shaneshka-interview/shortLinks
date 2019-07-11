import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

    constructor(props) {
        
    super(props);
    this.state = { links: [], loading: true };

    fetch('api/shorts')
      .then(response => response.json())
      .then(data => {
        this.setState({ links: data, loading: false });
      });

    //this.createShortLink = this.createShortLink.bind(this);
    }

  createShortLink = () => {
      let link = document.getElementById('longLink').value;

      if (link == "") return;

      fetch('api/shorts',
              {
                  method: 'post',
                  headers: {
                      "Content-type": "application/json; charset=UTF-8"
                  },
                  body: JSON.stringify(link) 
              })
          .then(response => response.json())
          .then(data => {
              this.setState({ links: [...this.state.links, data], loading: false });
          })
          .catch(error => {
              console.error('Error:', error);
              alert('Error:', error);
          });
  
  }

  static renderlinksTable (links) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Link</th>
            <th>Short</th>
          </tr>
        </thead>
        <tbody>
                {links.map(links =>
              <tr key={links.id}>
                <td>{links.id}</td>
                <td>{links.link}</td>
                        <td><a href= { '/r/'+ links.shortId }>{links.shortId}</a></td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderlinksTable(this.state.links);

    return (
      <div>
            <h1>Links</h1>
            <div className="input-group mb-3">
                <input id="longLink" type="text" className="form-control" placeholder="Looooooong link" aria-label="Looooooong link" aria-describedby="basic-addon2"/>
                <div className="input-group-append">
                    <button className="btn btn-outline-secondary" type="button" onClick={this.createShortLink}>shorten</button>
            </div>
        </div>
        {contents}
      </div>
    );
  }
}
