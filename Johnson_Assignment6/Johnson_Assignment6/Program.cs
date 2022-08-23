using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Johnson_Assignment6
{
  

    }
    class Account //Base class for instance variables and Credit/Debit formulas.
    {
        public double Balance;
        public string AccountName;
        public int AccountNumber;


        public Account(decimal balance, string name, int number) //Constructor for Balance, AccountName, and AccountNumber.
        {
           this.Balance = 0;
            this.AccountName = name;
            this.AccountNumber = 0;
        }
        public void setBalance(double balance) //Balance setter, validating if balance is greater than 0.
        {

            if (balance < 0)
            {
                balance = 0;
                NegativeNumberException nne =
                    new NegativeNumberException();
                throw nne;
            }
            this.Balance = balance; ;
        }

        public double getBalance() //Balance get method
        {
            return Balance;
        }

        public void setAccountName(string name)
        {
            this.AccountName = name;
        }

        public string getAccountName()
        {
            return this.AccountName;
        }

        public void setAccountNumber(int number)
        {
            this.AccountNumber = number;
        }

        public int getAccountNumber()
        {
            return this.AccountNumber;
        }

        

        public virtual void PrintAccount() //This method will return the information when called upon
        {
        Console.WriteLine("\nName : " + AccountName + ",Account Number: " + AccountNumber + ",InitialBlance: " + Balance);
           
        }


    }

class SavingsAccount : Account //Derived class inherits functionality of Account
{
    public static decimal InterestRate;

    public SavingsAccount(string name, int number, decimal balance, decimal interestRate) : base(balance, name, number)
    {
        this.setInterestRate(interestRate); //SavingsAccount constructor, calls upon base constructor for balance, name, and number

    }

    public void setInterestRate(decimal interestRate) //setter makes interest rate 0 if number is negative
    {
        if (interestRate < 0)
        {
            InterestRate = 0;
            NegativeNumberException nne =
                new NegativeNumberException();
            throw (nne);

        }
        else
        {
            InterestRate = interestRate;
        }
    }
    public override void PrintAccount()
    {
        Console.WriteLine("Interest Rate: " + InterestRate + " %");
    }


    class CheckingAccount : Account //Derived class inherits from base class
    {
        double FeeCharged; //Creates FeeCharged variable

        public CheckingAccount(string name, int number, decimal balance, double feeAmount) : base(balance, name, number) //Constructor for CheckingAccount, calls upon base constructor like SavingsAccount
        {
            this.setFeeAmount(feeAmount);

        }

        public void setFeeAmount(double feeAmount) //Setter operates much like interest rate, where negative is made into 0
        {
            if (feeAmount < 0)
            {
                NegativeNumberException nne =
                    new NegativeNumberException();
                throw (nne);
            }

            else
            {
                FeeCharged = feeAmount;
            }
        }

        public override void PrintAccount()
        {
            base.PrintAccount();
            Console.WriteLine("FeeCharged: " + FeeCharged.ToString("C"));
        }

    }
    class NegativeNumberException : Exception
    {

    }







    class Application
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("|| This program was written by Brandon Johnson for CSIS 209-D01 ||");

            Console.WriteLine("****************************************");
            Console.WriteLine("Create Checking Account 'C'");
            Console.WriteLine("Create Savings Account 'S'");
            Console.WriteLine("Quit Application 'Q'");
            Console.WriteLine("****************************************");
            Console.Write("Enter choice: ");
            string line = Console.ReadLine().ToLower();

            Console.WriteLine();
            Console.WriteLine("****************************************");


            while (line != "q" || line != "Q")
            {
                if (line == "c" || line == "C")
                {

                    Console.Write("Enter a name for the account: ");
                    string AccountName = ReadLine();

                    Console.Write("Enter an account number: ");
                    string AccountNumber = ReadLine();

                    Console.Write("Enter an initial balance for the account:  ");
                    string balance = ReadLine();

                    Console.Write("Enter the fee to be charged each transaction: ");
                    string FeeCharged = ReadLine();

                    CheckingAccount c = new CheckingAccount(AccountName);

                    try
                    {
                        c.setAccountNumber(AccountNumber);
                        c.setBalance(balance);
                        c.setFeeAmount(FeeCharged);
                    }
                    catch (NegativeNumberException e)
                    {
                        Console.WriteLine("Invalid Entry - Negative numbers are not permitted.");
                    }


                }

                else if (line == "s" || line == "S")
                {
                    Console.Write("Enter a name for the account: ");
                    string AccountName = ReadLine();

                    Console.Write("Enter an account number: ");
                    string AccountNumber = ReadLine();

                    Console.Write("Enter an initial balance for the account: ");
                    string balance = ReadLine();

                    Console.Write("Enter the account's interest rate: ");
                    string interestRate = ReadLine();

                    SavingsAccount s = new SavingsAccount(name);

                    try
                    {
                        s.setAccountNumber(number);
                        s.setBalance(balance);
                        s.setInterestRate(interestRate);

                    }
                    catch (NegativeNumberException e)
                    {
                        Console.WriteLine("Invalid Entry - Negative numbers are not permitted. ");
                    }
                }

                else if (line == "q" || line == "Q")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid entry - please enter a correct entry");
                }

            }
        }
    }
}



                       
    

