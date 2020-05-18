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

#Composite Proxy
There is a combination of proxy and composite pattern. This is a composite proxy, which allows us to create a pattern which we can work with large 
volumes of data. This pattern is used very often in game design. Modern CPUs like to have the data that they need to process next to each other. 
The modern CPU likes to have predictable data, and this has more to do with the internal instructions and the architecture of moden CPUs.


#Dynamic Proxy
Sometimes you want to construct a proxy at the runtime even with all the associated computation cost. One of the ways to achive this is by using

impromptu-interface (https://github.com/ekonbenefits/impromptu-interface)
Overall, when we have a dynamic object, we don't know its properties or functionality. Using Dyanimc proxy, we can implement such properties or
functionality for a dynamic object. 

#Proxy vs Decorator

Proxy provides an identical interface; decorator provides an enhanced interface. Decorator may replicate some or all of the interfce of an object, but 
decorator adds other functionality too

Decorator typically aggerages or has reference to what it is decorating. proxy doesn't have to

Proxy might not even be working with a metrialized object. Thik of it as the Lazy over an entire object. 