1. Create DB
	CREATE DATABASE QuestionDB;
2. Get the code from Git
	https://github.com/FrankMosso/Questions_Answers
3. Chage the Connection string
	QuestionsCodeFirstApi -> appsettings.json -> ConnectionStrings -> QuestionConnection -> add the new Local Connection string
4. Run the Api to genarate the DB from Code First
	4.1 - Open Data.Json and copy the content 
	4.2 - Execute the "/api/ImportData/MigrateData" Endpoint with the json string in Postman.
	4.3 - Verify the data in DB
5. Endpoint Testing
	5.1 - /api/Question/NewQuestion
	5.2 - /api/Question/AddAnswer
	5.3 - /api/Question/QuestionsByCriteria
