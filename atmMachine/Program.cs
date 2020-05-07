using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace atmMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            
            WriteLine("Welcome to the Extra Credit Union ATM");
            WriteLine();
            LogIn();
            WriteLine();



            ReadKey();
        }//closes main

        public static string LogIn()
        {
            string[] username = { "AverageStudent", "CanIGetanA", "ImTryingHere" };
            string[] password = { "CsGetDegrees", "heresA20", "123456" };
            string name = "", pass, v, input;
            bool loggedin = false, cont = true;
            int i, counter = 0, ans;
            double balance = 1000;
            while (loggedin == false )
            {
                if (counter <= 2)
                {


                    i = 0;
                    Write("Please enter your username: ");
                    name = ReadLine();
                    WriteLine();
                    Write("Please enter your password: ");
                    pass = ReadLine();
                    WriteLine();
                    while (i < username.Length)
                    {
                        if (name == username[i])
                        {
                            if (pass == password[i])
                            {
                                loggedin = true;
                                i = username.Length;
                                WriteLine("Login Successful");
                                WriteLine();
                                while (cont == true)
                                {
                                    WriteLine("1: Deposit");
                                    WriteLine("2: Withdraw");
                                    WriteLine("3: Check Balance");
                                    WriteLine("4: End Transaction");
                                    WriteLine();
                                    Write("Enter Menu Number: ");
                                    input = ReadLine();
                                    ans = Convert.ToInt32(input);
                                    WriteLine();

                                    switch (ans)
                                    {
                                        case 1:
                                            balance = deposit(ref balance);
                                            WriteLine();
                                            break;
                                        case 2:
                                            balance = withDraw(ref balance);
                                            WriteLine();
                                            break;
                                        case 3:
                                            balance = checkBalance(ref balance);
                                            WriteLine();
                                            break;
                                        case 4:
                                            WriteLine("Thank you for using the Extra Credit Union ATM.");
                                            WriteLine("Have a nice day.");
                                            cont = false;
                                            break;
                                        default:
                                            WriteLine("You did not enter a valid number");
                                            WriteLine();
                                            cont = true;
                                            break;
                                    }
                                }

                            }
                            else
                            {
                                WriteLine("Not a Valid password");
                                WriteLine();
                                i = username.Length;
                                counter++;
                            }
                        }
                        else if (i == username.Length - 1)
                        {
                            WriteLine("Not a Valid username");
                            WriteLine();
                            i++;
                            counter++;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                else
                {
                    Write("Knock Knock: ");
                    v = ReadLine();
                    WriteLine();
                        if(!(v == "who's there?" || v == "who is there?" || v == "Who's there?" || v == "Who is there?"))
                        {
                            WriteLine("Can't even figure out a knock knock joke, no wonder you couldn't sign in");
                        }
                        else
                        {
                            WriteLine("Not you! Wrong username and password!");
                            WriteLine();
                            WriteLine("*Slams Door*");
                        }

                    loggedin = true;
                }
                
            }

            return (string)name;
        }//closes login method

        public static double deposit(ref double balance)
        {
            double cash = 0, check, num, tC = 0, total;
            string userInput = "";

            while(userInput == "")
            {
                Write("Do you want to Deposit cash? Yes or No: ");
                userInput = ReadLine();
                WriteLine();
                if (userInput == "yes" || userInput == "Yes" || userInput == "YES")
                {
                    Write("Enter the amount of cash to deposit: ");
                    cash = Convert.ToDouble(ReadLine());
                    WriteLine();
                }

                Write("Are you depositing checks? Yes or No: ");
                userInput = ReadLine();
                WriteLine();
                if (userInput == "yes" || userInput == "Yes" || userInput == "YES")
                {
                        Write("How many checks will you be depositing: ");
                        num = Convert.ToDouble(ReadLine());
                        WriteLine();
                        for (int i = 0; i < num; i++)
                        {
                            Write("How much money is on the check: ");
                            check = Convert.ToDouble(ReadLine());
                            WriteLine();
                            tC += check;

                        }
                    
                }
                Write("Do you have any other deposits? Yes or No: ");
                userInput = ReadLine();
                WriteLine();
            }//closes deposit while

            total = tC + cash;
            balance += total;
            WriteLine("The total amount deposited is {0}, and your new balance is {1}.", total, balance);
            return balance;

        }//closes deposit method

        public static double withDraw(ref double balance)
        {
            Write("How much would you like to Withdraw?: ");
            double num = Convert.ToDouble(ReadLine());
            WriteLine();
            balance -= num;
            WriteLine("You have withdrawn {0} and your new balance is {1}.", num, balance);
            return balance;
         
        }//closes withDraw method

        public static double checkBalance(ref double balance)
        {
            WriteLine("Your current balance is {0}.", balance);
            return balance;
        }//closes checkBalance method

    }
}
