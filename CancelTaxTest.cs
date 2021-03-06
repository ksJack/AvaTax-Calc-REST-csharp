﻿namespace AvaTaxCalcREST
{
    using System;

    public class CancelTaxTest
    {
        public static void Test()
        {
            // Header Level Elements
            // Required Header Level Elements
            string accountNumber = "1234567890";
            string licenseKey = "A1B2C3D4E5F6G7H8";
            string serviceURL = "https://development.avalara.net";

            TaxSvc taxSvc = new TaxSvc(accountNumber, licenseKey, serviceURL);

            CancelTaxRequest cancelTaxRequest = new CancelTaxRequest();

            // Required Request Parameters
            cancelTaxRequest.CompanyCode = "APITrialCompany";
            cancelTaxRequest.DocType = DocType.SalesInvoice;
            cancelTaxRequest.DocCode = "INV001";
            cancelTaxRequest.CancelCode = CancelCode.DocVoided;

            CancelTaxResult cancelTaxResult = taxSvc.CancelTax(cancelTaxRequest);

            // Print results
            Console.WriteLine("CancelTaxTest Result: " + cancelTaxResult.ResultCode.ToString());
            if (!cancelTaxResult.ResultCode.Equals(SeverityLevel.Success))
            {
                foreach (Message message in cancelTaxResult.Messages)
                {
                    Console.WriteLine(message.Summary);
                }
            }
        }
    }
}
