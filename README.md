# Aurelia-app-Backend

Hello User,

This is the Backend Project for the Solution of Hahn Application Process.

Hahn.ApplicatonProcess.December2020.Data - Database related Project
Hahn.ApplicatonProcess.December2020.Web  - All the API Actions 
Hahn.ApplicatonProcess.December2020.Domain - All the business Logic.
Hahn.ApplicatonProcess.December2020.WebAPI - A Cloud hosted Serverless Application which is hosted by AWS CLOUD Serverless Application Model.

# WEBAPI SOLUTION

To run the project please install all the dependencies by running the following command
dotnet restore

once the packegs are installed, run the application (Hahn.ApplicatonProcess.December2020.Web Solution)
This is the Conventional WebAPI Solution which consists of 4 Methods for Applicant Entity

They were : 
1. POST - Add Applicant - It returns 201 with the Object that has been created - 400/500 incase of Errors
2. PUT - Update Applicant - It returns 204 - 400/500 incase of a Bad Request
3. GET/{id} - Get the Applicant info - It returns 200 with the Object Details - 404 if not found
4. DELETE/{id} - Delete the Applicant Data - Returns 204 If the operation is success.

https://localhost:5001/swagger will direct to the swaggerUI which contains the required input JSON Object with which we can just hit the API with the object


# CLOUD SOLUTION

In order to remove the compulsion of running both UI and backend Projects, have deployed a CLOUD Solution in AWS with the below URL
https://n2j0bhiyeb.execute-api.us-west-2.amazonaws.com/Prod/api/Applicant - POST/PUT

https://n2j0bhiyeb.execute-api.us-west-2.amazonaws.com/Prod/api/Applicant/{Id} - GET/DELETE


Have implemented FluentAPI Validation, so please do look at the Hahn.ApplicatonProcess.December2020.Domain.Validator.ApplicantValidator Class so that you will get a better understanding of the Validations.








