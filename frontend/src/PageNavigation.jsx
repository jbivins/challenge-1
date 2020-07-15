import React from 'react';

const Navigation = ({ firstHandler, previousHandler, nextHandler, lastHandler, pageIndex, maxPages }) => { 
  return (
    <div className="margin-bottom-10px">
      <button onClick={firstHandler}>First</button>
      <button onClick={previousHandler} disabled={pageIndex <= 0} name="previous">Previous</button>
      { pageIndex >= 0 ?
        <span id="pageLocation">Page {pageIndex + 1} of {maxPages}</span>
      : <span></span> }
      <button onClick={nextHandler} disabled={pageIndex + 1 > maxPages - 1} className="margin-left-10px" name="next">Next</button>
      <button onClick={lastHandler}>Last</button>
    </div>
  );
};

export default Navigation;