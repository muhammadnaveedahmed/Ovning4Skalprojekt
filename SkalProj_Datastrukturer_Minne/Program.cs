/* C # Data Structure Project 4 - Memory Management

Theory and Facts:

1. When data is stored in the stack, it is placed in a "Heap" so that the first stored object is at the bottom and the last stored object is placed at the top. 
 - So to access an object, all the above objects must be removed first.
 - When objects are stored, all objects are available all the time, as long as you know what to look for.
 - The advantage of data stored on the stack is that the data deletes itself when it has been used up, in contrast to the heap where stored data remains after it has been used.
 
2. Value types are stored on either the stack or on the heap, depending on where they are declared and always store the direct value in memory.
 - Reference types are always stored on the heap and instead store the address of the value in memory.
 
3. Since Int is a value type, when y is set to "= x", the value of x is copied to the memory position for y, x and y then points to different positions in the memory but which currently have the same value.
   When y is then set to "= 4", only the variable y is changed and not x, so what is returned is the original value of x which is set to 3.
   In the case of SkInt, SkInt must be a class that is a reference type.Thus, x stores the memory address of an instance of SkInt. 
   When y is set to "= x", the same memory address is copied from x to y and they both point to the same object. When then y.SkValue is set to "= 4", the value is set
   SkValue on the SkInt object that both x and y point to, and this is what is then returned.

Question # 1: ExamineList()

a. The capacity of the list increases when Count exceeds Capacity.
b. The capacity is doubled.
c. Since the size of the underlying array can not change dynamically during runtime, a new array must be created each time the size is to be changed, to then copy over all the previous values.
Therefore, it is usually more efficient to increase the capacity of the list by several elements at a time.
d. No The capacity of the list does not decrease when elements are removed.
e. When you can know in advance relatively accurately how many elements are to be stored in the structure.

Question # 2: ExamineQueue()
 - Queue Implimented in Queue Class
 - FIFO -> First in First Out
 - TestQueue Method

Questions # 3: ExamineStack()
 - FILO -> First in Last Out
 - Implimenting reverse text method and read a string from user using stack reverse the order of the characters.
 - Print the reverse string to the user.

Question # 4: CheckParanthesis()
 - Implimenting the CheckParanthesis method.
 - Load a string from the user and returned an answer that string is well-formed or not.


*/


using System;


namespace SkalProj_Datastrukturer_Minne
{


	class Program
	{

