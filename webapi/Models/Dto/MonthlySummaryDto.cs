namespace webapi.Models.Dto
{
    public class MonthlySummaryDto
    {
        public string ReportDate
        {
            get; set;
        }
        public string DataYM
        {
            get; set;
        }
        public string CompanyCode
        {
            get; set;
        }
        public string CompanyName
        {
            get; set;
        }
        public string Industry
        {
            get; set;
        }
        public long NowRevenue
        {
            get; set;
        }
        public long LastMonthRevenue
        {
            get; set;
        }
        public long LastYearSameMonthRevenue
        {
            get; set;
        }
        public double? MonthlyPercent
        {
            get; set;
        }
        public double? YearlyPercent
        {
            get; set;
        }
        public long CumulativeNowRevenue
        {
            get; set;
        }
        public long CumulativeLastYearRevenue
        {
            get; set;
        }
        public double? CumulativeChangePercent
        {
            get; set;
        }
        public string Comment
        {
            get; set;
        }
    }
}
