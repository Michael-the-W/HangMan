// Team Charlie: Gill, Wagner [Hangman] - 04/30/19 - WelcomeScreen: Home page of game, provides single player and multiplayer game options

using System.Windows;

namespace HangMan
{
   public partial class WelcomeScreen : Window
   {
      public WelcomeScreen()
      {
         InitializeComponent();
      }

      // Single player game option
      private void SinglePlayer_ButtonClick(object sender, RoutedEventArgs e)
      {
         SinglePlayerStart singlePlayerStart = new SinglePlayerStart();
         singlePlayerStart.Show();
         this.Close();
      }

      // Multiplayer game option
      private void MultiPlayer_ButtonClick(object sender, RoutedEventArgs e)
      {
         MultiPlayerStart multiPlayerStart = new MultiPlayerStart();
         multiPlayerStart.Show();
         this.Close();
      }
   }
}