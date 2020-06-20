##Strategy Pattern
Many algorithms can be decomposed into higher and lower level parts
For example:
Making tea can be decomposed into 
1. The process of making a hot beverage (boil water, pour into a cup)
2. Tea specific things (put tea bag into the hot water)

The high level algorithm can then be reused for making coffee or hot chocolate
Then the beverage specific algorithm can be used for every specfic case. In some other languages, this pattern is known as Policy Pattern.


#Usage in .Net
One of the places that Startegy pattern is used heavily in .Net framework is in equality and comparison strategy. 