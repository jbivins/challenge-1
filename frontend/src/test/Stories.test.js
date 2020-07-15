import React from 'react';
import { mount } from 'enzyme';
import Stories from '../Stories';

describe('Stories', () => {
  it('should start listing stories at number 1 when on the first page', () => {
    const component = mount(<Stories />);
    component.setState({ pageIndex: 0 });

    expect(component.find('ol').props().start).toEqual(1);
  });

  it('should start listing stories at number 21 when on the second page', () => {
    const component = mount(<Stories />);
    component.setState({ pageIndex: 1 });

    expect(component.find('ol').props().start).toEqual(21);
  });

  it('should have a hyperlink to the story when a url is specified', () => {
    const component = mount(<Stories />);
    const testStories = [
      {
        id: 1,
        url: 'http://localhost',
        title: 'Test story'
      }
    ];
    component.setState({ pageIndex: 1, stories: testStories });

    expect(component.find('a').props().href).toEqual('http://localhost');
  });

  it('should not have a hyperlink when a url is not specified', () => {
    const component = mount(<Stories />);
    const testStories = [
      {
        id: 1,
        title: 'Test story'
      }
    ];
    component.setState({ pageIndex: 1, stories: testStories });

    expect(component.find('a').props().href).toBeUndefined();
  });
});