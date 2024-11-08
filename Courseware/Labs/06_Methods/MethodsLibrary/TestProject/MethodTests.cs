using MethodsLibrary;
using Xunit;
using static MethodsLibrary.Make;

namespace TestProject
{
    public class MethodTests
    {
        [Fact]
        public void Value_And_Reference_Types_Struct()
        {
            // Create a a new public VALUE type LatLong in the MethodsLibrary project
            // Generate properties Lat and Long
            LatLong london = new LatLong() { Lat = 51.0, Long = 0.0 };
            LatLong bristol = london;
            bristol.Long -= 2.0;

            Assert.True(london.Lat == 51.0);
            Assert.True(london.Long == 0.0); // London and Bristol are two separate value types

            Assert.True(bristol.Lat == 51.0);
            Assert.True(bristol.Long == -2.0);
        }

        [Fact]
        public void Value_And_Reference_Types_Class()
        {
            // Create a a new public REFERENCE type LatLongClass in the MethodsLibrary project
            // Generate properties Lat and Long
            LatLongClass london = new LatLongClass() { Lat = 51.0, Long = 0.0 };
            LatLongClass bristol = london;
            bristol.Long -= 2.0;

            Assert.True(london.Lat == 51.0);
            Assert.True(london.Long == -2.0); // London and Bristol reference the same object

            Assert.True(bristol.Lat == 51.0);
            Assert.True(bristol.Long == -2.0);
        }

        [Fact]
        public void Null_Reference()
        {
            // Generate new reference type Car
            Car? c = null;

            bool started = false;

            // started = c.Start(); // Generate method, remove 'throw new NotImplementedException();', return true

            // Put in a not-null test, so that the car is only started if there is a car

            if (c != null)
            {
                started = c.Start();
            }
            Assert.False(started);
        }

        [Fact]
        public void Null_Reference_Resolve_By_Elvis()
        {
            Car? c = null;

            // started = c.Start();

            // Put in a not-null test using the Elvis operator, so that the car is only started if there is a car
            bool? started = c?.Start();

            Assert.Null(started); // Null assertion
        }



        [Fact]
        public void Try_Parse_Succeeds()
        {
            string input = "42";
            int result;
            // insert a call to TryParse
            int.TryParse(input, out result);
            Assert.Equal(42, result);
        }

        [Fact]
        public void Try_Parse_Succeeds_Inline_Out()
        {
            string input = "42";
            // insert a call to TryParse defining an inline out param
            int.TryParse(input, out int result);
            Assert.Equal(42, result);
        }

        [Fact]
        public void Try_Parse_Fails()
        {
            string input = "42X";
            int result;
            // Nothing to do on this test!!
            Assert.False(int.TryParse(input, out result));
        }

        [Fact]
        public void Statics()
        {
            int startCount = Car.Count;

            for (int i = 0; i < 42; i++)
            {
                new Car();
            }
            // Add a static int property Count with a public getter and a private setter
            // Create a parameterless constructor in Car and increment Count in the constructor
            Assert.Equal(42, Car.Count - startCount);
        }



        [Fact]
        public void Enums()
        {
            // Create an enum with the values Ford and BMW
            // Create a property in Car of type Make called Make
            // import the enum into this test file
            // so that you do not have to edit the code below
            Car c = new Car() { Make = Ford };
            Assert.Equal(Ford, c.Make);
        }


    }
}