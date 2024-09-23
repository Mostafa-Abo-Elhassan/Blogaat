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
<p align="center"> 1
  <img src="https://res.cloudinary.com/dfgunzope/image/upload/v1727061016/kvypybfqobi4nxhxj5sy.png" alt="Home Page" width="700px"/>
</p>
<p align="center"> 2
<img src="https://res.cloudinary.com/dfgunzope/image/upload/v1727061123/dnbcqo57oaweggn9nx5p.png" alt="User Profile" width="700px"/>
</p>
</p>
<p align="center"> 3
<img src="https://res.cloudinary.com/dfgunzope/image/upload/v1727061391/mlnd35kbttrxlzhks9ls.png" alt="User Profile" width="700px"/>
</p>
</p>
<p align="center"> 4
<img src="https://res.cloudinary.com/dfgunzope/image/upload/v1727061123/dnbcqo57oaweggn9nx5p.png" alt="User Profile" width="700px"/>
</p>
</p>
<p align="center"> 5
<img src="https://res.cloudinary.com/dfgunzope/image/upload/v1727061490/ln6mg3oz4ucvcysfvkdd.png" alt="User Profile" width="700px"/>
</p>
</p>
<p align="center"> 6
<img src="https://res.cloudinary.com/dfgunzope/image/upload/v1727061552/hioghzzsgs0vprrugxse.png" alt="User Profile" width="700px"/>
</p>
</p>
<p align="center"> 7
<img src="https://res.cloudinary.com/dfgunzope/image/upload/v1727061599/e1gt135uzqnh0q44zs40.png" alt="User Profile" width="700px"/>
</p>
</p>
<p align="center"> 8
<img src="https://res.cloudinary.com/dfgunzope/image/upload/v1727061627/zkx6lesxat3nw4qbzajo.png" alt="User Profile" width="700px"/>
</p>
</p>
<p align="center"> 9
<img src="https://res.cloudinary.com/dfgunzope/image/upload/v1727061653/b3znxacrtzzorjwdptg4.png" alt="User Profile" width="700px"/>
</p>
### Future Enhancements
- Add a comment system for blog posts.
- Improve search functionality for blog posts.
- Integrate third-party APIs for sharing posts on social media.

### License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## Blogaat Project Features

Blogaat is a simple blog platform built with ASP.NET MVC. The project supports user registration, viewing posts, and tagging. It also provides role-based access where:

- **Admin** can manage blog posts, tags, and users.
- **Super Admin** can manage blog posts, tags, admins, and users.

### Technologies Used
- C#, MVC, .NET 7
- Dependency Injection
- Froala Editor for rich text editing
- Cloudinary for cloud-based image hosting
- ASP.NET Identity for user management
- HTML, CSS, Bootstrap

### Project Link:
[Blogaat on GitHub](https://bit.ly/3TFccYN)
