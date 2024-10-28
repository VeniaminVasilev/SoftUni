namespace _01.BallGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> strength = new Stack<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            Queue<int> accuracy = new Queue<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            int goals = 0;

            while (true)
            {
                if (strength.Count == 0 || accuracy.Count == 0)
                {
                    break;
                }

                int currentStrength = strength.Peek();
                int currentAccuracy = accuracy.Peek();
                int sum = currentStrength + currentAccuracy;

                if (sum == 100)
                {
                    goals++;
                    strength.Pop();
                    accuracy.Dequeue();
                }
                else if (sum < 100)
                {
                    if (currentStrength < currentAccuracy)
                    {
                        strength.Pop();
                    }
                    else if (currentStrength > currentAccuracy)
                    {
                        accuracy.Dequeue();
                    }
                    else if (currentStrength == currentAccuracy)
                    {
                        int newStrength = currentStrength + currentAccuracy;
                        strength.Pop();
                        strength.Push(newStrength);
                        accuracy.Dequeue();
                    }
                }
                else if (sum > 100)
                {
                    currentStrength -= 10;
                    strength.Pop();
                    strength.Push(currentStrength);
                    accuracy.Dequeue();
                    accuracy.Enqueue(currentAccuracy);
                }
            }

            if (goals == 3)
            {
                Console.WriteLine($"Paul scored a hat-trick!");
            }
            else if (goals == 0)
            {
                Console.WriteLine($"Paul failed to score a single goal.");
            }
            else if (goals > 3)
            {
                Console.WriteLine($"Paul performed remarkably well!");
            }
            else if (goals > 0 && goals < 3)
            {
                Console.WriteLine($"Paul failed to make a hat-trick.");
            }

            if (goals > 0)
            {
                Console.WriteLine($"Goals scored: {goals}");
            }

            if (strength.Count > 0)
            {
                Console.WriteLine($"Strength values left: {string.Join(", ", strength)}");
            }

            if (accuracy.Count > 0)
            {
                Console.WriteLine($"Accuracy values left: {string.Join(", ", accuracy)}");
            }
        }
    }
}