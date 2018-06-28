using System;
using System.Collections.Generic;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Model;
using VK_Analysis_ConsoleAnalysis;
using VK_Analysis_ConsoleAnalysisAnalysis;

namespace VK_Analysis_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountService accountService = new AccountService(); //создание экземпляра AccountService

            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();
            VkApi vkApi= accountService.Authorize(login,password); //авторизация пользователя

            

            //Console.WriteLine("Введите ID человека: ");
            //long userId = Int64.Parse(Console.ReadLine());
            //Console.WriteLine("Введите название города: ");
            //string city = Console.ReadLine();


            //List<User> users = accountService.GetFriendsFromCity(userId,city); //получние всех друзей по заданному Id и городу
            //accountService.PrintUsers(users); //вывод списка друзей по заданному Id и городу


            GroupService groupService = new GroupService(vkApi); //создание экземпляра GroupService
            Console.WriteLine("Введите Id группы: ");
            string groupId = Console.ReadLine();

            List<User> Subscribers = groupService.GetGroupMembersInfo(groupId); //получние всех подписчиков по заданному Id группы
            groupService.SubscribersInfo(Subscribers);


            Console.ReadLine();
        }
    }
}
