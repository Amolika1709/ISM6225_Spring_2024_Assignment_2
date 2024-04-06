/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
test

*/

using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3,6,9,1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2,1,2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Check if the array is empty, if so, return 0.
                if (nums.Length == 0) return 0;

                // Initialize a pointer i to keep track of the unique elements.
                int i = 0;

                // Iterate through the array starting from the second element.
                for (int j = 1; j < nums.Length; j++)
                {
                    // If the current element is different from the previous unique element,
                    // increment i and update nums[i] to the current element.
                    if (nums[j] != nums[i])
                    {
                        i++;
                        nums[i] = nums[j];
                    }
                }

                // Create a StringBuilder to construct the output string.
                StringBuilder output = new StringBuilder();
                output.Append("Output: ");
                output.Append(i + 1); // Number of unique elements.
                output.Append(", nums = [");

                // Iterate through the array to construct the output string.
                for (int k = 0; k < nums.Length; k++)
                {
                    if (k <= i)
                    {
                        output.Append(nums[k]); // Append unique elements.
                    }
                    else
                    {
                        output.Append("_"); // Append placeholders for non-unique elements.
                    }

                    if (k < nums.Length - 1)
                    {
                        output.Append(", "); // Add comma and space for separation.
                    }
                }

                output.Append("]");

                // Print the formatted output.
                Console.WriteLine(output.ToString());

                // Return the number of unique elements (i + 1).
                return i + 1;
            }
            catch (Exception)
            {
                throw; // Propagate any exceptions.
            }
        }

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                int lastNonZeroIndex = 0; // Initialize a variable to keep track of the last index where a non-zero element was found.

                // Iterate through the array.
                for (int currentIndex = 0; currentIndex < nums.Length; currentIndex++)
                {
                    // If the current element is non-zero, move it to the position of the last non-zero element found.
                    if (nums[currentIndex] != 0)
                    {
                        nums[lastNonZeroIndex++] = nums[currentIndex];
                    }
                }

                // After moving all non-zero elements to the beginning of the array, fill the remaining positions with zeros.
                for (int i = lastNonZeroIndex; i < nums.Length; i++)
                {
                    nums[i] = 0;
                }

                // Convert the modified array to a list and return it.
                return nums.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Sort the input array in ascending order.
                Array.Sort(nums);

                // Initialize a list of lists to store the resulting triplets.
                IList<IList<int>> result = new List<IList<int>>();

                // Iterate through the array until the third last element.
                for (int firstIndex = 0; firstIndex < nums.Length - 2; firstIndex++)
                {
                    // Check if it's the first element or a different element from the previous one.
                    if (firstIndex == 0 || (firstIndex > 0 && nums[firstIndex] != nums[firstIndex - 1]))
                    {
                        // Set pointers for the two remaining elements of the triplet.
                        int secondIndex = firstIndex + 1, thirdIndex = nums.Length - 1, targetSum = 0 - nums[firstIndex];

                        // Iterate until the pointers meet.
                        while (secondIndex < thirdIndex)
                        {
                            // If the sum of the two elements equals the target sum, add the triplet to the result.
                            if (nums[secondIndex] + nums[thirdIndex] == targetSum)
                            {
                                result.Add(new List<int> { nums[firstIndex], nums[secondIndex], nums[thirdIndex] });

                                // Skip duplicates for the left pointer.
                                while (secondIndex < thirdIndex && nums[secondIndex] == nums[secondIndex + 1]) secondIndex++;
                                // Skip duplicates for the right pointer.
                                while (secondIndex < thirdIndex && nums[thirdIndex] == nums[thirdIndex - 1]) thirdIndex--;

                                // Move both pointers inward.
                                secondIndex++;
                                thirdIndex--;
                            }
                            // If the sum is less than the target, move the left pointer to the right.
                            else if (nums[secondIndex] + nums[thirdIndex] < targetSum)
                            {
                                secondIndex++;
                            }
                            // If the sum is greater than the target, move the right pointer to the left.
                            else
                            {
                                thirdIndex--;
                            }
                        }
                    }
                }

                // Return the list of triplets.
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Initialize variables to keep track of the maximum count of consecutive ones and the current count.
                int maximumConsecutiveOnes = 0;
                int currentConsecutiveOnes = 0;

                // Iterate through the array.
                foreach (int number in nums)
                {
                    // Check if the current number is 1.
                    if (number == 1)
                    {
                        // Increment the count of consecutive ones and update the maximum count if needed.
                        currentConsecutiveOnes++;
                        maximumConsecutiveOnes = Math.Max(maximumConsecutiveOnes, currentConsecutiveOnes);
                    }
                    else
                    {
                        // If the current number is not 1, reset the count of consecutive ones.
                        currentConsecutiveOnes = 0;
                    }
                }

                // Return the maximum count of consecutive ones.
                return maximumConsecutiveOnes;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // Initialize variables to store the decimal value and the base value.
                int decimalValue = 0; // This will store the final decimal value.
                int baseValue = 1; // This represents the current base value, starting with 2^0.

                // Iterate until the binary number is greater than 0.
                while (binary > 0)
                {
                    // Extract the last digit of the binary number.
                    int lastDigit = binary % 10;

                    // Remove the last digit from the binary number.
                    binary = binary / 10;

                    // Update the decimal value by adding the contribution of the last digit.
                    decimalValue += lastDigit * baseValue;

                    // Update the base value by multiplying it by 2, as we are moving to the next position.
                    baseValue = baseValue * 2;
                }

                // Return the calculated decimal value.
                return decimalValue;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // Check if the array has less than 2 elements, in which case the maximum gap is 0.
                if (nums.Length < 2) return 0;

                // Sort the array in ascending order.
                Array.Sort(nums);

                // Initialize a variable to store the maximum gap between consecutive elements.
                int maxGap = 0;

                // Iterate through the sorted array to find the maximum gap between consecutive elements.
                for (int i = 1; i < nums.Length; i++)
                {
                    // Calculate the difference between the current element and the previous one.
                    int gap = nums[i] - nums[i - 1];

                    // Update the maximum gap if the current gap is greater.
                    maxGap = Math.Max(maxGap, gap);
                }

                // Return the maximum gap.
                return maxGap;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Sort the array in non-decreasing order.
                Array.Sort(nums);

                // Iterate from the second last element backward until the third element.
                for (int currentIndex = nums.Length - 3; currentIndex >= 0; currentIndex--)
                {
                    // Check if the current triplet forms a valid triangle.
                    if (nums[currentIndex] + nums[currentIndex + 1] > nums[currentIndex + 2])
                    {
                        // If a valid triangle is found, return the sum of its sides.
                        return nums[currentIndex] + nums[currentIndex + 1] + nums[currentIndex + 2];
                    }
                }

                // If no valid triangle is found, return 0.
                return 0;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Iterate as long as the string 's' contains the substring 'part'.
                while (s.Contains(part))
                {
                    // Find the index of the first occurrence of the substring 'part' in the string 's'.
                    int indexOfPart = s.IndexOf(part);

                    // If the substring 'part' is found in the string 's', remove it.
                    if (indexOfPart != -1)
                    {
                        s = s.Remove(indexOfPart, part.Length);
                    }
                }

                // Return the modified string 's' enclosed within double quotes.
                return $"\"{s}\"";

            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}