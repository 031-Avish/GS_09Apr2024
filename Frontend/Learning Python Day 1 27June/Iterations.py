#learning Iterations with code and documentation in python
#Iterations
#Iterations are used to execute a block of code multiple times.
#Python supports the following types of iterations:

#1. for loop
#Syntax:
#for variable in sequence:
#    statement

#Example:
#Print numbers from 1 to 10
print("for loop")
for i in range(1,11):
    print(i)

#2. while loop
#Syntax:
#while condition:
#    statement

#Example:
#Print numbers from 1 to 10
print("while loop")
i=1
while i<=10:
    print(i)
    i+=1

# do while loop is not available in python

#3. Nested loops
#Syntax:
#for variable in sequence:
#    for variable in sequence:
#        statement

#Example:
#Print numbers from 1 to 10
print("Nested loops")
for i in range(1,11):
    for j in range(1,11):
        print(i,j)

#4. Loop Control Statements
#Loop control statements change the execution from its normal sequence.
#Python supports the following loop control statements:

#1. break statement
#The break statement terminates the loop containing it.
#Control of the program flows to the statement immediately after the body of the loop.

#Example:
#Print numbers from 1 to 10 but break the loop when the number is 5
print("break statement")
for i in range(1,11):
    if i==5:
        break
    print(i)

#2. continue statement
#The continue statement is used to skip the rest of the code inside a loop for the current iteration only.
#Loop does not terminate but continues on with the next iteration.

#Example:
#Print numbers from 1 to 10 but skip the number 5
print("continue statement")
for i in range(1,11):
    if i==5:
        continue
    print(i)

#3. pass statement
#The pass statement is used as a placeholder for future code.
#When the pass statement is executed, nothing happens, but you avoid getting an error when empty code is not allowed.

#Example:
#Print numbers from 1 to 10 but pass the number 5
print("pass statement")
for i in range(1,11):
    if i==5:
        pass
    print(i)

#4. else statement
#The else statement is used to execute a block of code when the condition of the loop is false.

#Example:
#Print numbers from 1 to 10 but print "Loop is over" when the loop is over
print("else statement")
for i in range(1,11):
    print(i)
else:
    print("Loop is over")

#5. range() function
#The range() function is used to generate a sequence of numbers.
#Syntax:
#range(start,stop,step)

#Example:
#Print numbers from 1 to 10 using the range() function
print("range() function")
for i in range(1,11):
    print(i)
    
#6. enumerate() function
#The enumerate() function is used to add a counter to an iterable and return it.
#Syntax:
#enumerate(iterable,start)

#Example:
#Print the index and value of each element in a list
print("enumerate() function")
list=[10,20,30,40]
for index,value in enumerate(list):
    print(index,value)

#7. zip() function
#The zip() function is used to combine two or more lists into a single list.
#Syntax:
#zip(list1,list2)

#Example:
#Combine two lists into a single list

print("zip() function")
list1=[10,20,30,40]
list2=[50,60,70,80]
for i,j in zip(list1,list2):
    print(i,j)

#8. reversed() function
#The reversed() function is used to reverse the order of an iterable.
#Syntax:
#reversed(iterable)

#Example:
#Reverse the order of a list
print("reversed() function")
list=[10,20,30,40]
for i in reversed(list):
    print(i)

