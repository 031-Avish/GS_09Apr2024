#learning condotional statements with code and documentation

#Conditional Statements
#Conditional statements are used to decide the flow of execution based on different conditions.
#Python supports the following conditional statements:
#1. if statement

#Syntax:
#if condition:
#    statement

#Example:
a=10
b=20
if a>b:
    print("a is greater than b")

#2. if-else statement
#Syntax:
#if condition:
#    statement
#else:
#    statement

#Example:
a=10
b=20
if a>b:
    print("a is greater than b")
else:
    print("b is greater than a")

#3. if-elif-else statement
#Syntax:
#if condition:
#    statement
#elif condition:
#    statement
#else:
#    statement

#Example:
a=10
b=20
if a>b:
    print("a is greater than b")
elif a==b:
    print("a is equal to b")
else:
    print("b is greater than a")

#Nested if statement
#Syntax:
#if condition:
#    statement
#    if condition:
#        statement
#    else:
#        statement
#else:
#    statement

#Example:
a=10
b=20
if a>b:
    print("a is greater than b")
else:
    print("b is greater than a")
    if a==b:
        print("a is equal to b")
    else:
        print("a is not equal to b")

#Short Hand if
#Syntax:
#if condition: statement

#Example:
a=10
b=20
if a>b: print("a is greater than b")

#Short Hand if-else
#Syntax:
#statement if condition else statement

#Example:
a=10
b=20
print("a is greater than b") if a>b else print("b is greater than a")

#Pass statement
#The pass statement is used to write empty loops. It is used when you do not have the content ready.
#Syntax:
#pass

#Example:
a=10
b=20
if a>b:
    pass
else:
    print("b is greater than a")

