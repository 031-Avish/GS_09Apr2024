# print all prime numbers upto given number

inp = None
while True:
    inp = input("Enter a number to print all prime number upto the given no. : ")
    if not inp.isdigit():
        print("Please enter a valid number.")
    else:
        break

def isPrime(num):
    if num>1:
        for i in range(2,int(num/2)+1):
            if(num%i==0):
                return False
    else:
        return False
    return True
num = int(inp)
if(num<2):
    print("No prime number found.")
    exit()
print("Prime numbers upto", num, "are:")
for i in range(2,num+1):
    if isPrime(i):
        print(i)
