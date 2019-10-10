/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeoSystems.Tools
{
    /// <summary>
    /// Currency converter information
    /// </summary>
    public struct CurrencyConverter
    {
        /// <summary>
        /// Conversion rate from Source to Dest
        /// </summary>
        public double ConversionRate;

        /// <summary>
        /// Source Currency
        /// </summary>
        public string SourceCurrency;

        /// <summary>
        /// Dest Currency
        /// </summary>
        public string DestCurrency;


        /// <summary>
        /// Constructor for CurrencyConverter struct
        /// </summary>
        /// <param name="Source">name of source eg "USD"</param>
        /// <param name="Dest">name of Dest eg "ZAR"</param>
        /// <param name="rate">rate eg ZAR = rate * USD</param>
        public CurrencyConverter(string Source, string Dest, double rate)
        {
            SourceCurrency = Source;
            DestCurrency = Dest;
            ConversionRate = rate;
        }
    }

    /// <summary>
    /// Currency converter class
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// List of currency converter data that has been downloaded
        /// </summary>
        public static List<CurrencyConverter> Currencies = new List<CurrencyConverter>(100);

        /// <summary>
        /// download currency info
        /// OLD SERVICE - NO LONGER AVAILABLE
        /// </summary>
        /// <param name="SourceCurr">Source currency eg "USD"</param>
        /// <param name="DestCurr">Dest Currency eg "ZAR"</param>
        private static void AddExhangeRateOld(string SourceCurr, string DestCurr)
        {
            try
            {
                string data = WebUtils.DownloadWebPage("http://rate-exchange.appspot.com/currency?from="+SourceCurr+"&to="+DestCurr+"&q=1");

                string[] fields = data.Split(new char[] {','});
                fields[0] = fields[0].Replace("{\"to\": \"","");
                fields[0] = fields[0].Replace("\"","");
                fields[0] = fields[0].Trim();

                fields[1] = fields[1].Replace("\"rate\": ","");
                fields[1] = fields[1].Trim();

                fields[2] = fields[2].Replace("\"from\": \"","");
                fields[2] = fields[2].Replace("\"","");
                fields[2] = fields[2].Trim();

                double rate;
                Double.TryParse(fields[1],out rate);

                CurrencyConverter tc = new CurrencyConverter(fields[2],fields[0],rate);
                Currencies.Add(tc);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add echange rate to be converted
        /// </summary>
        /// <param name="SourceCurr">Source currency</param>
        /// <param name="DestCurr">Destination current</param>
        public static void AddExhangeRate(string SourceCurr, string DestCurr)
        {
            try
            {
                string data = WebUtils.DownloadWebPage("https://www.google.com/finance/converter?a=1&from=" + SourceCurr + "&to=" + DestCurr);

                string exchratestr = NeoSystems.Tools.StringUtils.GetTextBetweenMarkers(data, "<span class=bld>", "</span>");
                string[] fields = exchratestr.Split(new char[] { ' ' });

                double rate;
                Double.TryParse(fields[0], out rate);

                CurrencyConverter tc = new CurrencyConverter(SourceCurr, DestCurr, rate);
                Currencies.Add(tc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Convert a value from one currency to something else
        /// </summary>
        /// <param name="source">name of source eg "USD"</param>
        /// <param name="dest">name of Dest eg "ZAR"</param>
        /// <param name="value">currency value to convert</param>
        /// <returns>converted currency value</returns>
        public static double Convert(string source, string dest, double value)
        {
            try
            {
                if (source == dest)
                {
                    return value;
                }
                else
                {
                    double result = 0;
                    bool f = false;
                    foreach(CurrencyConverter c in Currency.Currencies)
                    {
                        if ((c.SourceCurrency == source) && (c.DestCurrency == dest))
                        {
                            f = true;
                            result = value * c.ConversionRate;
                        }
                    }
                    if (!f) throw new Exception("Currency conversion data not available");
                    return result;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
