using System;
using System.Data;
using System.Data.SqlClient;
using GHCLEntityLayer;
using System.Collections.Generic;
using System.Linq;

namespace GHCLDataAccessLayer
{
    public class CommonDAL
    {
        #region Variable Declaration
        SqlConnection connection = null;
        #endregion

        #region CommonMethods

        /// <summary>
        /// To get states based on zone.
        /// </summary>
        /// <param name="headQuater"></param>
        /// <returns></returns>
        public List<States> GetStatesBasedOnZone(HeadQuater headQuater)
        {
            DataSet dsHeadQuater = null;
            List<States> states = new List<States>();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ZoneId",headQuater.ZoneId)
                };
                dsHeadQuater = new DataSet();
                dsHeadQuater = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetStatesBasedOnZone, spParams);
                if (dsHeadQuater != null && dsHeadQuater.Tables.Count > 0 && dsHeadQuater.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsHeadQuater.Tables[0].Rows.Count; i++)
                    {
                        States objStates = new States();
                        if (dsHeadQuater.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objStates.Id = Convert.ToInt32(dsHeadQuater.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objStates.StateName = dsHeadQuater.Tables[0].Rows[i]["StateName"].ToString();
                        states.Add(objStates);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return states;
        }

        /// <summary>
        /// To get list of head quaters based on state.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<HeadQuater> GetHeadQuaterBasedOnState(Town state)
        {
            DataSet dsHeadQuater = null;
            List<HeadQuater> headQuaters = new List<HeadQuater>();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@StateId",state.StateId)
                };
                dsHeadQuater = new DataSet();
                dsHeadQuater = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetHeadQuaterBasedOnState, spParams);
                if (dsHeadQuater != null && dsHeadQuater.Tables.Count > 0 && dsHeadQuater.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsHeadQuater.Tables[0].Rows.Count; i++)
                    {
                        HeadQuater objHeadQuater = new HeadQuater();
                        if (dsHeadQuater.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objHeadQuater.Id = Convert.ToInt32(dsHeadQuater.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objHeadQuater.HeadQuaterName = dsHeadQuater.Tables[0].Rows[i]["HeadQuaterName"].ToString();
                        headQuaters.Add(objHeadQuater);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return headQuaters;
        }

        /// <summary>
        /// Get towns based on head quater id.
        /// </summary>
        /// <param name="headquater"></param>
        /// <returns></returns>
        public List<Town> GetTownsBasedOnHeadQuater(Town headquater)
        {
            DataSet dsTowns = null;
            List<Town> towns = new List<Town>();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@HeadQuaterId",headquater.HeadQuaterId)
                };
                dsTowns = new DataSet();
                dsTowns = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetTownsBasedOnHeadQuater, spParams);
                if (dsTowns != null && dsTowns.Tables.Count > 0 && dsTowns.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsTowns.Tables[0].Rows.Count; i++)
                    {
                        Town objTown = new Town();
                        if (dsTowns.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objTown.Id = Convert.ToInt32(dsTowns.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objTown.TownName = dsTowns.Tables[0].Rows[i]["TownName"].ToString();
                        towns.Add(objTown);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return towns;
        }

        /// <summary>
        /// To get area head name based on selected head quater.
        /// </summary>
        /// <param name="headquater"></param>
        /// <returns></returns>
        public SalesOfficer GetAreaHeadNameBasedOnHeadQuater(SalesOfficer headquater)
        {
            DataSet dsAreaHead = null;
            SalesOfficer objAreaHead = new SalesOfficer();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@HeadQuaterId",headquater.HeadQuaterId)
                };
                dsAreaHead = new DataSet();
                dsAreaHead = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetAreaHeadByHeadQuaterId, spParams);
                if (dsAreaHead != null && dsAreaHead.Tables.Count > 0 && dsAreaHead.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsAreaHead.Tables[0].Rows.Count; i++)
                    {
                        if (dsAreaHead.Tables[0].Rows[i]["AreaHeadId"] != DBNull.Value)
                        {
                            objAreaHead.AreaHeadId = Convert.ToInt32(dsAreaHead.Tables[0].Rows[i]["AreaHeadId"].ToString());
                        }
                        objAreaHead.AreaHeadName = dsAreaHead.Tables[0].Rows[i]["AreaHeadName"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return objAreaHead;
        }

        /// <summary>
        /// To get all distributor types.
        /// </summary>
        /// <returns></returns>
        public List<DistributorType> GetDistributorType()
        {
            DataSet dsDistributorType = null;
            List<DistributorType> distributorTypes = new List<DistributorType>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsDistributorType = new DataSet();
                dsDistributorType = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetDistributorType, null);
                if (dsDistributorType != null && dsDistributorType.Tables.Count > 0 && dsDistributorType.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDistributorType.Tables[0].Rows.Count; i++)
                    {
                        DistributorType objDistributorType = new DistributorType();
                        if (dsDistributorType.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objDistributorType.Id = Convert.ToInt32(dsDistributorType.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objDistributorType.DistributorTypeDesc = dsDistributorType.Tables[0].Rows[i]["DistributorTypeDesc"].ToString();
                        objDistributorType.DistributorTypeShort = dsDistributorType.Tables[0].Rows[i]["DistributorTypeShort"].ToString();
                        distributorTypes.Add(objDistributorType);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return distributorTypes;
        }

        /// <summary>
        /// To get all Product type.
        /// </summary>
        /// <returns></returns>
        public List<ProductTypes> GetProductType()
        {
            DataSet dsProductType = null;
            List<ProductTypes> productTypes = new List<ProductTypes>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsProductType = new DataSet();
                dsProductType = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetProductTypes, null);
                if (dsProductType != null && dsProductType.Tables.Count > 0 && dsProductType.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsProductType.Tables[0].Rows.Count; i++)
                    {
                        ProductTypes objProductType = new ProductTypes();
                        if (dsProductType.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objProductType.Id = Convert.ToInt32(dsProductType.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objProductType.ProductType = dsProductType.Tables[0].Rows[i]["ProductType"].ToString();
                        productTypes.Add(objProductType);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return productTypes;
        }

        /// <summary>
        /// To check product exists based on SKUCode.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Product GetProductIdBasedOnSKUCode(Product product)
        {
            DataSet dsProducts = null;
            Product products = new Product();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ProductSKUCode",product.ProductSKUCode)
                };
                dsProducts = new DataSet();
                dsProducts = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetProductIdBasedOnSKUCode, spParams);
                if (dsProducts != null && dsProducts.Tables.Count > 0 && dsProducts.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsProducts.Tables[0].Rows.Count; i++)
                    {
                        if (dsProducts.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            products.Id = Convert.ToInt32(dsProducts.Tables[0].Rows[i]["Id"].ToString());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return products;
        }

        /// <summary>
        /// To get all months.
        /// </summary>
        /// <returns></returns>
        public List<MonthDetails> GetMonthDetails()
        {
            DataSet dsMonths = null;
            List<MonthDetails> months = new List<MonthDetails>();
            try
            {
                connection = SQLConnection.GetConnection();

                dsMonths = new DataSet();
                dsMonths = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetMonths, null);
                if (dsMonths != null && dsMonths.Tables.Count > 0 && dsMonths.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsMonths.Tables[0].Rows.Count; i++)
                    {
                        MonthDetails objMonth = new MonthDetails();
                        if (dsMonths.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objMonth.Id = Convert.ToInt32(dsMonths.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objMonth.MonthName = dsMonths.Tables[0].Rows[i]["MonthName"].ToString();
                        months.Add(objMonth);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return months;
        }

        /// <summary>
        /// To get sales officers based on area head.
        /// </summary>
        /// <param name="salesOfficer"></param>
        /// <returns></returns>
        public List<SalesOfficer> GetSalesOfficerBasedOnAreaHead(SalesOfficer salesOfficer)
        {
            DataSet dsSalesOfficers = null;
            List<SalesOfficer> salesOfficers = new List<SalesOfficer>();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@AreaHeadId",salesOfficer.AreaHeadId)
                };
                dsSalesOfficers = new DataSet();
                dsSalesOfficers = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetAllSalesOfficerBasedOnAreaHead, spParams);
                if (dsSalesOfficers != null && dsSalesOfficers.Tables.Count > 0 && dsSalesOfficers.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSalesOfficers.Tables[0].Rows.Count; i++)
                    {
                        SalesOfficer objSalesOfficer = new SalesOfficer();
                        if (dsSalesOfficers.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objSalesOfficer.Id = Convert.ToInt32(dsSalesOfficers.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objSalesOfficer.SalesOfficerName = dsSalesOfficers.Tables[0].Rows[i]["SalesOfficerName"].ToString();
                        salesOfficers.Add(objSalesOfficer);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return salesOfficers;
        }

        /// <summary>
        /// To get distributors based on area head id.
        /// </summary>
        /// <param name="areaHead"></param>
        /// <returns></returns>
        public List<Distributor> GetDistributorsBasedOnAreaHead(Distributor areaHead)
        {
            DataSet dsDistributors = null;
            List<Distributor> distributors = new List<Distributor>();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@AreaHeadId",areaHead.AreaHeadId)
                };
                dsDistributors = new DataSet();
                dsDistributors = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetAllDistributorBasedOnAreaHead, spParams);
                if (dsDistributors != null && dsDistributors.Tables.Count > 0 && dsDistributors.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDistributors.Tables[0].Rows.Count; i++)
                    {
                        Distributor objDistributors = new Distributor();
                        if (dsDistributors.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objDistributors.Id = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objDistributors.DistributorName = dsDistributors.Tables[0].Rows[i]["DistributorName"].ToString();
                        distributors.Add(objDistributors);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return distributors;
        }

        /// <summary>
        /// To get all distributors and area head name based on sales officer id.
        /// </summary>
        /// <param name="salesOfficer"></param>
        /// <returns></returns>
        public List<Distributor> GetDistributorsBasedOnSalesOfficer(DailySalesReporting salesOfficer)
        {
            DataSet dsDistributors = null;
            List<Distributor> distributors = new List<Distributor>();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@SalesOfficerId",salesOfficer.SalesOfficerId)
                };
                dsDistributors = new DataSet();
                dsDistributors = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetAllDistributorBasedOnSalesOfficer, spParams);
                if (dsDistributors != null && dsDistributors.Tables.Count > 0 && dsDistributors.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDistributors.Tables[0].Rows.Count; i++)
                    {
                        Distributor objDistributors = new Distributor();
                        if (dsDistributors.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objDistributors.Id = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objDistributors.DistributorName = dsDistributors.Tables[0].Rows[i]["DistributorName"].ToString();
                        if (dsDistributors.Tables[0].Rows[i]["AreaHeadId"] != DBNull.Value)
                        {
                            objDistributors.AreaHeadId = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["AreaHeadId"].ToString());
                        }
                        objDistributors.AreaHeadName = dsDistributors.Tables[0].Rows[i]["AreaHeadName"].ToString();
                        distributors.Add(objDistributors);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return distributors;
        }

        /// <summary>
        /// To get login details.
        /// </summary>
        /// <param name="loginDetails"></param>
        /// <returns></returns>
        public LoginDetails GetLoginDetails(LoginDetails loginDetails)
        {
            DataSet dsLoginDetails = null;
            LoginDetails objLoginData = new LoginDetails();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ContactNumber",loginDetails.ContactNumber),
                   new SqlParameter("@Password",loginDetails.Password),
                };
                dsLoginDetails = new DataSet();
                dsLoginDetails = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetLoginDetails, spParams);
                if (dsLoginDetails != null && dsLoginDetails.Tables.Count > 0 && dsLoginDetails.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsLoginDetails.Tables[0].Rows.Count; i++)
                    {
                        if (dsLoginDetails.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objLoginData.Id = Convert.ToInt32(dsLoginDetails.Tables[0].Rows[i]["Id"].ToString());
                        }
                        if (dsLoginDetails.Tables[0].Rows[i]["IsAdmin"] != DBNull.Value)
                        {
                            objLoginData.IsAdmin = Convert.ToBoolean(dsLoginDetails.Tables[0].Rows[i]["IsAdmin"].ToString());
                        }
                        if (dsLoginDetails.Tables[0].Rows[i]["IsActive"] != DBNull.Value)
                        {
                            objLoginData.IsActive = Convert.ToBoolean(dsLoginDetails.Tables[0].Rows[i]["IsActive"].ToString());
                        }
                        if (dsLoginDetails.Tables[0].Rows[i]["UserRole"] != DBNull.Value)
                        {
                            objLoginData.UserRole = dsLoginDetails.Tables[0].Rows[i]["UserRole"].ToString();
                        }
                        if (dsLoginDetails.Tables[0].Rows[i]["UserContactNumber"] != DBNull.Value)
                        {
                            objLoginData.UserContactNumber = dsLoginDetails.Tables[0].Rows[i]["UserContactNumber"].ToString();
                        }
                        if (dsLoginDetails.Tables[0].Rows[i]["UserName"] != DBNull.Value)
                        {
                            objLoginData.UserName = dsLoginDetails.Tables[0].Rows[i]["UserName"].ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return objLoginData;
        }

        /// <summary>
        /// DashBoard Details for today.
        /// </summary>
        /// <returns></returns>
        public List<DashBoardDataForToday> GetTodayDashBoardData()
        {
            DataSet dsDashBoard = null;
            List<DashBoardDataForToday> dashboardData = new List<DashBoardDataForToday>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsDashBoard = new DataSet();
                dsDashBoard = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetDashboardDetailsData, null);
                if (dsDashBoard != null && dsDashBoard.Tables.Count > 0 && dsDashBoard.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDashBoard.Tables[0].Rows.Count; i++)
                    {
                        DashBoardDataForToday objDashBoard = new DashBoardDataForToday();
                        if (dsDashBoard.Tables[0].Rows[i]["TodayTotalCalls"] != DBNull.Value)
                        {
                            objDashBoard.TodayTotalCalls = Convert.ToInt32(dsDashBoard.Tables[0].Rows[i]["TodayTotalCalls"].ToString());
                        }
                        if (dsDashBoard.Tables[0].Rows[i]["TodayTotalProductiveCalls"] != DBNull.Value)
                        {
                            objDashBoard.TodayTotalProductiveCalls = Convert.ToInt32(dsDashBoard.Tables[0].Rows[i]["TodayTotalProductiveCalls"].ToString());
                        }
                        if (dsDashBoard.Tables[0].Rows[i]["TodayTotalProductSoldByCategory"] != DBNull.Value)
                        {
                            objDashBoard.TodayTotalProductSoldByCategory = Convert.ToInt32(dsDashBoard.Tables[0].Rows[i]["TodayTotalProductSoldByCategory"].ToString());
                        }
                        if (dsDashBoard.Tables[0].Rows[i]["TodayTotalSaleOfficers"] != DBNull.Value)
                        {
                            objDashBoard.TodayTotalSaleOfficers = Convert.ToInt32(dsDashBoard.Tables[0].Rows[i]["TodayTotalSaleOfficers"].ToString());
                        }
                        if (dsDashBoard.Tables[0].Rows[i]["TodayTotalWorkingSalesOfficers"] != DBNull.Value)
                        {
                            objDashBoard.TodayTotalWorkingSalesOfficers = Convert.ToInt32(dsDashBoard.Tables[0].Rows[i]["TodayTotalWorkingSalesOfficers"].ToString());
                        }
                        objDashBoard.ProductCategory = dsDashBoard.Tables[0].Rows[i]["ProductCategory"].ToString();
                        if (dsDashBoard.Tables[0].Rows[i]["RetailingDate"] != DBNull.Value)
                        {
                            objDashBoard.RetailingDate = Convert.ToDateTime(dsDashBoard.Tables[0].Rows[i]["RetailingDate"].ToString());
                        }

                        dashboardData.Add(objDashBoard);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return dashboardData;
        }

        /// <summary>
        /// Daily Revenue for dashboard.
        /// </summary>
        /// <returns></returns>
        public List<DashBoardDailyRevenue> GetDailyRevenueDashBoardData(ZoneWiseAreaHeadSalesOfficer dailyrevenuefilter)
        {
            DataSet dsDashBoard = null;
            List<DashBoardDailyRevenue> dashboardData = new List<DashBoardDailyRevenue>();
            try
            {
                if (dailyrevenuefilter.MonthId == 13)
                {
                    dailyrevenuefilter.MonthId = 0;
                }
                if (dailyrevenuefilter.ZoneId == 5)
                {
                    dailyrevenuefilter.ZoneId = 0;
                }
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@MonthId",dailyrevenuefilter.MonthId),
                   new SqlParameter("@ZoneId",dailyrevenuefilter.ZoneId),
                   new SqlParameter("@AreaHeadId",dailyrevenuefilter.AreaHeadId),
                   new SqlParameter("@SalesOfficerId",dailyrevenuefilter.SalesOfficerId)
                };
                dsDashBoard = new DataSet();
                dsDashBoard = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetDailyRevenueData, spParams);
                if (dsDashBoard != null && dsDashBoard.Tables.Count > 0 && dsDashBoard.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDashBoard.Tables[0].Rows.Count; i++)
                    {
                        DashBoardDailyRevenue objDashBoard = new DashBoardDailyRevenue();
                        if (dsDashBoard.Tables[0].Rows[i]["RetailingDate"] != DBNull.Value)
                        {
                            objDashBoard.RetailingDate = Convert.ToDateTime(dsDashBoard.Tables[0].Rows[i]["RetailingDate"].ToString());
                        }
                        if (dsDashBoard.Tables[0].Rows[i]["ProductSKUCode"] != DBNull.Value)
                        {
                            objDashBoard.ProductSKUCode = dsDashBoard.Tables[0].Rows[i]["ProductSKUCode"].ToString();
                        }
                        if (dsDashBoard.Tables[0].Rows[i]["ProductPrice"] != DBNull.Value)
                        {
                            objDashBoard.ProductPrice = Convert.ToDecimal(dsDashBoard.Tables[0].Rows[i]["ProductPrice"].ToString());
                        }
                        if (dsDashBoard.Tables[0].Rows[i]["TotalProductSold"] != DBNull.Value)
                        {
                            objDashBoard.TotalProductSold = Convert.ToInt32(dsDashBoard.Tables[0].Rows[i]["TotalProductSold"].ToString());
                        }
                        if (objDashBoard.ProductPrice != 0 && objDashBoard.TotalProductSold != 0)
                        {
                            objDashBoard.DailyRevenue = Convert.ToDecimal(objDashBoard.ProductPrice * objDashBoard.TotalProductSold);
                        }
                        dashboardData.Add(objDashBoard);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return dashboardData;
        }

        /// <summary>
        /// To get daily revenue data based on area head.
        /// </summary>
        /// <param name="areaHead"></param>
        /// <returns></returns>
        public List<DashBoardDailyRevenue> GetDailyRevenueDashBoardDataForAreaHead(AreaHeadByContactNumber areaHead)
        {
            DataSet dsDashBoard = null;
            List<DashBoardDailyRevenue> dashboardData = new List<DashBoardDailyRevenue>();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@AreaHeadId",areaHead.AreaHeadId)
                };
                dsDashBoard = new DataSet();
                dsDashBoard = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetDailyRevenueDataForAreaHead, spParams);
                if (dsDashBoard != null && dsDashBoard.Tables.Count > 0 && dsDashBoard.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDashBoard.Tables[0].Rows.Count; i++)
                    {
                        DashBoardDailyRevenue objDashBoard = new DashBoardDailyRevenue();
                        if (dsDashBoard.Tables[0].Rows[i]["RetailingDate"] != DBNull.Value)
                        {
                            objDashBoard.RetailingDate = Convert.ToDateTime(dsDashBoard.Tables[0].Rows[i]["RetailingDate"].ToString());
                        }
                        if (dsDashBoard.Tables[0].Rows[i]["ProductSKUCode"] != DBNull.Value)
                        {
                            objDashBoard.ProductSKUCode = dsDashBoard.Tables[0].Rows[i]["ProductSKUCode"].ToString();
                        }
                        if (dsDashBoard.Tables[0].Rows[i]["ProductPrice"] != DBNull.Value)
                        {
                            objDashBoard.ProductPrice = Convert.ToDecimal(dsDashBoard.Tables[0].Rows[i]["ProductPrice"].ToString());
                        }
                        if (dsDashBoard.Tables[0].Rows[i]["TotalProductSold"] != DBNull.Value)
                        {
                            objDashBoard.TotalProductSold = Convert.ToInt32(dsDashBoard.Tables[0].Rows[i]["TotalProductSold"].ToString());
                        }
                        if (objDashBoard.ProductPrice != 0 && objDashBoard.TotalProductSold != 0)
                        {
                            objDashBoard.DailyRevenue = Convert.ToDecimal(objDashBoard.ProductPrice * objDashBoard.TotalProductSold);
                        }
                        dashboardData.Add(objDashBoard);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return dashboardData;
        }

        /// <summary>
        /// To get all distributors based on the contact number of sales officer or area head.
        /// </summary>
        /// <param name="salesOfficer"></param>
        /// <returns></returns>
        public List<Distributor> GetDistributorsBasedOnContactNumber(DailySalesReporting salesOfficer)
        {
            DataSet dsDistributors = null;
            List<Distributor> distributors = new List<Distributor>();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ContactNumber",salesOfficer.ContactNumber)
                };
                dsDistributors = new DataSet();
                dsDistributors = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetAllDistributorBasedOnConctactNumber, spParams);
                if (dsDistributors != null && dsDistributors.Tables.Count > 0 && dsDistributors.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDistributors.Tables[0].Rows.Count; i++)
                    {
                        Distributor objDistributors = new Distributor();
                        if (dsDistributors.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objDistributors.Id = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objDistributors.DistributorName = dsDistributors.Tables[0].Rows[i]["DistributorName"].ToString();
                        if (dsDistributors.Tables[0].Rows[i]["AreaHeadId"] != DBNull.Value)
                        {
                            objDistributors.AreaHeadId = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["AreaHeadId"].ToString());
                        }                       
                        objDistributors.AreaHeadName = dsDistributors.Tables[0].Rows[i]["AreaHeadName"].ToString();
                        if (dsDistributors.Tables[0].Rows[i]["SalesOfficerId"] != DBNull.Value)
                        {
                            objDistributors.SalesOfficerId = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["SalesOfficerId"].ToString());
                        }
                        distributors.Add(objDistributors);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return distributors;
        }

        /// <summary>
        /// To get attendence by contact number and month.
        /// </summary>
        /// <param name="myWorkingDays"></param>
        /// <returns></returns>
        public List<MyWorkingDays> GetMyAttendence(MyWorkingDays myWorkingDays)
        {
            DataSet dsWorkingDays = null;
            List<MyWorkingDays> myAttendence = new List<MyWorkingDays>();
            List<DateTime> dateTimes = new List<DateTime>();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ContactNumber",myWorkingDays.ContactNumber),
                   new SqlParameter("@Month",myWorkingDays.Month)
                };
                dsWorkingDays = new DataSet();
                dsWorkingDays = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetAttendenceOfTheMonth, spParams);
                if (dsWorkingDays != null && dsWorkingDays.Tables.Count > 0 && dsWorkingDays.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsWorkingDays.Tables[0].Rows.Count; i++)
                    {
                        if (dsWorkingDays.Tables[0].Rows[i]["WorkingDate"] != DBNull.Value)
                        {
                            dateTimes.Add(Convert.ToDateTime(dsWorkingDays.Tables[0].Rows[i]["WorkingDate"].ToString()));
                        }
                    }
                    if (dateTimes.Count > 0)
                    {
                        List<DateTime> result;
                        if (myWorkingDays.Month != null)
                        {
                            result = GetDates(Convert.ToInt32(myWorkingDays.Month));
                        }
                        else
                        {
                            myWorkingDays.Month = DateTime.Now.Month;
                            result = GetDates(Convert.ToInt32(myWorkingDays.Month));
                        }
                        foreach (var day in result)
                        {
                            MyWorkingDays objWorkingDate = new MyWorkingDays();
                            if (day <= DateTime.Now)
                            {
                                bool match = dateTimes.Any(X => X.Date == day);
                                if (match)
                                {
                                    objWorkingDate.WorkingDate = day;
                                    objWorkingDate.Attendence = "PRESENT";
                                }
                                else
                                {
                                    objWorkingDate.WorkingDate = day;
                                    objWorkingDate.Attendence = "ABSENT";
                                }
                                myAttendence.Add(objWorkingDate);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return myAttendence;
        }

        public static List<DateTime> GetDates(int month)
        {
            int year = DateTime.Now.Year;
            var dates = new List<DateTime>();

            // Loop from the first day of the month until we hit the next month, moving forward a day at a time
            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                dates.Add(date);
            }

            return dates;
        }

        /// <summary>
        /// To get all active zones.
        /// </summary>
        /// <returns></returns>
        public List<Zone> GetAllActiveZones()
        {
            DataSet dsZones = null;
            List<Zone> zones = new List<Zone>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsZones = new DataSet();
                dsZones = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetActiveZones, null);
                if (dsZones != null && dsZones.Tables.Count > 0 && dsZones.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsZones.Tables[0].Rows.Count; i++)
                    {
                        Zone objZone = new Zone();
                        if (dsZones.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objZone.Id = Convert.ToInt32(dsZones.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objZone.ZoneName = dsZones.Tables[0].Rows[i]["ZoneName"].ToString();
                        zones.Add(objZone);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return zones;
        }
        /// <summary>
        /// To get all active states.
        /// </summary>
        /// <returns></returns>
        public List<States> GetActiveStates()
        {
            DataSet dsStates = null;
            List<States> states = new List<States>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsStates = new DataSet();
                dsStates = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetActiveStates, null);
                if (dsStates != null && dsStates.Tables.Count > 0 && dsStates.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsStates.Tables[0].Rows.Count; i++)
                    {
                        States objstate = new States();
                        if (dsStates.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objstate.Id = Convert.ToInt32(dsStates.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objstate.StateName = dsStates.Tables[0].Rows[i]["StateName"].ToString();
                        states.Add(objstate);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return states;
        }

        /// <summary>
        /// To get all active head quaters.
        /// </summary>
        /// <returns></returns>
        public List<HeadQuater> GetActiveHeadQuaters()
        {
            DataSet dsHeadQuaters = null;
            List<HeadQuater> headQuaters = new List<HeadQuater>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsHeadQuaters = new DataSet();
                dsHeadQuaters = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetActiveHeadQuaters, null);
                if (dsHeadQuaters != null && dsHeadQuaters.Tables.Count > 0 && dsHeadQuaters.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsHeadQuaters.Tables[0].Rows.Count; i++)
                    {
                        HeadQuater objHeadQuater = new HeadQuater();
                        if (dsHeadQuaters.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objHeadQuater.Id = Convert.ToInt32(dsHeadQuaters.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objHeadQuater.HeadQuaterName = dsHeadQuaters.Tables[0].Rows[i]["HeadQuaterName"].ToString();
                        headQuaters.Add(objHeadQuater);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return headQuaters;
        }

        /// <summary>
        /// To get all active product categories.
        /// </summary>
        /// <returns></returns>
        public List<ProductCategories> GetActiveProductCategories()
        {
            DataSet dsProductCategories = null;
            List<ProductCategories> productCategories = new List<ProductCategories>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsProductCategories = new DataSet();
                dsProductCategories = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetActiveProductCategory, null);
                if (dsProductCategories != null && dsProductCategories.Tables.Count > 0 && dsProductCategories.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsProductCategories.Tables[0].Rows.Count; i++)
                    {
                        ProductCategories objProductCategories = new ProductCategories();
                        if (dsProductCategories.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objProductCategories.Id = Convert.ToInt32(dsProductCategories.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objProductCategories.ProductCategory = dsProductCategories.Tables[0].Rows[i]["ProductCategory"].ToString();
                        productCategories.Add(objProductCategories);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return productCategories;
        }

        /// <summary>
        /// To get all active area heads.
        /// </summary>
        /// <returns></returns>
        public List<AreaHead> GetAllActiveAreaheads()
        {
            DataSet dsAreaHeads = null;
            List<AreaHead> areaHeads = new List<AreaHead>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsAreaHeads = new DataSet();
                dsAreaHeads = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetActiveAreaHeads, null);
                if (dsAreaHeads != null && dsAreaHeads.Tables.Count > 0 && dsAreaHeads.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsAreaHeads.Tables[0].Rows.Count; i++)
                    {
                        AreaHead objAreaHead = new AreaHead();
                        if (dsAreaHeads.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objAreaHead.Id = Convert.ToInt32(dsAreaHeads.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objAreaHead.AreaHeadName = dsAreaHeads.Tables[0].Rows[i]["AreaHeadName"].ToString();
                        areaHeads.Add(objAreaHead);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return areaHeads;
        }

        /// <summary>
        /// To get area head id and name by contact number.
        /// </summary>
        /// <param name="contactNumber"></param>
        /// <returns></returns>
        public AreaHeadByContactNumber GetAreaHeadByContactNumber(AreaHeadByContactNumber contactNumber)
        {
            DataSet dsDistributors = null;
            AreaHeadByContactNumber objAreaHead = new AreaHeadByContactNumber();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ContactNumber",contactNumber.ContactNumber)
                };
                dsDistributors = new DataSet();
                dsDistributors = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetAreaHeadByConctactNumber, spParams);
                if (dsDistributors != null && dsDistributors.Tables.Count > 0 && dsDistributors.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsDistributors.Tables[0].Rows.Count; i++)
                    {                                         
                        if (dsDistributors.Tables[0].Rows[i]["AreaHeadId"] != DBNull.Value)
                        {
                            objAreaHead.AreaHeadId = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["AreaHeadId"].ToString());
                        }
                        objAreaHead.AreaHeadName = dsDistributors.Tables[0].Rows[i]["AreaHeadName"].ToString();
                        if (dsDistributors.Tables[0].Rows[i]["ZoneId"] != DBNull.Value)
                        {
                            objAreaHead.ZoneId = Convert.ToInt32(dsDistributors.Tables[0].Rows[i]["ZoneId"].ToString());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return objAreaHead;
        }

        /// <summary>
        /// To get all active products
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllActiveProducts()
        {
            DataSet dsProduct = null;
            List<Product> products = new List<Product>();
            try
            {
                connection = SQLConnection.GetConnection();
                dsProduct = new DataSet();
                dsProduct = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetActiveProducts, null);
                if (dsProduct != null && dsProduct.Tables.Count > 0 && dsProduct.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsProduct.Tables[0].Rows.Count; i++)
                    {
                        Product objProduct = new Product();
                        if (dsProduct.Tables[0].Rows[i]["Id"] != DBNull.Value)
                        {
                            objProduct.Id = Convert.ToInt32(dsProduct.Tables[0].Rows[i]["Id"].ToString());
                        }
                        objProduct.ProductName = dsProduct.Tables[0].Rows[i]["ProductName"].ToString();
                        objProduct.ProductDescription = dsProduct.Tables[0].Rows[i]["ProductDescription"].ToString();
                        objProduct.ProductSKUCode = dsProduct.Tables[0].Rows[i]["ProductSKUCode"].ToString();
                        objProduct.ProductWeightDescription = dsProduct.Tables[0].Rows[i]["ProductWeightDescription"].ToString();
                        objProduct.ProductWeight = dsProduct.Tables[0].Rows[i]["ProductWeight"].ToString();
                        if (dsProduct.Tables[0].Rows[i]["ProductCategoryId"] != DBNull.Value)
                        {
                            objProduct.ProductCategoryId = Convert.ToInt32(dsProduct.Tables[0].Rows[i]["ProductCategoryId"].ToString());
                        }
                        objProduct.ProductCategory = dsProduct.Tables[0].Rows[i]["ProductCategory"].ToString();
                        if (dsProduct.Tables[0].Rows[i]["NumberOfPieces"] != DBNull.Value)
                        {
                            objProduct.NumberOfPieces = Convert.ToInt32(dsProduct.Tables[0].Rows[i]["NumberOfPieces"].ToString());
                        }
                        if (dsProduct.Tables[0].Rows[i]["ProductPrice"] != DBNull.Value)
                        {
                            objProduct.ProductPrice = Convert.ToDecimal(dsProduct.Tables[0].Rows[i]["ProductPrice"].ToString());
                        }
                        if (dsProduct.Tables[0].Rows[i]["IsActive"] != DBNull.Value)
                        {
                            objProduct.IsActive = Convert.ToBoolean(dsProduct.Tables[0].Rows[i]["IsActive"].ToString());
                        }
                        objProduct.CreatedBy = dsProduct.Tables[0].Rows[i]["CreatedBy"].ToString();
                        products.Add(objProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return products;
        }

        /// <summary>
        /// To get zonal head details by contact number.
        /// </summary>
        /// <param name="contactNumber"></param>
        /// <returns></returns>
        public ZonalHeadByContactNumber GetZonalHeadByContactNumber(ZonalHeadByContactNumber contactNumber)
        {
            DataSet dsZonalHead = null;
            ZonalHeadByContactNumber objZonalHead = new ZonalHeadByContactNumber();
            try
            {
                connection = SQLConnection.GetConnection();
                SqlParameter[] spParams = new SqlParameter[]
                {
                   new SqlParameter("@ContactNumber",contactNumber.ContactNumber)
                };
                dsZonalHead = new DataSet();
                dsZonalHead = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, SPName_Constants.GetZonalHeadByConctactNumber, spParams);
                if (dsZonalHead != null && dsZonalHead.Tables.Count > 0 && dsZonalHead.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsZonalHead.Tables[0].Rows.Count; i++)
                    {
                        if (dsZonalHead.Tables[0].Rows[i]["ZonalHeadId"] != DBNull.Value)
                        {
                            objZonalHead.ZonalHeadId = Convert.ToInt32(dsZonalHead.Tables[0].Rows[i]["ZonalHeadId"].ToString());
                        }
                        objZonalHead.ZonalHeadName = dsZonalHead.Tables[0].Rows[i]["ZonalHeadName"].ToString();
                        if (dsZonalHead.Tables[0].Rows[i]["ZoneId"] != DBNull.Value)
                        {
                            objZonalHead.ZoneId = Convert.ToInt32(dsZonalHead.Tables[0].Rows[i]["ZoneId"].ToString());
                        }
                        objZonalHead.ZoneName = dsZonalHead.Tables[0].Rows[i]["ZoneName"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return objZonalHead;
        }
        #endregion
    }
}
