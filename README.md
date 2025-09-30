# 📦 Inventory Management System (C# Windows Forms)

A desktop application designed for managing product inventory, orders, and user accounts. 
This project serves as a pilot application to demonstrate database connectivity and the implementation of business logic via Stored Procedures and Triggers, developed for the Database Systems course.

## ✨ Key Features

* **User/Employee Management:** Functionality to register, update, view, and validate users (`tbUser`).
* **Product Inventory:** Tracking of product stock quantity (`pqty` in `tbProduct`).
* **Order Processing:** Registering orders (`tbOrder`).
* **Automated Stock Control:** Uses database triggers to automatically adjust product quantities upon order creation or deletion.
* **Business Logic in DB:** All data manipulation (CRUD) and core logic are implemented using **Stored Procedures** and **Triggers** in the MySQL database.

## 💻 Technologies Used

| Category | Technology | Tool/Framework |
| :--- | :--- | :--- |
| **Application** | C# | Windows Forms (Visual Studio) |
| **Database** | MySQL | MySQL DBMS (required for project submission) |
| **DB Access** | Connector/Net (or similar) | Used for connecting C# application to MySQL. |

## 📐 Database Objects

The core business logic is implemented in the database:

| Object Type | Name | Purpose |
| :--- | :--- | :--- |
| **Trigger** | `trg_DecreaseProductQuantity` | **Decreases** product quantity (`pqty`) in `tbProduct` every time a new order is successfully **inserted** into `tbOrder`. |
| **Trigger** | `trg_IncreaseProductQuantity` | **Increases** product quantity (`pqty`) in `tbProduct` every time an order is **deleted** from `tbOrder`. |
| **Procedure** | `sp_ValidateUser` | Validates a user's login credentials against the `tbUser` table. |
| **Procedure** | `sp_InsertUser`, `sp_UpdateUser` | Handles the creation and modification of user (employee) records. |
| **Procedure** | `sp_GetProductQuantity` | Fetches the current stock quantity for a specific product. |

## 🚀 Getting Started

To run this project:

1.  **Database Setup:**
    * Ensure you have a running **MySQL** instance.
    * Create the necessary tables: `tbUser`, `tbProduct`, and `tbOrder` (DDL not included here).
    * Execute the combined SQL script to create the **Stored Procedures** and **Triggers** (`trg_DecreaseProductQuantity`, `sp_ValidateUser`, etc.).
2.  **Configuration:** Update the **MySQL connection string** in the C# source code (e.g., in `LoginForm.cs`) to correctly point to your local database instance.
3.  **Run:** Build and run the solution in Visual Studio.

---
