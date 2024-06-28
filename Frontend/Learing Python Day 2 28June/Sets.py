#learn sets with examples and documentation

# A set is a collection which is unordered and unindexed. In Python sets are written with curly brackets.
# Set items are 
# unordered, 
# unchangeable, 
# and do not allow duplicate values.

# Create a Set:
# Sets are created by placing all the items (elements) inside curly braces {}, separated by comma, or by using the built-in set() function.
# It can have any number of items and they may be of different types (integer, float, tuple, string etc.). But a set cannot have a mutable element, like list, set or dictionary, as its element.

# Example
# Create a Set:
thisset = {"apple", "banana", "cherry"}
print(thisset)

# Note: Sets are unordered, so you cannot be sure in which order the items will appear.

# Access Items
# You cannot access items in a set by referring to an index or a key.
# But you can loop through the set items using a for loop, or ask if a specified value is present in a set, by using the in keyword.

# Example
# Loop through the set, and print the values:
thisset = {"apple", "cherry","banana"}
for x in thisset:
  print(x)

# Example
# Check if "banana" is present in the set:
thisset = {"apple", "cherry","banana"}
print("banana" in thisset)

# Change Items
# Once a set is created, you cannot change its items, but you can add new items.

# Add Items
# To add one item to a set use the add() method.
# To add more than one item to a set use the update() method.

# Example
# Add an item to a set, using the add() method:
thisset = {"apple", "banana", "cherry"}
thisset.add("orange")
print(thisset)

# Example
# Add multiple items to a set, using the update() method:
thisset = {"apple", "banana", "cherry"}
thisset.update(["orange", "mango", "grapes"])
print(thisset) #output: {'apple', 'banana', 'cherry', 'grapes', 'mango', 'orange'}

# Get the Length of a Set
# To determine how many items a set has, use the len() method.

# Example
# Get the number of items in a set:
thisset = {"apple", "banana", "cherry","banana"}
print(len(thisset)) #output: 3

# Remove Item
# To remove an item in a set, use the remove(), or the discard() method.

# Example
# Remove "banana" by using the remove() method:
thisset = {"apple", "banana", "cherry"}
thisset.remove("banana")
print(thisset) #output: {'apple', 'cherry'}

# Note: If the item to remove does not exist, remove() will raise an error.

# Example
# Remove "banana" by using the discard() method:
thisset = {"apple", "banana", "cherry"}
thisset.discard("banana")
print(thisset) #output: {'apple', 'cherry'}

# Note: If the item to remove does not exist, discard() will NOT raise an error.

# You can also use the pop(), method to remove an item, but this method will remove the last item. Remember that sets are unordered, so you will not know what item that gets removed.

# The return value of the pop() method is the removed item.

# Example
# Remove the last item by using the pop() method:
thisset = {"apple", "banana", "cherry"}
x = thisset.pop() #output: cherry
print(x)
print(thisset) #output: {'apple', 'banana'}
# Note: Sets are unordered, so when using the pop() method, you will not know which item that gets removed.


# The clear() method empties the set:
thisset = {"apple", "banana", "cherry"}
thisset.clear()
print(thisset) #output: set()

# The del keyword will delete the set completely:
thisset = {"apple", "banana", "cherry"}
del thisset
# print(thisset) #this will raise an error because the set no longer exists

# Join Two Sets
# There are several ways to join two or more sets in Python.
# You can use the union() method that returns a new set containing all items from both sets, or the update() method that inserts all the items from one set into another:

# Example
# The union() method returns a new set with all items from both sets:
set1 = {"a", "b" , "c"}
set2 = {1, 2, 3}
set3 = set1.union(set2)
print(set3) #output: {1, 2, 3, 'a', 'b', 'c'}

# Example
# The update() method inserts the items in set2 into set1:
set1 = {"a", "b" , "c"}
set2 = {1, 2, 3}
set1.update(set2)
print(set1) #output: {1, 2, 3, 'a', 'b', 'c'}

# Note: Both union() and update() will exclude any duplicate items.

# The set() Constructor
# It is also possible to use the set() constructor to make a set.

# Example
thisset = set(("apple", "banana", "cherry")) # note the double round-brackets
print(thisset) #output: {'apple', 'banana', 'cherry'}
