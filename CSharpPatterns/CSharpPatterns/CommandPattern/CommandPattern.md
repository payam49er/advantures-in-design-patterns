#Command Design Pattern
Ordinary C# statements are perishable. You can't undo a field or property assignment. We can't
directly serialize a sequence of actions. 

this is a very useful pattern in GUI commands. Multi level undo/redo,...
It lets us build an object which represents an instruction to perform a particular
action. It contains all the information necessary for the action to be taken. 

##Composite Command
One of the most common composite patterns is the composite command. It is a combination of the composite and command design pattern. 
Reminder ->  composite design pattern is wrapping multiple APIs into a single API. 