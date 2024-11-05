string[] muppets = { "kermit the frog", "miss piggy", "fozzie bear", "gonzo", "rowlf the dog", "scooter", "animal",
"rizzo the rat", "pepe the prawn", "walter", "clifford"} ;


foreach( string muppet in muppets)
{
    Console.WriteLine(muppet);
}

Console.WriteLine("\n");

List<string> muppetList = new List<string>();

foreach( string muppet in muppets)
{
    muppetList.Add(muppet);
}

foreach(string muppet in muppetList)
{
    Console.WriteLine(muppet);
}

Console.WriteLine("\n");

Console.WriteLine(muppetList[0]);

Console.WriteLine(muppetList[muppetList.Count - 1]);

Console.WriteLine("\n");

muppetList.Add("beaker");

Console.WriteLine(muppetList[muppetList.Count - 1]);
