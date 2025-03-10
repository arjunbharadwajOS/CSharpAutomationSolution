
# CSharpAutomationSolution
## Overview

This project is a test automation framework using Selenium for Web UI testing, Appium for Mobile App testing and RestSharp for API testing in C#. It allows automated browser testing and API validation within a single solution.

## Prerequisites

NET SDK (Version 6.0 or later)

Visual Studio (Recommended IDE)

Chrome/Firefox/Edge WebDriver (Matching your browser version)

NuGet Packages:

Selenium WebDriver

Selenium WebDriver Support

RestSharp

Appium.WebDriver

NUnit (or xUnit/MSTest)

## Installation

Clone the repository:

git clone https://github.com/arjunbharadwajOS/CSharpAutomationSolution.git
cd CSharpAutomationSolution

Open the project in Visual Studio.

Restore dependencies:

dotnet restore

Configure WebDriver paths (if necessary).

Appium plan for this quickstart is as follows:

-- Install Appium

-- Install an Appium driver and its dependencies

-- This guide provides instructions for the UiAutomator2 driver

-- Install an Appium client library in your language of choice

-- This guide contains options for JavaScript, Python, Java, Ruby, and .NET

-- Write and run a simple Appium automation script using a sample application

Reference Link: https://appium.io/docs/en/latest/quickstart/

## Running Tests

Running UI Tests

Execute Selenium tests via NUnit:

--dotnet test --filter UIAPIAutomationTests.Tests

Running API Tests

Execute API tests via NUnit:

dotnet test --filter UIAPIAutomationTests.Tests

Running Specflow BDD Tests

Execute API tests via NUnit:

dotnet test --filter Category="tag1"

Running Playwright Tests

dotnet test --filter SamplePlaywright.FirstPlaywrightMethod

Execute Mobile App tests via NUnit:

dotnet test --filter AppiumExample.AppiumTest

## Reporting

This project can generate and view test execution reports - ExtentReports for better visibility.

## Contributing

Fork the repository.

Create a new branch (feature-branch).

Commit your changes and push to the branch.

Open a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Contact

For any issues or enhancements, please create an issue on GitHub or reach out to ansimytech@gmail.com.

Extent Report Screenshots
![image](https://github.com/user-attachments/assets/17208160-39d4-4ce5-b6da-81cc4c672d87)
![image](https://github.com/user-attachments/assets/25ab514b-43fd-43e1-a610-4fc728778d22)
![image](https://github.com/user-attachments/assets/febe883c-b3ce-4448-9672-f920901fff03)



