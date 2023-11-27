Welcome user to SWProducts.

A simple product to manage your products.

Software required.

VS Code: https://code.visualstudio.com/download
Sqlite: https://www.sqlite.org/download.html
.NET Core: https://dotnet.microsoft.com/en-us/download AND https://code.visualstudio.com/docs/csharp/get-started

Once installed, check to see if the SDK has been successfully installed. 

Run CMD (windows)/Terminal (Apple): Run the following line:
dotnet --version 

 ~ This should return version number that you have installed

Next run the following:
dotnet tool install --global dotnet-ef

 ~ This should install entity frame work required to run this project. 

Now you may open VS Code and open the SWProducts project 
open the terminal in VS code and run the following lines

dotnet ef migrations add "Build DB"
dotnet ef update database

Then Finally

dotnet build
dotnet run

It should run on http://localhost:5059/ but look in your terminal for confirmation. 

Once on the page. Register your user. Then you will have access to Products Management. 

