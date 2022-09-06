using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                //user menu
                string line = "29535123p48723487597645723645";

                Console.WriteLine("Write a custom line or use the default line? [Y/N]. S to stop");
                string yesNo = Console.ReadLine();

                if (yesNo == "Y" || yesNo == "y" || yesNo == "yes" || yesNo == "Yes")
                {
                    line = Console.ReadLine();
                }
                else if (yesNo == "s" || yesNo == "S" || yesNo == "stop" || yesNo == "Stop") { break; };


                Console.WriteLine("Line being used:" + line);
                int colorTicker = 1;
                bool shouldTick = false;

                double finalSum = 0;
                for (int i = 0; i < line.Length; i++)
                {


                    int[] numIndex = new int[2] { -1, -1 }; // array för att see index av första och sista siffra som möter the conditions
                    string relevantNums = "";

                    if (Char.IsDigit(line[i]))
                    {

                        numIndex[0] = i;
                        for (int j = i + 1; j < line.Length; j++)
                        {

                            if (!Char.IsDigit(line[j]))
                            {
                                break;
                            }

                            else if (line[j] == line[numIndex[0]])
                            {
                                numIndex[1] = j;
                                Console.WriteLine("");

                                for (int k = 0; k < line.Length; k++) //skriver ut, färgar
                                {
                                    if (shouldTick == true)
                                    {
                                        colorTicker++;
                                    }
                                    if (colorTicker > 6)
                                    {
                                        colorTicker = 1;
                                    }

                                    if (k >= numIndex[0] && k <= numIndex[1])
                                    {
                                        switch (colorTicker)
                                        {
                                            case 1:
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                break;
                                            case 2:
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                break;
                                            case 3:
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                break;
                                            case 4:
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                break;
                                            case 5:
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                break;
                                            case 6:
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                break;
                                        }
                                        shouldTick = true;
                                        Console.Write(line[k]);
                                        relevantNums += line[k];
                                    }
                                    else
                                    {
                                        if (k < numIndex[0] || k > numIndex[1])
                                        {
                                            Console.Write(line[k]);
                                        }
                                    }
                                    Console.ResetColor();
                                }
                                break;
                            }


                        }
                        double.TryParse(relevantNums, out double sum);
                        finalSum += sum;
                    }

                }
                Console.WriteLine(""); Console.WriteLine("The sum of all coloured nummbers is: " + finalSum); Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}
