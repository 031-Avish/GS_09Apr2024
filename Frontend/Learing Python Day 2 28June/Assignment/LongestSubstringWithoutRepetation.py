# print Longest Substring Without Repeating Characters. That is in a given string find the longest substring that does not contain any character twice.
def longest_substring_without_repeating(s):
    start = 0
    char_map = {}
    ans=""
    # its a sliding window approach, when we find a repeating character
    # we move the start pointer to the next character of the repeating character
    # and update the character map
    #complexity is O(n) and substr function is O(n) so overall complexity is O(n^2)
    for end in range(len(s)):
        if s[end] in char_map:
            start = max(start, char_map[s[end]] + 1)
        char_map[s[end]] = end
        substr = s[start:end+1]
        if(len(substr)>len(ans)):
            ans=substr
    print("the longest substring without repeating characters is: ", ans)

# Test the function
str = input("Enter a string: ")
print(longest_substring_without_repeating(str))

