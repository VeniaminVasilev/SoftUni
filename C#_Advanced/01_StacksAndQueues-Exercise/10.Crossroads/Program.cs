namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            bool incident = false;
            string incidentCar = string.Empty;
            char characterHit = 'a';
            int totalCarsPassed = 0;

            while (true)
            {
                string command = Console.ReadLine();
                
                if (command == "END")
                {
                    Console.WriteLine($"Everyone is safe.");
                    Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
                    break;
                }
                else if (command == "green")
                {
                    if (queue.Count == 0) { continue; }

                    int greenTime = greenLight;
                    string remainingCharacters = string.Empty;

                    while (greenTime > 0)
                    {
                        string currentCar = queue.Peek();
                        int currentCarLength = currentCar.Length;
                        
                        for (int i = 0; i < currentCarLength; i++)
                        {
                            currentCar = currentCar.Remove(0, 1);
                            greenTime -= 1;

                            if (greenTime == 0) { break; }
                        }

                        if (greenTime == 0)
                        {
                            if (currentCar.Length != 0)
                            {
                                remainingCharacters = currentCar;
                            }
                            else if (currentCar.Length == 0)
                            {
                                totalCarsPassed++;
                                queue.Dequeue();
                            }

                            break;
                        }

                        if (currentCar.Length == 0)
                        {
                            totalCarsPassed++;
                            queue.Dequeue();

                            if (greenTime > 0 && queue.Count == 0) { break; }
                        }
                    }

                    int freeTime = freeWindow;
                    
                    if (remainingCharacters.Length != 0)
                    {
                        for (int i = 0; i < freeWindow; i++)
                        {
                            remainingCharacters = remainingCharacters.Remove(0, 1);
                            freeTime -= 1;

                            if (freeTime == 0 && remainingCharacters.Length != 0)
                            {
                                incident = true;
                                incidentCar = queue.Peek();
                                characterHit = remainingCharacters[0];
                                break;
                            }
                            else if (freeTime != 0 && remainingCharacters.Length == 0)
                            {
                                totalCarsPassed++;
                                queue.Dequeue();
                                break;
                            }
                            else if (freeTime == 0 && remainingCharacters.Length == 0)
                            {
                                totalCarsPassed++;
                                queue.Dequeue();
                                break;
                            }
                        }

                        if (freeWindow == 0)
                        {
                            incident = true;
                            incidentCar = queue.Peek();
                            characterHit = remainingCharacters[0];
                        }
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }

                if (incident)
                {
                    Console.WriteLine($"A crash happened!");
                    Console.WriteLine($"{incidentCar} was hit at {characterHit}.");
                    break;
                }
            }
        }
    }
}