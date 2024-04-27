Random rnd = new Random();

int width = GetWidth();
int time = GetTimeByDifficulty();

int index = rnd.Next(0, width);

String line = GetLine(index, width);

Console.WriteLine(line);

String pointerLine = "";
int pointerIndex = 0;

while (true)
{
    pointerLine = GetPointerLine(pointerIndex, width);
    
    Thread.Sleep(time);
    Console.Clear();
    Console.WriteLine(line);
    Console.WriteLine(pointerLine);

    Thread.Sleep(time);
    if (Console.KeyAvailable)
    {
        PrintResult(index, pointerIndex);
        break;
    }
    
    pointerIndex++;
    
    if (pointerIndex == width)
    {
        pointerIndex = 0;
    }
}


int GetWidth()
{
    Console.WriteLine("Please Enter the width (min: 1; max: 15): ");
    String widthString = Console.ReadLine()!;
    int validWidth = 0;
    while (true)
    {
        if (Int32.TryParse(widthString, out int width) && width > 1 && width <= 15)
        {
            validWidth = width;
            break;
        }
        else
        {
            Console.WriteLine("The Width Has To Be An Integer between 1 and 15");
            widthString = Console.ReadLine()!;
        }
    }

    return validWidth;
}


int GetTimeByDifficulty()
{
    int[] difficultyArray = [1, 2, 3, 4];
    Console.WriteLine("Enter Difficulty: ");
    Console.WriteLine("\"1\" => easy ");
    Console.WriteLine("\"2\" => normal ");
    Console.WriteLine("\"3\" => hard ");
    Console.WriteLine("\"4\" => expert ");
    String difficultyString = Console.ReadLine()!;
    int time = 0;
    while (true)
    {
        if (Int32.TryParse(difficultyString, out int difficulty) && difficultyArray.Contains(difficulty))
        {
            switch (difficulty)
            {
                case 1:
                {
                    time = 350;
                    break;
                }
                case 2:
                {
                    time = 250;
                    break;
                }
                case 3:
                {
                    time = 100;
                    break;
                }
                case 4:
                {
                    time = 50;
                    break;
                }
            }

            break;
        }
        else
        {
            Console.WriteLine("Please Choose a number between (1, 2, 3, 4)");
            difficultyString = Console.ReadLine()!;
        }
    }
    return time;

}


String GetLine(int index, int width)
{
    String line = "";
    for (int i = 0; i < index; i++)
    {
        line += "_";
    }

    line += "O";

    for (int i = index + 1; i < width; i++)
    {
        line += "_";
    }

    return line;
}

String GetPointerLine(int pointerIndex, int width)
{
    String pointerLine = "";
    for (int i = 0; i < pointerIndex; i++)
    {
        pointerLine += " ";
    }

    pointerLine += "^";

    for (int i = pointerIndex + 1; i < width; i++)
    {
        pointerLine += " ";
    }

    return pointerLine;
}

void PrintResult(int index, int pointerIndex)
{
    if (index == pointerIndex)
    {
        Console.WriteLine("You Win!");
    }
    else
    {
        Console.WriteLine("You Lose. Try to match the pointer to be below \'O\'.");
    }
}