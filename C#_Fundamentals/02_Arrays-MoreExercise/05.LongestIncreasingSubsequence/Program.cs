int[] nums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int n = nums.Length;
int[] len = new int[n];
int[] prev = new int[n];
int maxLen = 0;
int maxIndex = 0;

for (int i = 0; i < n; i++)
{
    len[i] = 1;
    prev[i] = -1;
    for (int j = 0; j < i; j++)
    {
        if (nums[i] > nums[j] && len[j] + 1 > len[i])
        {
            len[i] = len[j] + 1;
            prev[i] = j;
        }
    }
    if (len[i] > maxLen)
    {
        maxLen = len[i];
        maxIndex = i;
    }
}

int[] lis = new int[maxLen];
int index = maxLen - 1;
while (maxIndex != -1)
{
    lis[index] = nums[maxIndex];
    index--;
    maxIndex = prev[maxIndex];
}

Console.WriteLine(string.Join(" ", lis));