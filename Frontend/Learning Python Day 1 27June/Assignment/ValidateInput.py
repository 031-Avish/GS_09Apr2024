#Add validation the entered  name, age, date of birth and phone print details in proper format

name = input("Enter your name: ")
dob = input("Enter your date of birth: (DD-MM-YYYY) ")
phone = input("Enter your phone number: ")
import datetime
def calculateAge(dob):
    dob = datetime.datetime.strptime(dob, '%d-%m-%Y')
    today = datetime.date.today()
    age = today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))
    return age
def validateDate(dob):
    try:
        datetime.datetime.strptime(dob, '%d-%m-%Y')
    except ValueError:
        print("Incorrect data format, should be DD-MM-YYYY")
        return False
    return True
if not name.isalpha():
    print("Name should contain only alphabets. Please enter valid name.")
    
elif not phone.isdigit():
    print("Phone number should contain only digits. Please enter valid phone number.")
    
elif len(phone)!=10:
    print("Phone number should contain 10 digits. Please enter valid phone number.")
    
elif not validateDate(dob):
    print("Please enter valid date of birth.")
else:
    age=str(calculateAge(dob))
    print("User Details : ")
    print("******************************")
    print("Name          : ",name+
        "\nAge           : ",age+
        "\nDate of Birth : ",dob+
        "\nPhone         : ",phone)
    print("******************************")
