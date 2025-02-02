# MovieTrackerAPI-CQRS-AWS-S3

## Overview
The **MovieTrackerProject API** is a RESTful API built with **ASP.NET Core** and **MediatR** to manage users, movies, ratings, and integration with **TMDB API**. This project provides functionalities for user authentication, movie tracking (watchlist), rating movies, and managing user profiles.

## Technologies Used
- **ASP.NET Core Web API**
- **MediatR** for CQRS (Command Query Responsibility Segregation)
- **Amazon S3** for user profile photo storage
- **Entity Framework Core** for database operations
- **TMDB API** integration
- **Dependency Injection** for services and repositories

---
![Main](https://github.com/emirhandev/MovieTrackerAPI-CQRS-AWS-S3/blob/main/Images/1.png)
![Main](https://github.com/emirhandev/MovieTrackerAPI-CQRS-AWS-S3/blob/main/Images/2.png)
![Main](https://github.com/emirhandev/MovieTrackerAPI-CQRS-AWS-S3/blob/main/Images/3.png)

## API Endpoints

### 1. **User Management** (UserController)

#### Get all users
```http
GET /api/User/Get-All-User
```
- Retrieves a list of all registered users.

#### Get user by ID
```http
GET /api/User/{id}
```
- Fetches user details by their ID.

#### Get users with watchlist
```http
GET /api/User/Get-Users-With-Watchlist
```
- Returns users along with their movie watchlists.

#### Create a new user
```http
POST /api/User/Create-User
```
- **Response:** User created successfully!

#### Delete a user
```http
DELETE /api/User/Delete-User?id={id}
```
- Deletes a user by ID.

#### Update a user
```http
PUT /api/User/Update-User?id={id}
```
- Updates a user’s details.

#### Add a movie to a user's watchlist
```http
POST /api/User/Add-Movie-To-Watchlist
```
- Adds a movie to the user's watchlist.

#### Get user with ratings
```http
GET /api/User/Get-User-By-Id-WithRates/{id}
```
- Fetches a user's details along with their ratings.
 ![Rate](https://github.com/emirhandev/MovieTrackerAPI-CQRS-AWS-S3/blob/main/Images/10.png)
---
### 2. **Movie Management** (MovieController)

#### Get all movies
```http
GET /api/Movie/Get-All-Movies
```
- Retrieves all movies in the database.

#### Get movie by ID
```http
GET /api/Movie/{id}
```
- Fetches a movie by its ID.

#### Get movie by title
```http
GET /api/Movie/title/{title}
```
- Searches for a movie by title.

#### Get movie with ratings
```http
GET /api/Movie/Get-Movies-With-Rates/{title}
```
 
- Fetches a movie along with user ratings.
-  ![Rate](https://github.com/emirhandev/MovieTrackerAPI-CQRS-AWS-S3/blob/main/Images/6.png)

#### Create a new movie
```http
POST /api/Movie/Create-Movie
```

- Adds a new movie to the database.

#### Delete a movie
```http
DELETE /api/Movie/Delete-Movie?id={id}
```
- Deletes a movie by ID.

#### Update a movie
```http
PUT /api/Movie/Update-Movie
```

- Updates an existing movie.

---
### 3. **Ratings Management** (RateController)

#### Get all ratings
```http
GET /api/Rate/Get-AllRates
```
- Fetches all user ratings.
  ![Rate](https://github.com/emirhandev/MovieTrackerAPI-CQRS-AWS-S3/blob/main/Images/9.png)



#### Get rating by ID
```http
GET /api/Rate/{id}
```
- Retrieves a specific rating by ID.

#### Create a rating
```http
POST /api/Rate/Create-Rate
```
- Adds a new movie rating.

#### Update a rating
```http
PUT /api/Rate/Update-Rate
```
- Updates an existing rating.

#### Delete a rating
```http
DELETE /api/Rate/Delete-Rate?id={id}
```
- Deletes a rating by ID.

---
### 4. **TMDB Integration** (TMDBController)

#### Search for a movie using TMDB API
```http
GET /api/TMDB/search/{title}
```
- Searches for a movie using **TMDB API**.
  ![TMDB](https://github.com/emirhandev/MovieTrackerAPI-CQRS-AWS-S3/blob/main/Images/7.png)
  ![TMDB](https://github.com/emirhandev/MovieTrackerAPI-CQRS-AWS-S3/blob/main/Images/8.png)


#### Add a movie from TMDB to watchlist
```http
POST /api/TMDB/Add-Movie-to-Watchlist
```
- Adds a movie to a user’s watchlist using TMDB API.

---
### 5. **File Management (User Profile Photo)** (FileController)

#### Upload user profile photo
```http
POST /api/File/Upload-Profile-Photo?userId={id}
```
- Uploads a profile photo for a user to **Amazon S3**.
  ![File](https://github.com/emirhandev/MovieTrackerAPI-CQRS-AWS-S3/blob/main/Images/4.png)
    ![File](https://github.com/emirhandev/MovieTrackerAPI-CQRS-AWS-S3/blob/main/Images/5.png)

#### Delete user profile photo
```http
DELETE /api/File/Delete-Profile-Photo?userId={id}
```
- Deletes a user's profile photo from **Amazon S3**.

---
## How to Run the Project

### Prerequisites
- .NET 6 or higher
- SQL Server
- Amazon S3 (for profile photo storage)

### Steps to Run
1. Clone the repository:
   ```sh
   git clone https://github.com/your-username/MovieTrackerProject.git
   cd MovieTrackerProject
   ```
2. Set up the database:
   ```sh
   dotnet ef database update
   ```
3. Configure **Amazon S3** credentials in `appsettings.json`.
4. Run the application:
   ```sh
   dotnet run
   ```
5. API will be available at:
   ```sh
   http://localhost:5000/api/
   ```

---
## Contribution
Feel free to submit pull requests or open issues for improvements.

## License
This project is licensed under the MIT License.

