using Core;
using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

var textFile = new SimpleTextFile("C:\\Users\\Carlos Gonzalez\\Documents\\cursos\\Estructura de Datos\\tmp\\Animals");
using var logger = new LogWriter("C:\\Users\\Carlos Gonzalez\\Documents\\cursos\\Estructura de Datos\\tmp\\app.log");
try
{
    logger.WriteLog("info", "Application started");
    var lines = textFile.ReadLines();
    var list = lines.ToList();
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
                logger.WriteLog("info", "File listed");
                break;
            case "2":
                Console.WriteLine("Enter a new line: ");
                var newLine = Console.ReadLine();
                list.Add(newLine!);
                logger.WriteLog("info", $"New line added: {newLine} ");
                break;
            case "3":
                Console.WriteLine("Enter a new line: ");
                var lineToRemove = Console.ReadLine();
                list.Remove(lineToRemove!);
                logger.WriteLog("info", $"Line remove: {lineToRemove} ");
                break;
            case "4":
                Console.WriteLine("Enter a new line: ");
                var linesToRemove = Console.ReadLine();
                list.RemoveAll(item => item.Equals(linesToRemove));
                logger.WriteLog("info", $"All lines remove wiht value: {linesToRemove}");

                break;
            case "5":
                list.Sort();
                logger.WriteLog("info", "File saved");
                break;
            case "6":
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

}
catch (Exception ex)
{
    logger.WriteLog("Error", $"An error happended: {ex.Message}.");
}
finally
{
    logger.WriteLog("info", "Application ended");
}


string Menu()
{
    Console.WriteLine("Menu");
    Console.WriteLine("1. Show lines");
    Console.WriteLine("2. Add line");
    Console.WriteLine("3. Remove one occurrence");
    Console.WriteLine("4. Remove all occurrence");
    Console.WriteLine("5. Sort");
    Console.WriteLine("6. Save changes");
    Console.WriteLine("0. Exit");
    Console.WriteLine("Choose an option: ");
    return Console.ReadLine() ?? string.Empty;
}

