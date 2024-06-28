# Application to play the Cow and Bull game maintain score as well. - reff - Wordle of New York Times

#5 digit random number

import random

def generate_random_number():
    return random.randint(1000,9999)

def get_user_input():
    while True:
        user_input = input("Enter a 5 digit number: ")
        if not user_input.isdigit() or len(user_input) != 4:
            print("Please enter a valid 5 digit number.")
        else:
            break
    return user_input

def check_cow_bull(random_number, user_input):
    cow = 0
    bull = 0
    for i in range(4):
        if random_number[i] == user_input[i]:
            cow += 1
        elif user_input[i] in random_number:
            bull += 1
    return cow, bull

def play_game():
    random_number = str(generate_random_number())
    print(random_number)
    score = 500 #for each attempt 25 points will be deducted
    print("Welcome to the Cow and Bull game.")
    print("Rules:")
    print("1. You have to guess a 5 digit number.")
    print("2. If the digit is in the correct position, it is a cow.")
    print("3. If the digit is in the number but not in the correct position, it is a bull.")
    print("4. You have to guess the number in minimum attempts.")
    print("5. For each attempt 25 points will be deducted.")
    max_attempts = 20
    while max_attempts > 0:
        user_input = get_user_input()
        print("Score:", score)
        score -= 25
        max_attempts -= 1
        cow, bull = check_cow_bull(random_number, user_input)
        if cow == 4:
            print("You won the game score is",score , " with attempts left ." , max_attempts)
            return random_number
        print("Cows:", cow, "Bulls:", bull)
    return random_number
number= play_game()
print("Game Over")
print("Correct Number Was" ,number )

