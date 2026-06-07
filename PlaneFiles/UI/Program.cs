using Core;
using System.ComponentModel.Design;

var textFile = new SimpleTextFile("C:\\Users\\Carlos Gonzalez\\Documents\\cursos\\Estructura de Datos\\tmp\\Animals");
var lines = textFile.ReadLines();
var list=lines.ToList();
var option = string.Empty;

do
{
    option = Menu();
    switch (option)
    {
        case "1":
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            break;
        case "2":
            {
                Console.WriteLine("Enter a new line: ");
                var newLine = Console.ReadLine();
                list.Add(newLine!);
            }
            break;
        case "3":
            {
                Console.WriteLine("Enter a new line: ");
                var lineToRemove = Console.ReadLine();
                list.Remove(lineToRemove!);
            }
            break;
        case "4":
            {
                textFile.WriteLines(list.ToArray());
                Console.WriteLine("Changes saved");
            }
            break;
        default:
            break;
    }
} while (option != "0");
textFile.WriteLines(list.ToArray());
Console.WriteLine("Changes saved");

string Menu()
{
    Console.WriteLine("Menu");
    Console.WriteLine("1. Show lines");
    Console.WriteLine("2. Add line");
    Console.WriteLine("3. Remove one occurrence");
    Console.WriteLine("4. Remove all occurrence");
    Console.WriteLine("4. Sort");
    Console.WriteLine("4. Save changes");
    Console.WriteLine("0. Exit");
    Console.WriteLine("Choose an option: ");
    return Console.ReadLine() ?? string.Empty;
}

