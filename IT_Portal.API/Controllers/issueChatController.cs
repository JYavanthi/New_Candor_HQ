using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Persistence.IT_Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class issueChatController : ControllerBase
    {
        private IchatBox _chatBoxImplementation;

        public issueChatController(IchatBox chatBoxImplementation)
        {
            this._chatBoxImplementation = chatBoxImplementation;
        }


        [HttpGet("getComments")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _chatBoxImplementation.getChat(id);
            return Ok(data);
        }

        // POST api/<issueChatController>
        [HttpPost("sendCommentById")]
        public IActionResult postCHat([FromBody] IssueCommentsBox issuChat)
        {
            var data = _chatBoxImplementation.postChat(issuChat);
            return Ok(data);
        }
    }
}
