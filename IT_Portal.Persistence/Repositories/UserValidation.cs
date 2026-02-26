using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.IT_Models;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    internal class UserValidation : IvalidateUser
    {
        private readonly MicroLabsDevContext _context;

        public UserValidation(MicroLabsDevContext context)
        {
            this._context = context;
        }
        public string saveValidUser(int user)
        {
            try
            {

                var IncodedString = EncodeString(user);

                UserVal valInstance = new UserVal
                {
                    EmpNum = user,
                    ValCode = IncodedString,
                    IsActive = true
                };
                _context.UserVals.Add(valInstance);
                _context.SaveChanges();
                return IncodedString;
            }
            catch (Exception ex)
            {
                return _context.Database.GetDbConnection().ConnectionString;
            }
        }

        public string EncodeString(int input)
        {
            DateTime currentDate = DateTime.UtcNow;
            string dateString = currentDate.ToString("yyyy-MM-ddTHH:mm:ss");
            return $"{input}|{dateString}";
        }
        public static bool CheckDateInterval(string encodedString)
        {
            try
            {
                string[] parts = encodedString.Split('|');
                string originalString = parts[0];
                string dateString = parts[1];
                DateTime encodedDate = DateTime.ParseExact(dateString, "yyyy-MM-ddTHH:mm:ss", null, System.Globalization.DateTimeStyles.AssumeUniversal);

                TimeSpan difference = DateTime.UtcNow - encodedDate.ToUniversalTime();
                double minutesDifference = Math.Abs(difference.TotalMinutes);

                return minutesDifference <= 15;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public user checkValidUser(int user)
        {
            try
            {
                var dbData = _context.UserVals.Where(m => m.IsActive == true && m.EmpNum == user).OrderByDescending(m => m.Id).FirstOrDefault();
                var IncodedString = EncodeString(user);
                if (dbData != null && CheckDateInterval(dbData.ValCode))
                {
                    var empData = _context.Employees.Where(m => m.Active && m.EmployeeNo == user
                        .ToString()).FirstOrDefault();
                    var supportTeamData = _context.SupportTeams.Where(m => m.EmpId == user)
                        .FirstOrDefault();
                    var supportTeamAssignData = new List<SupportTeamAssgn>();
                    string Role = "User";
                    if (supportTeamData != null)
                    {
                        supportTeamAssignData = _context.SupportTeamAssgns.Where(m => m.SupportTeamId == supportTeamData.SupportTeamId)
                            .ToList();
                        Role = supportTeamData.Role;
                    }
                    return new user
                    {
                        isValid = true,
                        validationMessage = "User Validate Successfully.",
                        supportTeamData = supportTeamData,
                        empData = empData,
                        Role = Role,
                        supportTeamAssignList = supportTeamAssignData
                    };
                }
                else
                {
                    if (dbData != null)
                    {
                        UserVal valInstance = new UserVal
                        {
                            EmpNum = user,
                            ValCode = IncodedString,
                            IsActive = false
                        };
                        _context.Update(valInstance);
                        _context.SaveChanges();
                    }
                    throw new Exception("unautherised user.");
                }
            }
            catch (Exception ex)
            {
                return new user
                {
                    isValid = false,
                    validationMessage = ex.Message
                };
            }
        }

        public string onLogOut(int user)
        {
            try
            {
                var IncodedString = EncodeString(user);
                var dbData = _context.UserVals.Where(m => m.IsActive == true && m.EmpNum == user).OrderBy(m => m.Id).LastOrDefault();

                if (dbData == null)
                {
                    return "";
                }
                dbData.IsActive = false;

                _context.UserVals.Update(dbData);
                _context.SaveChanges();

                return "Log out Successfully.";

            }
            catch (Exception ex)
            {
                return "Exception" + ex.Message;
            }
        }
    }
}
