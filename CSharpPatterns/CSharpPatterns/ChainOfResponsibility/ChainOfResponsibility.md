#Motivation
A chain of components who all get a chance to process a command or a query, 
optionally having default processing implementation and an ability to terminate the processing chain. 

##Command Query Separation
There are two types of methods, command or query. Command asks for an action or change.
Query asks for information. 
CQS -> having seperate means of sending commands and queries e.g., direct field access