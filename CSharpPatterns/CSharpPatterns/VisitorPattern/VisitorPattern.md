##Visitor Design Pattern
There are situations when we need to add an operation to a class and all of its hierarchy. For example, a dcument model printable to
HTML/Markdown
We do not want to modify every class in the heirarchy. In this situation, an extension method possibly doesn't work as we need access to 
internal properties or fields. Creating an external component to handle the rendering is also very error prone. 

Visitor pattern helps us to solve this problem. A component (visitor) is allowed to traverse the entire inheritance hierarchy. 
Implemented by propagating a single visit() method throughout the entire hierarchy. 

##Dispatch
We need to understand what Dispatch is to understand how visitor works:
Which function to call?
Single dispatch: depends on name of request and type of receiver. Visitor design patter uses Double dispatch, which depends on name of request
and type of two receivers (type of visitor, type of element being visited). 