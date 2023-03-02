namespace PickRandomCards;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of cards to pick: ");
        var line = Console.ReadLine();

        if (int.TryParse(line, out int numberOfCards))
        {
            foreach (var card in CardPicker.PickSomeCards(numberOfCards))
            {
                Console.WriteLine(card);
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number");
        }
    }
}