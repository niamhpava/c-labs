using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Dog:Animal
    {
        private float tailLength;

        public float TailLength
        {
            get { return tailLength; }
            set { 
                if (value < 0.0f)
                {
                    value = 0.0f;
                }
                else if (value > 60.0f)
                {
                    value = 60.0f;
                }
                tailLength = value; 
            }
        }

        public Dog(string name = "Rover", int limbCount = 4, string colour = "grubby", float tailLength = 30):base(name, limbCount, colour)
        {
                this.TailLength = tailLength;
        }

        public string WagTail(int numberOfTimes)
        {
            StringBuilder message = new StringBuilder();
            for (int i = 0; i < numberOfTimes; i++)
            {
                message.Append("Wag ");
            }
            return message.ToString();
        }

        public override string Eat(string food)
        {
            return $"{base.Eat(food)}. I'm a DOG called {Name} using some of my {LimbCount} limbs to GOBBLE {food}. Woof!";

        }

    }
}
