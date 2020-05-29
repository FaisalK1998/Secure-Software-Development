# Secure-Software-Development
The purpose of this coursework was to implement a Bug Tracker application 
for Safari Security Testing Services. This service allows users to log in and view tickets. A ticket
should be created for every bug that is found. 

Users included in the system included: Developer, Tester and a Guest.

## Security Aspects

1. The user is required to enter a valid combination of a username and password in
   order to access the application.
2. The user’s details will be encrypted for security purposes (e.g. passwords)
3. The application will have unique user privileges for different users (developers,
   testers and clients), this will be handled via a separate database table
4. Connection to the application will be made secure by using TLS
5. A new session is created when a user logs into the system
6. The session will expire after 10 minutes if no user interaction is detected
7. The user is locked out after a certain number of failed attempts
8. Regular Expressions are used in order to reduce the chance of SQL Injection
