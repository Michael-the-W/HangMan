using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
   /// <summary>
   /// Interaction logic for StartPage.xaml
   /// </summary>
   public partial class MultiPlayerStart : Window
   {
      public MultiPlayerStart()
      {
         InitializeComponent();
         //Directions.Text = "";
      }

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
            Message.Text= "You can't escape!\nThe word must contain at least one letter";
            Word.Text = String.Empty;
         }
      }

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
               Message.Text = "You can't escape!\nThe word must contain at least one letter";
               Word.Text = String.Empty;
            }
         }
      }

      private void Button_Click_1(object sender, RoutedEventArgs e)
      {
         WelcomeScreen welcomeScreen = new WelcomeScreen();
         welcomeScreen.Show();
         this.Close();
      }
   }
}
