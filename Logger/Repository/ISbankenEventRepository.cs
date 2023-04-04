using Logger.Models;

namespace Logger.Repository
{
    public interface ISbankenEventRepository
    {
        void Delete(string eventId);
        SbankenEvent[] GetAll();
        SbankenEvent GetById(string eventId);
        void Save(SbankenEvent sbankenEvent);
    }
}