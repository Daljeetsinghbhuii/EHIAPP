Pre-requistes
1. VS2017 .NETCore with framework 2.2
2. MS SQL Server 2014 or above

Steps
1. Download API source from github i.e https://github.com/Daljeetsinghbhuii/EHIAPP.git
2. Execute SQL script on sql server query window. please refer EHIDBSchema.sql file available in main EHI folder
3. Change connection string in appsettings.json file in EHI.API project
5. Right click on EHI.API project and set as startup project
6. Run the project in editor and make sure port 5005 started listining
7. Now everthing is set test API endpoints. Now API endpont can be tested either via swagger UI or postman
8. In order to test via swagger, once the browser gets opened with http://localhost:5005/ url just append "swagger" text afterwoard
i.e. http://localhost:5005/swagger, This will generate the swagger UI and from there you can test the API by using "Try it out" button
available in each endpoint defination
9. In case if you want to test the API endpoint using postman, please find below endpoints

a. To get contact list 
http://localhost:5005api/Contact/List

b. To Add a contanct
http://localhost:5005/api/Contact/Add
Request
{
  "firstName": "Daljeet",
  "lastName": "Singh",
  "email": "daljeetsinghbhui@gmail.com",
  "phone": "8237437184",
  "status": true
}

c. To Update a contact
http://localhost:5005/api/Contact/Update
Request
{
  "contacttId": 1,
  "firstName": "Ramesh",
  "lastName": "Kumar",
  "email": "ramesh@gmail.com",
  "phone": "9565862568",
  "status": true
}

d. To delete a contact
http://localhost:5005/api/Contact/Delete/{contactId}


Some addtional points
1. I have used .NETCore web API with Lamda template to create API's, hence these API's can be exposed as lamda
2. These API's can be made as token based API by introducting identity managment server for example owin, identityserver4 or via Okta integration.
3. I have injected dependecy for middleware to handle exceptions, in this class only inside Invoke method can also validate token after making these API's as token based
4. I have installed swagger related nuget packages to generate swagger document which can be refered to see defination of each API's in the project

Thanks,
Daljeet