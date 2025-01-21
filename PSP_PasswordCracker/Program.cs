using System;
using System.Security.Cryptography;
using System.Text;

String filePath = "C:\\Users\\fran\\RiderProjects\\HilosGenericos\\HilosGenericos\\10k-most-common.txt";

string[] lines = File.ReadAllLines(filePath);
Random rng = new Random();
int randomNumber = rng.Next(0, lines.Length);
String tal = lines[randomNumber];

Console.WriteLine(HashString(tal));



String HashString(String toHash)
{
    byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(toHash);
    return ByteArrayToString(new MD5CryptoServiceProvider().ComputeHash(tmpSource));
    
}


static string ByteArrayToString(byte[] arrInput)
{
    int i;
    StringBuilder sOutput = new StringBuilder(arrInput.Length);
    for (i=0;i < arrInput.Length; i++)
    {
        sOutput.Append(arrInput[i].ToString("X2"));
    }
    return sOutput.ToString();
}
