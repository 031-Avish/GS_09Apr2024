#pyramids of Star

def pyramid(n):
    for i in range(n):
        print(" "*(n-i-1) + "*"*(2*i+1))

num=None
while True:
    num = input("Enter a number: ")
    if not num.isdigit():
        print("Please enter a valid number.")
    else:
        break

pyramid(num)
