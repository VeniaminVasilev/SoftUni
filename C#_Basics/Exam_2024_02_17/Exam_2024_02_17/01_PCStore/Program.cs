double priceProcessor = double.Parse(Console.ReadLine()) * 1.57;
double priceVideoCard = double.Parse(Console.ReadLine()) * 1.57;
double ram = double.Parse(Console.ReadLine()) * 1.57;
int numberRams = int.Parse(Console.ReadLine());
double percentDiscount = double.Parse(Console.ReadLine());

double processorWithDiscount = priceProcessor - (priceProcessor * percentDiscount);
double videoCardWithDiscount = priceVideoCard - (priceVideoCard * percentDiscount);
double priceRam = ram * (double)numberRams;

Console.WriteLine($"Money needed - {processorWithDiscount + videoCardWithDiscount + priceRam:F2} leva.");