using System;
using System.Collections.Generic;
using System.Text;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using System.Linq;

namespace VK_Analysis_ConsoleAnalysisAnalysis
{
    class GroupService
    {
        private readonly VkApi vkApi;
        public GroupService(VkApi _vkApi)
        {
            vkApi = _vkApi;
        }

        /// <summary>
        /// Метод получающий список всех подписчиков по заданому Id группы 
        /// </summary>
        /// <param name="userId"> Id группы </param>
        ///  <returns> Возвращает список всех подписчиков по заданому Id группы  </returns>
        public List<User> GetGroupMembersInfo(string groupId)
        {
            List<User> allUsers = new List<User>();
            int i = 0;
            var capacity = vkApi.Groups.GetMembers(new GroupsGetMembersParams
            {
                GroupId = groupId,
            });
            int count = Convert.ToInt32(capacity.TotalCount) ;
            while (i<count)
            {
                var members = vkApi.Groups.GetMembers(new GroupsGetMembersParams
                {
                    GroupId = groupId,
                    Offset = i,
                    Fields = UsersFields.City 
                });
                foreach (var member in members)
                {
                    allUsers.Add(member);
                }
                i += 1000;
            }

            return allUsers;
        }

        /// <summary>
        /// Метод получающий список городов проживания подписчиков с их количеством 
        /// </summary>
        /// <param name="subscribers"> список подписчиков </param>
        public void SubscribersInfo(List<User> subscribers)
        {
            var SubscribersInCity = subscribers.GroupBy(p => p.City?.Title)
                .Select(g => new { Name = g.Key, Count = g.Count() });

            foreach (var SubscriberInCity in SubscribersInCity)
                Console.WriteLine("{0} : {1}", SubscriberInCity?.Name, SubscriberInCity.Count);
        }
    }
}
