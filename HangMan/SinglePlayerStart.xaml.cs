using System.Windows;


namespace HangMan
{
   /// <summary>
   /// Interaction logic for SinglePlayerStart.xaml
   /// </summary>
   public partial class SinglePlayerStart : Window
   {
      int difficulty = -1;
      public SinglePlayerStart()
      {
         InitializeComponent();
      }

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

      private void Random_Click(object sender, RoutedEventArgs e)
      {
         difficulty = 0;
         difficultyText.Text = "Difficulty: Random";
      }
      private void Easy_Click(object sender, RoutedEventArgs e)
      {
         difficulty = 1;
         difficultyText.Text = "Difficulty: Easy";
      }

      private void Medium_Click(object sender, RoutedEventArgs e)
      {
         difficulty = 2;
         difficultyText.Text = "Difficulty: Medium";
      }

      private void Hard_Click(object sender, RoutedEventArgs e)
      {
         difficulty = 3;
         difficultyText.Text = "Difficulty: Hard";
      }

      private void Egg_Click(object sender, RoutedEventArgs e)
      {
         difficulty = 4;
         MainWindow mainWindow = new MainWindow(difficulty);
         mainWindow.Show();
         this.Close();
      }

      private void Button_Click_1(object sender, RoutedEventArgs e)
      {
         WelcomeScreen welcomeScreen = new WelcomeScreen();
         welcomeScreen.Show();
         this.Close();
      }
   }
}
