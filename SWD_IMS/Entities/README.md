To manage users, roles, and permissions in a relational database, you need to establish relationships between these entities. Below is an approach that involves creating several tables to manage these relationships:

1. **Users**: Stores user information.
2. **Roles**: Stores role information.
3. **Permissions**: Stores permission information.
4. **UserRoles**: A junction table to manage many-to-many relationships between users and roles.
5. **RolePermissions**: A junction table to manage many-to-many relationships between roles and permissions.

### Table Schemas

1. **Users Table**

```sql
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
```

2. **Roles Table**

```sql
CREATE TABLE Roles (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(100) NOT NULL UNIQUE,
    CreatedAt DATETIME DEFAULT GETDATE()
);
```

3. **Permissions Table**

```sql
CREATE TABLE Permissions (
    PermissionId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME
);
```

4. **UserRoles Table**

```sql
CREATE TABLE UserRoles (
    UserRoleId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    RoleId INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId),
    UNIQUE (UserId, RoleId)
);
```

5. **RolePermissions Table**

```sql
CREATE TABLE RolePermissions (
    RolePermissionId INT PRIMARY KEY IDENTITY(1,1),
    RoleId INT NOT NULL,
    PermissionId INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId),
    FOREIGN KEY (PermissionId) REFERENCES Permissions(PermissionId),
    UNIQUE (RoleId, PermissionId)
);
```

### Example Data Insertion

#### Insert Roles

```sql
INSERT INTO Roles (RoleName) VALUES ('Admin'), ('User'), ('Guest');
```

#### Insert Permissions

```sql
INSERT INTO Permissions (Name, Description)
VALUES ('Read', 'Allows read access to resources.'),
       ('Write', 'Allows write access to resources.'),
       ('Delete', 'Allows delete access to resources.'),
       ('Execute', 'Allows execution of resources.');
```

#### Insert Users

```sql
INSERT INTO Users (UserName, Email)
VALUES ('johndoe', 'johndoe@example.com'),
       ('janedoe', 'janedoe@example.com');
```

#### Assign Roles to Users

Assume UserId for 'johndoe' is 1 and RoleId for 'Admin' is 1:

```sql
INSERT INTO UserRoles (UserId, RoleId)
VALUES (1, 1);
```

#### Assign Permissions to Roles

Assume RoleId for 'Admin' is 1 and PermissionId for 'Read', 'Write', 'Delete', 'Execute' are 1, 2, 3, 4 respectively:

```sql
INSERT INTO RolePermissions (RoleId, PermissionId)
VALUES (1, 1), (1, 2), (1, 3), (1, 4);
```

### Fetching Data

To fetch users along with their roles and permissions:

```sql
SELECT u.UserId, u.UserName, r.RoleName, p.Name as PermissionName
FROM Users u
JOIN UserRoles ur ON u.UserId = ur.UserId
JOIN Roles r ON ur.RoleId = r.RoleId
JOIN RolePermissions rp ON r.RoleId = rp.RoleId
JOIN Permissions p ON rp.PermissionId = p.PermissionId
WHERE u.UserId = 1;
```

### Complete SQL Script

Here is a complete script to create the tables and insert data, including the queries to fetch user roles and permissions:

```sql
-- Create Users table
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Create Roles table
CREATE TABLE Roles (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(100) NOT NULL UNIQUE,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Create Permissions table
CREATE TABLE Permissions (
    PermissionId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME
);

-- Create UserRoles table
CREATE TABLE UserRoles (
    UserRoleId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    RoleId INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId),
    UNIQUE (UserId, RoleId)
);

-- Create RolePermissions table
CREATE TABLE RolePermissions (
    RolePermissionId INT PRIMARY KEY IDENTITY(1,1),
    RoleId INT NOT NULL,
    PermissionId INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId),
    FOREIGN KEY (PermissionId) REFERENCES Permissions(PermissionId),
    UNIQUE (RoleId, PermissionId)
);

-- Insert Roles
INSERT INTO Roles (RoleName) VALUES ('Admin'), ('User'), ('Guest');

-- Insert Permissions
INSERT INTO Permissions (Name, Description)
VALUES ('Read', 'Allows read access to resources.'),
       ('Write', 'Allows write access to resources.'),
       ('Delete', 'Allows delete access to resources.'),
       ('Execute', 'Allows execution of resources.');

-- Insert Users
INSERT INTO Users (UserName, Email)
VALUES ('johndoe', 'johndoe@example.com'),
       ('janedoe', 'janedoe@example.com');

-- Assign Roles to Users
-- Assuming UserId for 'johndoe' is 1 and RoleId for 'Admin' is 1
INSERT INTO UserRoles (UserId, RoleId)
VALUES (1, 1);

-- Assign Permissions to Roles
-- Assuming RoleId for 'Admin' is 1 and PermissionId for 'Read', 'Write', 'Delete', 'Execute' are 1, 2, 3, 4 respectively
INSERT INTO RolePermissions (RoleId, PermissionId)
VALUES (1, 1), (1, 2), (1, 3), (1, 4);

-- Query to fetch users along with their roles and permissions
SELECT u.UserId, u.UserName, r.RoleName, p.Name as PermissionName
FROM Users u
JOIN UserRoles ur ON u.UserId = ur.UserId
JOIN Roles r ON ur.RoleId = r.RoleId
JOIN RolePermissions rp ON r.RoleId = rp.RoleId
JOIN Permissions p ON rp.PermissionId = p.PermissionId
WHERE u.UserId = 1;
```

This setup ensures a clear and structured way to manage users, roles, and permissions, making it easy to define and query access controls within your application.