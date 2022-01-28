# Team1-P2
Project 2 with Stefan, Kyler, and Shaul

Project Title: Banked
Team/Roles:
Stefan Schweers - UX/Logistics
Shaul Stavi - Database/Testing
Kyler Dennis - UI/Integration
Overview:
	The objective of Banked is to create a timeline based calculator that takes one’s income, expenses, savings interest, and loan interest and creates a timeline of monthly expenses on a projection map to hitting a savings goal. After a user enters their data, they will receive a chart displaying their weekly expenses and when/if they will reach their savings goal. 

Users:
	Individuals wishing to see if their current budget will hit their savings goal and when
Adults 18 - 70
Focus on individuals with minimal investment accounts.

Features:
Personalized graph visual based on projected weekly expenses up to goal.
Timeline to savings goal using linear and exponential data.
(Stretch) Recommended expenditure changes to more quickly hit goals.

TechStack:
Angular Frontend: Html,CSS,JS
ASP.Net core web API
Azure SQL Database
Entity Framework
GitHub Actions
SonarCloud

Development:
	The Production Cycle for this project will consist of two sprints using the Agile Method. Sprint 1 will consist of development to a MVP with a focus on testing before first deployment. Sprint 2 will consist of UI/UX improvement.

Data Handling:
	UserData will be passed through the API as Http inputs to the server. Stored user data will only be accessible through Single Factor Authentication through the client. Input validation will be handled on the client side. Logic operations will be performed in the API after successfully accessing the database.

The Database currently has 5-6 Tables in mind with one-many and many-many connections. User Password information and user financial information will be in separate tables from the user information.

Timeline:
Initial Build (5 days)
Testing Phase 1 ( 3 days)
UI/UX Improvements (2 days)
Testing Phase 2 (-> Project Completion)

Stretch Goals:
By adding importance of expenses on inputs, we can create recommended actions for a user to take to faster reach their savings goal (ex: buying coffee every other day instead of daily)
System determines which expenditure to reduce based off severity tag
Automated advising can determine reduction timelines by input savings date goal
Multiple savings advising messages can be generated and displayed
Adding Report divergence: Allowing a user to enter new one time income at future points on their report to determine what % their new report has changed from their initial report
Allows for adding expense or income on existing report
Generates new report with new one time expense/income
Informs user of % change from original report savings timeline
ID as a Service




