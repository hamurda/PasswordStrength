using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CAppPasswordStrength
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isContinue = true;

            while (isContinue)
            {
                //Entry
                Console.WriteLine("Hi there! Please avoid following characters: \\,*,/,?,&");
                Console.WriteLine("Enter a password:");
                string password = Console.ReadLine().Trim(' ');

                //Checks if the entry is valid
                if (password == "" || password.IndexOfAny("*&\\?/".ToCharArray()) != -1)
                {
                    Console.WriteLine($"The entry is invalid.");
                }
                //Checks password when it's valid
                else
                {
                    StrengthAPIHelper.InitilizeClient();
                    BreachAPIHelper.InitilizeClient();
                    string strengthInfo = "";
                    string breachInfo = "";

                    //Gets password strength
                    try
                    {
                        strengthInfo = StrengthAPIHelper.GetStrength(password).Result;
                    }
                    catch (System.AggregateException)
                    {

                        strengthInfo = "Invalid";
                    }
                    finally
                    {
                        Console.WriteLine($"The password is: {strengthInfo}");
                    }

                    //Gets how many times password was pawned
                    try
                    {
                        breachInfo = BreachAPIHelper.GetBreachInfo(password).Result;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        //If it is not pawned before
                        if (breachInfo == "0")
                        {
                            Console.WriteLine($"The password \"{password}\" has never been pawned so far!");
                        }
                        else // If it is pawned before
                        {
                            Console.WriteLine($"The password \"{password}\" has been pawned {breachInfo} times so far!");
                        }
                    }

                }

                //If the user wants to try another entry
                Console.WriteLine("Do you want to check another password? Please hit 'Enter' for 'Yes' or type 'N' for 'no': ");
                string answer = Console.ReadLine().Trim(' ');
                if (answer.ToLower() == "n")
                {
                    isContinue = false;
                }
            }

        }

    }
}
