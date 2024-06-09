using NddcWebsiteLibrary.Model.IReport;

namespace NddcWebsiteLibrary.Data.IReport
{
    public interface IReportData
    {
        void AddIReport(MyIReportModel ireport);
        List<MyIReportModel> AllIreports();
        List<MyIReportModel> IreportsImages(int id);
    }
}