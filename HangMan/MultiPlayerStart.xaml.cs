// Team Charlie: Gill, Wagner [Hangman] - 04/30/19 - MultiPlayerStart: Provides a blank for one player to enter a word for the second player

using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace HangMan
{
   public partial class MultiPlayerStart : Window
   {
      public MultiPlayerStart()
      {
         InitializeComponent();
      }

      // Starts the game requiring at least one letter to be entered
      private void Button_Click(object sender, RoutedEventArgs e)
      {
         string guessWord = Word.Text;

         if (Regex.IsMatch(guessWord, "(^[A-za-z]+)|(.[A-Za-z]+.)|([A-Za-z]$)",  RegexOptions.Compiled))
         {
            MainWindow mainWindow = new MainWindow(1, guessWord);
            mainWindow.Show();
            this.Close();
         }
         else
         {
            ErrorMsg.Text= "You can't escape!\nThe word must contain at least one letter";
            Word.Text = string.Empty;
         }
      }

      // Allows player to press enter on the keyboard to start the game
      private void Word_PreviewKeyDown(object sender, KeyEventArgs e)
      {
         if (e.Key == Key.Return)
         {
            string guessWord = Word.Text;

            if (Regex.IsMatch(guessWord, "(^[A-za-z]+)|(.[A-Za-z]+.)|([A-Za-z]$)", RegexOptions.Compiled))
            {
               MainWindow mainWindow = new MainWindow(1, guessWord);
               mainWindow.Show();
               this.Close();
            }
            else
            {
               ErrorMsg.Text = "You can't escape!\nThe word must contain at least one letter";
               Word.Text = string.Empty;
            }
         }
      }

      // Sends player back to the Home Welcome Screen
      private void Home_Button_Click(object sender, RoutedEventArgs e)
      {
         WelcomeScreen welcomeScreen = new WelcomeScreen();
         welcomeScreen.Show();
         this.Close();
      }
   }
}