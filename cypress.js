cy.visit("http://myApp.app");

cy.get(`.elementName`).type(`some text{enter}`);

cy.get(`.button`).click();
cy.contains(`Clear compleated`).click();
