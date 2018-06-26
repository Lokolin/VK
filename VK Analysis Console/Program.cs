using System;
using System.Collections.Generic;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Model;
using VK_Analysis_ConsoleAnalysis;

namespace VK_Analysis_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountService accountService = new AccountService();

            accountService.Authorize();
            Console.WriteLine("Введите ID человека: ");
            long userId = Int64.Parse(Console.ReadLine());
            //accountService.GetAllFriends(userId);
            Console.WriteLine("Введите название города: ");
            string city = Console.ReadLine();
            List<User> users = accountService.GetFriendsFromCity(userId,city);
            accountService.PrintUsers(users);

            Console.ReadLine();
        }
    }
}
