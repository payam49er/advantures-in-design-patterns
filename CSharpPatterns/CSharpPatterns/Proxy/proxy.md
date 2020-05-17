#Proxy Pattern
Motivation is to provide an interface to a particular resource. The resource might be remote, expensive to construct, or may require logging 
or some other added functionality. 

#Protection Proxy
Protection proxy pattern is about access limitation. We want to make sure that certain API is only accessible to certain authorized requests.
With Protection Proxy, you use the interface that you have and create a wrapper. In the wrapper, you implement the logic to create protection 
and authority restrictions. 

#Property Proxy
This pattern helps us to create a property that needs to be exposed in different ways. Using an object to represent a property rather than literally 
using a property. 

#Value Proxy
It is a proxy that is created over a primitive type. Why? imagine you have an int or float, and you want to have stronger typing. 
A wrapper around a primitive value that controls certain operations around a value type. 