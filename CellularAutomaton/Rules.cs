using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton
{
    class Rules
    { 
        
        public int ifConflict(List<Rule> rules, Rule rule)
        {
            int conflict = 0;
            for (int i = 0; i < rules.Count; i++)
            {
                if (rules[i].comparison == 0 || rule.comparison == 1)
                {
                    if (rules[i].num > rule.num) conflict = 1;
                    break;
 
                }
                if (rules[i].comparison == 2 || rule.comparison == 2)
                {
                    if (!(rules[i].num == rule.num)) conflict = 1;
                    break;
                }

            }
            return conflict;
        }
    }

   
}
