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

namespace CellularAutomaton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainGUI: Window
    {

        List<Rule> rulesList1 = new List<Rule>();
        List<Rule> rulesList2 = new List<Rule>();

        public MainGUI()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainGUI_Loaded);
        }

        public MainGUI(List<Rule> rulesList1, List<Rule> rulesList2)
        {
            InitializeComponent();
            this.rulesList1 = rulesList1;
            this.rulesList2 = rulesList2;
            Loaded += new RoutedEventHandler(MainGUI_Loaded);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

       
        void MainGUI_Loaded(object sender, RoutedEventArgs e)
        {
            AddButtons();
        }

        static int size;
        List<List<Button>> grid_buttons;
        Button[,] bs;
       
        Button button;
        private void AddButtons()
        {
            if (string.IsNullOrWhiteSpace(size1.Text)) size = 10;
            else size = Int32.Parse(size1.Text);// * Int32.Parse(size1.Text); 

            for (int k = 0; k < size; k++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
            }

            bs = new Button[size, size];

           // grid_buttons = new List<List<Button>>();
             for (int i = 0; i < grid.RowDefinitions.Count; ++i)
                {
                 for (int j = 0; j < grid.ColumnDefinitions.Count; ++j)
                 { 
                     button = new Button();
                     button.SetValue(Grid.RowProperty, i);
                     button.SetValue(Grid.ColumnProperty, j);
                     button.Background = new SolidColorBrush(Colors.White);
                     button.Click += ChangeState;
                    button.Focusable = false;
                    

                         grid.Children.Add(button);
                       //  grid_buttons[i][j] = button;
                         bs[i, j] = button;
                         
                       
                 
             }
                 }

            
        }

        void ChangeState(object sender, RoutedEventArgs e)
        {
         
            //var rect = sender as System.Windows.Shapes.Rectangle;
            
               // rect.Fill = new SolidColorBrush(Colors.Black);
            Button button = sender as System.Windows.Controls.Button;
            button.Background = Brushes.Black;
            //rect.
        } 
        
        RulesGUI rules = new RulesGUI();


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
          
            rules.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           // grid.Children.Clear();
            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();
          
            AddButtons();
        }

        int[,] new_grid = new int[size,size];
        int[,] checkingState = new int[size,size];

        private int[,] checkStates()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (bs[i, j].Background.ToString() == "#FF000000") checkingState[i, j] = 0;
                    else checkingState[i, j] = 1;
                }

            }

            return checkingState;
 
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            //
            //for ()
            int k=0;
            int num=0;
            new_grid = new int[size, size];
            int initS = 0;
            int curr_point = 0;
            new_grid = checkStates();
            for (int v = 0; v < rulesList1.Count; v++)
            {
                if (rulesList1.Count != 0)
                {

                    for (int i = 2; i < size - 2; i++)
                    {
                        for (int j = 2; j < size - 2; j++)
                        {
                            if (bs[i, j].Background.ToString() == "#FF000000") initS = 0;
                            else initS = 1;
                            if (initS == rulesList1[v].initialState)
                            {
                                for (int x = -2; x <= 2; x++)
                                {
                                    for (int y = -2; y <= 2; y++)
                                    {
                                        if (bs[i + x, j + y].Background.ToString() == "#FF000000") curr_point = 0;
                                        else curr_point = 1;

                                        if (rulesList1[v].cells[k] == curr_point)
                                        {

                                            num++;
                                        }

                                        k++;
                                    }
                                }
                            }
                            /*else
                            {
                                new_grid[i, j] = initS;
                            }*/

                            if (num == 25) new_grid[i, j] = rulesList1[v].finalState;
                           /* else
                            {
                                if (bs[i, j].Background.ToString() == "#FF000000") new_grid[i, j] = 0;
                                else new_grid[i, j] = 1;
                            }*/

                            k = 0;
                            num = 0;
                        }
                    }
                    for (int s = 0; s < 2; s++)
                    {
                        for (int m = 0; m < size; m++)
                        {
                            if (bs[s, m].Background.ToString() != "#FF000000") new_grid[s, m] = 1;
                        }
                    }
                    for (int s = 0; s < size; s++)
                    {
                        for (int m = 0; m < 2; m++)
                        {
                            if (bs[s, m].Background.ToString() != "#FF000000") new_grid[s, m] = 1;
                        }
                    }
                    for (int s = 0; s < size; s++)
                    {
                        for (int m = size - 2; m < size; m++)
                        {
                            if (bs[s, m].Background.ToString() != "#FF000000") new_grid[s, m] = 1;
                        }
                    }

                    for (int s = size - 2; s < size; s++)
                    {
                        for (int m = 0; m < size; m++)
                        {
                            if (bs[s, m].Background.ToString() != "#FF000000") new_grid[s, m] = 1;
                        }
                    }

                    /*  for (int i = 0; i < size; i++)
                      {
                          for (int j = 0; j < size; j++)
                          {
                              if (new_grid[i, j] == 1) bs[i, j].Background = Brushes.White;
                              else bs[i, j].Background = Brushes.Black;
                          }
                      }*/
                }

                if (rulesList2.Count != 0)
                {
                    new_grid = checkStates();
                    int deadNum = 0;
                    int aliveNum = 0;
                    int initState = 0;
                    int finState = 0;
                    for (int i = 2; i < size - 2; i++)
                    {
                        for (int j = 2; j < size - 2; j++)
                        {
                            deadNum = 0;
                            aliveNum = 0;
                            finState = rulesList2[0].finalState;
                            if (bs[i, j].Background.ToString() == "#FF000000")
                            {
                                initState = 0;

                            }
                            else
                            {
                                initState = 1;

                            }
                            for (int x = -2; x <= 2; x++)
                            {
                                for (int y = -2; y <= 2; y++)
                                {
                                    if (bs[i + x, j + y].Background.ToString() == "#FF000000") deadNum++;
                                    else aliveNum++;
                                }
                            }


                            if (rulesList2[0].initialState == initState)
                            {
                                if (rulesList2[0].state == 1)
                                {
                                    if (rulesList2[0].comparison == 0)
                                    {
                                        if (aliveNum > rulesList2[0].num) new_grid[i, j] = finState;
                                    }
                                    if (rulesList2[0].comparison == 1)
                                    {
                                        if (aliveNum < rulesList2[0].num) new_grid[i, j] = finState;
                                    }
                                    if (rulesList2[0].comparison == 2)
                                    {
                                        if (aliveNum == rulesList2[0].num) new_grid[i, j] = finState;
                                    }

                                }

                                if (rulesList2[0].state == 0)
                                {
                                    if (rulesList2[0].comparison == 0)
                                    {
                                        if (deadNum > rulesList2[0].num) new_grid[i, j] = finState;
                                    }
                                    if (rulesList2[0].comparison == 1)
                                    {
                                        if (deadNum < rulesList2[0].num) new_grid[i, j] = finState;
                                    }
                                    if (rulesList2[0].comparison == 2)
                                    {
                                        if (deadNum == rulesList2[0].num) new_grid[i, j] = finState;
                                    }

                                }
                            }
                        }
                    }



                }
            }
            
            for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (new_grid[i, j] == 1) bs[i, j].Background = Brushes.White;
                            else bs[i, j].Background = Brushes.Black;
                        }
                    }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < size; i++ )
            {
                for (int j=0; j < size; j++)
                {
                    bs[i, j].Background = Brushes.White;
                }

            }

        }
    }
}
