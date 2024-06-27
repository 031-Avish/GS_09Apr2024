inp = None
while True:
    inp = input("Enter a number: ")
    if not inp.isdigit():
        print("Please enter a valid number.")
    else:
        break


num = int(inp)
def isPrime(num):
    if num>1:
        for i in range(2,int(num/2)+1):
            if(num%i==0):
                return False
    else:
        return False
    return True
if(isPrime(num)):
    print(num, "is a prime number.")
else:
    print(num, "is not a prime number.")


    