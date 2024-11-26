



public class Encode : IEncoder
{
    public int[] EncodeMethod1(string sender, string receiver, string message)
    {
        int senderSum = SumOfCharCodes(sender);
        int receiverSum = SumOfCharCodes(receiver);
        int offset = senderSum + receiverSum;

        return ApplyOffset(message, offset);
    }

    public int[] EncodeMethod2(string sender, string receiver, string message)
    {
        int senderSum = SumOfCharCodes(sender);
        int receiverSum = SumOfCharCodes(receiver);
        int offset = (senderSum * receiverSum) / (senderSum + receiverSum);

        return ApplyOffset(message, offset);
    }

    private int SumOfCharCodes(string text)
    {
        int sum = 0;
        int[] numbers = TextToNumber.ConvertTextToNumbers(text);
        foreach (int num in numbers)
        {
            sum += num;
        }
        return sum;
    }

    private int[] ApplyOffset(string message, int offset)
    {
        int[] messageNumbers = TextToNumber.ConvertTextToNumbers(message);
        for (int i = 0; i < messageNumbers.Length; i++)
        {
            messageNumbers[i] += offset;
        }
        return messageNumbers;
    }
}