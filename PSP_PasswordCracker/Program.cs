

//Pass the file path and file name to the StreamReader constructor
String filePath = "C:\\Users\\fran\\RiderProjects\\HilosGenericos\\HilosGenericos\\10k-most-common.txt";
//Read the first line of text

string[] lines = File.ReadAllLines(filePath);
Random rng = new Random();
int randomNumber = rng.Next(0, lines.Length);
Console.WriteLine(lines[randomNumber]);

Console.ReadLine();
