import React from 'react';
import PageNavigation from './PageNavigation';
import Story from './Story';
import SearchBar from './SearchBar';
import axios from 'axios';
import getBaseUrl from './Config';
import './index.css';

class Stories extends React.Component {

  state = {
    stories: [ ],
    pageIndex: -1,
    maxPages: -1,
    searchPhrase: ''
  };
  
  componentDidMount = () => {
    const url = getBaseUrl() + `/api/story/count`;

    axios
      .get(url)
      .then(res => {
        this.setState({ maxPages: res.data / 20 });
      },
      (error) => {
        
      })

    this.next();
  }

  first = (event) => {
    this.navigateToPage(0);
  }

  previous = (event) => {
    this.navigateToPage(this.state.pageIndex - 1);
  }

  next = (event) => {
    this.navigateToPage(this.state.pageIndex + 1);
  }

  last = (event) => {
    this.navigateToPage(this.state.maxPages - 1);
  }

  setSearchPhrase = (event) => {
    this.setState({ searchPhrase: event.target.value });
  }

  search = (event) => {
    const url = getBaseUrl() + `/api/story/search/${this.state.searchPhrase}`;

    axios
      .get(url)
      .then(res => {
        this.setState({ stories: res.data, pageIndex: 0 });
      },
      (error) => {
        
      });
  }

  navigateToPage = (page) => {
    const pageIndex = page;
    const url = getBaseUrl() + `/api/story?pageIndex=${pageIndex}&pageSize=20`;

    axios
      .get(url)
      .then(res => {
        this.setState({ stories: res.data, pageIndex: pageIndex, searchPhrase: '' });
      },
      (error) => {
        
      });
  }

  render() {
    return (
      <div>
        <PageNavigation
          firstHandler={this.first}
          previousHandler={this.previous}
          nextHandler={this.next}
          lastHandler={this.last}
          pageIndex={this.state.pageIndex}
          maxPages={this.state.maxPages} 
        />
        <SearchBar 
          searchPhraseValue={this.state.searchPhrase}
          changeHandler={this.setSearchPhrase}
          searchHandler={this.search}
        />
        <ol start={(this.state.pageIndex * 20) + 1}>
          {this.state.stories.map(story =>
            story !== null ?
            <Story key={story.id} item={story} />
            : <li>Removed</li>
          )}
        </ol>
      </div>
    );
  }
}

export default Stories;