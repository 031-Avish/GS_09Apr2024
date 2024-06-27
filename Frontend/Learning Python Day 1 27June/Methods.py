#learn Methods in python with code and documentation

#Methods
#Methods are functions that are associated with an object.
#Syntax:
#def method_name(parameters):
#    statement
#    return

#Example:
#Method to add two numbers
def add(a,b):
    return a+b

print("Method to add two numbers")
print(add(10,20))

#method with no return value
def display():
    print("Hello World")

print("Method with no return value")
display()

#method with default parameter
def greet(name="John"):
    print("Hello",name)

print("Method with default parameter")
greet()
greet("Smith")

#method with variable length arguments
def add(*args):
    sum=0
    for i in args:
        sum+=i
    return sum

print("Method with variable length arguments")
print(add(10,20))
print(add(10,20,30))
print(add(10,20,30,40))

#method with variable length keyword arguments
def display(**kwargs):
    for key,value in kwargs.items():
        print(key,value)

print("Method with variable length keyword arguments")
display(name="John",age=25)
display(name="Smith",age=30,city="New York")

#method with return value
def add(a,b):
    return a+b

print("Method with return value")
print(add(10,20))

#method with multiple return values
def addSub(a,b):
    return a+b,a-b

print("Method with multiple return values")
sum,diff=addSub(20,10)
print("Sum=",sum)
print("Difference=",diff)

#method with lambda function
add=lambda a,b:a+b
print("Method with lambda function")
print(add(10,20))


