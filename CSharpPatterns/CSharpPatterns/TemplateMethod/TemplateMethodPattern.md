#Template Method Pattern
Algorithms can be decomposed into common parts and specifics
Strategy pattern does this through composition:
High Level Algorithm uses an interface
Concrete implementations implement the interface

TM does the same thing through inheritance:
Overall algorithm makes use of abstract members
Inheritors override the abstract members
Parent template method invoked

TM pattern allows us to define the skeleton of the algorithm with concerete implementations defined in subclasses