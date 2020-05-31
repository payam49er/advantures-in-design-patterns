#Memento Pattern
An object or system goes through changes. 
There are different ways of navigating those changes. One way is to record every change (command) and tech a command to undo itself.
Another is to simply save snapshots of the system at particular point in time. 
So, Memento is a token/handle represnting the system state. It lets us to roll back to the state when the token was generated. May or may not directly expose state information. 
Essentially, we have to provide an API that gives back special tokens.

