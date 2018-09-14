using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_PersistenceFileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = "Data\\Data.txt";

            ObjectListReadWrite(textFilePath);

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        static void ObjectListReadWrite(string dataFile)
        {
            List<Character> CharacterClassListWrite = new List<Character>();

            List<string> CharacterStringListRead = new List<string>(); ;
            List<Character> CharacterClassListRead = new List<Character>(); ;

            // initialize a list of Character objects
            CharacterClassListWrite = InitializeListOfCharacters();

            Console.WriteLine("The following characters will be added to Data.txt.\n");
            // display list of Character objects
            DisplayCharacters(CharacterClassListWrite);

            Console.WriteLine("\nAdd characters to text file. Press any key to continue.\n");
            Console.ReadKey();

            // build the list of strings and write to the text file line by line
            WriteCharactersToTextFile(CharacterClassListWrite, dataFile);

            Console.WriteLine("Characters added successfully.\n");

            Console.WriteLine("Read into a string of Characters and display the Characters from data file. Press any key to continue.\n");
            Console.ReadKey();


            // build the list of Character class objects from the list of strings
            CharacterClassListRead = ReadCharactersFromTextFile(dataFile);

            // display list of Characters objects
            DisplayCharacters(CharacterClassListRead);
        }

        static List<Character> InitializeListOfCharacters()
        {
            List<Character> CharacterList = new List<Character>()
            {
                new Character()
                {
                    Id = 1,
                    LastName = "Flintstone",
                    FirstName = "Fred",
                    Address = "301 Cobblestone Way",
                    City = "Bedrock",
                    State = "MI",
                    Zip = "70777"
                },
                new Character()
                {
                    Id = 2,
                    LastName = "Rubble",
                    FirstName = "Barney",
                    Address = "303 Cobblestone Way",
                    City = "Bedrock",
                    State = "MI",
                    Zip = "70777"
                }
            };

            return CharacterList;
        }

        static void DisplayCharacters(List<Character> CharacterClassList)
        {
            foreach (Character character in CharacterClassList)
            {
                Console.WriteLine();
                Console.WriteLine($"Id: {character.Id}");
                Console.WriteLine($"Last Name: {character.LastName}");
                Console.WriteLine($"First Name: {character.FirstName}");
                Console.WriteLine($"Address: {character.Address}");
                Console.WriteLine($"City: {character.City}");
                Console.WriteLine($"State: {character.State}");
                Console.WriteLine($"Zip: {character.Zip}");
                Console.WriteLine();
            }
        }

        static void WriteCharactersToTextFile(List<Character> characterClassLIst, string dataFile)
        {
            string characterString;

            List<string> charactersStringListWrite = new List<string>();

            // build the list to write to the text file line by line
            foreach (var character in characterClassLIst)
            {
                characterString =
                    character.Id + "," +
                    character.LastName + "," +
                    character.FirstName + "," +
                    character.Address + "," +
                    character.City + "," +
                    character.State + "," +
                    character.Zip;

                charactersStringListWrite.Add(characterString);
            }

            File.WriteAllLines(dataFile, charactersStringListWrite);
        }

        static List<Character> ReadCharactersFromTextFile(string dataFile)
        {
            const char delineator = ',';

            List<string> CharacterStringList = new List<string>();

            List<Character> CharacterClassList = new List<Character>();

            // read each line and put it into an array and convert the array to a list
            CharacterStringList = File.ReadAllLines(dataFile).ToList();

            foreach (string characterString in CharacterStringList)
            {
                // use the Split method and the delineator on the array to separate each property into an array of properties
                string[] properties = characterString.Split(delineator);

                CharacterClassList.Add(
                    new Character() {
                        Id = Convert.ToInt32(properties[0]),
                        LastName = properties[1],
                        FirstName = properties[2],
                        Address = properties[3],
                        City = properties[4],
                        State = properties[5],
                        Zip = properties[6]
            });
            }

            return CharacterClassList;
        }
    }
}
