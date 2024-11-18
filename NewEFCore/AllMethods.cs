using Microsoft.EntityFrameworkCore;
using NewEFCore.Context;
using NewEFCore.Exceptions;
using NewEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace NewEFCore
{
    public class AllMethods
    {

        static int NewUserId = -1;
        public void Register(AppDbContext conn, string name, string surname, string Username, string Password)
        {
            var NewUser = new Users
            {
                UserName = name,
                UserSurname = surname,
                Usersname = Username,
                UserPassword = Password
            };

            conn.users.Add(NewUser);
            conn.SaveChanges();
        }
        public void Login(AppDbContext conn, string username, string password)
        {
            var user = conn.users.FirstOrDefault(x => x.Usersname == username && x.UserPassword == password);
            if (user != null)
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Login Successfully");
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                throw new UserNotFoundException("Error");
            }
        }
        public void ViewProducts(AppDbContext conn)
        {
            var product = conn.products.ToList();

            foreach (var item in product)
            {
                WriteLine($"Id:{item.Id},Name:{item.ProductName},Price:{item.ProductPrice}");
            }

            WriteLine("Sebete atmag istediyiniz mehsulun Id si ni daxil edin");
            int id = int.Parse(ReadLine());
            if (id == 0 && id <= 0)
            {
                throw new ProductNotFoundException("Error");
            }
            AddBasket(conn, id);

        }
        public void AddBasket(AppDbContext conn, int productId)
        {
            var product = conn.products.SingleOrDefault(x => x.Id == productId);

            if (product is not null)
            {
                var basket = new Baskets
                {
                    BasketUserId = NewUserId,
                    BasketProductId = product.Id,
                };
                conn.baskets.Add(basket);
                conn.SaveChanges();
                WriteLine("Mehsul sebete elave olundu");
            }
            else
            {
                throw new ProductNotFoundException("Bele mehsul yoxdur!");
            }
        }
        public void ViewBasket(AppDbContext conn)
        {

            var BasketItems = conn.baskets.Where(x => x.BasketUserId == NewUserId).Include(x => x.Product).ToList();
            foreach (var item in BasketItems)
            {
                WriteLine($"Id:{item.Id},Name:{item.Product.ProductName},Price:{item.Product.ProductPrice}");
            }
        }

        public void RemoveBasket(AppDbContext conn, int id)
        {
            var BasketItems = conn.baskets.SingleOrDefault(x => x.Id == id && x.BasketUserId == NewUserId);
            if (BasketItems is not null)
            {
                conn.baskets.Remove(BasketItems);
                conn.SaveChanges();
                WriteLine("Sebetden silindi!");
            }
            else
            {
                throw new ProductNotFoundException("Bele mehsul sebetde yoxdu!");
            }
        }

    }
}
