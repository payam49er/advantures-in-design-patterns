# Decorator

Adding behavior without altering a class itself. This is related to open closed relationship. 
Imagine you are doing unit testing, and you want to add a new funcitonality to your calss. But, you don't want to alter your existing code. You want to keep the new functionality seperate. (single responsibility)
It also needs to interact with the existing structure. 

Two options:
1. Inherit if your class is not sealed
2. If it is sealed, then you need to create a decorator pattern. Simply reference the object and build new functionality around that. In another word, extension method.

#CodeBuilder 
This class is an example of building a mutable StringBuilder style class. We are using StringBuilder functionality under another object. Now, we can extend other functionality 
to the StringBuilder that comes with .Net framewrok. 

#MyStringBuilder
MyStringBuilder demonstrates when we mix adapter pattern with decorator. Here, we replicate StringBuilder under MyStringBuilder, but we implement
an interface to be able to do +=


#Drago,Bird,Lizard
Here I show how C# resolves diamond problem that is common in multi inheritance languages such as C#. It is not a very elegant solution though.

#ICreature
Here, I am going to show the default interface that came with C# 8  syntax. this approach is intrusive and breaks the open/close principle as you 
have to go into the class and make some changes! You also need to do the casting that is showin in the main method.

#Dynamic Decorator
this is demonstrated in shape. We add decorator on top of decorator and this works well at the runtime as well. 

#Static Decorator
C# is not a great language for doing this. C++ is better for doing this. Because it can inherit from template argument. recurring template pattern in C++