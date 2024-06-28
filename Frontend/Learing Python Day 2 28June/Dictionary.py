#learn dictionary with examples and documentation

# A dictionary is a collection which is unordered, changeable and indexed. In Python dictionaries are written with curly brackets, and they have keys and values.
# Dictionary items are
# ordered,
# changeable,
# and does not allow duplicates.

# Create a Dictionary
# Dictionaries are written with curly brackets, and have keys and values:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}
print(my_dict)

# Dictionary Items
# Dictionary items are ordered, changeable, and does not allow duplicates.
# Dictionary items are presented in key:value pairs, and can be referred to by using the key name.
# Dictionary keys are unique, meaning that there can only be one key with a specific name in a dictionary.

# Example
# Print the "age" value of the dictionary:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}
print(my_dict["age"])

# Change Values
# You can change the value of a specific item by referring to its key name:
# Example
# Change the "age" to 40:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}
my_dict["age"] = 40
print(my_dict)

# Loop Through a Dictionary
# You can loop through a dictionary by using a for loop.
# When looping through a dictionary, the return value are the keys of the dictionary, but there are methods to return the values as well.
# Example
# Print all key names in the dictionary, one by one:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}
for x in my_dict:
    print(x)

# Example
# Print all values in the dictionary, one by one:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}
for x in my_dict:
    print(my_dict[x])

# Example
# You can also use the values() function to return values of a dictionary:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}
for x in my_dict.values():
    print(x)

# Example
# Loop through both keys and values, by using the items() function:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}
for x, y in my_dict.items():
    print(x, y)

# Check if Key Exists
# To determine if a specified key is present in a dictionary use the in keyword:
# Example
# Check if "model" is present in the dictionary:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}

if "model" in my_dict:
    print("Yes, 'model' is one of the keys in the my_dict dictionary")
else:
    print("No, 'model' is not one of the keys in the my_dict dictionary")
#output: No, 'model' is not one of the keys in the my_dict dictionary

# Dictionary Length
# To determine how many items (key-value pairs) a dictionary has, use the len() method.
# Example
# Print the number of items in the dictionary:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}
print(len(my_dict))

# Adding Items
# Adding an item to the dictionary is done by using a new index key and assigning a value to it:
# Example
# Add a new item to the original dictionary:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}
my_dict["model"] = "Mustang"
print(my_dict)

# Removing Items
# There are several methods to remove items from a dictionary:
# Example
# The pop() method removes the item with the specified key name:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}
my_dict.pop("age")
print(my_dict)

# Example
# The popitem() method removes the last inserted item:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}
my_dict.popitem()
print(my_dict)

# Example
# The del keyword removes the item with the specified key name:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}
del my_dict["city"]
print(my_dict)

# Example
# The del keyword can also delete the dictionary completely:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}
del my_dict
# print(my_dict) #this will raise an error because the dictionary no longer exists

# Example
# The clear() method empties the dictionary:
my_dict = {
    "name": "John",
    "age": 30,
    "city": "New York"
}
my_dict.clear()
print(my_dict)

# Dictionary Methods
# Python has a set of built-in methods that you can use on dictionaries.

# clear() - Removes all the elements from the dictionary
my_dict.clear()
print(my_dict)

# copy() - Returns a shallow copy of the dictionary
my_dict_copy = my_dict.copy()
print(my_dict_copy)

# fromkeys() - Returns a dictionary with the specified keys and values
keys = ['name', 'age', 'city']
values = ['John', 30, 'New York']
my_dict = dict.fromkeys(keys, values)
print(my_dict)

# get() - Returns the value of the specified key. If the key does not exist, it returns the specified default value
age = my_dict.get('age', 0)
print(age)

# items() - Returns a list containing a tuple for each key-value pair
items = my_dict.items()
print(items)

# keys() - Returns a list containing the dictionary's keys
keys = my_dict.keys()
print(keys)

# pop() - Removes the element with the specified key
my_dict.pop('age')
print(my_dict)

# popitem() - Removes the last inserted key-value pair
my_dict.popitem()
print(my_dict)

# setdefault() - Returns the value of the specified key. If the key does not exist, it inserts the key with the specified default value
name = my_dict.setdefault('name', 'Unknown')
print(name)

# update() - Updates the dictionary with the specified key-value pairs
my_dict.update({'age': 30, 'city': 'New York'})
print(my_dict)

# values() - Returns a list containing the dictionary's values
values = my_dict.values()
print(values)

# Nested Dictionaries
# A dictionary can contain dictionaries, this is called nested dictionaries.
# Example
# Create a dictionary that contain three dictionaries:
myfamily = {
    "child1": {
        "name": "Emil",
        "year": 2004
    },
    "child2": {
        "name": "Tobias",
        "year": 2007
    },
    "child3": {
        "name": "Linus",
        "year": 2011
    }
}
print(myfamily)

# Example
# Create three dictionaries, then create one dictionary that will contain the other three dictionaries:
child1 = {
    "name": "Emil",
    "year": 2004
}
child2 = {
    "name": "Tobias",
    "year": 2007
}
child3 = {
    "name": "Linus",
    "year": 2011
}

myfamily = {
    "child1": child1,
    "child2": child2,
    "child3": child3
}

print(myfamily)


