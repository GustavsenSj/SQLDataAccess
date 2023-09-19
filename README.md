# SQLDataAccess

This project/assignment is a part of the Fullstack course by Noroff. The given challenge was divided into two parts:

- SQL scripts to create a database according to the specifications.
- A repository implementation in a C# console application to access data from the provided Chinook database.

## Contributors

This project was made as a collaboration between the following people:

- [Minh Christian Tran](https://github.com/Mintra99)
- [Sjur Gutavsen](https://github.com/GustavsenSj)

## SQL scripts

The SQL scripts are located in the `SQLScripts/Assignment2_Part1` folder. The scripts are named according to the task they solve.

## C# console application

The console application is located in the `SQLDataAccess` folder. The application is a simple console application that uses the Chinook database to access data. The application supports the following requirements:

1. Read all the customers in the database, this should display their: Id, first name, last name, country, postal code, phone number and email.
2. Read a specific customer from the database (by Id), should display everything listed in the above point.
3. Read a specific customer by name. HINT: LIKE keyword can help for partial matches.
4. Return a page of customers from the database. This should take in limit and offset as parameters and make use of the SQL limit and offset keywords to get a subset of the customer data. The customer model from above should be reused.
5. Add a new customer to the database. You also need to add only the fields listed above (our customer object)
6. Update an existing customer.
7. Return the number of customers in each country, ordered descending (high to low). i.e. USA: 13, …
8. Customers who are the highest spenders (total in invoice table is the largest), ordered descending.
9. For a given customer, their most popular genre (in the case of a tie, display both). Most popular in this context means the genre that corresponds to the most tracks from invoices associated to that customer.

## Project structure

The project is structured in the following way:

### Console application SQLDataAccess

- `DB` - Files for the database connection
- `Exception` - Files for custom exceptions
- `Models` - Files for the model classes
- `Repositories` - Files for the repository classes
- `Service` - Files for the service classes used to access the repositories
- `SQL` - SQL scripts used to create the database used in the application

### SQL scripts
- `01_dbCreate.sql` - Creates a database called "SuperheroesDb"
- `02_tableCreate.sql` - Creates tables for Superhero, Assistant and Power
- `03_relationshipSuperheroAssistant.sql` - Alters Assistant table to create constraints and foreign key
- `04_relationshipSuperheroPow.sql` - Creates a linking table between Superhero and Power
- `05_insertSuperheroes.sql` - Inserts three superheroes into the database
- `06_insertAssistants.sql` - Inserts three assistants and assign them a superhero to assist
- `07_powers.sql` - Inserts four powers and assign powers to superheroes
- `08_updateSuperhero.sql` - Updates a superhero name  
- `09_deleteAssistant.sql` - Deletes an assistant
