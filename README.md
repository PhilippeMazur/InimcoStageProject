# InimcoStageProject
Prerequisites:
- Have SQL Server Management Studio installed
- Have VS Studio installed

HOW TO USE:

1. After downloading and unzipping the project we have to change the connection string in the backend:
     - Open Backend_miniproject > Backend_miniproject > appsettings.json
     - change the connection string to your SQL Server Management Studio connection string which should look like this:
        "Data Source=XXXXXX-XXXXXX;database=MiniProject;Integrated Security=XXXXX;Connect Timeout=30;Encrypt=XXXX;TrustServerCertificate=XXXX;ApplicationIntent=XXXXX;MultiSubnetFailover=False"

2. Start the backend project by pressing start at the top of Visual Studio

3. Start the frontend:
     - open your terminal and cd into Frontend_miniproject > Frontend_miniproject
     - type "ng serve"

4. Open any browser an go to http://localhost:4200
