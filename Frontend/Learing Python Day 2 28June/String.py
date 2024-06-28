#Learning Python string with some examples and documentation
# String

# String is a sequence of characters. It is a data type in python.
#  It is """immutable""". It means that once a string is created, it cannot be changed.
#  We can create a string by enclosing characters in single quotes or double quotes.
#  Python treats single quotes the same as double quotes.
#  Creating strings is as simple as assigning a value to a variable.
#  For example −

var1 = 'Hello World!'
var2 = "Python Programming"

# Accessing Values in Strings
# Python does not support a character type; these are treated as strings of length one, thus also considered a substring.
# To access substrings, use the square brackets for slicing along with the index or indices to obtain your substring.
# For example −

var1 = 'Hello World!'
var2 = "Python Programming"

print("var1[0]: ", var1[0])
print("var2[1:5]: ", var2[1:5]) # Output: ytho (index 1 to 4)

# Updating Strings
# You can "update" an existing string by (re)assigning a variable to another string.
# The new value can be related to its previous value or to a completely different string altogether.
# For example −

var1 = 'Hello World!'
print("Updated String :- ", var1[:6] + 'Python') # Output: Hello Python
##### var1[2]='a' ###### TypeError: 'str' object does not support item assignment
# var1[3]="Avish" # TypeError: 'str' object does not support item assignment

# Escape Characters
# Following table is a list of escape or non-printable characters that can be represented with backslash notation.
# An escape character is a backslash \ followed by the character you want to insert.
# An example of an illegal character is a double quote inside a string that is surrounded by double quotes:
# You will get an error if you use double quotes inside a string that is surrounded by double quotes:

# The following example will cause an error:
# txt = "We are the so-called "Vikings" from the north."
# To fix this problem, use the escape character \":
# The escape character allows you to use double quotes when you normally would not be allowed:

txt = "We are the so-called \"Vikings\" from the north."
print(txt) # Output: We are the so-called "Vikings" from the north.

# String Special Operators
# Assume string variable a holds 'Hello' and variable b holds 'Python', then −
# [a + b] will give HelloPython
# [a * 2] will give HelloHello
# [a[1]] will give e
# [a[1:4]] will give ell

a = 'Hello'
b = 'Python'

print(a + b) # Output: HelloPython
print(a * 2) # Output: HelloHello

# String Formatting Operator
# One of Python's coolest features is the string format operator %.
# This operator is unique to strings and makes up for the pack of having functions from C's printf() family.
# Following is a simple example −

name = "Avish"
print("Hello, %s!" % name) # Output: Hello, Avish!

# Here is the list of complete set of symbols which can be used along with % −
# %c	character
# %s	string conversion via str() prior to formatting
# %i	signed decimal integer
# %d	signed decimal integer
# %u	unsigned decimal integer
# %o	octal integer
# %x	hexadecimal integer (lowercase letters)
# %X	hexadecimal integer (UPPERcase letters)
# %e	exponential notation (with lowercase 'e')
# %E	exponential notation (with UPPERcase 'E')
# %f	floating point real number
# %g	the shorter of %f and %e
# %G	the shorter of %f and %E

# Triple Quotes
# Python's triple quotes comes to the rescue by allowing strings to span multiple lines, including verbatim NEWLINEs, TABs, and any other special characters.
# The syntax for triple quotes consists of three consecutive single or double quotes.
# An example is −

para_str = """this is a long string that is made up of several lines and non-printable characters such as TAB ( \t ) and they will show up that way when displayed. NEWLINEs within the string, whether explicitly given like this within the brackets [ \n ], or just a NEWLINE within the variable assignment will also show up. """

print(para_str)

# String Methods
# Python includes the following built-in methods to manipulate strings −
# capitalize()	Converts the first character to upper case

str = "this is string example....wow!!!"
print("str.capitalize() : ", str.capitalize()) # Output: This is string example....wow!!!

# center(width, fillchar)	Returns a string centered in a field
example = "Avish"
print(example.center(11, '*')) # Output: ***Avish***

