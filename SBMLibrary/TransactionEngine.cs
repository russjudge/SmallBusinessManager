using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBMLibrary
{
    public static class TransactionEngine
    {
        public static void ReceiveInventory(ICollection<ActiveInventoryObject> Activity, string receiptID)
        {

            DateTime transTime = DateTime.Now;
            //decimal discount = 0;
            int productCount = 0;
            if (Activity != null)
            {
                foreach (ActiveInventoryObject aio in Activity)
                {
                    InventoryTransactionObject tran = new InventoryTransactionObject();

                    //aio.TotalDollarChanged -= newItem_TotalDollarChanged;
                    tran.ReceiptID = receiptID;

                    tran.TransactionTime = transTime;

                    //tran.CostEach = 0;
                    //tran.TransactionAmount = amount;

                    tran.CostEach = aio.AdditionalOverhead + aio.WholeSalePrice;
                    tran.TransactionAmount = tran.CostEach * aio.Quantity;
                    productCount += aio.Quantity;

                    tran.Quantity = aio.Quantity;  //Quantity to reflect change in ActiveInventory.  Negative to remove from Inventory.


                    //Part of Pair matching:
                    
                    //tran.Discount = aio.Discount;
                    //tran.DiscountRateLevel = aio.DiscountRateLevel;
                    tran.ExportedToWeb = false;
                    tran.IsSale = true;
                    tran.PairMatched = false;
                    tran.ProductID = aio.ProductID;

                    
                    tran.SellingPriceEach = 0; // priceEach;

                    tran.SKU = aio.SKU;

                    tran.UPC = aio.UPC;


                    Cache.Current.InventoryActivity.Add(tran);

                    //discount += aio.Discount;
                }
            }
            Cache.Current.SaveInventoryActivity();

        }
        public static FinancialObject Post(ICollection<ActiveInventoryObject> Activity, 
            string receiptID, decimal cash, decimal credit, decimal check, 
            PricingModelObject selectedPricingModel, decimal tax, decimal profitLoss, string USStateOfSale, decimal totalSale, decimal discountAmount)
        {

            DateTime transTime = DateTime.Now;
            decimal discount = 0;
            int productCount = 0;
            if (Activity != null)
            {
                foreach (ActiveInventoryObject aio in Activity)
                {
                    InventoryTransactionObject tran = new InventoryTransactionObject();

                    //aio.TotalDollarChanged -= newItem_TotalDollarChanged;
                    tran.ReceiptID = receiptID;

                    tran.TransactionTime = transTime;
                    decimal amount = aio.GetTotalPrice(selectedPricingModel);

                    tran.TransactionAmount = amount;


                    productCount += aio.Quantity;

                    tran.Quantity = -aio.Quantity;  //Quantity to reflect change in ActiveInventory.  Negative to remove from Inventory.


                    //Part of Pair matching:
                    //tran.CostEach =
                    tran.Discount = aio.Discount;
                   // tran.DiscountRateLevel = aio.DiscountRateLevel;
                    tran.ExportedToWeb = false;
                    tran.IsSale = true;
                    tran.PairMatched = false;
                    tran.ProductID = aio.ProductID;

                    decimal priceEach = aio.GetPriceEach(selectedPricingModel);
                    if (selectedPricingModel != null)
                    {

                        if (selectedPricingModel.IncludesSalesTax)
                        {
                            priceEach = priceEach / (1 + Configuration.Current.CurrentSalesTax);
                        }
                    }
                    tran.SellingPriceEach = priceEach;

                    tran.SKU = aio.SKU;

                    tran.UPC = aio.UPC;


                    Cache.Current.InventoryActivity.Add(tran);

                    discount += aio.Discount;
                }
            }
            Cache.Current.SaveInventoryActivity();

            FinancialObject fin = new FinancialObject();
            fin.ReceiptID = receiptID;
            fin.DiscountAmount = discount;
            fin.TotalCash = cash;
            fin.TotalCredit = credit;
            fin.TotalCheck = check;

            fin.TotalTax = tax;
            fin.TotalSale = fin.TotalCredit + fin.TotalCash + fin.TotalCheck - fin.TotalTax;
            fin.ProductCount = productCount;
            fin.ProfitLoss = profitLoss;
            fin.Station = Configuration.Current.StationID;
            fin.User = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            if (selectedPricingModel != null)
            {

                fin.PricingModelInEffect = selectedPricingModel.Name;
            }
            fin.USStateOfSale = USStateOfSale;

            fin.DiscountAmount += discountAmount;

            Cache.Current.CurrentFinancials.Add(fin);
            Cache.Current.SaveFinancials();
            return fin;
        }
        public static void StageReceiving(string reportFile)
        {
            List<InventoryTransactionObject> working = new List<InventoryTransactionObject>();
            int quantity = 0;
            foreach (InventoryTransactionObject trans in Cache.Current.InventoryActivity)
            {
                quantity += trans.Quantity;
                working.Add(trans);
            }
            foreach (InventoryTransactionObject tran1 in working)
            {

                Cache.Current.ReadyForOpenCartUpdate.Add(tran1);
                Cache.Current.InventoryActivity.Remove(tran1);
            }
            Cache.Current.SaveReadyForOpenCartUpdate();
            
            Cache.Current.SaveInventoryActivity();
            CreateReceiveInventoryStagingReport(reportFile, quantity);
        }

        private static void CreateReceiveInventoryStagingReport(string path, int totalproduct)
        {
            XFont fontH1 = new XFont("Arial", 18, XFontStyle.Bold);
            XFont fontH2 = new XFont("Arial", 16, XFontStyle.Italic);
            XFont font = new XFont("Arial", 12);

            using (PdfDocument document = new PdfDocument())
            {
                document.Info.Title = "Fox One POS Stage Received Inventory Report";

                PdfPage page = document.AddPage();
                double x = 50;
                double y = 100;
                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    double ls = font.GetHeight(gfx);
                    double lsH1 = fontH1.GetHeight(gfx);
                    double lsH2 = fontH2.GetHeight(gfx);
                    using (XImage img = XImage.FromFile(Configuration.LogoFile))
                    {
                        double width = img.PixelWidth * 72 / img.HorizontalResolution;
                        double height = img.PixelHeight * 72 / img.HorizontalResolution;
                        gfx.DrawImage(img, x, y, width, height);


                        y += height;
                    }
                    

                    gfx.DrawString(Configuration.Current.BusinessName + " Stage Received Inventory Report", fontH1, XBrushes.Black, x, y);
                    y += lsH1;

                    gfx.DrawString("Station: " + Configuration.Current.StationID, fontH2, XBrushes.Black, x, y);

                    y += lsH2;

                    gfx.DrawString(DateTime.Now.ToString(), fontH2, XBrushes.Black, x, y);

                    y += lsH2 * 2;
                    gfx.DrawString("Total product received: " + totalproduct.ToString(), font, XBrushes.Black, x, y);
                }
                document.Save(path);
            }
        }
        public static void CloseDay(decimal startingCash, decimal CashOnHand, string reportFile)
        {
            decimal cash = startingCash;
            decimal profit = 0;
            decimal revenue = 0;
            
            int saleCount = 0;
            int productQuantity = 0;
            decimal discountAmount =0;
            decimal taxAmount = 0;

            decimal creditAmount = 0;
            decimal checkAmount = 0;

            List<InventoryTransactionObject> working = new List<InventoryTransactionObject>();
            List<FinancialObject> financialList = new List<FinancialObject>();

            foreach (InventoryTransactionObject trans in Cache.Current.InventoryActivity)
            {
                
                working.Add(trans);
                FinancialObject f = Cache.Current.CurrentFinancials.GetFinancial(trans.ReceiptID);
                if (f != null)
                {
                    if (trans.ProductID != 0)
                    {
                        cash += f.TotalCash;
                        profit += f.ProfitLoss;
                        revenue += f.TotalSale;

                        saleCount++;
                        productQuantity += f.ProductCount;
                        discountAmount += f.DiscountAmount;
                        taxAmount += f.TotalTax;
                        creditAmount += f.TotalCredit;
                        checkAmount += f.TotalCheck;
                        financialList.Add(f);
                    }
                }
              
            }
            decimal overShort = CashOnHand - cash;
            FinancialObject fin = null;
            InventoryTransactionObject tran = null;
            if (overShort != 0)
            {
                fin = new FinancialObject();
                profit += overShort;
                
                fin.TotalTax = 0;
                fin.DiscountAmount = 0;
                fin.PricingModelInEffect = string.Empty;
                fin.ProductCount = 0;
                fin.ProfitLoss = overShort;
                fin.ReceiptID = DateTime.Today.ToString("yyyyMMdd") + " " + Configuration.Current.StationID + "-" + Configuration.Current.ReceiptIDNumber++;
                Configuration.Current.Save();
                fin.Station = Configuration.Current.StationID;
                fin.TotalCash = overShort;
                fin.TotalSale = overShort;
                fin.User = System.Security.Principal.WindowsIdentity.GetCurrent().Name;


                tran = new InventoryTransactionObject();
                tran.ReceiptID = fin.ReceiptID;
                tran.CostEach = 0;
                tran.Discount = 0;
                tran.DiscountRateLevel = 0;
                tran.ExportedToWeb = false;
                tran.IsSale = true;
                tran.PairMatched = false;
                tran.ProductID = 0;
                tran.Quantity = 0;
                tran.SellingPriceEach = 0;
                tran.SKU = string.Empty;
                tran.TransactionAmount = overShort;
                tran.TransactionTime = DateTime.Now;
                tran.UPC = string.Empty;
                
            }

            foreach (InventoryTransactionObject tran1 in working)
            {
                
                Cache.Current.ReadyForOpenCartUpdate.Add(tran1);
                Cache.Current.InventoryActivity.Remove(tran1);
            }
            if (tran != null)
            {
                Cache.Current.ReadyForOpenCartUpdate.Add(tran);
                working.Add(tran);
            }
            foreach (FinancialObject fin1 in financialList)
            {
                Cache.Current.StagedFinancials.Add(fin1);
                Cache.Current.CurrentFinancials.Remove(fin1);
            }
            if (fin != null)
            {
                Cache.Current.StagedFinancials.Add(fin);
                financialList.Add(fin);
            }

            Cache.Current.SaveReadyForOpenCartUpdate();
            Cache.Current.SaveStagedFinancials();
            Cache.Current.SaveFinancials();
            Cache.Current.SaveInventoryActivity();
            

            CreatePDFCloseDayReport(startingCash, CashOnHand, cash, creditAmount, checkAmount,
                profit, revenue, saleCount, productQuantity, discountAmount, taxAmount, reportFile, financialList, working);

        }
        static XFont fontH1 = new XFont("Arial", 18, XFontStyle.Bold);
        static XFont fontH2 = new XFont("Arial", 16, XFontStyle.Italic);
        static XFont font = new XFont("Arial", 12);

        static XFont fontBold = new XFont("Arial", 12, XFontStyle.Bold);


        static double PageLength = 0;
        static void CreatePDFCloseDayReport(decimal startCash, decimal ActualEndCash, decimal ExpectedEndCash,
            decimal totalCredit, decimal totalCheck, decimal profitLoss, decimal totalRevenue, 
            int saleCount, int quantityProductSold, decimal amountDiscounted, decimal taxAmount, string path,
            List<FinancialObject> financials, List<InventoryTransactionObject> inventoryTransactions)
        {
           
            using (PdfDocument document = new PdfDocument())
            {
                document.Info.Title = "Fox One POS Close Day Report";

                PdfPage page = document.AddPage();
                PageLength = page.Height;
                double x = 50;
                double y = 100;
                double ls = 0;
                double lsH1 = 0;
                double lsH2 = 0;

                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    ls = font.GetHeight(gfx);
                    lsH1 = fontH1.GetHeight(gfx);
                    lsH2 = fontH2.GetHeight(gfx);
                    
                    using (XImage img = XImage.FromFile(Configuration.LogoFile))
                    {
                        
                        double width = img.PixelWidth * 72 / img.HorizontalResolution;
                        double height = img.PixelHeight * 72 / img.VerticalResolution;
                        gfx.DrawImage(img, x, y, width, height);
                        
                        
                        y+= height;
                    }
                    //gfx.DrawImage()
                    gfx.DrawString(Configuration.Current.BusinessName + " Close Day Report", fontH1, XBrushes.Black, x, y);
                    y += lsH1;

                    gfx.DrawString("Station: " + Configuration.Current.StationID, fontH2, XBrushes.Black, x, y);

                    y += lsH2;

                    gfx.DrawString(DateTime.Now.ToString(), fontH2, XBrushes.Black, x, y);

                    y += lsH2 * 2;

                    gfx.DrawString("Starting Cash: " + startCash.ToString("C"), font, XBrushes.Black, x, y);
                    y += ls;

                    gfx.DrawString("Ending Cash: " + ActualEndCash.ToString("C"), font, XBrushes.Black, x, y);
                    y += ls;

                    gfx.DrawString("Expected Cash: " + ExpectedEndCash.ToString("C"), font, XBrushes.Black, x, y);
                    y += ls;

                    gfx.DrawString("Over/Short: " + (ActualEndCash - ExpectedEndCash).ToString("C"), font, XBrushes.Black, x, y);
                    y += ls;

                    gfx.DrawString("Total Cash Sales: " + (ExpectedEndCash - startCash).ToString("C"), font, XBrushes.Black, x, y);
                    y += ls;


                    /*
                     * decimal totalCredit, decimal totalCheck, decimal profitLoss, decimal totalRevenue, 
            int saleCount, int quantityProductSold, decimal amountDiscounted, decimal taxAmount
                     * */

                    gfx.DrawString("Total Credit Sales: " + totalCredit.ToString("C"), font, XBrushes.Black, x, y);
                    y += ls;
                    gfx.DrawString("Total Check Sales: " + totalCheck.ToString("C"), font, XBrushes.Black, x, y);
                    y += ls;



                    gfx.DrawString("Total Revenue: " + totalRevenue.ToString("C"), font, XBrushes.Black, x, y);
                    y += ls;

                    gfx.DrawString("Amount of Discounts granted: " + amountDiscounted.ToString("C"), font, XBrushes.Black, x, y);
                    y += ls;


                    gfx.DrawString("Sales Tax Total: " + taxAmount.ToString("C"), font, XBrushes.Black, x, y);
                    y += ls;


                    gfx.DrawString("Profit/Loss: " + profitLoss.ToString("C"), font, XBrushes.Black, x, y);
                    y += ls;

                    gfx.DrawString("Number of Purchases: " + saleCount.ToString(), font, XBrushes.Black, x, y);
                    y += ls;

                    gfx.DrawString("Count of Products Sold: " + quantityProductSold.ToString(), font, XBrushes.Black, x, y);
                    y += ls;



                }



                int pgNum=2;
                x = 50;
                y = 100;

                itemNumber = 0;

                while (itemNumber < inventoryTransactions.Count)
                {
                    WriteTransactionPage(document.AddPage(), pgNum, inventoryTransactions);
                }

                //itemNumber = 0;

                //while (itemNumber < financials.Count)
                //{
                //    WriteTransactionPage(document.AddPage(), pgNum, inventoryTransactions);
                //}

                document.Save(path);
            }

          

            
        }


        static int itemNumber = 0;

        static void WriteTransactionPage(PdfPage page, int pageNumber, List<InventoryTransactionObject> inventoryTransactions)
        {
            double x = 50;
            double y = 100;
            using (XGraphics gfx = XGraphics.FromPdfPage(page))
            {
                double ls = 0;
                double lsH1 = 0;
                double lsH2 = 0;
                ls = font.GetHeight(gfx);
                lsH1 = fontH1.GetHeight(gfx);
                lsH2 = fontH2.GetHeight(gfx);

                gfx.DrawString(Configuration.Current.BusinessName, fontH1, XBrushes.Black, x, y);
                y += lsH1;

                gfx.DrawString("Activity Report - Inventory", fontH2, XBrushes.Black, x, y);
                y += lsH2;





                gfx.DrawString("Receipt ID\t\t        Time     \t\tProduct ID\t\tSKU\t\tSelling Price\t\tQuantity\t\tAmount", fontBold, XBrushes.Black, x, y); ;
                y += ls;










                while (itemNumber < inventoryTransactions.Count && y < PageLength)
                {
                    InventoryTransactionObject tran = inventoryTransactions[itemNumber];

                    gfx.DrawString(tran.ReceiptID + "\t\t" + tran.TransactionTime.ToString("MM/dd/yyyy hh:mm") + "\t\t" + tran.ProductID.ToString() + "\t\t" + tran.SKU + "\t\t"
                        + tran.SellingPriceEach.ToString("C") + "\t\t" + tran.Quantity.ToString() + "\t\t" + tran.TransactionAmount.ToString("C"), font, XBrushes.Black, x, y); ;
                    y += ls;
                    itemNumber++;
                }

            }

        }

        static void WriteFinancialPage(PdfPage page, int pageNumber, List<FinancialObject> financials)
        {
            double x = 50;
            double y = 100;
            using (XGraphics gfx = XGraphics.FromPdfPage(page))
            {
                double ls = 0;
                double lsH1 = 0;
                double lsH2 = 0;
                ls = font.GetHeight(gfx);
                lsH1 = fontH1.GetHeight(gfx);
                lsH2 = fontH2.GetHeight(gfx);

                gfx.DrawString(Configuration.Current.BusinessName, fontH1, XBrushes.Black, x, y);
                y += lsH1;

                gfx.DrawString("Activity Report - Finances", fontH2, XBrushes.Black, x, y);
                y += lsH2;





                gfx.DrawString("Receipt ID\t\t        Time     \t\tProduct ID\t\tSKU\t\tSelling Price\t\tQuantity\t\tAmount", fontBold, XBrushes.Black, x, y); ;
                y += ls;










                //while (itemNumber < financials.Count && y < PageLength)
                //{
                //    FinancialObject tran = financials[itemNumber];

                //    gfx.DrawString(tran.ReceiptID + "\t" + tran.TransactionDateTime.ToString("MM/dd/yyyy hh:mm") + "\t" + tran..ToString() + "\t" + tran.SKU + "\t"
                //        + tran.SellingPriceEach.ToString("C") + "\t" + tran.Quantity.ToString() + "\t" + tran.TransactionAmount.ToString("C"), font, XBrushes.Black, x, y); ;
                //    y += ls;
                //    itemNumber++;
                //}

            }

        }
    }
}
