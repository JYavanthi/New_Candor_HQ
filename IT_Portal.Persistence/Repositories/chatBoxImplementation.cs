using AutoMapper;
using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class chatBoxImplementation : IchatBox
    {
        private readonly MicroLabsDevContext _context;
        private readonly IMapper _mapper;

        public chatBoxImplementation(MicroLabsDevContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        async Task<IssueCommentsBox> IchatBox.getChat(int issueId)
        {
            try
            {
                var result = await _context.IssueCommentsBoxes
                    .Where(m => m.IssueId == issueId)
                    .FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }


        bool IchatBox.postChat(IssueCommentsBox issueChat)
        {
            try
            {
                var result = _context.IssueCommentsBoxes
                    .Where(m => m.IssueId == issueChat.IssueId)
                    .FirstOrDefault();
                if (result == null)
                {
                    var chatInstance = new IssueCommentsBox
                    {
                        IssueId = issueChat.IssueId,
                        TextChat = issueChat.TextChat
                    };

                    _context.IssueCommentsBoxes.Add(chatInstance);

                    _context.SaveChanges();
                }
                else
                {
                    result.TextChat = issueChat.TextChat;

                }

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                return false;
            }
        }
    }
}
