using NddcWebsiteLibrary.Databases;
using NddcWebsiteLibrary.Model.ServiceGate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Data.ServiceGate
{
    public class SqlServiceGate
    {
        private const string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;
        public SqlServiceGate(ISqlDataAccess db)
        {
            this.db = db;
        }

        public void AddInquiry(MyInquiryModel inquiry)
        {
            inquiry.DateAdded = DateTime.Now;

            db.SaveData("Insert Into Compliants (Type, Name, Email, Phone, Message, DateAdded, Location) values(@Type, @Name, @Email, @Phone, @Message, @DateAdded, @Location)", new { inquiry.Type, inquiry.Name, inquiry.Email, inquiry.Phone, inquiry.Message, inquiry.DateAdded, inquiry.Location }, connectionStringName, false);
        }
        public void AddCompliant(MyCompliantModel compliant)
        {
            compliant.DateAdded = DateTime.Now;

            db.SaveData("Insert Into Inquiry (Type, Name, Email, Phone, Message, DateAdded, Location) values(@Type, @Name, @Email, @Phone, @Message, @DateAdded, @Location)", new { compliant.Type, compliant.Name, compliant.Email, compliant.Phone, compliant.Message, compliant.DateAdded, compliant.Location }, connectionStringName, false);
        }
        
    }
}
