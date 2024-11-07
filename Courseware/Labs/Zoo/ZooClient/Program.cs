using Zoo;

Animal animal1 = new Animal("Florence", 4, "Black and White" );

//animal1.name = "Florence";
//animal1.LimbCount = 4;
//animal1.Colour = "Black and White";

//Animal animal2 = new Animal("Boris") {  LimbCount=8, Colour = "Black" };
Animal animal2 = new Animal("Boris") {  Colour = "Black" };

//animal2.name = "Boris";
//animal2.LimbCount = 8;
//animal2.Colour = "Black";

Animal animal3 = new Animal("Maria");

//Console.WriteLine(animal1.Eat("Grass"));
//Console.WriteLine(animal2.Eat("Flies"));

Dog dog1 = new Dog(limbCount:3, name:"Fido");
Console.WriteLine(dog1.Eat("Biscuits"));
Console.WriteLine(dog1.WagTail(10));


List<Animal> zoo = new List<Animal>();
zoo.Add(animal1);
zoo.Add(animal2);
zoo.Add(animal3);
zoo.Add(dog1);

foreach (Animal animal in zoo)
{
    Console.WriteLine(animal.Move(10, "West"));
    Console.WriteLine(animal.Move(10));
    Console.WriteLine(animal.Eat("Candyfloss"));
}

Console.WriteLine($"There are {Animal.AnimalCount} animals");