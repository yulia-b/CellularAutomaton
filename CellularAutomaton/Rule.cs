using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CellularAutomaton
{
   public class Rule
    {
        public int initialState;
        public string name;
        public int state;
        public int comparison;
        public int num;
        public int finalState;
        public int[] cells;

        public Rule(int initialState, string name, int state, int num, int comparison, int finalState)
        {
            this.initialState = initialState;
            this.name = name;
            this.num = num;
            this.state = state;
            this.comparison = comparison;
            this.finalState = finalState;
        }

        public Rule(int[] cells, int inState, string name, int fState)
        {
            this.cells = cells;
            this.name = name;
            this.finalState = fState;
            this.initialState = inState;
 
        }
    }
}
