@setup_feature
Feature: DeleteBooking

Scenario:  Returns the ids of all the bookings that exist within the API. Can take optional query strings to search and return a subset of booking ids
	When delete the record
	Then check whether the record is deleted
	 