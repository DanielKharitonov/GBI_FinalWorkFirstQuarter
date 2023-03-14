// Задача: написать программу, которая из имеющегося массива строк формирует массив из строк,
// длина которых меньше либо равна 3 символа. Первоначальный массив можно ввести с клавиатуры,
// либо задать на старте выполнения алгоритма. 

Console.Clear();

void PrintArray(string[] array)
{
    System.Console.WriteLine(" [" + string.Join(",", array) + "]");
}

string[] EnterLine()
{
    char enteredSymbol = ' ';
    string line = "";
    int positionSymbolInLine = 1;
    string action = "stop line";
    ConsoleKeyInfo clik;
    do
    {
        clik = Console.ReadKey();
        if (clik.Key != ConsoleKey.Spacebar && clik.Key != ConsoleKey.Escape)
        {
            enteredSymbol = clik.KeyChar;
            line = line.PadRight(positionSymbolInLine, enteredSymbol);
            positionSymbolInLine++;
        }
        else if (clik.Key != ConsoleKey.Spacebar)
        {
            action = "stop programm";
        }

    } while (clik.Key != ConsoleKey.Spacebar && clik.Key != ConsoleKey.Escape);
    string[] arrayLine = { line, action };
    return arrayLine;
}

string[] EnterLines()
{
    string[] arrayLine = new string[2]; ;
    string[] arrayLines = new string[1];
    int indexArrayLines = 0;
    do
    {
        arrayLine = EnterLine();

        if (arrayLine[1] != "stop programm")
        {
            Array.Resize(ref arrayLines, arrayLines.Length + 1);
            arrayLines[indexArrayLines] = arrayLine[0];
            indexArrayLines++;
        }
        else if (arrayLine[1] == "stop programm")
        {
            arrayLines[indexArrayLines] = arrayLine[0];
        }
    } while (arrayLine[1] != "stop programm");
    Console.Clear();
    return arrayLines;
}

string[] ArrayLinesOfNSymbols(string[] arrayLines, int numberSymbols)
{
    string[] newArrayLines = new string[0];
    int indexNewArrayLines = 0;

    for (int i = 0; i < arrayLines.Length; i++)
    {
        if (arrayLines[i].Length <= numberSymbols)
        {
            Array.Resize(ref newArrayLines, newArrayLines.Length + 1);
            newArrayLines[indexNewArrayLines] = arrayLines[i];
            indexNewArrayLines++;
        }
    }
    return newArrayLines;
}

System.Console.WriteLine("Введите массив строк.");
System.Console.WriteLine("Для разделения строк нижмите клавишу Spacebar. Для завершения ввода нажмите клавишу Escape. При вводе не нажимайте клавишу Enter");
System.Console.WriteLine();
string[] arrayLines = EnterLines();

System.Console.WriteLine("Вы ввели следующий массив строк:");
PrintArray(arrayLines);
System.Console.WriteLine();

int numberSymbols = 3;
string[] arrayLinesOfNSymbols = ArrayLinesOfNSymbols(arrayLines, numberSymbols);

System.Console.WriteLine("Массив строк, длина которых меньше либо равна 3 символа");
PrintArray(arrayLinesOfNSymbols);