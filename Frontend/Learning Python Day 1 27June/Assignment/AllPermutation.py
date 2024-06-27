#find permutation of string

from itertools import permutations
inp = input("Enter a string: ")
perm = permutations(inp)
for i in list(perm):
    print(''.join(i))

