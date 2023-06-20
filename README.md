# VuelingExam Project
## Made by Miquel Trujillo at Vueling University, 20/06/2023.

This .NET Framework 4.8 project is an implementation of a RESTful Windows Communication Foundation (WCF) service that processes student data. It leverages Dependency Injection (DI) via the Autofac framework, handles global errors, and provides logging functionality using the log4net library. 

## Basic Program Flow

1. The WCF Service (`VuelingWcfService`) accepts two primary operations. `WriteData` takes in a `StudentDto` object, checks if the provided student data is null, and then passes the student data to the business logic (`Bl`) layer for further processing. `ReadData` retrieves the list of `StudentDto` objects from the business logic layer.

2. The business logic layer (`Bl`) in turn interacts with the Infrastructure layer (`Repo`) to read or write student data, while also checking for null parameters.

3. The infrastructure layer (`Repo`) directly interacts with a file system for persistence. It uses an `IFileWrapper` for file operations, which allows for easier testing by abstracting the filesystem's operations, it also checks for null parameters.

## Detailed Info

~ Configuration and wiring of all components is done using the Autofac registrations in the `AutofacConfig` class, it also uses custom Modules like `Log4NetConfig.cs` and `AutofacConfigRepoInclusion.cs` for accessing Infrastructure layer (repo class) and integrating Log4Net into Autofac.

~ `StudentDto` class represents the student data that will be processed by the service. It includes properties for the student's name, surname, and a list of values.

~ The Bl class bridges the gap between the WCF service and the Infrastructure layer (Repo class).
The class `AutofacConfigRepoInclusion` is the Autofac Module that registers the `Repo` and `FileWrapper` classes with the Autofac DI container. This ensures that an instance of `Repo` or `FileWrapper` is provided when an `IRepo` or `IFileWrapper` is needed.

~ The service employs a global error handling system (`GlobalErrorBehaviorAttribute`, `GlobalErrorHandler`), which logs all unhandled exceptions and also wraps them in a WCF FaultException, ensuring the service provides enough information to the client without exposing sensitive data.

~ The service's logging writes both to the console and a daily rolling file. It uses a highly customized class-based setup (`Log4NetConfig`) instead of XML-based setup to provide a more code-focused customization.
On the class `Log4NetConfig` there's also a custom Autofac.Module Load method to integrate Log4Net easily into Autofac.
There are two reasons on why I created my own Log4Net Autofac module instead of using the built-in module provided by Autofac.Log4Net.
One reason is that Autofac.Log4Net downloads a vulnerable version of Log4Net by default and its references are too fragile and hard to fix if updated.
(CVE-2018-1285 https://github.com/advisories/GHSA-2cwj-8chv-9pp9)
The other reason is that Autofac.Log4Net, unlike Autofac or Log4Net, is a little-known third-party library, which can be really risky and hard to maintain if deployed into production.

~ `FileWrapper` is the wrapper class for `System.IO.File`, that implements `IFileWrapper`. This is to abstract the file system operations and makes the code more testable by making it possible to mock file operations.

~ `VuelingWcfService.svc` uses a customized Factory and Service to manage WCF from Autofac.

~ `Web.config` contains the SOAP to RESTful API configuration changes, along with an aditional layer of logging (`traceListener`) in case there's an exception before WCF starts.

~ `Global.asax.cs` contains the base code to gather the Autofac container from `AutofacConfig` and assign it to the AutofacHostFactory.

~ `RepoTests` is a suite of unit tests designed to ensure the correctness of the `Repo` class. It verifies that the `Repo` class writes and reads data correctly. This suite uses the Moq library to create mock objects for testing, ensuring that the tests are isolated and do not depend on the real file system or other external dependencies.
