const int maxTextLength = 20;
const int loadingTime = 3;
const int printTime = 30;
const int endTime = 300;

string dataV;
string dataP;
string dataK;

const string name = "Friend";
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
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(introduction);
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine();
    PrintTypewriter("Hello ", ConsoleColor.Black, ConsoleColor.White);
    PrintTypewriter(name, ConsoleColor.Black, ConsoleColor.Green);
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

    dataV = InputData("Enter V: ");
    dataP = InputData("Enter P: ");
    dataK = InputData("Enter K: ");

    Answer();
    CloseMassage();
}

void Answer()
{
    var answerV = Convert.ToString(Summary(dataV));
    var answerP = Convert.ToString(Summary(dataP));
    var answerK = Convert.ToString(Summary(dataK));
    var summaryTotal = int.Parse(answerV) + int.Parse(answerP) + int.Parse(answerK);

    Loading();
    Console.WriteLine();
    Console.Clear();
    PrintTypewriter("Sums of your answers is:", ConsoleColor.Black, ConsoleColor.White);
    Console.WriteLine();
    Console.WriteLine();
    PrintTypewriter(dataV, ConsoleColor.White, ConsoleColor.Black);
    PrintTypewriter(" V", ConsoleColor.Cyan, ConsoleColor.Black);
    PrintTypewriter(answerV, ConsoleColor.Cyan, ConsoleColor.Black);
    PrintTypewriter(" ", ConsoleColor.Cyan, ConsoleColor.Black);
    Console.WriteLine();
    PrintTypewriter(dataP, ConsoleColor.White, ConsoleColor.Black);
    PrintTypewriter(" P", ConsoleColor.DarkCyan, ConsoleColor.Black);
    PrintTypewriter(answerP, ConsoleColor.DarkCyan, ConsoleColor.Black);
    PrintTypewriter(" ", ConsoleColor.DarkCyan, ConsoleColor.Black);
    Console.WriteLine();
    PrintTypewriter(dataK, ConsoleColor.White, ConsoleColor.Black);
    PrintTypewriter(" K", ConsoleColor.DarkMagenta, ConsoleColor.Black);
    PrintTypewriter(answerK, ConsoleColor.DarkMagenta, ConsoleColor.Black);
    PrintTypewriter(" ", ConsoleColor.DarkMagenta, ConsoleColor.Black);
    Console.WriteLine();
    Console.WriteLine();
    PrintTypewriter("Total sum is: ", ConsoleColor.Black, ConsoleColor.White);
    var total = Convert.ToString(summaryTotal);
    PrintTypewriter(total, ConsoleColor.Gray, ConsoleColor.Black);
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

int Summary(string data)
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