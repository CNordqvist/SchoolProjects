
Random random = new Random();

ConsoleKey key;

int[] box = new int[2];
Meny(box);
int[] player = new int[2] { box[0] / 2, box[1] / 2 };

char[,] gameField = new char[box[0], box[1]];
DrawBox(box);
LevelEdit(random, gameField);
Console.Clear();
AppleSpawner(random);
while (true)
{
    int apples = 1;
    int[,] playerTail = new int[apples, apples];
    char[] nextStep = new char[2];
    Print(gameField, player);
    ReadNext(gameField, player, nextStep);
    MovePlayer(nextStep);
        
    if (nextStep[1] == 'A')
    {
        int[,] temp = new int[1,1];
        apples++;
        AppleSpawner(random);
        for (int i = 0; i < playerTail.Length-1; i++)
        {
            temp[0,0] = playerTail[i,i];
            playerTail[i + 1, i + 1] = playerTail[i, i];
            player
        }
    }

    Console.Clear();

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
        gameField[random.Next(1, gameField.GetLength(0)-1), random.Next(1, gameField.GetLength(1)-1)] = 'O';
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

char[] ReadNext(char[,] gameField, int[] player, char[] nextStep)
{
    
    key = Console.ReadKey(true).Key;
    //Spara rikning och vilket tecken som finns där
    if (key == ConsoleKey.UpArrow)
    {
        nextStep[0] = 'w';
        nextStep[1] = gameField[player[0]-1, player[1]];
    }
    else if (key == ConsoleKey.DownArrow)
    {
        nextStep[0] = 's';
        nextStep[1] = gameField[player[0]+1, player[1]];
    }
    else if (key == ConsoleKey.LeftArrow) 
    { 
        nextStep[0] = 'd';
        nextStep[1] = gameField[player[0], player[1] - 1];
    }
    else if (key == ConsoleKey.RightArrow)
    {
        nextStep[0] = 'a';
        nextStep[1] = gameField[player[0], player[1] + 1];
    }
    return nextStep;
}
int[] MovePlayer(char[] nextStep)
    //ta steget och spara i player
{
    if (nextStep[0] == 'w' && nextStep[1] != '#' && nextStep[1] != 'O')
    {
        player[0]--;
    }
    else if (nextStep[0] == 's' && nextStep[1] != '#' && nextStep[1] != 'O')
    {
        player[0]++;
    }
    else if (nextStep[0] == 'd' && nextStep[1] != '#' && nextStep[1] != 'O')
    {
        player[1]--;
    }
    else if (nextStep[0] == 'a' && nextStep[1] != '#' && nextStep[1] != 'O')
    {
        player[1]++;
    }

    return player;
}

char[,] DrawBox(int[] box)
{

    //Y
    for (int i = 0; i < box[0]; i++)
    {
        //X
        for (int j = 0; j < box[1]; j++)
        {

            if (i == 0 || i == box[0] - 1 || j == 0 || j == box[1] - 1)
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
int[] Meny(int[] box)
{ 
    Console.WriteLine("Hur hög ska spelarenan vara?");
    try 
    {
        box[0] = int.Parse(Console.ReadLine());
    } catch { }
    Console.WriteLine("Hur bred ska spelarenan vara?");
    try 
    {
        box[1] = int.Parse(Console.ReadLine());
    }
    catch { }
    return box;
}

char[,] AppleSpawner(Random random)
{
    //slumpa fram ett äpple på tom plats
    while (true)
    {
        int y = random.Next(1, box[0] - 1);
        int x = random.Next(1, box[1] - 1);
        if (gameField[y, x] != 'O')
        {
            gameField[y, x] = 'A';
            break;
        }
    }
    return gameField;
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