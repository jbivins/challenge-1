import React from 'react';
import { mount } from 'enzyme';
import PageNavigation from '../PageNavigation';

describe('PageNavigation', () => {

  it('should call the onNextHandler when the next button is clicked', () => {
    const onNextHandler = jest.fn();
    const component = mount(<PageNavigation nextHandler={onNextHandler} />);

    component.find("button[name='next']").simulate('click');

    expect(onNextHandler).toHaveBeenCalled();
  });
  
  it('should disable the next button when we are at the last page', () => {
    const component = mount(<PageNavigation pageIndex={2} maxPages={2} />);

    expect(component.find("button[name='next']").props().disabled).toBe(true);
  });

  it('should call the onPreviousHandler when the previous button is clicked', () => {
    const onPreviousHandler = jest.fn();
    const component = mount(<PageNavigation previousHandler={onPreviousHandler} />);

    component.find("button[name='previous']").simulate('click');

    expect(onPreviousHandler).toHaveBeenCalled();
  });

  it('should disable the previous button when we are at the first page', () => {
    const component = mount(<PageNavigation pageIndex={0} maxPages={2} />);

    expect(component.find("button[name='previous']").props().disabled).toBe(true);
  });

  it('should show the page location', () => {
    const component = mount(<PageNavigation pageIndex={0} maxPages={2} />);
    const pageLocationElements = component.find("span#pageLocation").props().children;

    expect(pageLocationElements.join('')).toEqual('Page 1 of 2');
  });
});