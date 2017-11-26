using IAWeb.Infra.Contexts;

namespace IAWeb.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly IAWebDataContext _context;

        public Uow(IAWebDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Do nothing :)
        }
    }
}
