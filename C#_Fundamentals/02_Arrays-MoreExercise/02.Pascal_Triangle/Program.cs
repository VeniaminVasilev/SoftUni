int lines = int.Parse(Console.ReadLine());
long[] allRows = new long[lines];
long[] currentRow = new long[lines];
allRows[0] = 1;
Console.WriteLine(allRows[0]);

for (int row = 1; row < lines; row++)
{
    for (int currentCell = 0; currentCell <= row; currentCell++)
    {
        if (currentCell == 0)
        {
            currentRow[currentCell] = 0 + allRows[currentCell]; ;
        }
        else
        {
            currentRow[currentCell] = allRows[currentCell - 1] + allRows[currentCell];
        }
        Console.Write(currentRow[currentCell] + " ");
    }
    for (int j = 0; j < lines; j++)
    {
        allRows[j] = currentRow[j];
    }
    Console.WriteLine();
}