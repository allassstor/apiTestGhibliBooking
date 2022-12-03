@setup_feature
Feature: GetGhibliLocationsId

Scenario: Returns an individual location
	When forms a request for receiving information by id
	Then check whether the information received