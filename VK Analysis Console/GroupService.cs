using System;
using System.Collections.Generic;
using System.Text;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VK_Analysis_ConsoleAnalysisAnalysis
{
    class GroupService
    {
        private readonly VkApi vkApi;
        public GroupService(VkApi _vkApi)
        {
            vkApi = _vkApi;
        }

        public void GetGroupMembersInfo(string groupId)
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
                    Console.WriteLine(member.FirstName + " " + member.LastName + " " + member.City?.Title);
                    allUsers.Add(member);
                }
                i += 1000;
            }

            Console.WriteLine("Число подписчиков в группе" + allUsers.Count);
        }
    }
}