# count(str, beg= 0,end=len(string))	Counts how many times str occurs in string or in a substring of string if starting index beg and ending index end are given

str = "this is string example....wow!!!"
sub = "i"
print("str.count(sub, 4, 40) : ", str.count(sub, 4, 40)) # Output: 2

str1 = "this is string example....wow!!!"
str2 = "exam"
print(str1.find(str2)) # Output: 15
print(str1.find(str2, 10)) # Output: 15 (start from 10th index)
print(str1.find(str2, 40)) # Output: -1 (start from 40th index)

# index(str, beg=0, end=len(string))	Same as find(), but raises an exception if str not found

str1 = "this is string example....wow!!!"
str2 = "exam"
print(str1.index(str2)) # Output: 15
print(str1.index(str2, 10)) # Output: 15 (start from 10th index)
# print(str1.index(str2, 40)) # Output: ValueError: substring not found

# isalnum()	Returns true if string has at least 1 character and all characters are alphanumeric and false otherwise

str = "this2009"  # No space in this string
print("str.isalnum() ",str.isalnum()) # Output: True

str = "this is string example....wow!!!"
print("str.isalnum() ",str.isalnum()) # Output: False

# isalpha()	Returns true if string has at least 1 character and all characters are alphabetic and false otherwise

str = "this"  # No space & digit in this string
print("str.isalpha()",str.isalpha()) # Output: True

str = "this is string example....wow!!!"
print("str.isalpha()",str.isalpha()) # Output: False

# isdigit()	Returns true if string contains only digits and false otherwise

str = "123456"  # Only digit in this string
print("str.isdigit() ",str.isdigit()) # Output: True

str = "this is string example....wow!!!"
print("str.isdigit() ",str.isdigit()) # Output: False

# islower()	Returns true if string has at least 1 cased character and all cased characters are in lowercase and false otherwise

str = "this is string example....wow!!!"
print("str.islower() ",str.islower()) # Output: True

str = "this is string example....WOW!!!"
print("str.islower() ",str.islower()) # Output: False

# isnumeric()	Returns true if a unicode string contains only numeric characters and false otherwise

str = "this2009"  # No space in this string
print("str.isnumeric() ",str.isnumeric()) # Output: False

str = "23443434"
print("str.isnumeric() ",str.isnumeric()) # Output: True

# isspace()	Returns true if string contains only whitespace characters and false otherwise

str = "       "  # Only space in this string
print("str.isspace() ",str.isspace()) # Output: True

str = "This is string example....wow!!!"
print("str.isspace() ",str.isspace()) # Output: False

# istitle()	Returns true if string is properly "titlecased" and false otherwise

str = "This Is String Example...Wow!!!"
print("str.istitle() ",str.istitle()) # Output: True

str = "This is string example....wow!!!"
print("str.istitle() ",str.istitle()) # Output: False

# isupper()	Returns true if string has at least one cased character and all cased characters are in uppercase and false otherwise

str = "THIS IS STRING EXAMPLE....WOW!!!"
print("str.isupper() ",str.isupper()) # Output: True

str = "THIS is string example....wow!!!"
print("str.isupper() ",str.isupper()) # Output: False

# join(seq)	Merges (concatenates) the string representations of elements in sequence seq into a string, with separator string

s = "-"
seq = ("a", "b", "c") # This is sequence of strings.

print(s.join( seq )) # Output: a-b-c

# len(string)	Returns the length of the string

str = "this is string example....wow!!!"
print("Length of the string: ", len(str)) # Output: 32

# lower()	Converts all uppercase letters in string to lowercase

str = "THIS IS STRING EXAMPLE....WOW!!!"
print("str.lower() ",str.lower()) # Output: this is string example....wow!!!

# lstrip()	Removes all leading whitespace in string

str = "     this is string example....wow!!!     "
print(str.lstrip()) # Output: this is string example....wow!!!

# max(str)	Returns the max alphabetical character from the string str

str = "this is really a string example....wow!!!"
print("Max character: " + max(str)) # Output: y

