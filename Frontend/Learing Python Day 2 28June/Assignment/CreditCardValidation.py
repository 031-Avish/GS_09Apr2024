# Credit card validation - Luhn check algorithm

# explaination of Luhn check algorithm for credit card validation
# The Luhn algorithm, also known as the Luhn formula or modulus 10 algorithm, is a simple checksum formula used to validate a variety of identification numbers, such as credit card numbers, IMEI numbers, National Provider Identifier numbers in the United States, Canadian Social
# Insurance
# Numbers,

# The formula verifies a number against its included check digit, which is usually appended to a partial account number to generate the full account number. This number must pass the following test:

# From the rightmost digit (excluding the check digit) and moving left, double the value of every second digit. The check digit is neither doubled nor included in this calculation; the first digit doubled is the digit located immediately left of the check digit. If the result of this doubling operation is greater than 9 (e.g., 8 × 2 = 16), then add the digits of the result (e.g., 16: 1 + 6 = 7, 18: 1 + 8 = 9) or, alternatively, the same final result can be found by subtracting 9 from that result (e.g., 16: 16 − 9 = 7, 18: 18 − 9 = 9).
# Take the sum of all the digits.
# If the total modulo 10 is equal to 0 (if the total ends in zero) then the number is valid according to the Luhn formula; otherwise, it is not valid.

# Example

# Suppose the account number is 79927398713.
# Double every second digit from the right:
# 7 9 9 2 7 3 9 8 7 1 3
# 7 18 9 4 7 6 9 16 7 2 3
# Sum the digits of the products (e.g., 10: 1 + 0 = 1, 18: 1 + 8 = 9):
# 7 9 9 4 7 6 9 7 7 2 3
# Sum the remaining digits:
# 7 + 9 + 9 + 4 + 7 + 6 + 9 + 7 + 7 + 2 + 3 = 70
# Since the sum is divisible by 10, the account number is valid. This algorithm is used to validate credit card numbers.

# Write a python program to validate the credit card number using the Luhn check algorithm.

# Input
# 79927398713

# Output
# Credit card number is valid

# code for a 12 digit credit card number

def luhn_check(card_number):
    card_number = [int(x) for x in card_number]
    for i in range(0, len(card_number), 2):
        card_number[i] = card_number[i] * 2
        if card_number[i] > 9:
            card_number[i] = card_number[i] - 9
    return sum(card_number) % 10 == 0

card_number = input("Enter a 12 digit credit card number: ")
if luhn_check(card_number):
    print("Credit card number is valid")
else:
    print("Credit card number is not valid")
# Output: Credit card number is valid