		/// <summary>
		/// The main method, vill handle the menues for the program
		/// </summary>
		/// <param name="args"></param>
		static void Main()
		{
			while (true)
			{
				Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
					+ "\n1. Examine a List"
					+ "\n2. Examine a Queue"
					+ "\n3. Examine a Stack"
					+ "\n4. CheckParanthesis"
					+ "\n0. Exit the application");
				char input = ' '; //Creates the character input to be used with the switch-case below.
				try
				{
					input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
				}
				catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
				{
					Console.Clear();
					Console.WriteLine("Please enter some input!");
				}
				switch (input)
				{
					case '1':
						ExamineList();
						break;
					case '2':
						ExamineQueue();
						break;
					case '3':
						ExamineStack();
						break;
					case '4':
						CheckParanthesis();
						break;
					/*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
					case '0':
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
						break;
				}
			}
		}

		/// <summary>
		/// Examines the datastructure List
		/// </summary>
		static void ExamineList()
		{
			/*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

			Console.WriteLine("Examine a List: \n"
				+ "\n+Value"
				+ "\n-Value"
				+ "\n0 - Return to Main Menu\n");

			List<string> theList = new List<string>(); // The list to store content and to be examined
			bool returnToMainMenu = false;

			while (!returnToMainMenu) // Work with the list until user wants to return to main menu
			{
				// Print contents of the list each loop
				Console.WriteLine($"Current List Count: {theList.Count}");
				Console.WriteLine($"Current List Capacity: {theList.Capacity}");
				Console.Write($"Current contents:");
				foreach (var entry in theList)
					Console.Write($" '{entry}'");
				Console.WriteLine();

				string? input = Console.ReadLine();
				if (input != null)
				{

					char? nav = input[0]; // Get first char in input string
					string value = input.Substring(1); // Get the remaining part of the input string

					switch (nav)
					{
						case '+': // Add
							theList.Add(value);
							break;
						case '-': // Remove
							theList.Remove(value);
							break;
						case '0': // Return to main menu
							returnToMainMenu = true;
							break;
						default: // Invalid input command
							Console.WriteLine("Please enter either +Value or -Value");
							break;
					}
				}
			}
		}

		/// <summary>
		/// Examines the datastructure Queue
		/// </summary>
		static void ExamineQueue()
		{
			/*
			 * Loop this method untill the user inputs something to exit to main menue.
			 * Create a switch with cases to enqueue items or dequeue items
			 * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
			*/

			bool returnToMainMenu = false;

			while (!returnToMainMenu)
			{

				Console.WriteLine("Examine a Queue: \n"
						+ "\nt - Test"
						+ "\n0 - Return to Main Menu");

				Queue<string> theQueue = new Queue<string>();
				List<string>? queueOperations = null;

				string? input = Console.ReadLine();
				if (input != null)
				{

					char? nav = input[0]; // Get first character in input string
					string value = input.Substring(1); // Get remaining part of input string

					switch (nav)
					{
						case 't': // Test queue
							queueOperations = TestQueue();
							break;
						case '0': // return to main menu
							returnToMainMenu = true;
							break;
						default: // Invalid input
							Console.WriteLine("Please enter a valid input.");
							break;
					}
				}

				if (queueOperations != null) // Check if the test queue data has been obtained from the ICA queue simulation
				{
					foreach (string operation in queueOperations)
					{
						switch (operation) // Each entry is either a name to be enqueued or a dequeue-command
						{
							case "Dequeue": // Deqeueu
								theQueue.Dequeue();
								break;
							default: // Enqueue, entry is a name
								theQueue.Enqueue(operation);
								break;
						}

						// Print contents after each queue operation
						Console.WriteLine($"Current Queue Count: {theQueue.Count}");
						Console.Write($"Current contents:");
						foreach (var entry in theQueue)
							Console.Write($" '{entry}'");
						Console.WriteLine();
					}
				}

			}
		}

		/// <summary>
		/// Provides queue operations, simulating a queue in a ICA store
		/// </summary>
		/// <returns>Simulated queue actions</returns>
		static List<string> TestQueue()
		{
			var queueOperations = new List<string>(); // Contains simulated queue actions

			queueOperations.Add("Kalle");
			queueOperations.Add("Greta");
			queueOperations.Add("Dequeue");
			queueOperations.Add("Stina");
			queueOperations.Add("Dequeue");
			queueOperations.Add("Olle");
			queueOperations.Add("Pelle");
			queueOperations.Add("Dequeue");
			queueOperations.Add("Dequeue");
			queueOperations.Add("Adam");
			queueOperations.Add("Dequeue");
			queueOperations.Add("Dequeue");

			return queueOperations;
		}

		/// <summary>
		/// Examines the datastructure Stack
		/// </summary>
		static void ExamineStack()
		{
			/*
			 * Loop this method until the user inputs something to exit to main menue.
			 * Create a switch with cases to push or pop items
			 * Make sure to look at the stack after pushing and and poping to see how it behaves
			*/


			bool returnToMainMenu = false;

			while (!returnToMainMenu)
			{

				Console.WriteLine("Examine a Queue: \n"
						+ "\nr - Reverse Text"
						+ "\n0 - Return to Main Menu");

				string? input = Console.ReadLine(); // Get user action

				if (input != null)
				{
					char? nav = input[0]; // Get first char in input string
					string value = input.Substring(1); // Get remaining part of input string

					switch (nav)
					{
						case 'r': // Reverse
							Console.WriteLine("Input string to reverse: ");
							var text = Console.ReadLine();
							var reversed = ReverseText(text);
							Console.WriteLine($"\nReversed: {reversed}\n");
							break;
						case '0': // Return to main menu
							returnToMainMenu = true;
							break;
						default: // Invalid input
							Console.WriteLine("Please enter a valid input.");
							break;
					}
				}
			}
		}

		/// <summary>
		/// Reverses the passed text string
		/// </summary>
		/// <param name="text">Text string to be reversed</param>
		/// <returns>The reversed text strings</returns>
		static string ReverseText(string text)
		{
			Stack<char> chars = new Stack<char>(); // Stores input string as a Stack of letters

			foreach (var c in text) // Fill the stack
				chars.Push(c);

			string result = String.Empty; // Will store the reversed string result

			for (var i = 0; i < text.Length; i++)
				result += (chars.Pop()); // Pop the letters from the stack, will be in reversed order

			return result;
		}

		static void CheckParanthesis()
		{
			/*
			 * Use this method to check if the paranthesis in a string is Correct or incorrect.
			 * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
			 * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
			 */

			Console.WriteLine("Check Paranthesis: \n"
					+ "\nc - Check String"
					+ "\n0 - Return to Main Menu");

			string? input = Console.ReadLine(); // Get user action
			if (input != null)
			{
				char? nav = input[0];

				switch (nav)
				{
					case 'c': // Check for paranthesis
						Console.WriteLine("Input string to check: ");
						var text = Console.ReadLine();
						var result = CheckStringForParanthesis(text);
						Console.WriteLine("\nFormat is " + (result ? "correct" : "incorrect") + ".\n");
						break;
					case '0': // Return to main menu
						return;
					default: // Invalid input
						Console.WriteLine("Please enter a valid input.");
						break;
				}
			}

		}

		/// <summary>
		/// Checks if the passed input string has a valid paranthesis format.
		/// </summary>
		/// <param name="text">Text string to be checked.</param>
		/// <returns>True on valid paranthesis format, otherwise false.</returns>
		private static bool CheckStringForParanthesis(string? text)
		{
			char[] openings = { '(', '[', '{', '<' };
			char[] closings = { ')', ']', '}', '>' };

			var openingChars = new Stack<char>(); // Will store all found opening paranthesises

			if (text != null)
			{
				foreach (char c in text) // Iterate through all letters
				{
					if (openings.Contains(c)) // Found an opening paranthesis
					{
						openingChars.Push(c); // Push to stack
					}
					else if (closings.Contains(c)) // Found a closing paranthesis
					{
						if (Array.IndexOf(openings, openingChars.Peek()) // Check if the last pushed opening is of the same type
						== Array.IndexOf(closings, c))                   // as the currently found closing paranthesis
						{
							openingChars.Pop(); // Then pop the last found opening
						}
					}

				}
			}

			if (openingChars.Count == 0) // No remaining unclosed paranthesis openings exist
				return true; // Check succeeded
			else
				return false; // Check failed
		}
	}
}
