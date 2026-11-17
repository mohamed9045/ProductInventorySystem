# Product Inventory System

## About the Project

This project is a simple Product Inventory System for managing products in a small store.

The system allows the user to add, view, edit, and delete products. It also stores product information such as name, SKU, price, quantity, category, and expiry date.

## Technologies Used

- C#
- .NET 8
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- HTML and CSS
- Bootstrap

## Project Structure

The project is divided into three main parts:

- **DAL:** Handles database operations. It contains the DbContext, Product entity, configurations, and repository.
- **BLL:** Contains the ProductService, interfaces, ViewModels, and validation rules.
- **Presentation:** Contains the MVC Controllers and Views used to interact with the system.

## Database

The project uses SQL Server with Entity Framework Core.

The Product entity contains the following properties:

- Id
- Name
- SKU
- Description
- Price
- StockQuantity
- Category
- IsActive
- CreatedAt
- ExpiryDate

The database configuration is handled using Fluent API in ProductConfiguration.

The SKU field has a unique index to prevent duplicate product codes.

## Repository Pattern

I used the Repository Pattern to separate database operations from the business logic.

IProductRepository defines the required methods, while ProductRepository implements these methods using ApplicationDbContext.

The repository handles adding, updating, deleting, and retrieving products.

## Dependency Injection

Dependency Injection is used to connect the different parts of the application.

ProductRepository is registered with IProductRepository, and ProductService is registered with IProductService.

The registration is handled through service registration classes and called from Program.cs.

## CRUD Operations

The application supports the following operations:

- **Create:** Add a new product.
- **Read:** Display all products and view product details.
- **Update:** Edit existing product information.
- **Delete:** Delete a product after confirmation.

## Validation

The project includes server-side and client-side validation.

The validation rules are:

- Product name is required and cannot exceed 100 characters.
- SKU is required, cannot exceed 20 characters, and must be unique.
- Description cannot exceed 500 characters.
- Price must be greater than zero.
- Stock quantity cannot be negative.
- Expiry date cannot be in the past.
- Grocery products must have an expiry date.
- The system checks whether the product ID exists before performing operations.

Data Annotations are used for basic validation, while additional business rules are handled in ProductService and ProductFormViewModel.

## How to Run

1. Open the solution in Visual Studio.
2. Make sure SQL Server is installed and running.
3. Update the connection string in appsettings.json if needed.
4. Set ProductInventorySystem as the startup project.
5. Apply the existing EF Core migrations if the database has not been created.
6. Run the project.

## Conclusion

This project helped me practice working with ASP.NET Core MVC, SQL Server, Entity Framework Core, Repository Pattern, Dependency Injection, and CRUD operations.