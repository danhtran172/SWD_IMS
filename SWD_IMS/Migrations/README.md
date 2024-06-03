#### Apply the Migration to Update the Database

Apply the migration to the database using the following command:

```bash
dotnet ef database update
```

This command will create the database and apply the initial schema as defined in the migration.

#### 6. Making Changes and Creating New Migrations

Whenever you make changes to your entity classes or `DbContext`, you need to create a new migration and update the database.

1. **Modify Your Models:**

For example, add a new property to the `User` class:

**Models/User.cs:**
```csharp
public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; } // New property
}
```

2. **Create a New Migration:**

```bash
dotnet ef migrations add AddPhoneNumberToUser
```

3. **Apply the New Migration:**

```bash
dotnet ef database update
```

#### 7. Viewing Applied Migrations

To see the list of applied migrations, you can run:

```bash
dotnet ef migrations list
```

#### 8. Reverting a Migration

If you need to revert the last applied migration, you can use:

```bash
dotnet ef database update <PreviousMigrationName>
```

Replace `<PreviousMigrationName>` with the name of the migration you want to revert to.

#### 9. Removing a Migration

If you need to remove the last migration before it is applied to the database, you can use:

```bash
dotnet ef migrations remove
```