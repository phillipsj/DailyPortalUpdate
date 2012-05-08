#Introduction

This application is a C# console application that uses the [Socrata C# API](https://github.com/socrata/socrata-api-csharp).  The applicaiton reads a list of datasets that needed updated and loops through each one, creates a working copy, publishes the dataset, then sets it to publicly viewable.  Not all configuration is in the configuration file at the moment, but will be soon.

##Development Environment
The application was developed using MonoDevelop and the Mono 2.10.8 framework.  The application should run the .NET framework without issue.  

##Notes
Make sure to install [root certificates](http://www.mono-project.com/FAQ:_Security) or https will not work with mono.
