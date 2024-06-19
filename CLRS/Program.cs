using CLRS;

public class Program
{
    public static void Main(string[] args)
    {
        List<double> list = new() { 1, 100, 4, 10.5, 324, 10, 10, 4, 8};
        SortAlgorithms.InsertionSort(list);

        foreach (double d in list)
        {
            Console.WriteLine(d); 
        }

    }
}