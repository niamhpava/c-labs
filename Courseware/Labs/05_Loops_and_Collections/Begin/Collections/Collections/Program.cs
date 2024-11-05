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

Console.WriteLine("\n");

foreach ( string muppet in muppetList)
{
    Console.Write($"{muppet}, ");
}

muppetList.Sort();

Console.WriteLine("\n");

foreach (string muppet in muppetList)
{
    Console.Write($"{muppet}, ");
}

Console.WriteLine("\n");

Console.WriteLine(muppetList[0]);

Console.WriteLine(muppetList[muppetList.Count - 1]);

Console.WriteLine(muppetList[muppetList.Count - 2]);

Console.WriteLine("\n");

string slice = muppetList[5].Substring(2, 3);
string slice2 = muppetList[6].Substring(3, 4);

Console.WriteLine(slice + ", " + slice2);

Console.WriteLine("\n");


Dictionary<string, string> muppetdict = new()
{
    ["beaker"] = "meep",
    ["miss piggy"] = "hi-ya!",
    ["kermit"] = "hi-ho!",
    ["cookie monster"] = "om nom nom"
};

var catchphrase = muppetdict["miss piggy"];

Console.WriteLine(catchphrase);

Console.WriteLine("\n");


foreach (KeyValuePair<string, string> kvp in muppetdict)
{
    Console.WriteLine(kvp.ToString());
}

Console.WriteLine("\n");


foreach (string muppet in muppetdict.Keys)
{
    Console.Write($"{muppet}, "); 
}

Console.WriteLine("\n");


foreach (string catchphrase2 in muppetdict.Values)
{
    Console.Write($"{catchphrase2}, ");
}

Console.WriteLine("\n");
