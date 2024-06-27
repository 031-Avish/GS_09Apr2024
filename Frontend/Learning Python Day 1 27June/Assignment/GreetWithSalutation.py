#greet with salutation
def greetWithSalutation(name,salutation):
    print("Hello",salutation, name, "Welcome to Python World !!!")

name=input("Enter your name: ")
gender=input("Enter your gender: (M/F) ")

if(gender=="M" or gender=="m"): 
    greetWithSalutation(name,"Mr.")
elif(gender=="F" or gender=="f"):
    greetWithSalutation(name,"Ms.")
else:
    print("Wrong input. Please enter M or F.")

