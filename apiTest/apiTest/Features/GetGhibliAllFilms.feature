@setup_feature
Feature: GetGhibliAllFilms

Scenario: 	The Films endpoint returns information about all of the Studio Ghibli films
	When forms a request to get all information about films
	Then checks whether the information is received