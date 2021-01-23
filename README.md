# InternetSpeedMonitor

This is for long term monitoring of your internet speeds. This is meant to be used and scheduled on an always on machine. I created this to hold ISPs accountable. This will output a log for a given day in the provide directory. It will also out a csv file for all the results in a given day. This file can be used to send to your ISP as evidence in any conflicts you may have.

Please be sure to change the following settings in the App.config file, before you run this. For the Log and Results folder be sure to include a '\' at the end of the path.
  LogFolder: This will be the directory that the log files will write to.
  ResultsFolder: this will be the directory that the csv file is generated in.
  
As of right now only 2 servers are available to test from. They are located in New York and California. To select the server closest to you please check the App.config file and mark the UseCalifiornia setting to 'True' if you wish to use the California server or the UseNewYork setting to 'True' if you would like to use the New York server. The other option should be 'False'.
  
