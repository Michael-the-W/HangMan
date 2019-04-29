using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HangMan
{
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

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         WelcomeScreen welcomeScreen = new WelcomeScreen();
         welcomeScreen.Show();
         this.Close();
      }
   }
}
