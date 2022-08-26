using System;
using System.Collections.Generic;

// Main()
string[][] friendsJaggedArray = new string[][]
{
    new string[] {"Nancy", "Jonathan"},
    new string[] {"Vecna", "Demogorgon", "Mind Flayer", "Papa", "The Mayor"},
    new string[] {"Lucas", "Dustin", "Will"},
    new string[] {"El", "Hopper", "Mike", "Eddie"},
};

charactersSayHello(friendsJaggedArray);

// Functions:
bool checkArraysInside(string[][] jaggedArray, string[] regularArray)
{
	for (int i = 0; i < jaggedArray.Length; ++i)
	{
		if (regularArray == jaggedArray[i])
			return true;
	}
	
	return false;
}

void charactersSayHello(string[][] jaggedArrayCharacters)
{
	string[] mainArray;
	string[][] remainArrays = new string[jaggedArrayCharacters.Length - 1][];
	int amountGreetings = 1;
	
	for (int x = 0; x < jaggedArrayCharacters.Length; ++x)
	{

		Console.WriteLine($"===Beginning of loop {x + 1}===");
		mainArray = jaggedArrayCharacters[x];

		Console.WriteLine("=============================\n");
		Console.WriteLine($"{nameof(mainArray)} at iteration number {x + 1}:");
		foreach (string person in mainArray)
		{
			Console.WriteLine(person);
		}

		Console.WriteLine("=============================\n");

		Console.WriteLine($"{nameof(remainArrays)} at iteration number {x + 1}:");
		for (int z = 0; z < remainArrays.Length; ++z)
		{
			for (int k = 0; k < jaggedArrayCharacters.Length; ++k)
			{
				if (jaggedArrayCharacters[k] != mainArray &&
				 !checkArraysInside(remainArrays, jaggedArrayCharacters[k]))
				{
					remainArrays[z] = jaggedArrayCharacters[k];
					break;
				}
			}
			foreach (string person in remainArrays[z])
				Console.WriteLine(person);
			Console.WriteLine("=====Next array inside of remainArrays====");
		}

		for (int v = 0; v < mainArray.Length; ++v)
		{
			for (int w = 0; w < remainArrays.Length; ++w)
			{
				foreach (string person in remainArrays[w])
				{
					Console.WriteLine($"{mainArray[v]} says 'Hey there!' to {person}, and this is greeting"
					+ $" number {amountGreetings}!");
					++amountGreetings;
				}
			}
		}
		Console.WriteLine($"\n===End of loop {x + 1}===");
	}

	Console.WriteLine("The amount of times the Stranger Things characters greeted each"+
			$" other was {amountGreetings - 1}");
}