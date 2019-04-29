using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
   class SinglePlayerWords
   {
      List<string> wordsList = new List<string>();
      List<string> easyWordsList = new List<string>();
      List<string> mediumWordsList = new List<string>();
      List<string> hardWordsList = new List<string>();
      List<string> eggWordsList = new List<string>();



      public List<string> ListOfWords
      {
         get => assignWordsList();
         set => wordsList = value;
      }

      public List<string> EasyWords
      {
         get => assignEasyList();
         set => easyWordsList = value;
      }

      public List<string> MediumWords
      {
         get => assignMediumList();
         set => mediumWordsList = value;
      }

      public List<string> HardWords
      {
         get => assignHardList();
         set => hardWordsList = value;
      }

      public List<string> EggWords
      {
         get => assignEggList();
         set => eggWordsList = value;
      }

      public List<string> assignWordsList()
      {
         List<string> tempList = new List<string>();
         //WordsArray = System.IO.File.ReadAllLines(@"../../Wo.txt");
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
   }
}
