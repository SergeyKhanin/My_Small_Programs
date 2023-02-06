using Solver;

const string folderPath = @"D:\Git\My_Small_Programs\Ayurveda\Ayurveda\tests\";

const int maxTextLength = 20;
const int loadingTime = 1;
const int printTime = 20;
const int endTime = 300;

const string introduction = "\nAyurveda, a natural system of medicine, originated in India more than 3,000 years ago." +
                            "\nThe term Ayurveda is derived from the Sanskrit words ayur (life) and veda (science or knowledge)." +
                            "\nThus, Ayurveda translates to knowledge of life." +
                            "\nBased on the idea that disease is due to an imbalance or stress in a person's consciousness," +
                            "\nAyurveda encourages certain lifestyle interventions" +
                            "\nand natural therapies to regain a balance between the body, mind, spirit, and the environment.";

const string instructions = "\nYou can only enter whole single digits." +
                            "\nYou can only enter 20 symbols." +
                            "\nYou cannot enter alphabets.";

while (true)
{
    Console.Clear();
    PrintTypewriter("Hello, what is your name? ", ConsoleColor.Black, ConsoleColor.White);
    PrintTypewriter("Enter you name: ", ConsoleColor.Black, ConsoleColor.White);
    Console.ForegroundColor = ConsoleColor.Green;
    var name = Console.ReadLine();

    if (name == String.Empty)
    {
        name = "Unidentified";
    }

    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(introduction);
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine();
    PrintTypewriter("Nice to meet you ", ConsoleColor.Black, ConsoleColor.White);
    PrintTypewriter(name ??= "Unidentified", ConsoleColor.Black, ConsoleColor.Green);
    PrintTypewriter(", this is Ayurveda test!", ConsoleColor.Black, ConsoleColor.White);
    Console.WriteLine();
    Console.WriteLine();
    PrintTypewriter("V", ConsoleColor.Black, ConsoleColor.Cyan);
    PrintTypewriter(" is Vata dosha.", ConsoleColor.Black, ConsoleColor.White);
    Console.WriteLine();
    PrintTypewriter("P", ConsoleColor.Black, ConsoleColor.DarkCyan);
    PrintTypewriter(" is Pitta dosha.", ConsoleColor.Black, ConsoleColor.White);
    Console.WriteLine();
    PrintTypewriter("K", ConsoleColor.Black, ConsoleColor.DarkMagenta);
    PrintTypewriter(" is Kapha dosha.", ConsoleColor.Black, ConsoleColor.White);
    Console.WriteLine();
    Console.WriteLine();
    PrintTypewriter("Instructions: ", ConsoleColor.Black, ConsoleColor.DarkRed);
    PrintTypewriter(instructions, ConsoleColor.Black, ConsoleColor.DarkGray);
    Console.WriteLine();
    Console.WriteLine();
    PrintTypewriter("Press \"Enter\" to continue!", ConsoleColor.Black, ConsoleColor.DarkYellow);
    Console.ReadLine();

    var dataV = InputData("Enter V: ");
    var dataP = InputData("Enter P: ");
    var dataK = InputData("Enter K: ");

    Answer(name, dataV, dataP, dataK);
    CloseMassage();
}

void Answer(string name, string dataV, string dataP, string dataK)
{
    var answerV = Convert.ToString(CharSummary(dataV));
    var answerP = Convert.ToString(CharSummary(dataP));
    var answerK = Convert.ToString(CharSummary(dataK));

    var summaryTotal = Summary.Solve(int.Parse(answerV), int.Parse(answerP), int.Parse(answerK));

    Loading();
    Console.WriteLine();
    Console.Clear();
    PrintTypewriter("Sums of your answers is:", ConsoleColor.Black, ConsoleColor.White);
    Console.WriteLine();
    PrintLetter(dataV, answerV, " V", ConsoleColor.Cyan);
    PrintLetter(dataP, answerP, " P", ConsoleColor.DarkCyan);
    PrintLetter(dataK, answerK, " K", ConsoleColor.DarkMagenta);
    Console.WriteLine();
    Console.WriteLine();
    PrintTypewriter("Total sum is: ", ConsoleColor.Black, ConsoleColor.White);
    var total = Convert.ToString(summaryTotal);
    PrintTypewriter(total, ConsoleColor.Gray, ConsoleColor.Black);
    SaveToFile(name, answerV, answerP, answerK, dataV, dataP, dataK);
}

void PrintTypewriter(string text, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
{
    foreach (var items in text)
    {
        Console.BackgroundColor = backgroundColor;
        Console.ForegroundColor = foregroundColor;
        Console.Write(items);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Thread.Sleep(printTime);
    }
}

int CharSummary(string data)
{
    var summary = 0;
    foreach (var items in data)
    {
        var text = Convert.ToString(items);
        var value = Convert.ToInt32(text);
        summary += value;
    }

    var result = summary;
    return result;
}

void Loading()
{
    for (int i = 0; i < 101; i++)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("\r" + i.ToString() + "%");
        Thread.Sleep(loadingTime);
        Console.BackgroundColor = ConsoleColor.Black;
    }
}

void ItemCheck(string data)
{
    foreach (var items in data)
    {
        var text = Convert.ToString(items);
        var value = Convert.ToInt32(text);
        Console.Write(value.ToString());
        Console.Clear();
    }
}

bool DataCheck(string data)
{
    var result = data.Length == maxTextLength;

    if (!result)
    {
        Console.Clear();
        PrintTypewriter("Length", ConsoleColor.Black, ConsoleColor.Blue);
        return result;
    }

    try
    {
        ItemCheck(data);
        return result;
    }
    catch (Exception)
    {
        Console.Clear();
        PrintTypewriter("Symbol", ConsoleColor.Black, ConsoleColor.Green);
        result = false;
        return result;
    }
}

void SaveToFile(string name, string answerV, string answerP, string answerK, string dataV, string dataP, string dataK)
{
    File.WriteAllLines(folderPath + name + "_Ayurveda_Test.txt", new[]
    {
        "Name is: " + name,
        String.Empty,
        "Vata dosha is: " + answerV,
        "Pitta dosha is: " + answerP,
        "Kapha dosha is: " + answerK,
        String.Empty,
        "Answers: ",
        dataV,
        dataP,
        dataK
    });
}

void PrintLetter(string data, string answer, string letter, ConsoleColor color)
{
    Console.WriteLine();
    PrintTypewriter(data, ConsoleColor.White, ConsoleColor.Black);
    PrintTypewriter(letter, color, ConsoleColor.Black);
    PrintTypewriter(answer, color, ConsoleColor.Black);
    PrintTypewriter(" ", color, ConsoleColor.Black);
}

void CloseMassage()
{
    PrintTypewriter("    Press \"Enter\" to restart program!", ConsoleColor.Black, ConsoleColor.DarkYellow);
    Console.ReadKey();
}

string InputData(string massage)

{
    while (true)
    {
        Console.Clear();
        PrintTypewriter(massage, ConsoleColor.Black, ConsoleColor.DarkYellow);

        var data = Console.ReadLine();
        if (data != null && DataCheck(data))
        {
            PrintTypewriter("Correct data!", ConsoleColor.Black, ConsoleColor.Green);
            Thread.Sleep(endTime);
            Console.Clear();
            return data;
        }

        PrintTypewriter(" incorrect data", ConsoleColor.Black, ConsoleColor.Red);
        PrintTypewriter(", please, try again! ", ConsoleColor.Black, ConsoleColor.White);
        Thread.Sleep(endTime);
    }
}