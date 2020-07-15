import React from 'react';

const SearchBar = ({ searchPhraseValue, changeHandler, searchHandler }) => { 
  return (
    <div>
      <input type="text" name="searchPhrase" placeholder="Search Here" value={searchPhraseValue} onChange={changeHandler} />
      <button onClick={searchHandler} className="margin-left-10px">Search</button>
    </div>
  );
};

export default SearchBar;