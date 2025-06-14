# Demo WinForms Product Application simulating synchronous 

This is a demo .NET Framework 4.8 WinForms application that demonstrates a layered architecture for managing products. The project is designed to help you explore concepts such as business/data separation and the impact of synchronous delays (with potential for async/await exploration).

## Features

- **WinForms UI** for product listing.
- **Business Layer** (`ProductService`) simulates business logic processing with artificial delays.
- **Data Layer** (`JsonProductRepository`) simulates data access with artificial delays and stores data in a local JSON file.
- **Contracts** define interfaces for loose coupling between layers.

## Project Structure
Demo.WinForms.UI/ Forms/ ProductList.cs         
# Main product list form Demo.Business/ ProductService.cs        
# Business logic with delay Contracts/ IProductService.cs     
# Service interface Demo.Data.Json/ JsonProductRepository.cs 
# Data access with delay Contracts/ IProductRepository.cs  
# Repository interface Models/ Product.cs           
# Product model DataFiles/ products.json            
# Product data storage

## How It Works

- The UI calls the business service to load products.
- The business service introduces a 5-second delay to simulate processing.
- The data repository introduces a 5-second delay to simulate slow data access.
- Products are read from and written to a JSON file.

## Running the Application

1. **Requirements:**  
   - Visual Studio 2022  
   - .NET Framework 4.8

2. **Build and Run:**  
   - Open the solution in Visual Studio.
   - Build the solution.
   - Run the WinForms project (`Demo.WinForms.UI`).

3. **Usage:**  
   - Click the "Load Products" button to see the effect of delays in both business and data layers.

## Customization

- To experiment with async/await, refactor the synchronous methods to their async counterparts and use `Task.Delay` instead of `Thread.Sleep`.

## Notes

- The artificial delays are for demonstration purposes only.
- The UI will freeze during delays because the current implementation is synchronous.

---

**Enjoy exploring layered architecture and async/await concepts with this demo!**
