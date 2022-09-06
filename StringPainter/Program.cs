// See https://aka.ms/new-console-template for more information


string line = "29535123p48723487597645723645";


for (int i = 0; i < line.Length - 1; i++)
{

    if (!char.IsDigit(line[i])) //Kolla om i är en siffra annars hoppa raden
    {
        continue;
    }

    for (int j = i + 1; j < line.Length; j++) // Hitta sista siffran i giltiga tal
    {
        if (!char.IsDigit(line[j]) )
        {
            break;
        } 
        else if (line[i] == line[j]) //När giltigt tal hittats skriv ut hela raden med talet markerat.
        {
            for (int k = 0; k < line.Length; k++)
            {
                if (k >= i && k <= j)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(line[k]);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(line[k]);
                }
            }
            Console.WriteLine("");
            break;
        }
    }
}

Console.ReadKey();