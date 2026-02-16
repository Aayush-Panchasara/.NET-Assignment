### Assignment 1



###### 1\) What problem was EF solving compared to ADO.NET?

--> 

Disadvantages of using ADO.NET: 

* Too much boiler-plate code = create connection -> open connection -> write query -> execute query -> read the result data -> close the connection.
* Object relational Mapping = We have to manually map the database tables to the objects.
* Complex maintenance = SQL query are scattered everywhere. It is hard to manage the schema change.
* Change tracking = We have to manually write the about changes and when to update the data.
* Migration = We manually write SQL query inorder to applied the changies.



Problem solved by EF:

* Boiler-plate reduction
* Change tracking = EF track entity changes automatically.
* Migration = Automatically update the schema on the database based the c# classes/objects.
* Rapid Development = It just focus on working with objects rather than manually writing the sql queries.



------------------------------------------------------------------------------------------------------------------------------------------



###### 2\) Explain EDM architecture (Conceptual, Mapping, Storage).

-->

Entity Data Model(EDM) is a conceptual model that defined how application object and database table are connected. It solve the object-relational mapping problem.



It has 3 layer :

1. Conceptual Model(CSDL) = This represents Application views of data. It contain C# Classes, properties, relationships.
2. Storage Model (SSDL) = This represents Database views of data. It contain table, column, primary key, foreign key etc.
3. Mapping Model(MSL) = It connects the conceptual model with the storage model. It is responsible for defining which class maps to which table, which properties map to which column, relationships between two or more tables.



------------------------------------------------------------------------------------------------------------------------------------------



###### 3\) Difference between EF Core and EF6. 

-->



|**EF Core**|**EF6**|
|-|-|
|Cross-plateform(.Net Core)|Support .NET framework (Windows only)|
|Performance is faster than EF6|Slower compare to EF Core|
|<br />Support wide range of database like SQL server, SQLite, PostgreSQL, MySQL Etc.<br />|Primarily supports traditional relational databases|
|Light weight architecture|Heavy architecture|





------------------------------------------------------------------------------------------------------------------------------------------



###### 4)What happens internally when SaveChanges() is called?

-->

When the SaveChanges() is called than EF core performs a multi-step pipeline internally.

1. Detect changes = EF Core first checks the Change Tracker.It looks at all tracked entities and determines their state. It could be added, modified, deleted, unchanged, detached. This is called Snapshot of change tracking.
2. Validate entities = It validate the entities, constrains etc
3. Generate the SQL = Now EF builds SQL based on entity states. Ex. added then insertion.
4. Open Database Connection = EF opens it automatically using the provider.
5. Start Transaction = EF Core automatically creates a transaction. This ensures atomicity, consistency.
6. Execute SQL Commands = Now EF sends commands to the database, Execute it.
7. Commit Transaction = Changes applied to the database.

###### 

-----------------------------------------------------------------------------------------------------------------------------------------



###### 5)What is Change Tracking?

-->

Change Tracking is the mechanism by which Entity Framework keeps track of changes made to entities (objects).It helps EF to know what INSERT, UPDATE, or DELETE SQL to generate when SaveChanges() is called.

It usages the Entity states to keep track the changes.

* Added: The object is new and doesn't exist in the database yet. EF will generate an INSERT.
* Unchanged: The object matches the database. No SQL will be generated.
* Modified: At least one property has been changed. EF will generate an UPDATE.
* Deleted: The object is marked for removal. EF will generate a DELETE.
* Detached: The object is not being tracked.



Types of change tacking : 

1. Snapshot Change Tracking : It is the default tracking mechanism. It takes the snapshot of original data and compares during  SaveChanges().
2. Notification Change Tracking : Used when entity implements INotifyPropertyChanged,INotifyPropertyChanging interface.





------------------------------------------------------------------------------------------------------------------------------------------



###### 6)Difference between DbContext and DbSet?

-->



|**DbContext**|**DbSet**|
|-|-|
|It is the main class that manages the database session.|It represent the table in the database.|
|Think of it as a bridge between your application and a database|Think of it as a Collection of entities map to the table.|
|<br />It is responsible for:<br /><br />1)Managing database connection<br />2)Change tracking<br />3)Transactions<br />4)SaveChanges()<br />5)Model configuration<br />6)LINQ query execution<br />|It is responsible for:<br /><br />1)Querying data<br />2)Adding data<br />3)Removing data<br />$)Updating data (via tracking)|





