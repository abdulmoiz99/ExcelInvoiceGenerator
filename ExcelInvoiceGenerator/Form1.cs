using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelInvoiceGenerator
{
    public partial class Form1 : Form
    {
        double quantity = 0, basePrice = 0, SGST = 0, CGST = 0, IGST = 0, rate = 0, amount = 0, TotalAmount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void cmb_PartyName_Load(object sender, EventArgs e)
        {

            string[] lineOfContents = File.ReadAllLines(Application.StartupPath + "\\PartyDetails.csv");
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(',');
                cmb_PartyName.Items.Add(tokens[1]);
            }
            btn_GenerateInvoice_Click(sender, e);
        }

        private void cmb_PartyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmb_PartyName.SelectedIndex + 1;
            string[] lineOfContents = File.ReadAllLines(Application.StartupPath + "\\PartyDetails.csv");
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(',');
                if (tokens[0] == index.ToString())
                {
                    lab_Address.Text = tokens[2];
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "\\PartyDetails.csv");
        }

        private void btn_GenerateInvoice_Click(object sender, EventArgs e)
        {


            XLWorkbook Workbook = new XLWorkbook(Application.StartupPath + "\\template.xlsx");
            IXLWorksheet Worksheet = Workbook.Worksheet(1);
            Worksheet.Cell("A1").Value = "TAX INVOICE";
            Worksheet.Cell("A2").Value = "Billed From:-";
            Worksheet.Cell("A3").Value = "HUBBERHOLME";
            Worksheet.Cell("A4").Value = "A-13, Lower Ground Foor, Sector 58, Noida 201301";
            Worksheet.Cell("A5").Value = "GSTIN:  09CMFPS6001N2ZM";
            Worksheet.Cell("A6").Value = "PH: 0091-9582796098";
            Worksheet.Cell("A7").Value = "BILL TO:";

            Worksheet.Cell("F2").Value = "INVOICE NO.";
            Worksheet.Cell("F4").Value = "BUYER'S ORDER NO. & DATE:	";
            Worksheet.Cell("F7").Value = "Ship To:-";

            Worksheet.Cell("H4").Value = "PARTY NAME AS PER BOOKS";

            Worksheet.Cell("I2").Value = "Date";
            Worksheet.Cell("I3").Value = dateTimePicker1.Value.ToShortDateString();

            //Invoice table header

            Worksheet.Cell("A15").Value = "SKU		";
            Worksheet.Cell("D15").Value = "QTY";
            Worksheet.Cell("E15").Value = "BASE PRICE";
            Worksheet.Cell("F15").Value = "TOTAL TAXABLE VALUE";
            Worksheet.Cell("G15").Value = "SGST";
            Worksheet.Cell("H15").Value = "CGST";
            Worksheet.Cell("I15").Value = "IGST";
            Worksheet.Cell("J15").Value = "RATE";
            Worksheet.Cell("K15").Value = "AMOUNT";

            int index = cmb_PartyName.SelectedIndex + 1;
            string[] lineOfContents = File.ReadAllLines(@"C:\Users\moiza\Desktop\SKULIST.csv");
            int startIndexForSku = 16;
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(',');
                Worksheet.Cell("A" + startIndexForSku).Value = tokens[0]; //suk
                Worksheet.Cell("D" + startIndexForSku).Value = tokens[1];//quantity
                double.TryParse(tokens[1], out quantity);

                // to merge cell
                var range = Worksheet.Range("A" + startIndexForSku + ":C" + startIndexForSku);
                range.Merge();
                //to set border
                var borderRange = Worksheet.Range("A" + startIndexForSku + ":K" + startIndexForSku);
                borderRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                borderRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                //find sku in the database
                string[] sku = File.ReadAllLines(@"C:\Users\moiza\Desktop\SKUDetails.csv");

                foreach (var item in sku)
                {
                    string[] skus = item.Split(',');
                    if (skus[0] == tokens[0])
                    {
                        double.TryParse(skus[1], out basePrice);
                        double.TryParse(skus[2], out SGST);
                        double.TryParse(skus[3], out CGST);
                        double.TryParse(skus[4], out IGST);
                        double.TryParse(skus[5], out rate);

                        amount = basePrice + SGST + CGST + IGST;
                        TotalAmount += amount * quantity;
                        Worksheet.Cell("E" + startIndexForSku).Value = basePrice; // base price
                        Worksheet.Cell("F" + startIndexForSku).Value = basePrice; // total taxable value
                        Worksheet.Cell("G" + startIndexForSku).Value = SGST; //SGST
                        Worksheet.Cell("H" + startIndexForSku).Value = CGST; //CGST
                        Worksheet.Cell("I" + startIndexForSku).Value = IGST; //IGST
                        Worksheet.Cell("J" + startIndexForSku).Value = rate + "%"; //Rate
                        Worksheet.Cell("J" + startIndexForSku).SetDataType(XLDataType.Number);
                        Worksheet.Cell("J" + startIndexForSku).Style.NumberFormat.Format = "0.00%";
                        Worksheet.Cell("K" + startIndexForSku).Value = amount; //amount

                    }
                }
                startIndexForSku++;
                if (tokens[0] == index.ToString())
                {
                    lab_Address.Text = tokens[2];
                }
            }
            startIndexForSku++;

            // total amount in words
            // to merge cell
            var range1 = Worksheet.Range("D" + startIndexForSku + ":H" + startIndexForSku);
            range1.Merge();
            //to set border
            var borderRange2 = Worksheet.Range("B" + startIndexForSku + ":K" + startIndexForSku);
            borderRange2.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            borderRange2.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            
            string amountInWords = NumberToWords.ConvertAmount(Math.Round(TotalAmount, 0));
            Worksheet.Cell("B" + startIndexForSku).Value = "In Words";
            Worksheet.Cell("D" + startIndexForSku).Value = amountInWords;
            Worksheet.Cell("I" + startIndexForSku).Value = "TOTAL";
            Worksheet.Cell("K" + startIndexForSku).Value = TotalAmount;


            //signature and date
            startIndexForSku++;
            startIndexForSku++;
            Worksheet.Cell("H" + startIndexForSku).Value = "Signature & Date:";
            startIndexForSku++;
            startIndexForSku++;
            startIndexForSku++;
            Worksheet.Cell("H" + startIndexForSku).Value = "\tFOR HUBBERHOLME";


            Workbook.SaveAs(@"C:\Users\moiza\Desktop\file.xlsx");

        }
    }
}
