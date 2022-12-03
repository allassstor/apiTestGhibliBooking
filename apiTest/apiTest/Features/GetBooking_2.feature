@setup_feature
Feature: GetBooking_2

Scenario: Returns the ids of all the bookings that exist within the API. Can take optional query strings to search and return a subset of booking ids.
	When forms a request to get all id
	Then check whether the information is received

