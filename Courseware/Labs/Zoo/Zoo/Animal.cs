using System.Runtime.CompilerServices;

namespace Zoo
{
    public class Animal
    {
        public string Name { get; set; }
        //private int limbCount;
        public string Colour { get; set; }
        public static int AnimalCount = 0;
        
        //public Animal():this("Anon", 6, "Brown")
        //{
        //    //name = "Anon";
        //    //LimbCount = 6;
        //    //Colour = "Brown";
        //}

        public Animal(string name="Anonymous", int limbCount=6, string colour="Brown")
        {
            this.Name = name;
            this.LimbCount = limbCount;
            Colour = colour;
            AnimalCount++;
        }

        //public int GetLimbCount()
        //{
        //    return limbCount;
        //}

        //public void SetLimbCount(int value)
        //{
        //    if (value < 0)
        //    {
        //        value = 0;
        //    }
        //    limbCount = value;
        //}

        private int limbCount;

        public int LimbCount
        {
            get 
            { 
                return limbCount; 
            }
            set 
            { 
                if (value < 0 || value > 1000)
                {
                    value = 0;
                }
                limbCount = value; 
            }
        }


        public static int GetAnimalCount()
        {
            return AnimalCount;
        }

        public virtual string Eat(string food)
        {
            return $"I'm an animal called {Name} using some of my {LimbCount} limbs to eat {food}";
        }

        public string Move(int distance=5, string direction="South")
        {
            return $"I'm an animal called {Name} using some of my {LimbCount} limbs to move {direction} for {distance} metres";
        }

        public string Move(int distance=7)
        {
            return $"I'm an animal called {Name} using some of my {LimbCount} limbs to move {distance} metres";
        }

        public string Move(string direction)
        {
            return $"I'm an animal called {Name} using some of my {LimbCount} limbs to move {direction}";
        }

    }
}
