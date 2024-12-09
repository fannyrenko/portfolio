using System;

class PalindromeChecker
{
    // Static method to check if a string is a palindrome
    public static bool IsPalindrome(string str)
    {
        // Convert the string to lowercase to handle case-insensitivity
        str = str.ToLower();

        // Initialize pointers for the start and end of the string
        int left = 0;
        int right = str.Length - 1;

        // Continue checking until the pointers meet
        while (left < right)
        {
            // Skip non-alphanumeric characters from the left
            while (left < right && !char.IsLetterOrDigit(str[left]))
            {
                left++;
            }

            // Skip non-alphanumeric characters from the right
            while (left < right && !char.IsLetterOrDigit(str[right]))
            {
                right--;
            }

            // If the characters at the current pointers are not equal, return false
            if (str[left] != str[right])
            {
                return false;
            }

            // Move the pointers inward
            left++;
            right--;
        }

        // If all characters matched, return true (it's a palindrome)
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to enter a string
        Console.WriteLine("Enter a sentence or word:");
        string input = Console.ReadLine();

        // Check if the input string is a palindrome using the PalindromeChecker class
        bool isPalindrome = PalindromeChecker.IsPalindrome(input);

        // Display the result to the user
        if (isPalindrome)
        {
            Console.WriteLine("The given string is a palindrome.");
        }
        else
        {
            Console.WriteLine("The given string is not a palindrome.");
        }
    }
}
