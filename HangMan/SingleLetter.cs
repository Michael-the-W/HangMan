// Team Charlie: Gill, Wagner [Hangman] - 04/30/19 - SingleLetter: Provides a label with a single letter to the game interface and stores the letter until it needs to be displayed

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

      // The character that stores the letter or character to be assigned to the label
      public char Letter
      {
         get => _letter;
         set => _letter = value;
      }

      // The label to be displayed on the game interface
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
         }
      }

      // Assign the letter to the label so the letter can be displayed on the game interface
      public void assignLabel()
      {
         LocalLabel.Content = Letter;
      }
   }
}