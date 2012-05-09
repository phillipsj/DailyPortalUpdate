Introduction
============

This application is a C# console application that uses the [Socrata C# API](https://github.com/socrata/socrata-api-csharp).  The applicaiton reads a list of datasets that needed updated and loops through each one, creates a working copy, publishes the dataset, then sets it to publicly viewable.  Not all configuration is in the configuration file at the moment, but will be soon.  The application uses [log4net](http://logging.apache.org/log4net/) for logging and currently configured to write an Apache error log style log.

Development Environment
=======================

The application was developed using MonoDevelop and the Mono 2.10.8 framework.  The application should run the .NET framework without issue.

Dependencies
------------

The dependencies for this application are in the *Libs* folder.  The **Socrata.dll** and the **log4net.dll** are the only external dependencies.  

Application Configuration
=========================

The application has an example app.config file named app.example.config.  You will need to rename the file to app.config, once it has been renamed you will need to enter your Socrata information as stated [here](https://github.com/socrata/socrata-api-csharp) in the *Configuration* section.  Also in the app.config file you will see a section called *Datasets*.  This section is the list of datasets that you want to update, the key is the view id from Socrata and value is the file that you want to upload.  The application assumes that the first row of the file is a header.  This may be added to the configuration file, but not at the moment.

log4net
-------

Since log4net is used for logging, the configuration section is included in the app.config.  If you would like to customize the configuration please refer [here](http://logging.apache.org/log4net/release/manual/configuration.html).  

Notes
=====

Make sure to install [root certificates](http://www.mono-project.com/FAQ:_Security) or https will not work with mono.
