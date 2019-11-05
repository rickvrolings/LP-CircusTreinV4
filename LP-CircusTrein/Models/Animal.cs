using System;
using System.Collections.Generic;
using System.Text;
using static LP_CircusTreinV4.Models.Enums;

namespace LP_CircusTreinV4.Models
{
    public class Animal
    { 
        public Diet Diet { get; private set; }
        public Size Size { get; private set; }
        public bool Placed { get; set; } // Received feedback that it is hard to check if an animal is placed. So i created this bool. 

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
