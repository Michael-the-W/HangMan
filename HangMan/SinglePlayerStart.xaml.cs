// Team Charlie: Gill, Wagner [Hangman] - 04/30/19 - SinglePlayerStart: Provides difficulty levels for the player to choose from

using System.Windows;

namespace HangMan
{
   public partial class SinglePlayerStart : Window
   {
      int difficulty = -1;
      public SinglePlayerStart()
      {
         InitializeComponent();
      }

      // Starts a game based on the user-chosen difficulty level
      private void Button_Click(object sender, RoutedEventArgs e)
      {
         if(difficulty == -1)
         {
            difficultyText.Text = "Please choose a difficulty";
         }
         else
         {
            MainWindow mainWindow = new MainWindow(difficulty);
            mainWindow.Show();
            this.Close();
         }
      }

      // Sets difficulty level to random
      private void Random_Click(object sender, RoutedEventArgs e)
      {
         difficulty = 0;
         difficultyText.Text = "Difficulty: Random";
      }

      // Sets difficulty level to easy
      private void Easy_Click(object sender, RoutedEventArgs e)
      {
         difficulty = 1;
         difficultyText.Text = "Difficulty: Easy";
      }

      // Sets difficulty level to medium
      private void Medium_Click(object sender, RoutedEventArgs e)
      {
         difficulty = 2;
         difficultyText.Text = "Difficulty: Medium";
      }

      // Sets difficulty level to hard
      private void Hard_Click(object sender, RoutedEventArgs e)
      {
         difficulty = 3;
         difficultyText.Text = "Difficulty: Hard";
      }

      // Starts a game based on a hidden easter egg
      private void Egg_Click(object sender, RoutedEventArgs e)
      {
         difficulty = 4;
         MainWindow mainWindow = new MainWindow(difficulty);
         mainWindow.Show();
         this.Close();
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