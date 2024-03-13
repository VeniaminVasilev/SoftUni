string[] array1 = Console.ReadLine()
    .Split(" ");

string[] array2 = Console.ReadLine()
    .Split(" ");

for(int i = 0; i < array2.Length; i++)
{
    for (int j = 0; j < array1.Length; j++)
    {
        if (array2[i] == array1[j])
        {
            Console.Write(array2[i] + " ");
        }
    }
}