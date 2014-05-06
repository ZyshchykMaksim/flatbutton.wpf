using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlatUIWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<StackPanel> items = new ObservableCollection<StackPanel>();
        public MainWindow()
        {
            InitializeComponent();
        }


        public ObservableCollection<StackPanel> Items
        {
            get { return items; }
            set { items = value; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var icons = FlatInformation.Instance.CollectionIcon;
            if (icons != null && icons.Any())
            {
                foreach (var icon in icons)
                {
                    StackPanel panel = new StackPanel() { Orientation = Orientation.Horizontal };
                    var flatButton = new FlatButton()
                        {
                            AwesomeIcon = icon.Key,
                            IconColor = Brushes.Black,
                            BorderRadius = 3,
                            BorderBrush = Brushes.LightGray,
                            Background = Brushes.Transparent,
                            Width = 35,
                            Height = 35,
                            FontSize = 20,
                            Cursor = Cursors.Hand,
                            IsPress = false,
							Margin = new Thickness(5)
                        };
                    TextBlock box = new TextBlock()
                        {
                            Text = icon.Key.ToString(),
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center
                        };
                    panel.Children.Add(flatButton);
                    panel.Children.Add(box);
                    Items.Add(panel);
                }
            }
        }
    }
}
