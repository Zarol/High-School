using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace LunchMoneyMatch.Resume
{
    class StackPanelHolder
    {
            public String Name { get; set; }
            public StackPanel Panel { get; set; }
            public StackPanelHolder(String name, StackPanel sp)
            {
                this.Name = name;
                this.Panel = sp;
            }
    }
}
