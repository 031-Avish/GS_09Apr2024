#learn list and indexing in python with code and documentation

#List and Indexing
#List is a collection which is ordered and changeable. Allows duplicate members.
#List is defined by square brackets [].
#Indexing is used to access the elements of a list.
#Indexing starts from 0.
#Negative indexing starts from -1.
#Slicing is used to access a range of elements in a list.
#Syntax:
#list_name[index]
#list_name[start:end]
#list_name[start:end:step]

#Example:
#Create a list
list=[10,20,30,40]
print("List")
print(list)

#Access the first element of the list
print("Access the first element of the list")
print(list[0])

#Access the last element of the list
print("Access the last element of the list")
print(list[-1])

#Access a range of elements in the list
print("Access a range of elements in the list")
print(list[1:3])

#Access a range of elements in the list with step
print("Access a range of elements in the list with step")
print(list[0:4:2])

#Change the value of an element in the list
print("Change the value of an element in the list")
list[0]=50
print(list)

#Add an element to the list
print("Add an element to the list")
list.append(60)
print(list)

#Remove an element from the list
print("Remove an element from the list")
list.append(30)
list.remove(30) # removes the first occurence of 30
print(list)

#Insert an element at a specific position in the list
print("Insert an element at a specific position in the list")
list.insert(2,70) # insert 70 at index 2
print(list)

#Remove an element at a specific position in the list   
print("Remove an element at a specific position in the list")
list.pop(2) # removes the element at index 2
print(list)

#Remove the last element from the list
print("Remove the last element from the list")
list.pop()
print(list)

#Remove all elements from the list
print("Remove all elements from the list")
list.clear()
print(list)

#Copy a list
print("Copy a list")
list=[10,20,30,40]
list1=list.copy()
print(list1)

#Join two lists
print("Join two lists")
list2=[50,60,70,80]
list3=list+list2
print(list3)

#Join two lists using the extend() method
print("Join two lists using the extend() method")
list.extend(list2)
print(list)

#Count the number of times an element appears in the list
print("Count the number of times an element appears in the list")
list=[10,20,30,40,30]
print(list.count(30))

#Find the index of an element in the list
print("Find the index of an element in the list")
print(list.index(30))


