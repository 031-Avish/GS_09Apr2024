#code to understand operators in python

#Arithmetic Operators
#Arithmetic operators are used to perform mathematical operations like addition, subtraction, multiplication etc.
print("Arithmetic Operators")
a=10
b=20
print("Addition: ",a+b)
print("Subtraction: ",a-b)
print("Multiplication: ",a*b)
print("Division: ",a/b)
print("Modulus: ",a%b)
print("Exponentiation: ",a**b)
print("Floor Division: ",a//b)

#Comparison Operators
#Comparison operators are used to compare values. It either returns True or False according to the condition.
a=10
b=20 
print("Comparison Operators")
print("a == b ",a==b)
print("a != b ",a!=b)
print("a > b ",a>b)
print("a < b ",a<b)
print("a >= b ",a>=b)
print("a <= b ",a<=b)


#Logical Operators
#Logical operators are the and, or, not operators.
a=10
b=20
print("Logical Operators")

print("a>b and a<b",a>b and a<b)
print("a>b or a<b",a>b or a<b)
print("not a>b",not a>b)


#Identity Operators
#Identity operators are used to compare the objects, not if they are equal, but if they are actually the same object, with the same memory location.
a=[1,2,3]
b=[1,2,3]
print("Identity Operators")
print("a and B are equal: ",a==b) #True because a and b have the same values    
print("a is b : ",a is b)  #False because a and b are two different objects
print(a is not b) #True because a and b are two different objects

a=[1,2,3]
b=a
print("a and B are equal: ",a==b) #True because a and b have the same values
print("a is b ",a is b)  #True because a and b are two different names for the same object
print(a is not b) #False because a and b are two different names for the same object

#Membership Operators
#Membership operators are used to test if a sequence is presented in an object.
print("Membership Operators")
list=[10,20,30,40]

print("10 in list",10 in list)
print("50 in list",50 in list)

#Bitwise Operators
#Bitwise operators are used to compare (binary) numbers.
print("Bitwise Operators")
a=10
b=20
print("a & b",a&b)  
print("a | b",a|b)
print("a ^ b",a^b)
print("~a",~a)
print("a << 2",a<<2)
print("a >> 2",a>>2)

#Assignment Operators
#Assignment operators are used to assign values to variables.
print("Assignment Operators")
a=10
b=20
a+=b
print(a)
a-=b
print(a)
a*=b
print(a)
a/=b
print(a)
a%=b
print(a)

#Ternary Operator
#Ternary operators also known as conditional expressions are operators that evaluate something based on a condition being true or false.
print("Ternary Operator")
a=10
b=20
min=a if a<b else b
print(min)
max=a if a>b else b
print(max)

#Operator Precedence
# ** Exponentiation
# ~ + - Complement, unary plus and minus (method names for the last two are +@ and -@)
# * / % // Multiply, divide, modulo and floor division
# + - Addition and subtraction
# >> << Right and left bitwise shift
# & Bitwise 'AND'
# ^ | Bitwise exclusive `OR' and regular `OR'
# <= < > >= Comparison operators
# <> == != Equality operators
# = %= /= //= -= += *= **= Assignment operators
# is is not Identity operators
# in not in Membership operators
# not or and Logical operators
# Parentheses () Parentheses

