using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
// using System.Linq;
using Dapper;
using GroupMe.Interfaces;
using GroupMe.Models;

namespace GroupMe.Repositories
{
    public class GroupMembersRepository
    {
        private readonly IDbConnection _db;

        public GroupMembersRepository(IDbConnection db)
        {
            _db = db;
        }

        public GroupMember Create(GroupMember gm)
        {
            string sql = @"
            INSERT INTO 
                group_members(accountId, groupId, role)
            VALUES(@AccountId, @GroupId, @Role);
            SELECT LAST_INSERT_ID();
            ";
            gm.Id = _db.ExecuteScalar<int>(sql, gm);
            return gm;
        }

        public void Create(string accountId, int groupId, string role)
        {
            string sql = @"
            INSERT INTO 
                group_members(accountId, groupId, role)
            VALUES(@accountId, @groupId, @role);
            ";
            _db.ExecuteScalar<int>(sql, new { accountId, groupId, role });
        }

        internal List<GroupMember> GetMembersByGroupId(int id)
        {
            // REVIEW joining data and mapping to two classes
            string sql = @"
            SELECT *
            FROM group_members gm
            JOIN accounts a ON a.id = gm.accountId
            WHERE groupId = @id; 
            ";
            //               vv g         vv p     vv return type of the entire Query
            return _db.Query<GroupMember, Profile, GroupMember>(sql, (g, p) =>
            {
                g.Profile = p;
                return g;
            }, new { id }).ToList();
        }
    }
}