namespace Tsp;

public class Tester
{
    public void Test1()
    {
        // var bits = BitAllocator.CalculateNecessaryBits(17);
        // Console.WriteLine(bits);

        byte b = 0b0010;
        int bitNumber = 1;
        
        var bit = (b >> bitNumber) & 1;
        Console.WriteLine(Convert.ToString(b, 2));
    }
    
    public void Test2()
    {
        Area area = new Area(5, 3, 25);
        
    }
}