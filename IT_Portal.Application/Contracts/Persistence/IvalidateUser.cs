using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IvalidateUser
    {
        public string saveValidUser(int user);
        public user checkValidUser(int user);
        public string onLogOut(int user);
    }
}
