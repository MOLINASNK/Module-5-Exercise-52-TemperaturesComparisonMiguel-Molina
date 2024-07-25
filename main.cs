using System;

class Program {
  public static void Main (string[] args) {
    const int numTemperatures = 5;
        const int minTemp = -30;
        const int maxTemp = 130;
        int[] temperatures = new int[numTemperatures];

        for (int i = 0; i < numTemperatures; i++)
        {
            temperatures[i] = GetValidTemperature(i + 1);
        }

        CheckTemperatureOrder(temperatures);
        DisplayTemperatures(temperatures);
    }

    static int GetValidTemperature(int index)
    {
        const int minTemp = -30;
        const int maxTemp = 130;
        int temperature;

        while (true)
        {
            Console.Write($"Enter temperature {index}: ");
            if (int.TryParse(Console.ReadLine(), out temperature) && temperature >= minTemp && temperature <= maxTemp)
            {
                return temperature;
            }
            Console.WriteLine($"Temperature {temperature} is invalid, Please enter a valid temperature between {minTemp} and {maxTemp}");
        }
    }

    static void CheckTemperatureOrder(int[] temperatures)
    {
        bool isGettingWarmer = true;
        bool isGettingCooler = true;

        for (int i = 1; i < temperatures.Length; i++)
        {
            if (temperatures[i] <= temperatures[i - 1])
            {
                isGettingWarmer = false;
            }
            if (temperatures[i] >= temperatures[i - 1])
            {
                isGettingCooler = false;
            }
        }

        if (isGettingWarmer)
        {
            Console.WriteLine("Getting warmer");
        }
        else if (isGettingCooler)
        {
            Console.WriteLine("Getting cooler");
        }
        else
        {
            Console.WriteLine("It's a mixed bag");
        }
    }

    static void DisplayTemperatures(int[] temperatures)
    {
        Console.WriteLine("5-day Temperature: [" + string.Join(", ", temperatures) + "]");
        double average = CalculateAverage(temperatures);
        Console.WriteLine($"Average Temperature is {average:F1} degrees");
    }

    static double CalculateAverage(int[] temperatures)
    {
        int sum = 0;
        for (int i = 0; i < temperatures.Length; i++)
        {
            sum += temperatures[i];
        }
        return (double)sum / temperatures.Length;
  }
}