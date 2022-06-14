namespace Tsp;

public class Tester
{
    public void TestRequiredBits()
    {
        var bits = BitsCalculator.CalculateRequiredBits(2);
        Console.WriteLine(bits);

        byte b = 0b0010;
        
        
        
    }

    public void TestBitFromByte()
    {
        byte b = 0b0110;
        int bitNumber = 3;
        
        Console.WriteLine(BitsCalculator.GetBitFromByte(b, bitNumber));
    }
    
    public void TestArea()
    {
        Area area = new Area(5, 3, 25);
        
    }
}