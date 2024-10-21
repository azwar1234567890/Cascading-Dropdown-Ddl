Cascading Dropdown in ASP.NET WebForms with SQL Server
This project demonstrates the use of cascading dropdown lists (Country and State) in an ASP.NET WebForms application. The data is stored and retrieved from a SQL Server database, and the operations are handled via stored procedures.

                                                Features
                                                1.Cascading dropdowns for Country and State.
                                                2.Insert, Update, and Delete records using SQL Server.
                                                3.Display records in a GridView.
                                                4.Usage of stored procedures for database operations.


                                                Prerequisites
                                                1.Visual Studio (with .NET Framework)
                                                2.SQL Server (Express version is fine)
                                                3.SQL Server Management Studio (SSMS) for running SQL scripts

                                                Installation
                                                Step 1: Clone or download the repository
                                                Step 2: Clone the repository using Git:
                                                git clone https://github.com/your-repo-link.git
                                                Step 3: Create a new database.

CREATE DATABASE dropdown;
USE dropdown;

CREATE TABLE ddl (
    id INT PRIMARY KEY IDENTITY,
    country VARCHAR(50),
    city VARCHAR(50)
);

CREATE TABLE country (
    c_id INT IDENTITY PRIMARY KEY,
    c_country VARCHAR(50)
);

CREATE TABLE state (
    s_id INT IDENTITY PRIMARY KEY,
    c_id INT,
    s_name VARCHAR(50)
);

INSERT INTO country (c_country) VALUES ('India'), ('Pakistan'), ('Sri Lanka'), ('Bangladesh');

INSERT INTO state (c_id, s_name) VALUES 
(1, 'Uttar Pradesh'), 
(1, 'Bihar'),
(2, 'Lahore'),
(2, 'Islamabad'),
(3, 'Colombo'),
(3, 'Jaffna'),
(4, 'Dhaka'),
(4, 'Kishoreganj');

-- Display all countries
CREATE PROCEDURE displaycountry AS
BEGIN
    SELECT * FROM country;
END;

-- Display states based on selected country
CREATE PROCEDURE displaystate (@c_id INT) AS
BEGIN
    SELECT * FROM state WHERE c_id = @c_id;
END;

-- Display data for GridView
CREATE PROCEDURE ddljoin AS
BEGIN
    SELECT d.id, c.c_country, s.s_name 
    FROM ddl d
    JOIN country c ON d.country = c.c_id
    JOIN state s ON d.city = s.s_id;
END;

-- Insert new record
CREATE PROCEDURE dbinsert (@country VARCHAR(50), @city VARCHAR(50)) AS
BEGIN
    INSERT INTO ddl (country, city) VALUES (@country, @city);
END;

-- Update existing record
CREATE PROCEDURE dbupdate (@id INT, @country VARCHAR(50), @city VARCHAR(50)) AS
BEGIN
    UPDATE ddl SET country = @country, city = @city WHERE id = @id;
END;

-- Edit existing record
CREATE PROCEDURE ddledit (@id INT) AS
BEGIN
    SELECT * FROM ddl WHERE id = @id;
END;

-- Delete record
CREATE PROCEDURE ddldelete (@id INT) AS
BEGIN
    DELETE FROM ddl WHERE id = @id;
END;

Add Connection Strings :
SqlConnection con = new SqlConnection("data source=YOUR_SERVER_NAME\\SQLEXPRESS; initial catalog=dropdown; integrated security=true");


Step 5: Run the Project
1. Open the project in Visual Studio.
2. Build and run the application.
3. The application will display a form with cascading dropdowns (Country and State) and a GridView to show the existing records.

Project Structure
1.WebForm1.aspx: The main ASP.NET page with the dropdowns and GridView.
2.WebForm1.aspx.cs: Code-behind file handling server-side logic.
3.Stored Procedures: SQL Server stored procedures used for CRUD operations.

Usage
1.Country Dropdown: Select a country, and the State dropdown will update automatically based on your selection.
2.Submit Button: Insert new records into the database.
3.Edit Button: Edit existing records.
4.Delete Button: Remove records from the database.

License
This project is licensed under the MIT License.

Feel free to replace "https://github.com/azwar1234567890/Cascading-Dropdown-Ddl" with the actual GitHub URL of your repository.






