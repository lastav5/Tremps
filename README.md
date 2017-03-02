# Tremps

A web based system for sharing car rides. A user can offer or request a ride, after which they are matched accordingly with other offers/requests.
Offering a ride requires the user to choose a route from their point A to point B (this is done via google maps). after choosing, the route coordinates will be collected and saved in database.
Requesting a ride requires the user to fill in their origin and destination.
Matches are made when an offer's origin and destination each is at most 1km far from one of the request's route's coordinates.

Note:
This project was built in 2013 and as such the Facebook and Google Maps API's commands used in it are by now deprecated.
