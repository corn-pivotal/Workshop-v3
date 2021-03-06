# Workshop v3 Demo and Source Code

## Overview
This Workshop demo and accompanying source code is designed to help facilitate a deeper understanding of Pivotal Application Services, Spring Cloud Services, and Steeltoe.  The source code is based on two existing projects:
1. [Steeltoe Workshop](https://github.com/SteeltoeOSS/Workshop) developed by Dave Tillman
2. [PCF Exchange Demo and Workshop](https://github.com/pivotal-field-engineering/pcfechange-polyglot-demo) developed by Andrew Stakhov

A live demonstration can be found [here](https://exchangeui.apps.islands.cloud/).  This project is still in development and will be updated regularly.

### Technology
This application is intended to be deployed using Pivotal Application Services on Cloud Foundry. The source code for this project is implemented using dependency injection in .NET Core v2 and the following technologies:

1. Steeltoe v2 Open Source Libraries
2. Configuration Server
3. Eureka Discovery Server
4. Hystrix Circuit Breakers
5. RabbitMQ Messaging
6. Redis Caching
7. Pivotal UAC/SSO
8. MySQL Connector
11. User Provided Services

### Requirements
The following are required for building and deploying the applications in this workshop.

- [Cloud Foundry CLI](https://github.com/cloudfoundry/cli)
- [Git Client](https://git-scm.com/downloads)
- [.NET Core SDK 2.0](https://www.microsoft.com/net/download)
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio 2017](https://www.visualstudio.com/downloads/)
- [Java 8 JDK](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html) - Optional, needed to run Eureka and Config servers locally

## Design
While the workshop application helps demonstrate the functionality of Pivotal Application Services and Spring Cloud Services using Steeltoe, there was a need to expose some of the underlying workings of these applications running on PAS. This workshop and demo will help 
users better understand how PAS can help developers deploy at scale. Some additional techniques are used in the development of these applications such as utilizing service client libraries and shared model libraries. 

The following are some of the patterns used in development:

- Micro services using service client shared libraries
- Configuration Services to handle application configuration
- User Provided Services and Configurtion Services to handle service connections
- User and Service Security using OAuth and JWT methods
- Application support for Blue Green Deployments
- Continuous integration and deployment using Visual Studio Team Services
- Polyglot language support including Java, .NET Framework, and .NET Core applications and services

### CI/CD Pipeline using VSTS
The entire project is setup to demonstrate continuous delivery via CI/CD pipelines setup in Visual Studio Team Services. When a change is checked in by a developer, the pipeline will build the application, deploy the artifacts back into the github repository, and push the applications on to PAS.

## Projects
The following are the projects found in this repository and a short description of the functionality that each is designed to demonstrate.

### Exchange UI
Standalone web application for the PCF Exchange demo/workshop.

### Market Data Service
Market data service used by the PCF Exchange demo/workshop.

### Order Manager Service (Java and .NET Core)
Order manager service used by the PCF Exchange demo/workshop.

### Exchange BTUSD Service
Currency conversion service used by the PCF Exchange demo/workshop.

### Exchange Legacy Service
.NET Framework version of the Exchange BTUSD Service used by the PCF Exchange demo/workshop.

## Installation Instructions
### Deploying through the VSTS Pipeline
This demo source code repository has been integrated into a CI/CD pipeline using Visual Studio Team Services. The build and release jobs developed leverage the Cloud Foundry plug-in to deploy the application on to Pivotal Cloud Foundry. 
The portal for the VSTS CI/CD pipeline can be found [here](https://pivotal-workshops.visualstudio.com/Workshop/). Access is required to the portal to view the job definitions.

### Installation Packages without Visual Studio
Installation packages that are ready to push are available in the Release section of this repository.  You can find them [here](https://github.com/corn-pivotal/Workshop-v3/releases).

### Cloning and Building the Solution
This project is developed using Visual Studio 2017. To build this solution, clone this repo and open the solution file. The projects can then be published and pushed from the publish folder. 

### Configuration
Additional configuration instructions can be found in the content directory of this project.





