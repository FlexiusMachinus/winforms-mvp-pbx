using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DB_CourseWork.Core.Data;

namespace DB_CourseWork.Core
{
    public class SubscriberPhoneService : ISubscriberPhoneService
    {
        private readonly PbxContext _context;

        public SubscriberPhoneService(PbxContext context)
        {
            _context = context;
            _context.SubscriberPhones.Load();
        }

        public IList<SubscriberPhone> GetAllSubscriberPhones()
        {
            return _context.SubscriberPhones.Local.ToBindingList();
        }

        public SubscriberPhone FindSubscriberPhoneByNumber(string phoneNumber)
        {
            return _context.SubscriberPhones.FirstOrDefault(p => p.Number == phoneNumber);
        }
    }
}
