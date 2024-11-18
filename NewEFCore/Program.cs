using NewEFCore.Context;
using NewEFCore.Exceptions;
using NewEFCore.Models;
using System;
using static System.Console;

namespace NewEFCore
{
    internal class Program
    {
        static int NewUserId = -1;
        static void Main(string[] args)
        {
            {
                bool one = true, two = true, three = true, four = true;
                AllMethods ac = new AllMethods();

                using (AppDbContext conn = new())
                {
                    do
                    {
                        ForegroundColor = ConsoleColor.DarkCyan;
                        WriteLine("1.Login\n2.Register");
                        string NewAccount = ReadLine();
                        switch (NewAccount)
                        {
                            case "1":
                                do
                                {
                                    try
                                    {

                                        ForegroundColor = ConsoleColor.Magenta;
                                        WriteLine("Username daxil et: ");
                                        string username = ReadLine();

                                        ForegroundColor = ConsoleColor.Magenta;
                                        WriteLine("Password daxil et: ");
                                        string password = ReadLine();

                                        ac.Login(conn, username, password);
                                    }
                                    catch (UserNotFoundException ex)
                                    {
                                        ForegroundColor = ConsoleColor.Red;
                                        WriteLine("Error:" + ex.Message);
                                    }
                                }
                                while (!one);
                                break;

                            case "2":

                                do
                                {
                                    ForegroundColor = ConsoleColor.Magenta;
                                    WriteLine("Name daxil et: ");
                                    string name = ReadLine();

                                    ForegroundColor = ConsoleColor.Magenta;
                                    WriteLine("Surname daxil et: ");
                                    string surname = ReadLine();

                                    ForegroundColor = ConsoleColor.Magenta;
                                    WriteLine("Username daxil et: ");
                                    string username = ReadLine();

                                    ForegroundColor = ConsoleColor.Magenta;
                                    WriteLine("Password daxil et: ");
                                    string password = ReadLine();

                                    ac.Register(conn, name, surname, username, password);
                                }

                                while (!two);
                                break;
                            default:
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine("Number not found 404");
                                break;
                        }
                    }
                    while (!three);

                    do
                    {
                        int id;
                        ForegroundColor = ConsoleColor.DarkCyan;
                        WriteLine("1.Mehsullara bax\n2.Sebete bax\n3.Sebetden mehsulu sil\n4.Log out");
                        string account = ReadLine();
                        switch (account)
                        {
                            case "1":
                                ac.ViewProducts(conn);
                                break;
                            case "2":
                                ac.ViewBasket(conn);
                                break;
                            case "3":
                                try
                                {
                                    WriteLine("Silmek istediyiniz mehsulun Id sini daxil edin");
                                    string word = ReadLine();
                                    if (int.TryParse(word, out id))
                                    {
                                        ForegroundColor = ConsoleColor.Green;
                                        WriteLine("Silindi!");
                                        break;
                                    }
                                    else
                                    {
                                        ForegroundColor = ConsoleColor.Red;
                                        WriteLine("String yox eded daxil edin!");
                                    }
                                    ac.RemoveBasket(conn, id);
                                }
                                catch (ProductNotFoundException ex)
                                {
                                    ForegroundColor = ConsoleColor.Red;
                                    WriteLine("Error: " + ex.Message);
                                }
                                break;
                            default:
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine("Number not found 404");
                                break;
                        }
                    }
                    while (!four);


                }
            }
        }
    }
}

//        }
//        //static void Register(AppDbContext conn, string name, string surname, string Username, string Password)
//        //{
//        //    var NewUser = new Users
//        //    {
//        //        UserName = name,
//        //        UserSurname = surname,
//        //        Username = Username,
//        //        UserPassword = Password
//        //    };

//        //    conn.users.Add(NewUser);
//        //    conn.SaveChanges();
//        //}
//        //static void Login(AppDbContext conn, string username, string password)
//        //{
//        //    var user = conn.users.SingleOrDefault(x => x.Username == username && x.UserPassword == password);
//        //    if (user != null)
//        //    {
//        //        WriteLine("Login Successfully");
//        //    }
//        //    else
//        //    {
//        //        WriteLine("Error");
//        //    }
//        //}
//        //static void ViewProducts(AppDbContext conn)
//        //{
//        //    var product = conn.products.ToList();

//        //    foreach (var item in product)
//        //    {
//        //        WriteLine($"Id:{item.ProductId},Name:{item.ProductName},Price:{item.ProductPrice}");
//        //    }

//        //    WriteLine("Sebete atmag istediyiniz mehsulun Id si ni daxil edin");
//        //    int id = int.Parse(ReadLine());
//        //    if (id == 0 && id <= 0)
//        //    {
//        //        WriteLine("Duzgun eded daxil etmediz!");
//        //    }
//        //    AddBasket(conn, id);

//        //}
//        //static void AddBasket(AppDbContext conn, int id)
//        //{
//        //    var product = conn.products.SingleOrDefault(x => x.ProductId == id);

//        //    if (product is not null)
//        //    {
//        //        var basket = new Baskets
//        //        {
//        //            BasketUserId = NewUserId,
//        //            BasketProductId = id
//        //        };
//        //        conn.baskets.Add(basket);
//        //        conn.SaveChanges();
//        //        WriteLine("Mehsul sebete elave olundu");
//        //    }
//        //    else
//        //    {
//        //        WriteLine();//exception
//        //    }
//        //}
//        //static void ViewBasket(AppDbContext conn)
//        //{

//        //    var BasketItems = conn.baskets.Where(x => x.BasketUserId == NewUserId).Include(x => x.Product).ToList();
//        //    foreach (var item in BasketItems)
//        //    {
//        //        WriteLine($"Id:{item.BasketId},Name:{item.Product.ProductName},Price:{item.Product.ProductPrice}");
//        //    }
//        //}
//    }
//}
