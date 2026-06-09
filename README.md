To run the application you must run both the **api ( PiggyBank.API)** and the **frontend (piggy-bank)** projects

## Frontend
To run the frontend make sure you have the following installed
* Node - documentation related to installing node is located here https://nodejs.org/docs/latest/api/
* NPM - documentation related to installing NPM is located here https://docs.npmjs.com/

After you have installed node and npm use the terminal of your IDE choice to CD to the **piggy-bank** root folder
Once you are in the root folder run the following commands

```bash
npm install​
```

This command will install all the project packages for you

```bash
npm run build​
```

Once the packages have been successfully installed you can run the application using the following command

```bash
npm run serve​
```

The link for the application is http://localhost:8080

## Backend

Before you run the backend/api you must first update the database connection string located in the appsetting.json file from the PiggyBank.API project

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=PiggyBankDb;Trusted_Connection=True;"
}
```

Change the server to match with your machine server name

Once you have updated the serve name you can run the application

**Please Note**

* If you are running the api for the first time it will create the database for you and seed the table with dummy data, so there is no need for running the migrations manually
* The endpoints are documented, they have comments on expected parameters and have short description for each endpoint


