// Team Charlie: Gill, Wagner [Hangman] - 04/30/19 - SinglePlayerWords: Holds lists of words/phrases for all the words available to play in single player mode

using System.Collections.Generic;

namespace HangMan
{
   class SinglePlayerWords
   {
      List<string> wordsList = new List<string>();
      List<string> easyWordsList = new List<string>();
      List<string> mediumWordsList = new List<string>();
      List<string> hardWordsList = new List<string>();
      List<string> eggWordsList = new List<string>();

      #region Lists (Properties)
      // List of all the words/phrases available in single player. Used for the "Random" selection.
      public List<string> ListOfWords
      {
         get => assignWordsList();
         set => wordsList = value;
      }

      // List of all the Easy difficulty words/phrases available in single player. Used for the "Easy" selection.
      public List<string> EasyWords
      {
         get => assignEasyList();
         set => easyWordsList = value;
      }

      // List of all the Medium difficulty words/phrases available in single player. Used for the "Medium" selection.
      public List<string> MediumWords
      {
         get => assignMediumList();
         set => mediumWordsList = value;
      }

      // List of all the Hard difficulty words/phrases available in single player. Used for the "Hard" selection.
      public List<string> HardWords
      {
         get => assignHardList();
         set => hardWordsList = value;
      }

      // List of all the Easter Egg words/phrases available from the Single Player start screen. Used for the "Easter Egg" selection hidden from the player (but still available to the player).
      public List<string> EggWords
      {
         get => assignEggList();
         set => eggWordsList = value;
      }
      #endregion

      #region Assign Lists Methods
      // Return a list of the words from all the List files to be assigned to the ListOfWords list
      public List<string> assignWordsList()
      {
         List<string> tempList = new List<string>();

         foreach(string x in EasyWords)
         {
            tempList.Add(x);
         }

         foreach (string x in MediumWords)
         {
            tempList.Add(x);
         }

         foreach (string x in HardWords)
         {
            tempList.Add(x);
         }

         return tempList;
      }

      // Return a list of the words from the EasyWords list file to be assigned to the EasyWords list
      public List<string> assignEasyList()
      {
         List<string> tempList = new List<string>();
         string[] WordsArray;
         WordsArray = System.IO.File.ReadAllLines(@"../../EasyWords.txt");
         foreach (string x in WordsArray)
         {
            tempList.Add(x);
         }

         return tempList;
      }

      // Return a list of the words from the MediumWords list file to be assigned to the EasyWords list
      public List<string> assignMediumList()
      {
         List<string> tempList = new List<string>();
         string[] WordsArray;
         WordsArray = System.IO.File.ReadAllLines(@"../../MediumWords.txt");
         foreach (string x in WordsArray)
         {
            tempList.Add(x);
         }

         return tempList;

      }

      // Return a list of the words from the HardWords list file to be assigned to the HardWords list
      public List<string> assignHardList()
      {
         List<string> tempList = new List<string>();
         string[] WordsArray;
         WordsArray = System.IO.File.ReadAllLines(@"../../HardWords.txt");
         foreach (string x in WordsArray)
         {
            tempList.Add(x);
         }

         return tempList;
      }

      // Return a list of the words from the EggWords list file to be assigned to the EggWords list
      public List<string> assignEggList()
      {
         List<string> tempList = new List<string>();
         string[] WordsArray;
         WordsArray = System.IO.File.ReadAllLines(@"../../EggWords.txt");
         foreach (string x in WordsArray)
         {
            tempList.Add(x);
         }

         return tempList;
      }
      #endregion
   }
}
