# MigrationTask
instal .net core 8
build project ctr+shift+b
go to package manager console 
make default project: MigratationTask.Data 
update Update-Database -context   MigrationTaskContext
Update-Database -Context ApplicationDbContext for identity server

to register a new user u can you swagger register api with sending email and password like 
 email:'myemail@mail.com',pass: '@Passw0rd'
 
 use this email to login on frontend first

for front end after clone :https://github.com/3laasaleh/migrationitui.git

   npm i 

   ng s 

   make sure angular @18.2.0 is installed on ur machine