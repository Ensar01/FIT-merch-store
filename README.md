# FIT-merch-store 🛍️

FIT Merch Store is a web application developed as part of a college project, designed to facilitate the purchase of official merchandise for the Faculty of Information Technologies. The goal of this project is to provide a seamless online shopping experience while implementing core web development concepts such as authentication, authorization, and data management.

I was responsible for developing the backend using ASP.NET Core and Entity Framework. ASP.NET Identity and JWT were implemented for authentication and authorization, allowing secure user management. Email services were integrated specifically for account registration confirmation, enhancing security and user verification.

The application supports standard CRUD operations, enabling administrators to manage products, users, and orders efficiently. Customers can browse available merchandise, add items to their wishlist, and place orders. Additionally, users can leave reviews for products, edit their profiles, and manage their account settings. The system ensures that only authenticated users can complete purchases, leave reviews, and update their information, maintaining data integrity and security.

A basic reporting system is also implemented, allowing administrators to generate a list of all registered users on the site.

## 🚀 Getting Started (Local Setup)

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Ensar01/FIT-merch-store.git
   ```

2. **Open the project in Visual Studio**

3. **Apply EF Core migrations (if needed):**
   ```bash
   dotnet ef database update
   ```

4. **Run the application:**
   - Using Visual Studio (IIS Express), or
   - From terminal:
     ```bash
     dotnet run
     ```
