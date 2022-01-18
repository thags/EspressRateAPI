namespace EspressRateAPI.Models
{
    public interface IEspressoRepository
    {
        IEnumerable<EspressoItem> GetAll();
        EspressoItem Get(int id);
        EspressoItem Add(EspressoItem item);
        void Remove(int id);
        bool Update(EspressoItem item);
    }
}
