﻿using EntryControl;
// Filling up Event table
var simulate = new SimulateMovement();
simulate.Simulate();

// Make report of worked hours and saving all data to ReportWorkHours table, work time in seconds
var reportWorkHours = new GenerateReportWorkHours();
reportWorkHours.Generate();

//Make report of all event on all gates, sorting by worker name and time, savin data to ReportEvents table
var reportEvents= new GenerateEventsReport();
reportEvents.Generate();


