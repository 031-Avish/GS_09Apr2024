#Function to show ways to print output in python
def printOutput():
    print("hello world")
    print("hello","world")  #default separator is space
    print("hello"+"world")  #concatenation
    print("hello","world",sep=" ") #separator is space
    print("hello","world",sep="") #no separator
    print("hello","world",sep=":") #separator is colon
    print("hello","world",sep="---") #separator is ---
    print("hello","world",sep="---",end=" ") #separator is --- and  end is space (No new line character is printed)
    print("hello world") 
    print("hello world",end=" ")    #end is space (No new line character is printed)

printOutput()