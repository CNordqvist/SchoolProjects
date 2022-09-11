// See https://aka.ms/new-console-template for more information


/*
while (true) {
  
    Random random = new Random();
    string line = "29535123p48723487597645723645";
    char input;
    double sum = 0;
    
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
        string lineNums = "";

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
                        lineNums += line[l];
                        ColorSwitch(color);
                        Console.Write(line[l]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(line[l]);
                    }
                    
                }
                sum += double.Parse(lineNums);
                Console.WriteLine("");
                break;
            }
            
        }
    }
    Console.WriteLine("\nAll the colored numbers add up to: " + sum);
}

ConsoleColor ColorSwitch(int color)
{
    switch (color)
    {
        case 0:
            return Console.ForegroundColor = ConsoleColor.Green;
        case 1:
            return Console.ForegroundColor = ConsoleColor.DarkRed;
        case 2:
            return Console.ForegroundColor = ConsoleColor.Magenta;
        case 3:
            return Console.ForegroundColor = ConsoleColor.Blue;
        default:
            return Console.ForegroundColor = ConsoleColor.Red;
    }
}
*/
// övning 19


Random random = new Random();

ConsoleKey key;

//storlek på arena med kant
int[] box = {
 /* Height */ 13,
 /* Width  */ 13 };
//Startposition of player
int[] player = {
/* Yaxis */ box[0]/2,
/* Xaxis */ box[1]/2 };

char[,] gameField = new char[box[0], box[1]];

DrawBox(box);
LevelEdit(random, gameField);

while (true)
{
    
    Print(gameField, player);
    MovePlayer(gameField, player);

    Console.Clear();

}

char[,] DrawBox(int[] box)
{

    //Y
    for (int i = 0; i < box[0]; i++)
    {
        //X
        for (int j = 0; j < box[1]; j++)
        {

            if (i == 0 || i == box[0]-1 || j == 0 || j == box[1]-1)
            {
                gameField[i, j] = '#';
            }
            else
            {
                gameField[i, j] = '-';
            }

        }
    }
    return gameField;
}

char[,] LevelEdit(Random random,char[,] gameField)
{
    //Mängd stenar, minst 5%, max 20%
    //X-2 * Y-2 = arenan utan kanten
    int slumpMängd = random.Next(
        (gameField.GetLength(0) - 2) * (gameField.GetLength(1) - 2) / 20, //min
        (gameField.GetLength(0) - 2) * (gameField.GetLength(1) - 2) / 5 //max
        ) ;

    for (int i = 0; i < slumpMängd; i++)
    {
        //Stenens Y = random mellan 2 till (maxlängd - 2) pga kanten, samma med X
        gameField[random.Next(2, gameField.GetLength(0)-2), random.Next(2, gameField.GetLength(1)-2)] = '\x263c';
    }


    return gameField;
    };


void Print(char[,] gameField, int[] player)
{
    for (int i = 0; i < gameField.GetLength(0); i++)
    {
        for (int j = 0; j < gameField.GetLength(1); j++)
        {
            if (i == player[0] && j == player[1])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("@");
                Console.ResetColor();
            }
            else
            {
                Console.Write(gameField[i, j]);
            }
        }
        Console.WriteLine();
    }
}

int[] MovePlayer(char[,] gameField, int[] player)
{
    key = Console.ReadKey(true).Key;
    //Om nästa steg inte är restricted, ta det
    if (key == ConsoleKey.UpArrow
        && gameField[player[0]-1,player[1]] != '#'
        && gameField[player[0] - 1, player[1]] != '\x263c')
    {
        player[0] -= 1;
    }
    else if (key == ConsoleKey.DownArrow
        && gameField[player[0] + 1, player[1]] != '#'
        && gameField[player[0] + 1, player[1]] != '\x263c')
    {
        player[0] += 1;
    }
    else if (key == ConsoleKey.LeftArrow 
        && gameField[player[0], player[1] -1] != '#'
        && gameField[player[0], player[1] - 1] != '\x263c')
    {
        player[1] -= 1;
    }
    else if (key == ConsoleKey.RightArrow 
        && gameField[player[0], player[1] +1] != '#'
        && gameField[player[0], player[1] + 1] != '\x263c')
    {
        player[1] += 1;
    }
    return player;
}
/*
 for (int y = 0; y < box[0]; y++)
        {
            for (int j = 0; j < box[1]; j++)
            {

                
            }
            Console.WriteLine(" ");
        }
*/
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
/*
int[] tal = { 1, 3, 2, 5, 4, 9 };
int temp = 0;

for (int i = 0; i < tal.Length-1; i++)
{
    for (int j = i+1; j < tal.Length; j++)
    {

        if (tal[i] > tal[j])
        {
            temp = tal[i];
            tal[i] = tal[j];
            tal[j] = temp;
        }

    }
}
for (int k = 0; k < tal.Length; k++)
{
    Console.Write(tal[k] + " ");
}

int[] tal = { 1, 3, 2, 5, 4, 9 };
int[] sorted = new int[tal.Length];
int temp = 0;

for (int j = 0; j < tal.Length; j++)
{
    for (int i = 0; i < tal.Length; i++)
    {
       if (tal[j] < sorted[i])
        {
            sorted[i] = tal[j];
        }
    }
}

for (int k = 0; k < tal.Length; k++)
{
    Console.Write(sorted[k] + " ");
}*/