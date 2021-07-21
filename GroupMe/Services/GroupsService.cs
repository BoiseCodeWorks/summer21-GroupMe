using System;
using System.Collections.Generic;
using GroupMe.Models;
using GroupMe.Repositories;

namespace GroupMe.Services
{
    public class GroupsService
    {
        private readonly GroupsRepository _groupRepo;
        private readonly GroupMembersRepository _groupMembersRepo;

        public GroupsService(GroupsRepository groupRepo, GroupMembersRepository groupMembersRepo)
        {
            _groupRepo = groupRepo;
            _groupMembersRepo = groupMembersRepo;
        }

        internal List<Group> GetGroups()
        {
            return _groupRepo.GetAll();
        }

        internal Group CreateGroup(Group groupData)
        {
            var group = _groupRepo.Create(groupData);
            // lets add a member
            _groupMembersRepo.Create(group.CreatorId, group.Id, "Owner");
            return group;
        }

        internal Group GetGroup(int id)
        {
            return _groupRepo.GetById(id);
        }

        internal List<GroupMember> GetMembers(int id)
        {

            var members = _groupMembersRepo.GetMembersByGroupId(id);
            return members;
        }

        internal Group EditGroup(Group groupData, string userId)
        {
            var group = _groupRepo.GetById(groupData.Id);
            if (group == null)
            {
                throw new Exception("nope bad id");
            }
            // is this right??????
            if (group.CreatorId != userId)
            {
                throw new Exception("nope wrong user NOT YOURS");
            }
            group.Name = groupData.Name ?? group.Name;
            group.Img = groupData.Img ?? group.Img;
            group.Description = groupData.Description ?? group.Description;

            return _groupRepo.Update(group);
        }
    }
}