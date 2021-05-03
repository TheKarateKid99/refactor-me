using System;

namespace ProcessDelivery.Common
{
    public static class RiksValidatorV2
    {
        /// <summary>
        /// Generic Risk Validation Class that validates the return Risk of a given object
        /// Class to be validated requires following fields: LastReturnedDate,LastDueDate,CurrentDueDate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="dateReturned"></param>
        /// <returns></returns>
        public static string ReturnRiskValidator<T>(T item, DateTime dateReturned)
        {
            try
            {
                var lastReturnedDate = typeof(T).GetProperty("LastReturnedDate") == null ? throw new Exception("LastReturnedDate field missing")
                                                                                        : (DateTime?)typeof(T).GetProperty("LastReturnedDate")?.GetValue(item);
                var lastDueDate = typeof(T).GetProperty("LastReturnedDate") == null ? throw new Exception("LastReturnedDate field missing")
                                                                                        : (DateTime?)typeof(T).GetProperty("LastDueDate")?.GetValue(item);
                var currentDueDate = typeof(T).GetProperty("LastReturnedDate") == null ? throw new Exception("LastReturnedDate field missing")
                                                                                        : (DateTime)typeof(T).GetProperty("CurrentDueDate")?.GetValue(item);

                if (lastReturnedDate != null && lastDueDate != null)
                {
                    if (lastDueDate == lastReturnedDate)
                    {
                        var riskLevel = DetermineRiskLevel(currentDueDate, dateReturned);

                        switch (riskLevel)
                        {
                            case 1:
                                return "LowRisk: returned on due date last 2 times";
                            case 2:
                                return "MediumRisk: returned on due date last time but late this time";
                            case 3:
                                return "MediumRisk: returned on due date last time but early this time";
                            default:
                                return "Risk could not be calculated as criteria does not fall within range"; 
                        }

                    }
                    else
                    {
                        if (lastDueDate < lastReturnedDate)
                        {

                            var riskLevel = DetermineRiskLevel(currentDueDate, dateReturned);

                            switch (riskLevel)
                            {
                                case 1:
                                    return "MediumRisk: returned late last time but on due date this time";
                                case 2:
                                    return "HighRisk: returned late last time and late this time";
                                case 3:
                                    return "MediumRisk: returned late last time but early this time";
                                default:
                                    return "Risk could not be calculated as criteria does not fall within range";
                            }

                        }
                        else
                        {
                            var riskLevel = DetermineRiskLevel(currentDueDate, dateReturned);

                            switch (riskLevel)
                            {
                                case 1:
                                    return "LowRisk: returned on early last time and on due date this time";
                                case 2:
                                    return "MediumRisk: returned early last time but late this time";
                                case 3:
                                    return "LowRisk: returned early last time and early this time";
                                default:
                                    return "Risk could not be calculated as criteria does not fall within range";
                            }
                        }
                    }
                }

                if (currentDueDate == dateReturned)
                {
                    return "LowRisk: first time being returned and returned on time";
                }

                if (currentDueDate < dateReturned)
                {
                    return "MediumRisk: first time being returned and returned late";
                }

                return "LowRisk: first time being returned and returned early";

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static int DetermineRiskLevel(DateTime currentDueDate, DateTime dateReturned)
        {
            if (currentDueDate == dateReturned)
            {
                return 1;
            }
            else if (currentDueDate < dateReturned)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}
