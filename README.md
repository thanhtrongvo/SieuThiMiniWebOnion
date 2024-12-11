# Mini Supermarket Web Application

This repository contains a Mini Supermarket web application built using **ASP.NET Core MVC**. The project demonstrates the use of modern web development techniques, Entity Framework Core for data handling, and a layered architecture to create a feature-rich application.

## Features

- **Product Management**: Add, update, delete, and view products.
- **Category Management**: Organize products into categories.
- **Shopping Cart**: Allow customers to add/remove items and view cart details.
- **Order Management**: Place orders and view order history.
- **Authentication and Authorization**: User roles for customers and administrators.

## Technologies Used

- **Framework**: ASP.NET Core MVC
- **Database**: Microsoft SQL Server
- **ORM**: Entity Framework Core
- **Frontend**: Bootstrap, HTML5, CSS3, JavaScript
- **Authentication**: ASP.NET Core Identity
- **Version Control**: Git

## Installation

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

### Steps to Run Locally

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/thanhtrongvo/SieuThiMiniWebOnion.git
   cd WebShopMini
   ```

2. **Set Up Database**:
   - Open `appsettings.json` and configure the connection string to your SQL Server instance.
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=your_server;Database=MiniSupermarket;Trusted_Connection=True;"
   }
   ```

3. **Run Migrations**:
   ```bash
   dotnet ef database update
   ```

4. **Run the Application**:
   ```bash
   dotnet run
   ```

5. Open your browser and navigate to `https://localhost:5159`.

## Project Structure

```
MiniSupermarket/
├── MiniSupermarket.Presentation/  # Presentation layer for Controllers and Views
├── MiniSupermarket.Application/   # Application layer for business logic
├── MiniSupermarket.Domain/        # Domain layer for core entities and interfaces
├── MiniSupermarket.Infrastructure/ # Infrastructure layer for data access
├── wwwroot/                       # Static files (CSS, JS, images)
├── appsettings.json               # Configuration settings
```

### Onion Architecture Layers

1. **Domain**:
   - Contains the core entities, interfaces, and domain logic.
2. **Application**:
   - Implements business logic and application services.
3. **Infrastructure**:
   - Handles database interactions and external dependencies.
4. **Presentation**:
   - Manages the user interface and interaction logic.

## Screenshots

### Home Page
![Home Page](https://via.placeholder.com/800x400?text=Home+Page+Screenshot)

### Product List
![Product List](https://via.placeholder.com/800x400?text=Product+List+Screenshot)

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch: `git checkout -b feature/your-feature`.
3. Commit your changes: `git commit -m 'Add some feature'`.
4. Push to the branch: `git push origin feature/your-feature`.
5. Open a pull request.

## License

This project is licensed under the [MIT License](LICENSE).

---

For any inquiries or issues, feel free to contact [votrong1471@gmail.com].
