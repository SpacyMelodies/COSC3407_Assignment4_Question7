using CircularLinkedList;

internal class Program
{    private static void Main(string[] args)
    {
        Console.WriteLine("Second Chance Algorithm Tester");
        Console.WriteLine("--------------------");
        int capacity = GetAllowedInteger("Enter size of your list (between 30 and 40"); // Gets desired capacity from uer

        // initializes the circular linked list with node values either 0 or 1
        // prints the initial list, gets the desired victim indexes from the
        // user, then calls the Victimze method
        CircularLinkedList.CircularLinkedList myLinky = new CircularLinkedList.CircularLinkedList(capacity);
        myLinky.PrintLinkedList();
        int[] victimArr = GetVictimArr(capacity);
        myLinky.Victimize(victimArr);

        //prints the list after the Second Change Algorithm has been
        // altered from the desired victims
        Console.WriteLine("after victims:");
        myLinky.PrintLinkedList();

        Console.ReadLine();
    }

    // returns an integer array of vitcim indexes bounded to the capacity size the user chose
    private static int[] GetVictimArr(int capacity)
    {
        int[] victimArr = new int[3]; //Hardcoded 3 victims as per assignment
        for (int i = 0; i < victimArr.Length; i++)
        {
            Console.WriteLine($"Enter victim #{i + 1}: ");
            bool isInt = int.TryParse(Console.ReadLine(), out victimArr[i]);
            while (!isInt || victimArr[i] >= capacity || victimArr[i] < 0)
            {
                Console.WriteLine($"Please enter a valid index between 0 and {capacity - 1}");
                isInt = int.TryParse(Console.ReadLine(), out victimArr[i]);
            }
        }
        return victimArr;
    }

    // returns user intputted integer bounded between 30 and 40
    private static int GetAllowedInteger(string message)
    {
        Console.WriteLine(message);
        string input = Console.ReadLine();
        bool isValid = int.TryParse(input, out int value);
        while (!isValid || value < 30 || value > 40)
        {
            Console.WriteLine("enter integer between 30 and 40");
            input = Console.ReadLine();
            isValid = int.TryParse(input, out value);
        }
        return value;
    }
}