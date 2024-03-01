using Microsoft.Data.SqlClient;
namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to Pradnya's ATM!");

            Console.WriteLine("Menu");
            Console.WriteLine("1 : Create New Savings Account");
            Console.WriteLine("2 : Deposit amount into existing savings account.");
            Console.WriteLine("3 : Withdraw amount from existing savings account.");
            Console.WriteLine("Please select 1 or 2 or 3");
            string accountno;

            string choice = Console.ReadLine();

            switch (choice)
            {

                case "1":
                    {
                        string conString = @"Data Source=DESKTOP-VDMQ3OL\SQLEXPRESS;Database = ATM;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;MultiSubnetFailover=False";
                        Console.WriteLine("Please insert your Account Details to create a Savings Account");
                        Console.WriteLine("FirstName");
                        string FirstName = Console.ReadLine();
                        Console.WriteLine("LastName");
                        string LastName = Console.ReadLine();
                        Console.WriteLine("Opening Balance");
                        string startingbalance = Console.ReadLine();
                        decimal StartingBalance = decimal.Parse(startingbalance);
                        string sqlCommand = "Insert into BankAccount (FirstName, LastName, StartingBalance) Values (@FirstName, @LastName, @StartingBalance);";

                        Console.WriteLine("Connection to SQL Database");
                        using (SqlConnection conn = new SqlConnection(conString))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(sqlCommand, conn))
                            {
                                cmd.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar).Value = FirstName;
                                cmd.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar).Value = LastName;
                                cmd.Parameters.Add("@StartingBalance", System.Data.SqlDbType.Decimal).Value = StartingBalance;

                                // Execute the query
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    Console.WriteLine("Data inserted successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to insert data.");
                                }
                            }
                            break;
                        }
                    }
                case "2":
                    {
                        Console.WriteLine("Enter your Account Number");
                        accountno = Console.ReadLine();
                        int AccountNumber = int.Parse(accountno);
                        Console.WriteLine("Enter amount to deposit or press enter to skip");
                        string depositamt = Console.ReadLine();
                        decimal DepositAmt = decimal.Parse(depositamt);
                        //Console.WriteLine("Enter amount to withdraw or press enter to skip");
                        //string withdrawalamt = Console.ReadLine();
                        //decimal WithdrawalAmt = decimal.Parse(withdrawalamt);
                        string conString1 = @"Data Source=DESKTOP-VDMQ3OL\SQLEXPRESS;Database = ATM;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;MultiSubnetFailover=False";
                        string sqlCommand1 = @"UPDATE BankAccount SET StartingBalance = StartingBalance + @DepositAmt WHERE AccountNumber = @AccountNumber";

                        Console.WriteLine("Connection to SQL Database");
                        using (SqlConnection conn = new SqlConnection(conString1))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(sqlCommand1, conn))
                            {
                                cmd.Parameters.Add("@DepositAmt", System.Data.SqlDbType.Decimal).Value = DepositAmt;
                                cmd.Parameters.Add("@AccountNumber", System.Data.SqlDbType.Int).Value = AccountNumber;

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    Console.WriteLine("Deposit successful.");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to deposit amount.");
                                }


                            }
                        }
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Enter your Account Number");
                        accountno = Console.ReadLine();
                        int AccountNumber = int.Parse(accountno);
                        Console.WriteLine("Enter amount to WITHDRAW or press enter to skip");

                        string withdrawalamt = Console.ReadLine();
                        decimal WithdrawalAmt = decimal.Parse(withdrawalamt);
                        string conString2 = @"Data Source=DESKTOP-VDMQ3OL\SQLEXPRESS;Database = ATM;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;MultiSubnetFailover=False";
                        string sqlCommand2 = @"UPDATE BankAccount SET StartingBalance = StartingBalance - @WithdrawalAmt WHERE AccountNumber = @AccountNumber";

                        Console.WriteLine("Connection to SQL Database");
                        using (SqlConnection conn = new SqlConnection(conString2))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(sqlCommand2, conn))
                            {
                                cmd.Parameters.Add("@WithdrawalAmt", System.Data.SqlDbType.Decimal).Value = WithdrawalAmt;
                                cmd.Parameters.Add("@AccountNumber", System.Data.SqlDbType.Int).Value = AccountNumber;

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    Console.WriteLine("Withdrawal successful.");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to Withdraw amount.");
                                }


                            }
                        }
                        break;
                    }
            }
        }
    }
}
