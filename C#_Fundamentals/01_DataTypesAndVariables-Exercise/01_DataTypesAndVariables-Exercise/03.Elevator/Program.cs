int numberOfPeople = int.Parse(Console.ReadLine());
int capacityOfElevator = int.Parse(Console.ReadLine());

int courses = 0;

if (numberOfPeople % capacityOfElevator == 0)
{
    courses = numberOfPeople / capacityOfElevator;
}
else
{
    courses = (numberOfPeople / capacityOfElevator) + 1;
}

Console.WriteLine(courses);