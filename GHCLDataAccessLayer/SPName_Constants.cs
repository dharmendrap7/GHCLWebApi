using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHCLDataAccessLayer
{
    static class SPName_Constants
    {
        //STORED PROC FOR ZONE
        public static readonly string AddZone = "AddZone";
        public static readonly string GetZones = "GetZones";
        //STORED PROC FOR STATES
        public static readonly string AddState = "AddState";
        public static readonly string GetStates = "GetStates";
        //STORED PROC FOR HEAD QUATER
        public static readonly string AddHeadQuater = "AddHeadQuater";
        public static readonly string GetHeadQuaters = "GetHeadQuaters";
        public static readonly string GetStatesBasedOnZone = "GetStatesBasedOnZone";
        //STORED PROC FOR TOWNS
        public static readonly string GetTowns = "GetTowns";
        public static readonly string AddTown = "AddTown";
        public static readonly string GetHeadQuaterBasedOnState = "GetHeadQuaterBasedOnState";
        public static readonly string GetTownsBasedOnHeadQuater = "GetTownsBasedOnHeadQuater";

        //STORED PROC FOR AREA HEAD
        public static readonly string AddAreaHead = "AddAreaHead";
        public static readonly string GetAreaHeads = "GetAreaHeads";
        //STORED PROC USED TO FIND  THE USER EXISTS WITH THE SAME CONTACT NUMBER OR EMAIL.
        public static readonly string GetExistingCustomer = "GetExistingCustomer";

        //STORED PROC FOR SALES OFFICER
        public static readonly string AddSalesOfficer = "AddSalesOfficer";
        public static readonly string GetSalesOfficer = "GetSalesOfficer";
        public static readonly string GetAreaHeadByHeadQuaterId = "GetAreaHeadByHeadQuaterId";

        //STORED PROC FOR DISTRIBUTOR
        public static readonly string AddDistributor = "AddDistributor";
        public static readonly string GetDistributor = "GetDistributor";
        public static readonly string GetDistributorType = "GetDistributorType";

        //STORED PROC FOR PRODUCT CATEGORY
        public static readonly string GetProductTypes = "GetProductTypes";
        public static readonly string GetProductCategory = "GetProductCategory";
        public static readonly string AddProductCategory = "AddProductCategory";

        //STORED PROC FOR PRODUCT
        public static readonly string GetProducts = "GetProducts";        
        public static readonly string AddProduct = "AddProduct";
        public static readonly string GetProductIdBasedOnSKUCode = "GetProductIdBasedOnSKUCode";

        //STORED PROC FOR MONTHLY TARGET FOR SALES OFFICER
        public static readonly string GetMonths = "GetMonths";
        public static readonly string GetAllSalesOfficerBasedOnAreaHead = "GetAllSalesOfficerBasedOnAreaHead";
        public static readonly string GetMonthlyTarget = "GetMonthlyTarget";
        public static readonly string AddMonthlyTarget = "AddMonthlyTarget";

        //STORED PROC FOR DAILY SALES REPORTING
        public static readonly string GetAllDistributorBasedOnAreaHead = "GetAllDistributorBasedOnAreaHead";
        public static readonly string GetDailyReportingData = "GetDailyReportingData";
        public static readonly string AddDailyRetailing = "AddDailyRetailing";
        public static readonly string GetAllDistributorBasedOnSalesOfficer = "GetAllDistributorBasedOnSalesOfficer";
        public static readonly string GetDailyReportingDataForExport = "GetDailyReportingDataForExport";
        public static readonly string DeleteDailyRetailingData = "DeleteDailyRetailingData";

        //STORED PROC FOR RETAILING REPORT ZONE WISE
        public static readonly string GetRetailingZoneWiseData = "GetRetailingZoneWiseData";
        public static readonly string GetRetailingStateWiseData = "GetRetailingStateWiseData";
        public static readonly string GetRetailingAreaHeadWiseData = "GetRetailingAreaHeadWiseData";
        public static readonly string GetRetailingSOWiseData = "GetRetailingSOWiseData";
        public static readonly string GetRetailingDBWiseData = "GetRetailingDistributorWiseData";
        public static readonly string GetMonthlyCardZoneData = "GetMonthlyReportCardZone";
        public static readonly string GetMonthlyCardAreaHeadData = "GetMonthlyReportCardAreaHead";
        public static readonly string GetMonthlyCardSOData = "GetMonthlyReportCardSO";


        //STORED PROC FOR LOGIN DETAILS.
        public static readonly string GetLoginDetails = "GetLoginDetails";

        //STORED PROC FOR GET USER ID AND PASSWORD
        public static readonly string GetUserAndTheirPassword = "GetUserAndTheirPassword";

        //STORED PROC FOR PRODUCT PRICE CONFIGURATION.
        public static readonly string GetProductPriceConfiguration = "GetProductPriceConfiguration";
        public static readonly string AddProductPriceConfiguration = "AddProductPriceConfiguration";

        //STORED PROC FOR SKU ANALYSIS SCREEN.
        public static readonly string GetSKUProductCategorywiseTotalValue = "GetSKUProductCategorywiseTotalValue";
        public static readonly string GetSKUProductWisePerformance = "GetSKUProductWisePerformance";

        //STORED PROC FOR STOCK ANALYSIS.
        public static readonly string AddStockAnalysisData = "AddStockAnalysisData";
        public static readonly string GetStockAnalysisData = "GetStockAnalysisData";

        //STORED PROC FOR DASH BOARD DATA.
        public static readonly string GetDashboardDetailsData = "GetDashboardDetailsData";
        public static readonly string GetDailyRevenueData = "GetDashboardDetailsDataDailyRevenue";
        public static readonly string GetDailyRevenueDataForAreaHead = "GetDashboardDetailsDataDailyRevenueForAreaHead";
        public static readonly string GetAreaHeadsByZone = "GetAreaHeadsByZone";
        public static readonly string GetSalesOfficersByZone = "GetSalesOfficersByZone";        
        public static readonly string GetDashboardDataForAvgMonthyCalls = "GetDashboardDataForAvgMonthyCalls";
        public static readonly string GetDashboardDataTotalValue = "GetDashboardDataTotalValue";

        //STORED PROC FOR SALES OFFICER SCREENS.
        public static readonly string GetAllDistributorBasedOnConctactNumber = "GetAllDistributorBasedOnConctactNumber";
        public static readonly string GetAttendenceOfTheMonth = "GetAttendenceOfTheMonth";

        public static readonly string GetAreaHeadByConctactNumber = "GetAreaHeadByConctactNumber";

        //STORED PROC FOR DAILY WORK STATUS.
        public static readonly string GetDailyWorkStatusTotalStrength = "GetDailyWorkStatusTotalStrength";
        public static readonly string GetDailyWorkStatusMarketWorking = "GetDailyWorkStatusMarketWorking";

        //STORED PROC FOR ALL ACTIVE DATA.
        public static readonly string GetActiveZones = "GetActiveZones";
        public static readonly string GetActiveZonesWithAllZones = "GetActiveZonesWithAllZones";
        public static readonly string GetActiveStates = "GetActiveStates";
        public static readonly string GetActiveHeadQuaters = "GetActiveHeadQuaters";
        public static readonly string GetActiveTowns = "GetActiveTowns";
        public static readonly string GetActiveAreaHeads = "GetActiveAreaHeads";
        public static readonly string GetActiveSalesOfficer = "GetActiveSalesOfficer";
        public static readonly string GetActiveDistributors = "GetActiveDistributors";
        public static readonly string GetActiveProductCategory = "GetActiveProductCategory";
        public static readonly string GetActiveProducts = "GetActiveProducts";

        //STORED PROC FOR ZONAL HEAD
        public static readonly string GetZonalHeadByConctactNumber = "GetZonalHeadByConctactNumber";
    }
}
