# BlackJack
To Run:
Clone and open solution file in /BlackJack directory
Restore nugets, build and run API.
Swagger should startup to show the API

To Play (via Swagger):
POST /BlackJack to Create a new game with a list of Participants (only one tested at the moment)
GET /BlackJack to get the players current hand if the game is in progress. Will also return the dealers hand if the game is finished
PUT /BlackJack to Hit or Stick for a participant

WishList
1) Better code coverage and more unit testing
2) Better seperation with Clean Architecture (possibly introduce an Infrastructure assembly)