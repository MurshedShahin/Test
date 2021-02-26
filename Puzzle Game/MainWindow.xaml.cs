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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Puzzle_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[,] btnLights;
        int GridSize = 5;

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 1; i < 26; i++)
            {
                GSize.Items.Add(i);
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int btnY = ((btn.TabIndex - 1) % GridSize);
            int btnX = (int)((btn.TabIndex - 1) / GridSize);

            ToggleButtonColor(btn);

            // Toggle button left
            if (btnX > 0)
            {
                ToggleButtonColor(btnLights[(btnX - 1), btnY]);
            }
            // Toggle button right
            if (btnX < (GridSize - 1))
            {
                ToggleButtonColor(btnLights[(btnX + 1), btnY]);
            }
            // Toggle button Up
            if (btnY > 0)
            {
                ToggleButtonColor(btnLights[btnX, (btnY - 1)]);
            }
            // Toggle button Down
            if (btnY < (GridSize - 1))
            {
                ToggleButtonColor(btnLights[btnX, (btnY + 1)]);
            }

            // MessageBox.Show(btn.TabIndex.ToString());

        }

        private void ToggleButtonColor(Button button)
        {
            if (((SolidColorBrush)button.Background).Color == Colors.DarkGreen)
            {
                button.Background = new SolidColorBrush(Colors.LightGreen);
            }

            else if (((SolidColorBrush)button.Background).Color == Colors.LightGreen)
            {
                button.Background = new SolidColorBrush(Colors.DarkGreen);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            LoadGrid();


        }

        private void LoadGrid()
        {
            PuzzleGrid.Children.Clear();
            PuzzleGrid.ColumnDefinitions.Clear();
            PuzzleGrid.RowDefinitions.Clear();
            Application.Current.MainWindow.MinWidth = GridSize * 90;
            Application.Current.MainWindow.MinHeight = GridSize * 90 + 50;
            btnLights = new Button[GridSize, GridSize];

            for (int i = 0; i < GridSize; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(0, GridUnitType.Auto);
                PuzzleGrid.ColumnDefinitions.Add(colDef);

                for (int j = 0; j < GridSize; j++)
                {
                    RowDefinition rd = new RowDefinition();
                    rd.Height = new GridLength(0, GridUnitType.Auto);
                    PuzzleGrid.RowDefinitions.Add(rd);
                    Button btn = new Button();
                    //btn.Content = "A";

                    btnLights[i, j] = btn;
                    btnLights[i, j].Content = j + (i * GridSize) + 1;
                    btnLights[i, j].Width = 90;
                    btnLights[i, j].Height = 90;
                    btnLights[i, j].Background = new SolidColorBrush(Colors.DarkGreen);
                    btnLights[i, j].Click += Button_Click;


                    btnLights[i, j].BorderThickness = BorderThickness;
                    btnLights[i, j].TabIndex = j + (i * GridSize) + 1;

                    btnLights[i, j].SetValue(Grid.ColumnProperty, i);
                    btnLights[i, j].SetValue(Grid.RowProperty, j);
                    PuzzleGrid.Children.Add(btnLights[i, j]);
                }


            }
            Random rnd = new Random();
            //int month = rnd.Next(1, GridSize);
            for (int k = 1; k <= rnd.Next(1, GridSize); k++)
            {
                ToggleButtonColor(btnLights[rnd.Next(0, GridSize), rnd.Next(0, GridSize)]);
            }

        }

        private void GSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            //MessageBox.Show(cmb.SelectedItem.ToString());
            GridSize = Convert.ToInt32(cmb.SelectedItem.ToString());
            LoadGrid();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            LoadGrid();
        }
    }
}
