import { SignalRTestFrontendPage } from './app.po';

describe('signal-rtest-frontend App', function() {
  let page: SignalRTestFrontendPage;

  beforeEach(() => {
    page = new SignalRTestFrontendPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
