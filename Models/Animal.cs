using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuhuZoo.Models
{
    public enum Color { Orange, Red, Green, Blue, Yellow, White, Black, 
        Grey, Magenta, Purple, Cyan, Transparent, Other }
    class Animal : BaseClass
    {
        public Color color {  get; set; }
        public string Race { get; set; }
    }
}
