int days = int.Parse(Console.ReadLine());

int treatedPatients = 0;
int notTreatedPatients = 0;
int doctors = 7;

for (int i = 1; i <= days; i++)
{
    int numberOfPatientsForTheDay = int.Parse(Console.ReadLine());

    if (i % 3 == 0 && notTreatedPatients > treatedPatients)
    {
        doctors++;
    }

    if (numberOfPatientsForTheDay <= doctors)
    {
        treatedPatients += numberOfPatientsForTheDay;
    }
    else if (numberOfPatientsForTheDay > doctors)
    {
        treatedPatients += doctors;
        notTreatedPatients += numberOfPatientsForTheDay - doctors;
    }
}
Console.WriteLine($"Treated patients: {treatedPatients}.");
Console.WriteLine($"Untreated patients: {notTreatedPatients}.");