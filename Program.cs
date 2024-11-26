

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your text:");
        string message = Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Enter the sender's name:");
        string sender = Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Enter the receiver's name:");
        string receiver = Console.ReadLine();
        Console.Clear();

        IEncoder encoder = new Encode();

        Console.WriteLine("Choose the encoding method (1 or 2):");
        string choice = Console.ReadLine();
        Console.Clear();

        int[] encodedMessage = null;

        if (choice == "1")
        {
            encodedMessage = encoder.EncodeMethod1(sender, receiver, message);
        }
        else if (choice == "2")
        {
            encodedMessage = encoder.EncodeMethod2(sender, receiver, message);
        }
        else
        {
            Console.WriteLine("Invalid option.");
            return;
        }

        Console.WriteLine("Enter file path:");
        string path = Console.ReadLine();

        // ذخیره فایل‌ها
        SaveAsTxt(encodedMessage, Path.Combine(path, "output.txt"));
        SaveAsIni(encodedMessage, Path.Combine(path, "output.ini"));
        SaveAsCsv(encodedMessage, Path.Combine(path, "output.csv"));

        Console.WriteLine("Done.");
    }

    static void SaveAsTxt(int[] data, string filePath)
    {
        File.WriteAllText(filePath, string.Join(" ", data));
    }

    static void SaveAsIni(int[] data, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("[EncodedData]");
            for (int i = 0; i < data.Length; i++)
            {
                writer.WriteLine($"Value{i + 1}={data[i]}");
            }
        }
    }

    static void SaveAsCsv(int[] data, string filePath)
    {
        File.WriteAllText(filePath, string.Join(",", data));
    }
}