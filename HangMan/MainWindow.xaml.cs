﻿// Team Charlie: Gill, Wagner [Hangman] - 04/30/19 - MainWindow: Main game window where the keyboard and gallows are displayed and the player can guess the word.

using HangMan.Letters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace HangMan
{
   public partial class MainWindow : Window
   {
      double width;
      double height;
      string guessingWord;
      int wrongGuess = 0;
      char[] charactersToHide = new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
      List<SingleLetter> singleLetters = new List<SingleLetter>();

      // MainWindow constructor that is given the difficulty level for Single Player and the Word to Guess is by default empty to indicate Single Player mode
      public MainWindow(int difficulty, string wordToGuess = "")
      {
         InitializeComponent();
         width = HangMan.Width;
         height = HangMan.Height + 75;

         #region Gallows
         // Instantiate Gallows

         /*  Hanging Line  */
         Line myLine1 = new Line();
         myLine1.Stroke = System.Windows.Media.Brushes.Black;
         myLine1.X1 = width - 100;
         myLine1.X2 = width - 100;
         myLine1.Y1 = height - 350;
         myLine1.Y2 = height - 300;
         myLine1.StrokeThickness = 4;
         HangMan.Children.Add(myLine1);

         /*  Top Horizontal Line  */
         Line myLine2 = new Line();
         myLine2.Stroke = System.Windows.Media.Brushes.Black;
         myLine2.X1 = width - 200;
         myLine2.X2 = width - 100;
         myLine2.Y1 = height - 350;
         myLine2.Y2 = height - 350;
         myLine2.StrokeThickness = 4;
         HangMan.Children.Add(myLine2);

         /*  Long Vertical Line  */
         Line myLine3 = new Line();
         myLine3.Stroke = System.Windows.Media.Brushes.Black;
         myLine3.X1 = width - 200;
         myLine3.X2 = width - 200;
         myLine3.Y1 = height - 350;
         myLine3.Y2 = height - 100;
         myLine3.StrokeThickness = 4;
         HangMan.Children.Add(myLine3);


         /*  Bottom Horizontal Line  */
         Line myLine = new Line();
         myLine.Stroke = System.Windows.Media.Brushes.Black;
         myLine.X1 = width - 225;
         myLine.X2 = width - 50;
         myLine.Y1 = height - 100;
         myLine.Y2 = height - 100;
         myLine.StrokeThickness = 4;
         HangMan.Children.Add(myLine);
         #endregion

         // Single Player will not give a string. Use the default constructor to 
         // test for an empty string and then choose word from list of words available for single player
         if (wordToGuess == "")
         {
            
            SinglePlayerWords words = new SinglePlayerWords();
            int numOfChoices;
            Random random = new Random();
            switch (difficulty)
            {
               case 0:
                  numOfChoices = words.ListOfWords.Count;
                  guessingWord = words.ListOfWords[random.Next(1, numOfChoices)];
                  break;
               case 1:
                  words.EasyWords = words.EasyWords;
                  numOfChoices = words.EasyWords.Count;
                  guessingWord = words.EasyWords[random.Next(1, numOfChoices)];
                  break;
               case 2:
                  words.MediumWords = words.MediumWords;
                  numOfChoices = words.MediumWords.Count;
                  guessingWord = words.MediumWords[random.Next(1, numOfChoices)];
                  break;
               case 3:
                  words.HardWords = words.HardWords;
                  numOfChoices = words.HardWords.Count;
                  guessingWord = words.HardWords[random.Next(1,numOfChoices)];
                  break;
               case 4:
                  words.EggWords = words.EggWords;
                  numOfChoices = words.EggWords.Count;
                  guessingWord = words.EggWords[random.Next(1, numOfChoices)];
                  break;
               default:
                  numOfChoices = words.ListOfWords.Count;
                  guessingWord = words.ListOfWords[random.Next(1,numOfChoices)];
                  break;

            }
         }
         // Multi-Player requires a string. Use the word given.
         else
         {
            guessingWord = wordToGuess;
         }

         // Convert the word to guess to ALL CAPS and convert and assign it to a character array
         guessingWord = guessingWord.ToUpper();
         char[] guessWordArray = guessingWord.ToCharArray();

         Label tempLabel = new Label(); // Temporary label assigned to the SingleLetter's label
         tempLabel.Content = "a";       // Initialize the Content property of the temporary label (This value will be changed later, so the value doesn't matter)

         // Assign the word to guess into the Letter character for each SingleLetter
         foreach (char x in guessWordArray)
         {
            SingleLetter letter = new SingleLetter();
            letter.Letter = x;
            letter.LocalLabel = tempLabel;

            if (!charactersToHide.Contains(x))
            {
               letter.assignLabel();
               letter.LocalLabel.BorderThickness = new Thickness(0);
            }

            singleLetters.Add(letter);


         }
         int labelCount = 0;

         // Display all the labels on the game interface
         foreach (SingleLetter x in singleLetters)
         {
            ++labelCount;
            if (x.Letter == ' ')
               x.LocalLabel.BorderThickness = new Thickness(0, 0, 0, 0);
            if (labelCount < 15)
            {
               labelList.Items.Add(x.LocalLabel);
            }
            else
            {
               overFlowList.Items.Add(x.LocalLabel);
            }
         }
      }

      // Even that fires when a letter of the alphabet keyboard is clicked on the game interface
      private void Letter_Click(object sender, RoutedEventArgs e)
      {
         Button btn = sender as Button;
         string s = btn.Content.ToString();

         Char c;
         bool result = Char.TryParse(s, out c);
         btn.Visibility = Visibility.Collapsed;
         MainGrid.UpdateLayout();

         // Run code inside if the user has fewer than 6 wrong guesses
         if (wrongGuess < 6)
         {
            // Add the letter to the game interface if the letter is in the word to guess
            if (guessingWord.ToUpper().Contains(c))
            {
               foreach (SingleLetter x in singleLetters)
               {
                  // If the letter clicked is in one of the letters, assign the letter stored in the SingleLetter to the label
                  if (x.Letter == c)
                     x.assignLabel();
               }
               printLabels(); // Run the method to print labels

               // Open the Result Screen if the word is guessed correctly
               if (guessingWord == onScreenListReturn())
               {
                  ResultScreen resultScreen = new ResultScreen(true, guessingWord);
                  resultScreen.Show();

                  this.Close();
               }
            }

            // Add a part to the Hang Man (Steve) if the player guesses a letter wrong
            else
            {
               #region Draw Steve
               switch (wrongGuess)
               {
                  case 0:
                     Canvas can = new Canvas();
                     can.Width = 75;
                     can.Height = 75;
                     HangMan.Children.Add(can);

                     Ellipse myEllipse = new Ellipse();
                     myEllipse.Stroke = System.Windows.Media.Brushes.Black;
                     myEllipse.StrokeThickness = 4;
                     myEllipse.Width = 50;
                     myEllipse.Height = 50;

                     Canvas.SetLeft(myEllipse, width - 237.5);
                     Canvas.SetTop(myEllipse, height - 412.5);
                     can.Children.Add(myEllipse);
                     break;
                  case 1:
                     Line myLine4 = new Line();
                     myLine4.Stroke = System.Windows.Media.Brushes.Black;
                     myLine4.X1 = width - 100;
                     myLine4.X2 = width - 100;
                     myLine4.Y1 = height - 250;
                     myLine4.Y2 = height - 200;
                     myLine4.StrokeThickness = 4;
                     HangMan.Children.Add(myLine4);
                     break;
                  case 2:
                     Line myLine5 = new Line();
                     myLine5.Stroke = System.Windows.Media.Brushes.Black;
                     myLine5.X1 = width - 100;
                     myLine5.X2 = width - 135;
                     myLine5.Y1 = height - 230;
                     myLine5.Y2 = height - 255;
                     myLine5.StrokeThickness = 4;
                     HangMan.Children.Add(myLine5);
                     break;
                  case 3:
                     Line myLine6 = new Line();
                     myLine6.Stroke = System.Windows.Media.Brushes.Black;
                     myLine6.X1 = width - 100;
                     myLine6.X2 = width - 65;
                     myLine6.Y1 = height - 230;
                     myLine6.Y2 = height - 255;
                     myLine6.StrokeThickness = 4;
                     HangMan.Children.Add(myLine6);
                     break;
                  case 4:
                     Line myLine7 = new Line();
                     myLine7.Stroke = System.Windows.Media.Brushes.Black;
                     myLine7.X1 = width - 65;
                     myLine7.X2 = width - 100;
                     myLine7.Y1 = height - 175;
                     myLine7.Y2 = height - 200;
                     myLine7.StrokeThickness = 4;
                     HangMan.Children.Add(myLine7);
                     break;
                  case 5:
                     Line myLine = new Line();
                     myLine.Stroke = System.Windows.Media.Brushes.Black;
                     myLine.X1 = width - 100;
                     myLine.X2 = width - 135;
                     myLine.Y1 = height - 200;
                     myLine.Y2 = height - 175;
                     myLine.StrokeThickness = 4;
                     HangMan.Children.Add(myLine);
                     break;
                  default:
                     break;
               }
               #endregion

               wrongGuess++;
               LettersGuessed.Text += " " + c;
            }
         }

         // If the player has guessed wrong 6 times, show the Result Screen showing the player they lost with the word they were supposed to guess
         if (wrongGuess == 6)
         {
            foreach (SingleLetter x in singleLetters)
            {
               x.assignLabel();
            }
            printLabels();

            ResultScreen resultScreen = new ResultScreen(false, guessingWord);
            resultScreen.Show();

            this.Close();
         }
      }

      // Clear the current word/phrase printing on the screen and print out all the labels and their pre-assigned content
      private void printLabels()
      {
         labelList.Items.Clear();
         overFlowList.Items.Clear();

         int labelCount = 0;
         foreach (SingleLetter x in singleLetters)
         {
            ++labelCount;
            if (x.Letter == ' ')
               x.LocalLabel.BorderThickness = new Thickness(0, 0, 0, 0);
            if (labelCount < 15)
            {
               labelList.Items.Add(x.LocalLabel);
            }

            else
            {
               overFlowList.Items.Add(x.LocalLabel);
            }
         }
      }

      // Button to go to the Welcome Screen
      private void Home_Button_Click(object sender, RoutedEventArgs e)
      {
         WelcomeScreen welcomeScreen = new WelcomeScreen();
         welcomeScreen.Show();
         this.Close();
      }

      // Returns all the characters on the screen as a string
      private string onScreenListReturn()
      {
         string tempString = string.Empty;
         foreach (Label x in labelList.Items)
         {
            tempString += x.Content;
         }
         foreach (Label x in overFlowList.Items)
         {
            tempString += x.Content;
         }
         return tempString;
      }
   }
}