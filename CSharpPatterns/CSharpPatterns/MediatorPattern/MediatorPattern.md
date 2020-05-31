#Mediator Pattern
This pattern makes it possible for components to talk to each other without even being aware of each other's presence. 
Imagine situation where participants in a system can go in an out of the the system at anytime, a chat room is a good example. 
It makes no sense for such componentes to have a direct reference to each other. Those references may go dead. 
The solution is to have all such components refer to a central component that facilitates communication. 