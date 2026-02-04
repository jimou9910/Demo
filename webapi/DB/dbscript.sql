CREATE TABLE [dbo].[MonthlySummary](
	[ReportDate] [nvarchar](7) NOT NULL,
	[DataYM] [nvarchar](6) NOT NULL,
	[CompanyCode] [nvarchar](10) NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
	[Industry] [nvarchar](50) NOT NULL,
	[NowRevenue] [bigint] NOT NULL,
	[LastMonthRevenue] [bigint] NOT NULL,
	[LastYearSameMonthRevenue] [bigint] NOT NULL,
	[MonthlyPercent] [float] NULL,
	[YearlyPercent] [float] NULL,
	[CumulativeNowRevenue] [bigint] NOT NULL,
	[CumulativeLastYearRevenue] [bigint] NOT NULL,
	[CumulativeChangePercent] [float] NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_MonthlySummary] PRIMARY KEY CLUSTERED 
(
	[DataYM] ASC,
	[CompanyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE PROCEDURE [dbo].[AddMonthlySummary]
    @ReportDate NVARCHAR(7),
    @DataYM NVARCHAR(6),
    @CompanyCode NVARCHAR(10),
    @CompanyName NVARCHAR(50),
    @Industry NVARCHAR(50),
    @NowRevenue BIGINT,
    @LastMonthRevenue BIGINT,
    @LastYearSameMonthRevenue BIGINT,
    @MonthlyPercent FLOAT,
    @YearlyPercent FLOAT,
    @CumulativeNowRevenue BIGINT,
    @CumulativeLastYearRevenue BIGINT,
    @CumulativeChangePercent FLOAT,
    @Comment NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO MonthlySummary (
        ReportDate, DataYM, CompanyCode, CompanyName, Industry,
        NowRevenue, LastMonthRevenue, LastYearSameMonthRevenue,
        MonthlyPercent, YearlyPercent,
        CumulativeNowRevenue, CumulativeLastYearRevenue,
        CumulativeChangePercent, Comment
    )
    VALUES (
        @ReportDate, @DataYM, @CompanyCode, @CompanyName, @Industry,
        @NowRevenue, @LastMonthRevenue, @LastYearSameMonthRevenue,
        @MonthlyPercent, @YearlyPercent,
        @CumulativeNowRevenue, @CumulativeLastYearRevenue,
        @CumulativeChangePercent, @Comment
    );
END;
GO

CREATE PROCEDURE GetMonthlySummary
    @CompanyCode NVARCHAR(10) = NULL,
    @DataYM NVARCHAR(6) = NULL
AS
BEGIN
    SELECT 
        ReportDate, DataYM, CompanyCode, CompanyName, Industry,
        NowRevenue, LastMonthRevenue, LastYearSameMonthRevenue,
        MonthlyPercent, YearlyPercent,
        CumulativeNowRevenue, CumulativeLastYearRevenue,
        CumulativeChangePercent, Comment
    FROM 
        MonthlySummary
    WHERE
        (@CompanyCode IS NULL OR CompanyCode = @CompanyCode) AND
        (@DataYM IS NULL OR DataYM = @DataYM);
END;
