namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IEmployeeMasters
    {
        Task<IEnumerable<object>> Getemplaoyedata();
    }
}
