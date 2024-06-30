using CLRS;

public class Program
{
    public static void Main(string[] args)
    {
        //List<double> list = new() {3, 2, 8, 1, 5, 4, 6, 7};
        //SortAlgorithms.MergeSort(list, 0, list.Count - 1);
        double[] list = { 3, 2, 8, 1, 5, 4, 6, 7 };
        SortAlgorithms.HeapSort(list);

        foreach (double d in list)
        {
            Console.WriteLine(d); 
        }

    }
}