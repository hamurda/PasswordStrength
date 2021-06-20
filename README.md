# Password Strength - Platform Engineering .NET Coding Challenge

The project contains two main applications: 
* PasswordStrengthWebAPI - Web API to calculate password strength and fetch how many times it was pawned
* CAppPasswordStrength - A console application where the user enters a password and finds its strength and the number of times the password has appeared in data breaches by interacting with PasswordStrengthWebAPI.

The repository also contains the unit test project inside CAppPasswordStrength, which is called CAppPasswordStrength.Tests to replicate some scenarios when using the console application.

## Technology
* .NET Framework 4.6.1
* C#

## Usage

Console Application, CAppPasswordStrength, has two classes to work with APIs: StrengthAPIHelper and BreachAPIHelper. In both classes, please find where it says "{yourhostnumber}" in StrengthAPIUrlBase and BreachAPIUrlBase classes and change the URL accordingly.
* StrengthAPIHelper.cs --- line 22 ---   _strengthAPIUrlBase = "http://localhost:{yourhostnumber}/api/PasswordCheck/"
* BreachAPIHelper.cs  --- line 20 --- _breachAPIUrlBase = "http://localhost:{yourhostnumber}/api/PasswordBreach/"


The console app should return "The entry is invalid." in case the user enters an empty string or use one of the following characters; \,*,/,?,&.
Otherwise;
* Passwords less than 6 characters are considered too short and the app returns "VeryWeak". (E.g. "a[12B")
* Passwords equals to or more than 6 characters with one type of characters content returns "Weak". (E.g. "abcdef", "1234567")
* Passwords equals to or more than 6 characters with two types of characters content returns "Medium". (E.g. "abcdeF", "12345ab")
* Passwords equals to or more than 6 characters with three types of characters content returns "Strong". (E.g. "abcdE1", "12345a]", "12[]Ab")
* Passwords more than 6 characters with all four typse of characters content returns "Unbreakable". (E.g. "Abc12[!")

## Room for Improvement

* Currently, console app sends the password to API in the URL and exposes the password. It could be sent in header or by another method so password would be protected.
* Currently, PasswordStrengthWebAPI converts string to SHA1 to work with the Pwned Passwords API version 5. After achieving the previous improvement, SHA converter potentially could be included in the console app so that API wouldn't have to run all the interim steps.
* Currently, in CAppPasswordStrength, classes StrengthAPIHelper and BreachAPIHelper have repetitive properties and methods. These members could be implemented with the help of an interface (e.g. IAPIHelper) and be inherited.

### Thank you for your time and consideration. 

