using System;
using System.IO;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Core.Training[] trainings = new Core.Training[]
        {
            new Training001.Training(), 
            new Training002.Training(), 
            new Training003.Training(), 
            new Training004.Training(), 
            new Training005.Training(), 
            new Training006.Training(), 
            new Training007.Training(), 
            new Training008.Training(), 
            new Training009.Training(), 
            new Training010.Training(), 
            new Training011.Training(), 
            new Training012.Training(), 
            new Training013.Training(), 
            new Training014.Training(), 
            new Training099.Training(), 
        };

        Console.WriteLine($"=== MENU ===");
        for(int i=0;i<trainings.Length;i++)
        {
            Console.WriteLine($"{i + 1}. {trainings[i].GetTitle()}");
        }
        Console.WriteLine($"0. All trainings");
        string? line = Console.ReadLine(); 
        if(line == null)
        {
            return;
        }
        if(line.Trim() == "0")
        {
            for(int i=0;i<trainings.Length;i++)
            {
                Core.Training training = trainings[i];
                training.Run(i + 1);
            }
            return;
        }

        int index;
        if(int.TryParse(line, out index))
        {
            if(index >= 1 && index <= trainings.Length)
            {
                trainings[index-1].Run(index);
            }
        }
    }
}
