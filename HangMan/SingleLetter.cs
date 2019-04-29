using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HangMan.Letters
{
   class SingleLetter
   {
      
      private Label localLabel = new Label();
      private char _letter;
      const int BORDER_WIDTH = 2;

      public char Letter
      {
         get => _letter;
         set => _letter = value;
      }

      public Label LocalLabel
      {
         get { return localLabel; }
         set
         {
            localLabel.BorderThickness = new Thickness(0, 0, 0, 3);
            localLabel.Foreground = new SolidColorBrush(Color.FromRgb(38, 30, 30));
            localLabel.BorderBrush = new SolidColorBrush(Color.FromRgb(184, 1, 0));
            localLabel.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            localLabel.HorizontalAlignment = HorizontalAlignment.Center;
            localLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            localLabel.FontWeight = FontWeights.Bold;
            localLabel.FontSize = 20;
            localLabel.Width = 30;
            localLabel.Height = 40;
            
            //localLabel.Content = value.ToString();
         }
      }

      public void assignLabel()
      {
         LocalLabel.Content = Letter;
      }
   }
}