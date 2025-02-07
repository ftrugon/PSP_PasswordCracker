using System;
using System.Security.Cryptography;
using System.Text;
using PSP_PasswordCracker;


class Program
{
    
    static void Main(string[] args)
    {
        String filePath = "C:\\Users\\fran\\RiderProjects\\PSP_PasswordCracker\\PSP_PasswordCracker\\2151220-passwords.txt";

        String[] lines = File.ReadAllLines(filePath);
        Random rng = new Random();
        int randomNumber = rng.Next(0, lines.Length);

        HilosController hc = new HilosController();
        
        String tal = lines[0];
        String hash = PasswdEncoder.Instancia.HashString(tal);
        Console.WriteLine($"hash to catch --> {hash}");
        
        
        Console.WriteLine($"Cuantos hilos quieres: ");

        int hilos;
        while (!int.TryParse(Console.ReadLine(), out hilos) || hilos <= 0)
        {
            Console.WriteLine("Por favor, ingresa un número válido de hilos.");
        }
        
        List<MiHilo> hilosLista = new List<MiHilo>();

        String[][] listaDividida = SplitArray(lines, hilos);

        for (int i = 0; i < hilos; i++)
        {
            MiHilo hilo = new MiHilo(listaDividida[i], hash, hc);
            hilosLista.Add(hilo);
            hilo.Start();
        }

        
    }
    
    public static string[][] SplitArray(string[] passwords, int numParts)  
    {        
        int nSize = (int)Math.Ceiling((double)passwords.Length / numParts);
        string[][] result = new string[numParts][];
    
        for (int i = 0; i < numParts; i++)  
        {  
            int start = i * nSize;  
            int length = Math.Min(nSize, passwords.Length - start);  
            result[i] = passwords.Skip(start).Take(length).ToArray();  
        }  

        return result;  
    }

    
}