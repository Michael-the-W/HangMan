// Team Charlie: Gill, Wagner [Hangman] - 04/30/19 - ResultScreen: Displays the result of the game and the word being guessed, with a play again option

using System.Windows;

namespace HangMan
{
    // Displays the result of the game and the word being guessed
    public partial class ResultScreen : Window
    {
        public ResultScreen(bool result, string correctWord)
        {
           InitializeComponent();

           if (result)
           {
               Result.Text = "You're not dead.";
               Answer.Text = ($"You guessed {correctWord} correctly");
           }
           else
           {
               Result.Text = "You're dead.";
               Answer.Text = ($"The word was {correctWord}");
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