# min(str)	Returns the min alphabetical character from the string str

str = "this is a string example....wow!!!"
print("Min character: " + min(str)) # Output: " "

# replace(old, new [, max])	Replaces all occurrences of old in string with new or at most max occurrences if max given

str = "this is string example....wow!!! this is really string"
print(str.replace("is", "was")) # Output: thwas was string example....wow!!! thwas was really string

# rfind(str, beg=0,end=len(string))	Same as find(), but search backwards in string

str1 = "this is really a string example....wow!!!"
str2 = "is"
print(str1.rfind(str2)) # Output: 5
print(str1.rfind(str2, 10)) # Output: 25 (start from 10th index)
print(str1.rfind(str2, 40)) # Output: -1 (start from 40th index)

# rindex( str, beg=0, end=len(string))	Same as index(), but search backwards in string

str1 = "this is really a string example....wow!!!"
str2 = "is"
print(str1.rindex(str2)) # Output: 5
print(str1.rindex(str2, 10)) # Output: 25 (start from 10th index)
# print(str1.rindex(str2, 40)) # Output: ValueError: substring not found

# rstrip()	Removes all trailing whitespace of string

str = "     this is string example....wow!!!     "
print(str.rstrip()) # Output:      this is string example....wow!!!

# split(str="", num=string.count(str))	Splits string according to delimiter str (space if not provided) and returns list of substrings; split into at most num substrings if given

str = "Line1-abcdef \nLine2-abc \nLine4-abcd"
print(str.split( )) # Output: ['Line1-abcdef', 'Line2-abc', 'Line4-abcd']
print(str.split(' ', 1 )) # Output: ['Line1-abcdef', '\nLine2-abc \nLine4-abcd']

# splitlines( num=string.count('\n'))	Splits string at all (or num) NEWLINEs and returns a list of each line with NEWLINEs removed

str = "Line1-a b c d e f\nLine2- a b c\n\nLine4- a b c d"
print(str.splitlines( )) # Output: ['Line1-a b c d e f', 'Line2- a b c', '', 'Line4- a b c d']

# startswith(str, beg=0,end=len(string))	Determines if string or a substring of string (if starting index beg and ending index end are given) starts with substring str; returns true if so and false otherwise

str = "this is string example....wow!!!"
print(str.startswith( 'this' )) # Output: True
print(str.startswith( 'is', 2, 4 )) # Output: True

# strip([chars])	Performs both lstrip() and rstrip() on string

str = "     this is string example....wow!!!     "
print(str.strip()) # Output: this is string example....wow!!!

# swapcase()	Inverts case for all letters in string

str = "this is string example....wow!!!"
print(str.swapcase()) # Output: THIS IS STRING EXAMPLE....WOW!!!

# title()	Returns "titlecased" version of string

str = "this is string example....wow!!!"
print(str.title()) # Output: This Is String Example....Wow!!!

# upper()	Converts lowercase letters in string to uppercase

str = "this is string example....wow!!!"
print(str.upper()) # Output: THIS IS STRING EXAMPLE....WOW!!!


# string slicing    

# Python allows for either pairs of single or double quotes. Subsets of strings can be taken using the slice operator ([ ] and [:] ) with indexes starting at 0 in the beginning of the string and working their way from -1 at the end.

# The plus (+) sign is the string concatenation operator and the asterisk (*) is the repetition operator. For example −

str = 'Hello World!'
print("str[0]: ", str[0]) # Output: H
print("str[2:5]: ", str[2:5]) # Output: llo
print("str[2:]: ", str[2:]) # Output: llo World!
print("str * 2: ", str * 2) # Output: Hello World!Hello World!
print("str + 'TEST': ", str + 'TEST') # Output: Hello World!TEST

# Python String Formatting
# Escape Sequence	Description
# \\	Backslash (\)
# \'	Single quote (')
# \"	Double quote (")
# \t	ASCII Horizontal Tab (TAB)
# \n	ASCII Linefeed (LF)

