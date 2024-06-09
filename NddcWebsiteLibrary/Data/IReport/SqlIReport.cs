using NddcWebsiteLibrary.Databases;
using NddcWebsiteLibrary.Model.Home;
using NddcWebsiteLibrary.Model.IReport;
using NddcWebsiteLibrary.Model.ServiceGate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Data.IReport
{
    public class SqlIReport : IReportData
    {
        private const string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;
        public SqlIReport(ISqlDataAccess db)
        {
            this.db = db;
        }

        public void AddIReport(MyIReportModel ireport)
        {
            //ireport.DateAdded = DateTime.Now;

            db.SaveData("Insert Into IReports (Type, Title, Name, Email, Phone, State, Location, DateAdded, Comment, ImageUrl1, ImageUrl2, ImageUrl3, ImageUrl4) values(@Type, @Title, @Name, @Email, @Phone, @State, @Location, @DateAdded, @Comment, @ImageUrl1, @ImageUrl2, @ImageUrl3, @ImageUrl4)", new { ireport.Type, ireport.Title, ireport.Name, ireport.Email, ireport.Phone, ireport.State, ireport.Location, ireport.DateAdded, ireport.Comment, ireport.ImageUrl1, ireport.ImageUrl2, ireport.ImageUrl3, ireport.ImageUrl4 }, connectionStringName, false);
        }
        public List<MyIReportModel> AllIreports()
        {
            return db.LoadData<MyIReportModel, dynamic>("select ROW_NUMBER() OVER (ORDER BY Id DESC) As SrNo, Id, Type, Name, Location, State, DateAdded, ImageUrl1 from IReports Order By Id DESC", new { }, connectionStringName, false).ToList();
        }
        public List<MyIReportModel> IreportsImages(int id)
        {
            return db.LoadData<MyIReportModel, dynamic>("Select ImageUrl1, ImageUrl2, ImageUrl3, ImageUrl4 from IReports Where Id = @Id", new { Id = id }, connectionStringName, false).ToList();
        }

    }
}
