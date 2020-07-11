using Leave_Management_netCore.Contracts;
using Leave_Management_netCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_netCore.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {

        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveHistory entity)
        {
            _db.LeaveHistories.Add(entity);
            //Save
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.LeaveHistories.Remove(entity);
            //Save
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            return _db.LeaveHistories.ToList();
        }

        public LeaveHistory FindById(int id)
        {
            var leavetype = _db.LeaveHistories.Find(id);
            return leavetype;
        }

        public bool IsExists(int id)
        {
            var exists = _db.LeaveHistories.Any(x => x.Id == id);
            return exists;
        }

        public bool Save()
        {
            //return _db.SaveChanges() > 0;
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            _db.LeaveHistories.Update(entity);
            //Save
            return Save();
        }
    }
}
