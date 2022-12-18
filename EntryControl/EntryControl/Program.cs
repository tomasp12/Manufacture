using EntryControl;
// Filling up Event Database
var simulate = new SimulateMovement();
simulate.Simulate();

// Make report off worked hours and saving all data to ReportWorkHours database, work time in seconds
var reportWorkHours = new GenerateReportWorkHours();
reportWorkHours.Generate();
