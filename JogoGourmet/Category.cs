using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoGourmet
{
    public class Category
    {
        public string Name { get; set; } = string.Empty;
        public string Question { get; set; } = string.Empty;
        public string Positive { get; set; } = string.Empty;
        public string Negative { get; set; } = string.Empty;
        public Category? categoryPositive { get; set; }
        public Category? categoryNegative { get; set; }
        public Category(string name, string question, string positive, string negative) {
            this.Name = name;
            this.Question = question;
            this.Positive = positive;
            this.Negative = negative;
        }
    }
}
