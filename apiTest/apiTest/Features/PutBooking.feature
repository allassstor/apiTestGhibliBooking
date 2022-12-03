@setup_feature
Feature: PutBooking

Scenario: Updates a current booking
	When updating data by id
	Then checking if the updates are saved