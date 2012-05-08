using System;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using Socrata.Data.View;
using log4net;
using log4net.Config;
using log4net.Appender;

namespace DailyPortalUpdate
{
	class MainClass
	{
		/// <summary>
		/// The logger for log4net.
		/// </summary>
		private static readonly ILog logger = LogManager.GetLogger (typeof(MainClass));
		
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name='args'>
		/// The command-line arguments.
		/// </param>
		public static void Main (string[] args)
		{			
			//Load the configuration from the app.config file
			XmlConfigurator.Configure ();
				
			//Log the start of the update process			
			logger.Info ("Starting the upload process.");	
			
			//Get the datasets that need updating from the config file
			Hashtable datasets;			
			try {
				datasets = System.Configuration.ConfigurationManager.GetSection ("Datasets") as Hashtable;
			} catch (Exception ex) {
				logger.Error (ex.Message + ex.Source + ex.StackTrace);
				logger.Info ("Error loading list of datasets, now exiting.");
				return;
			}
			
			//Loop through each key-value pair and publish
			foreach (var key in datasets.Keys) {				
				logger.Info ("Starting to process: " + key.ToString ());
				
				//Append to a dataset 
				try {
					logger.Info ("Getting view " + key.ToString ());
					var v = View.FromId (key.ToString ());
					logger.Info ("Creating working copy.");
					var workingView = v.WorkingCopy ();						
					if (workingView != null) {
						workingView.Replace (datasets [key].ToString (), 1);							
						logger.Info ("Publishing dataset.");
						workingView.Publish ();
					} else {
						logger.Info ("View: " + key.ToString () + " was not found.");
					}
					logger.Info ("Setting dataset to public.");
					v.SetPublic (true);
				} catch (Exception ex) {
					//Log any errors that occur during the try
					logger.Error (ex.Message);
				}
			}			
			//Log when the data upload is finished
			logger.Info ("Data processing has finished.");
		}		
	}
}