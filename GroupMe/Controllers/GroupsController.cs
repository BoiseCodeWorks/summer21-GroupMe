using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using GroupMe.Models;
using GroupMe.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroupMe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly GroupsService _gs;

        public GroupsController(GroupsService gs)
        {
            _gs = gs;
        }

        [HttpGet]
        public ActionResult<List<Group>> Get()
        {
            try
            {
                List<Group> groups = _gs.GetGroups();
                return Ok(groups);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Group> GetOne(int id)
        {
            try
            {
                Group group = _gs.GetGroup(id);
                return Ok(group);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("{id}/members")]
        public ActionResult<List<GroupMember>> GetMembers(int id)
        {
            try
            {
                List<GroupMember> members = _gs.GetMembers(id);
                return Ok(members);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Group>> Create([FromBody] Group groupData)
        {
            try
            {
                // what does this do?????
                // gets the bearer token from the request headers
                // asks auth0 if the bearer token is valid
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                // NEVER EVER TRUST THE CLIENT
                groupData.CreatorId = userInfo.Id;

                var g = _gs.CreateGroup(groupData);
                return Ok(g);

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}