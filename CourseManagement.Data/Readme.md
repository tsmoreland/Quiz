# Data Project setup

## Setup EntityFrameworkCore 

1. add the following packages to data project:

	- entityframeworkcore.sqlserver
	- entityframeworkcore.tools
	- entityframeworkcore

2. add to the UI project

	- entityframeworkcore.sqlserver
	- entityframeworkcore.design

## Setup DbContext

- add class inheriting from DbContext to data project (will be changed later)
- override OnConfiguring and add 
	```
	optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = QuizApp; Trusted_Connection = True; ");
	```
- setup a few model classes in domain project and add DbSet<Model> entries for them in DbContext
- if necessary override OnModelCreating and configure the objects with fluent api, this is preferred over attribute based approach directly on models except for a few places where there may be overlap between UI and database like Required and MaxLength

## Create migration and update

- at this point you should be able to Add-Migration Initial in package manager followed by Update-Database.
- if migration goes back due to complexities in model then use Remove-Migration

## Things to Note

- one to many should be defined on both ends of the model, item with List<> should have HasMany(item => item.Property) while target should have HasOne(item = item.Parent).WithMany(parent => parent.Children).HasForeignKey(item => ParentId).IsRequired()
  is required may be optional here if it's 0 to many.  Note if we're hiding the list then the WithMany will use a string naming the parent property (as it can't use lambda syntax due to parent property being privete)

  ## Moving from hard coded to injected

  1. add constructor to context taking DbContextOptions<DataContext> options where DataContext is the class name 
  2. in Startup.cs or whereever services can be configured add services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionName")));  Making sure to hav using Microsoft.EntityFrameworkCore in namespaces or
  the UseSqlServer won't be found
  3. in appsettings.json add root level "ConnectionStrings" and an item name "ConnectionName" with the value of the connection string
