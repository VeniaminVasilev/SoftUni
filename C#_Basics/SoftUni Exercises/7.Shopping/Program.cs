double budgetOfPeter = double.Parse(Console.ReadLine());
int videocards = int.Parse(Console.ReadLine());
int processors = int.Parse(Console.ReadLine());
int rams = int.Parse(Console.ReadLine());

double totalVideocards = videocards * 250.0;
double priceProcessor = totalVideocards * 0.35;
double totalProcessors = priceProcessor * processors;
double priceRam = totalVideocards * 0.10;
double totalRams = priceRam * rams;

double totalSum = totalVideocards + totalProcessors + totalRams;

if (videocards > processors)
{
    totalSum = totalSum * 0.85;
}

double difference = Math.Abs(totalSum - budgetOfPeter);

if (budgetOfPeter >= totalSum)
{
    Console.WriteLine($"You have {difference:F2} leva left!");
} else
{
    Console.WriteLine($"Not enough money! You need {difference:F2} leva more!");
}