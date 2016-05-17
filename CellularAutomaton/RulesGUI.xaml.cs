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
using System.Drawing;
 

namespace CellularAutomaton
{
    /// <summary>
    /// Interaction logic for RulesGUI.xaml
    /// </summary>
    public partial class RulesGUI : Window
    {


        string name;
        string state_gui;
        int initState;
        int finState;
        int states;
        int nums;
        int comparisons;
        int final;
        List<Rule> rulesList1 = new List<Rule>();
        public List<Rule> rulesList2 = new List<Rule>();
        List<Point> positions = new List<Point>();
        List<Button> buttons = new List<Button>();
       //List<int> states_gui = new List<int>(25);
        int[] states_gui;

        public RulesGUI()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(RulesGUI_Loaded);
        }

        void RulesGUI_Loaded(object sender, RoutedEventArgs e)
        {
            AddButtons();
        }


        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        Rectangle rect;
        private void AddButtons()
        {
       
            for (int i = 0; i < 25; ++i)
            {
                Button button = new Button();
                button.SetValue(Grid.ColumnProperty, i);
                button.Background = new SolidColorBrush(Colors.White);


                grid_neigh.Children.Add(button);
                button.Click += ChangeState;
                button.Focusable = false;
                buttons.Add(button);
            }


        }
        void ChangeState(object sender, RoutedEventArgs e)
        {
            state_gui = state.Text.ToString();
            Button button = sender as Button;
            if (state_gui == "Alive") button.Background = new SolidColorBrush(Colors.White);
            else
            {
                button.Background = new SolidColorBrush(Colors.Black);
                

               
            }
            //rect.
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Application.Current.MainWindow.Show();
            MainGUI main = new MainGUI(rulesList2, rulesList1);
            App.Current.MainWindow = main;
            //MainGUI mg = new MainGUI();
            main.Show();
            this.Hide();
        }
        int k = 1;
        Rule rule;
        private void addRule_Click(object sender, RoutedEventArgs e)
        {

            if (initialState.Text.ToString() == "Alive") initState = 1;
            else initState = 0;

            if (state1.Text.ToString() == "Alive") states = 1;
            else states = 0;
      
            nums = Int32.Parse(num1.Text);

            if (comparison1.Text.ToString() == "more than") comparisons = 0;
            else if (comparison1.Text.ToString() == "exactly") comparisons = 1;
            else if (comparison1.Text.ToString() == "less than") comparisons = 2;
            //comparisons = comparison1.Text.ToString();

            if (initState == 1) finState = 0;
            else finState = 1;

            name = "rule" + k;
            rule = new Rule(initState, name, states, nums, comparisons, finState);
             rulesList1.Add(rule);
            rules.Items.Add("rule_"+k);
            k++;
           // num1.Clear();
           
 
           // cells[5].Fill = new SolidColorBrush(Colors.Blue);

            for (int i = 0; i < 25; i++)
            {
               // if cells[i]
 
            }
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        
        }

        private void rules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = rules.SelectedIndex;
            num1.Text = rulesList1[index].num.ToString();
            
            //initialState.Items.Cast<ComboBoxItem>.Where() = rulesList1[index].initialState;
           // state1.SelectedValue = rulesList1[index].state[0];

           
            //num1.Text = rules.SelectedIndex.ToString();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            states_gui = new int[25];
            int state_middle;
            if (finalState.Text.ToString() == "Alive") final = 1;
            else final = 0;
            if (buttons[12].Background.ToString() == "#FF000000")
            {
                state_middle = 0;
                
            }
            else
            {
                state_middle = 1;
               
            }
           
            for (int i = 0; i < 25; i++)
            {
                // if cells[i]
                if (i == 12)
                {
                    states_gui[i] = state_middle;
                    continue; 
                }
                if (buttons[i].Background.ToString() == "#FF000000") states_gui[i] = 0;
                else states_gui[i] = 1;

            }

            name = "rule" + k;
            rule = new Rule(states_gui, state_middle, name, final);
            rulesList2.Add(rule);
            rules2.Items.Add("rule_" + k);
            k++;
            rule = null;
          
            
        }
    }
}
