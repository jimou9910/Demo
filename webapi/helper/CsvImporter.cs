using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;
using webapi.Models;
using webapi.Models.Dto;

namespace webapi.helper
{
    public class CsvImporter
    {
        private readonly DEMOContext _context;

        public CsvImporter(DEMOContext context)
        {
            _context = context;
        }

        public async Task ImportCsvDataAsync(string csvFilePath)
        {
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE [MonthlySummary]");
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<MonthlySummaryDto>();
                foreach (var record in records)
                {
                    await _context.Procedures.AddMonthlySummaryAsync(
                        record.ReportDate,
                        record.DataYM,
                        record.CompanyCode,
                        record.CompanyName,
                        record.Industry,
                        record.NowRevenue,
                        record.LastMonthRevenue,
                        record.LastYearSameMonthRevenue,
                        record.MonthlyPercent,
                        record.YearlyPercent,
                        record.CumulativeNowRevenue,
                        record.CumulativeLastYearRevenue,
                        record.CumulativeChangePercent,
                        record.Comment
                    );
                }
            }
        }
    }
}
