import React from 'react';

const Story = ({ item }) => { 
  return (
    <li>
      { (item.url !== null) ? <a href={item.url}>{item.title}</a> : <span>{item.title}</span> }
    </li>
  );
};

export default Story;