using DAL.Entity;

namespace DAL.IRepository;

public interface ISystemSetingRepo
{
    Task<bool> ChangeMinWithDrawalLimit(SystemSettings systemSetings);
    Task<SystemSettings?> GetLimitAmount();
}
