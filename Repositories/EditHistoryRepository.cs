using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class EditHistoryRepository : GenericRepository<EditHistory>, IEditHistoryRepository
    {
        public EditHistoryRepository(ApplicationContext context) : base(context)
        {
      
        }

        public async Task AddEditAsync(int Id)
        {
            EditHistory hist = new EditHistory();
            hist.ContactId = Id;
            hist.ModifiedDate = DateTime.Now;
            await _context.EditHistories.AddAsync(hist);
        }
        public IEnumerable<EditHistory> GetHistory(int Id)
        {
            return _context.EditHistories.Where(d => d.ContactId == Id).ToList();
        }
    }
}
