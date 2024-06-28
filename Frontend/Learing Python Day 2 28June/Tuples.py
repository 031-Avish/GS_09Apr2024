# learn tuple with examples and documentation

# Tuple is a collection of items which is ordered and unchangeable. Allows duplicate members.
# Tuple items are indexed, the first item has index [0], the second item has index [1] etc.

# Tuple items are ordered, 
# unchangeable,
#  allow duplicate values.

# Create a Tuple:
# Tuple is created by placing all the items (elements) inside parentheses (), separated by commas.

# Example
# Create a Tuple:
thistuple = ("apple", "banana", "cherry")
print(thistuple)

#delete in tuple
# We cannot remove items in a tuple.
# Tuples are unchangeable, so you cannot remove items from it, but you can delete the tuple completely:

# Example
# The del keyword can delete the tuple completely:
thistuple = ("apple", "banana", "cherry")
del thistuple

# print(thistuple) #this will raise an error because the tuple no longer exists

# Tuple Methods
# Python has two built-in methods that you can use on tuples.

# Method	Description
# count()	Returns the number of times a specified value occurs in a tuple
example = (1, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9)   
print(example.count(2)) #output: 2

# index()	Searches the tuple for a specified value and returns the position of where it was found
example = (1, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9)
print(example.index(2)) #output: 1

# Tuple Length
# To determine how many items a tuple has, use the len() method:

# Example
thistuple = ("apple", "banana", "cherry")
print(len(thistuple))

# Tuple Items - Data Types
# Tuple items can be of any data type:

# Example
# String, int and boolean data types:
tuple1 = ("apple", "banana", "cherry") #string
tuple2 = (1, 5, 7, 9, 3) #int
tuple3 = (True, False, False) #bool
tuple4 = ("apple" , 1, 5, 7, 9, 3, True) #mix

# type() function
# From Python's perspective, tuples are defined as objects with the data type 'tuple':

# Example
mytuple = ("apple", "banana", "cherry")
print(type(mytuple)) #output: <class 'tuple'>

# The tuple() Constructor
# It is also possible to use the tuple() constructor to make a tuple.

# Example
thistuple = tuple(("apple", "banana", "cherry")) # note the double round-brackets
print(thistuple) #output: ('apple', 'banana', 'cherry')

# Tuple Unpack
# When we create a tuple, we normally assign values to it. This is called "packing" a tuple:

# Example
fruits = ("apple", "banana", "cherry")
a, b, c = fruits
print(a) #output: apple
print(b) #output: banana
print(c) #output: cherry

# Loop Through a Tuple
# You can loop through the tuple items by using a for loop.

# Example
thistuple = ("apple", "banana", "cherry")
for x in thistuple:
  print(x)

# Loop Through the Index Numbers
# You can also loop through the tuple items by referring to their index number.

# Use the range() and len() functions to create a suitable iterable.

# Example
thistuple = ("apple", "banana", "cherry")
for i in range(len(thistuple)):
  print(thistuple[i])

# Using a While Loop
# You can loop through the list items by using a while loop.

# Example
thistuple = ("apple", "banana", "cherry")
i = 0
while i < len(thistuple):
    print(thistuple[i])
    i = i + 1

# Join Two Tuples
# To join two or more tuples you can use the + operator:

# Example
tuple1 = ("a", "b" , "c")
tuple2 = (1, 2, 3)
tuple3 = tuple1 + tuple2
print(tuple3) #output: ('a', 'b', 'c', 1, 2, 3)

# Multiply Tuples
# If you want to multiply the content of a tuple a given number of times, you can use the * operator:

# Example
fruits = ("apple", "banana", "cherry")
mytuple = fruits * 2
print(mytuple) #output: ('apple', 'banana', 'cherry', 'apple', 'banana', 'cherry')


# Tuple Slicing
# You can return a range of items by using the slice syntax.

# Example
# Return the third, fourth, and fifth item:
thistuple = ("apple", "banana", "cherry", "orange", "kiwi", "melon", "mango")
print(thistuple[2:5]) #output: ('cherry', 'orange', 'kiwi')


