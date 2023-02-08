using System;
using System.Collections.Generic;
using System.Linq;
using DB_CourseWork.Core.Data;

namespace DB_CourseWork.Core
{
    public class PhoneStatusService : IPhoneStatusService
    {
        private readonly PbxContext _context;

        private readonly List<PhoneStatus> _phoneStatuses;
        private readonly PhoneStatus _connectedStatus;
        private readonly PhoneStatus _disconnectedStatus;
        private readonly PhoneStatus _debtStatus;

        public PhoneStatusService(PbxContext context)
        {
            _context = context;

            // Commented on this in the interface source file
            _phoneStatuses = _context.PhoneStatuses.OrderBy(s => s.Id).ToList();
            _connectedStatus = _phoneStatuses[0];
            _disconnectedStatus = _phoneStatuses[1];
            _debtStatus = _phoneStatuses[2];
        }

        public IList<PhoneStatus> GetStatuses()
        {
            return _phoneStatuses;
        }

        public bool IsPhoneConnected(SubscriberPhone phone)
        {
            return (phone.CurrentStatus == _connectedStatus);
        }

        public bool IsPhoneDebtor(SubscriberPhone phone)
        {
            return (phone.CurrentStatus == _debtStatus);
        }

        public void SetConnectedStatus(SubscriberPhone phone, string comment = "")
        {
            SetNewPhoneStatus(phone, _connectedStatus, comment);
        }

        public void SetDisconnectedStatus(SubscriberPhone phone, string comment = "")
        {
            SetNewPhoneStatus(phone, _disconnectedStatus, comment);
        }

        public void SetDebtStatus(SubscriberPhone phone, string comment = "")
        {
            SetNewPhoneStatus(phone, _debtStatus, comment);
        }

        private void SetNewPhoneStatus(SubscriberPhone phone, PhoneStatus newStatus, string comment)
        {
            var newStatusEntry = new StatusHistoryEntry(phone, newStatus, DateTime.Now, comment);
            phone.StatusHistory.Add(newStatusEntry);
        }
    }
}
