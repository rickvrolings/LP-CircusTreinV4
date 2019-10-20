using System;
using System.Collections.Generic;
using System.Text;
using static LP_CircusTreinV4.Models.Enums;

namespace LP_CircusTreinV4.Models
{
    public class Animal
    { 
        public Diet Diet { get; }
        public Size Size { get; }

        public Animal(Diet diet, Size size)
        {
            this.Diet = diet;
            this.Size = size;
        }

        public override string ToString()
        {
            return this.Diet.ToString() + ", " + this.Size.ToString();
        }
    }
}
