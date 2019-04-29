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
   /// <summary>
   /// Interaction logic for WelcomeScreen.xaml
   /// </summary>
   public partial class WelcomeScreen : Window
   {
      public WelcomeScreen()
      {
         InitializeComponent();
      }

      private void SinglePlayer_ButtonClick(object sender, RoutedEventArgs e)
      {
         SinglePlayerStart singlePlayerStart = new SinglePlayerStart();
         singlePlayerStart.Show();
         this.Close();
      }

      private void MultiPlayer_ButtonClick(object sender, RoutedEventArgs e)
      {
         MultiPlayerStart multiPlayerStart = new MultiPlayerStart();
         multiPlayerStart.Show();
         this.Close();
      }
   }
}
