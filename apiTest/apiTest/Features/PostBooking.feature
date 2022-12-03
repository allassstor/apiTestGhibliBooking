@setap_feature
Feature: PostBooking

Scenario: Creates a new booking in the API
	When creates new information
	Then check if the information is added