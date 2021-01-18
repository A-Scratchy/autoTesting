context("Actions", () => {
  beforeEach(() => {
    cy.visit("https://www.saucedemo.com");
  });

  it("login to swag labs", () => {
    cy.get("#user-name")
      .type("standard_user")
      .should("have.value", "standard_user");

    cy.get("#password")
      .type("secret_sauce")
      .should("have.value", "secret_sauce");

    cy.get("#login-button").click();
  });
});
