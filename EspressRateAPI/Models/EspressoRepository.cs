namespace EspressRateAPI.Models
{
    public class EspressoRepository : IEspressoRepository
    {
        private readonly EspressoContext _context;

        public EspressoRepository(EspressoContext context)
        {
            _context = context;
        }

        public IEnumerable<EspressoItem> GetAll()
        {
            return _context.EspressoItems.ToList();
        }

        public EspressoItem Get(int id)
        {
            return _context.EspressoItems.Find(id);
        }

        public EspressoItem Add(EspressoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _context.EspressoItems.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Remove(int id)
        {
            var toRemove = _context.EspressoItems.Find(id);
            if (toRemove != null)
            {
                _context.EspressoItems.Remove(toRemove);
                _context.SaveChanges();
            }
            
        }

        public bool Update(EspressoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _context.EspressoItems.Update(item);
            _context.SaveChanges();
            return true;
        }
    }
}
