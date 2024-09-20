## [Blog Website using ASP.NET MVC](https://github.com/Mostafa-Abo-Elhassan/Blogaat)

### Project Overview
This project is a full-featured blog website built using ASP.NET MVC. The application provides a platform for users to create, edit, and view blog posts, while ensuring security and role-based access control through ASP.NET Identity.

### Key Features
- **User Authentication & Authorization**: Users can register, log in, and manage their profiles. Role-based permissions are enforced, differentiating between regular users and admins.
- **CRUD Operations**: Full support for creating, reading, updating, and deleting blog posts.
- **Profile Pages**: Each user has a customizable profile page displaying their personal information and blog contributions.
- **Responsive Design**: The user interface is styled using Bootstrap to ensure that it works well on both desktop and mobile devices.

### Technologies Used
- **ASP.NET MVC**: For building the core of the web application.
- **ASP.NET Identity**: For user authentication and role management.
- **Entity Framework**: Used for database interactions and data management.
- **SQL Server**: As the database for managing user information, blog posts, and more.
- **Bootstrap**: For responsive front-end design.

### Installation Instructions
1. Clone the repository:
    ```bash
    git clone https://github.com/Mostafa-Abo-Elhassan/Blogaat.git
    ```
2. Navigate to the project directory:
    ```bash
    cd Blogaat
    ```
3. Restore the dependencies:
    ```bash
    dotnet restore
    ```
4. Update the `appsettings.json` file with your SQL Server connection string.
5. Apply the migrations and update the database:
    ```bash
    dotnet ef database update
    ```
6. Run the application:
    ```bash
    dotnet run
    ```

### Screenshots
<p align="center">
  <img src="path_to_screenshot1.png" alt="Home Page" width="400px"/>
  <img src="path_to_screenshot2.png" alt="User Profile" width="400px"/>
</p>

### Future Enhancements
- Add a comment system for blog posts.
- Improve search functionality for blog posts.
- Integrate third-party APIs for sharing posts on social media.

### License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
