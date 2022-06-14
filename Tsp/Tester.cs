namespace Tsp;

public class Tester
{
    public void TestRequiredBits()
    {
        var bits = BitsCalculator.CalculateRequiredBits(2);
        Console.WriteLine(bits);
    }

    public void TestBitFromByte()
    {
        byte b = 0b0110;
        int bitNumber = 3;
        
        Console.WriteLine(BitsCalculator.GetBitFromByte(b, bitNumber));
    }

    public void TestByteFormat()
    {
        byte b = 0;
        Console.WriteLine(BitsCalculator.FormatByte(b, 4));
    }
    
    public void TestArea()
    {
        Area area = new Area(6, 5, 25);
        
    }
}