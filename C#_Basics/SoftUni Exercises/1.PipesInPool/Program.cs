int volume = int.Parse(Console.ReadLine());
int pipe1 = int.Parse(Console.ReadLine());
int pipe2 = int.Parse(Console.ReadLine());
double hours = double.Parse(Console.ReadLine());

double litersResult = hours * (pipe1 + pipe2);
double percentsFull = (litersResult * 100) / volume;
double percentsWaterFromPipe1 = ((hours * pipe1) * 100) / litersResult;
double percentsWaterFromPipe2 = ((hours * pipe2) * 100) / litersResult;

if (litersResult <= volume)
{
    Console.WriteLine($"The pool is {percentsFull:F2}% full. Pipe 1: {percentsWaterFromPipe1:F2}%. Pipe 2: {percentsWaterFromPipe2:F2}%.");
} else
{
    Console.WriteLine($"For {hours:F2} hours the pool overflows with {litersResult - volume:F2} liters.");
}