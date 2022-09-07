// See https://aka.ms/new-console-template for more information

while (true) {
  
    Random random = new Random();
    string line = "29535123p48723487597645723645";
    char input;

    //användar meny

    Console.WriteLine("\nVill du göra en egen string? y/n. s för stop");
    char.TryParse(Console.ReadLine(), out input);

    if (input == 'y')
    {
        Console.WriteLine("Var god och skriv in den sträng du vill använda");
        line = Console.ReadLine();
    } 
    else if (input == 's')
    {
        break;
    }
    else if (input != 'n') 
    {
        Console.WriteLine("Unrecognized character");
        continue;
    }


    for (int i = 0; i < line.Length-1; i++)
    {
        int color = random.Next(4);

        if (!char.IsDigit(line[i]))
        {
            continue;
        }

        for (int j = i+1; j < line.Length; j++)
        {
            if (!char.IsDigit(line[j]))
            {
                break;
            }

            //hitta sista siffran i ett tal som stämmer med kriterierna, printa linjen
            else if (line[j] == line[i]) 
                
            {
                for (int l = 0; l < line.Length; l++)
                {
                    if (l >= i && l <= j)
                    {
                        switch (color) {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                        }
                        Console.Write(line[l]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(line[l]);
                    }
                    
                }
                Console.WriteLine("");
                break;
            }
        }
    }
}

// 
/*
// be om text #1
Console.WriteLine("Please write the first string");
string userString1 = Console.ReadLine();
// be om text #2
Console.WriteLine("Please write the string inside the first string you want found");
string userString2 = Console.ReadLine();



// hitta text2 innuti text1
int index1 = userString1.IndexOf(userString2);

// skriv ut med text 2 markerad
for (int i = 0; i < userString1.Length; i++)
{
    if (i >= index1 && i < index1+ userString2.Length)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(userString1[i]);
        Console.ResetColor();
    }
    else
    {
        Console.Write(userString1[i]);
    }
}
*/