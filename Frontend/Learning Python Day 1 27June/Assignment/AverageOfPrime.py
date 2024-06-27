def isPrime(num):
    if num>1:
        for i in range(2,int(num/2)+1):
            if(num%i==0):
                return False
    else:
        return False
    return True
sum=0
count=0
for i in range(1,11):
    while True:
        inp = input("Enter a number: ")
        if not inp.isdigit():
            print("Please enter a valid number.")
        else:
            if(isPrime(int(inp))):
                sum+=int(inp)
                count+=1
            break
if count==0:
    print("No prime number entered.")
else:
    Average=sum/count
    print("Average of prime numbers entered: ",Average)


    