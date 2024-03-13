string[] days = {
    "Monday",
    "Tuesday",
    "Wednesday",
    "Thursday",
    "Friday",
    "Saturday",
    "Sunday"
};

int selectedDay = int.Parse(Console.ReadLine());

if (selectedDay < 1 || selectedDay > 7)
{
    Console.WriteLine("Invalid day!");
}
else
{
    Console.WriteLine($"{days[selectedDay - 1]}");
}