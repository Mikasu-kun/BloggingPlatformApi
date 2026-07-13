# BloggingPlatformApi
Basic RESTful API for blogging platform. The API allows performing CRUD (Create, Read, Update, and Delete) operations on blog posts. Additionally, blog posts can be filtered by a search term. 
### Stack:
- ASP.NET Core 10
- PostgreSQL
- Entity Framework Core (Npgsql)


### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/Mikasu-kun/BloggingPlatformApi
   ```
2. Navigate to the project directory:
   ```bash
   cd BloggingPlatformApi
   ```

3. Open the project in Visual Studio Insiders
   
4. Restore dependencies:
    ```bash
       dotnet restore
    ```
5. Configure the connection string in the appsettings.json file:
   ```json
    "ConnectionStrings": {
    "DefaultConnection": "Host=XXXXXXX;Port=XXXXXXX;Database=XXXXXXX;Username=XXXXXXX;Password=XXXXXXX;"
    }
   ```

6. Run the migration script:
   ```bash
   dotnet Update-Database
   ```
   
7. Run the application


# Usage


## Create Blog Post
Create a new blog post using the POST method

```http
POST /posts
{
  "title": "My First Blog Post",
  "content": "This is the content of my first blog post.",
  "category": "Technology",
  "tags": ["Tech", "Programming"]
}
```

Responce:
```http
{
  "id": 1,
  "title": "My First Blog Post",
  "content": "This is the content of my first blog post.",
  "category": "Technology",
  "tags": ["Tech", "Programming"],
  "createdAt": "2021-09-01T12:00:00Z",
  "updatedAt": "2021-09-01T12:00:00Z"
}
```

## Update Blog Post
Update an existing blog post using the PUT method

```http
PUT /posts/1
{
  "title": "My Updated Blog Post",
  "content": "This is the updated content of my first blog post.",
  "category": "Technology",
  "tags": ["Tech", "Programming"]
}
```

Responce:
```http
{
  "id": 1,
  "title": "My Updated Blog Post",
  "content": "This is the updated content of my first blog post.",
  "category": "Technology",
  "tags": ["Tech", "Programming"],
  "createdAt": "2021-09-01T12:00:00Z",
  "updatedAt": "2021-09-01T12:30:00Z"
}
```

## Delete Blog Post
Delete an existing blog post using the DELETE method

```http
DELETE /posts/1
```

## Get Blog Post
Get a single blog post using the GET method

```http
GET /posts/1
```

Responce:
```http
{
  "id": 1,
  "title": "My First Blog Post",
  "content": "This is the content of my first blog post.",
  "category": "Technology",
  "tags": ["Tech", "Programming"],
  "createdAt": "2021-09-01T12:00:00Z",
  "updatedAt": "2021-09-01T12:00:00Z"
}
```

## Get All Blog Posts

```http
GET /posts
```

Responce:
```http
[
  {
    "id": 1,
    "title": "My First Blog Post",
    "content": "This is the content of my first blog post.",
    "category": "Technology",
    "tags": ["Tech", "Programming"],
    "createdAt": "2021-09-01T12:00:00Z",
    "updatedAt": "2021-09-01T12:00:00Z"
  },
  {
    "id": 2,
    "title": "My Second Blog Post",
    "content": "This is the content of my second blog post.",
    "category": "Technology",
    "tags": ["Tech", "Programming"],
    "createdAt": "2021-09-01T12:30:00Z",
    "updatedAt": "2021-09-01T12:30:00Z"
  }
]
