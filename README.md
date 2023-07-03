# SuBook-Social-Networking-App

SuBook is a social networking application which has been implemented by using server and client modules. 

The Server module manages the storage of posts, posts feed, and friendships between the users, and the Client module acts as a user who shares posts, adds and removes other users from his/her friendship, and views posts of other users.

The server listens on a predefined port and accepts incoming client connections. 

Each client knows the IP address and the listening port of the server (to be entered through the Graphical User Interface (GUI)).

Clients connect to the server on a corresponding port and identify themselves with their usernames.

Server keeps the usernames of currently connected clients in order to avoid the same name to be connected more than once at a given time to the server.
