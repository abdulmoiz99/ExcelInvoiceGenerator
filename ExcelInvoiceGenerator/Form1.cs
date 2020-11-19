using ClosedXML.Excel;
using Microsoft.VisualBasic.FileIO;
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
        int counter;
        string password = "P123";
        string[] skuList;
        List<string> unavailableSKU = new List<string>();
        List<HSNData> hsnDataList = new List<HSNData>();
        List<double> taxRate = new List<double>();

        class HSNData
        {
            public string HSN;
            public double totalTaxValue;
            public double quantity;
            public double rate;
        };

        public Form1()
        {
            InitializeComponent();
        }

        private List<string> FindNewSKU()
        {
            List<string> orderedSKU = new List<string>();
            List<string> availableSKU = new List<string>();
            List<string> newSKU = new List<string>();
            string[] skuDetails = File.ReadAllLines(Application.StartupPath + "\\SKUDetails.csv");
            for (int i = 0; i < skuList.Length; i++) 
            {
                orderedSKU.Add(skuList[i].Split(',')[0]);
            }
            for (int i = 1; i < skuDetails.Length; i++)
            {
                availableSKU.Add(skuDetails[i].Split(',')[0]);
            }
            orderedSKU = orderedSKU.Distinct().ToList();
            foreach (string SKU in orderedSKU) 
            {
                if (!availableSKU.Contains(SKU)) 
                {
                    newSKU.Add(SKU);
                }
            }
            return newSKU;
        }

        private void cmb_PartyName_Load(object sender, EventArgs e)
        {
            counter = Convert.ToInt32(File.ReadAllText(Application.StartupPath + "\\config.dat"));
            string[] lineOfContents = File.ReadAllLines(Application.StartupPath + "\\PartyDetails.csv");
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(',');
                cmb_PartyName.Items.Add(tokens[1]);
            }
            lab_CurrentInvoice.Text = " Current Invoice No: " + counter.ToString();
            //btn_GenerateInvoice_Click(sender, e);
        }

        private void cmb_PartyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmb_PartyName.SelectedIndex + 1;
            string[] lineOfContents = File.ReadAllLines(Application.StartupPath + "\\PartyDetails.csv");
            foreach (var line in lineOfContents)
            {
                string[] tokens = CSVParser(line);
                if (tokens[0] == index.ToString())
                {
                    lab_Address.Text = tokens[2] + "\n" + tokens[3] + "\n" + tokens[4] + "\n" + tokens[5] + "\n" + tokens[6] + "\n" + tokens[7] + "\n" + tokens[8];
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "\\PartyDetails.csv");
        }

        private void btn_GenerateInvoice_Click(object sender, EventArgs e)
        {
            if (skuList == null) 
            {
                MessageBox.Show("Please upload the SKU list first!", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            unavailableSKU.Clear();
            hsnDataList.Clear();
            double quantity = 0, basePrice = 0, SGST = 0, CGST = 0, IGST = 0, rate = 0, amount = 0, TotalAmount = 0;
            string HSN = String.Empty, invoiceNo = String.Empty;
            XLWorkbook Workbook = new XLWorkbook(Application.StartupPath + "\\template.xlsx");
            IXLWorksheet Worksheet = Workbook.Worksheet(1);
            Worksheet.Cell("A1").Value = "TAX INVOICE";
            Worksheet.Cell("A2").Value = "Billed From:-";
            try
            {
                string[] billFrom = File.ReadAllLines(Application.StartupPath + "\\Setup\\billFrom.txt");
                Worksheet.Cell("A3").Value = billFrom[0];
                Worksheet.Cell("A4").Value = billFrom[1];
                Worksheet.Cell("A5").Value = billFrom[2];
                Worksheet.Cell("A6").Value = billFrom[3];
                Worksheet.Cell("F3").Value = invoiceNo = billFrom[4] + counter;
            }
            catch (Exception)
            {
                MessageBox.Show("billFrom: No such file in directory or the data is missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                Worksheet.Cell("A7").Value = "BILL TO:";
                string[] parties = File.ReadAllLines(Application.StartupPath + "\\PartyDetails.csv");
                foreach (string line in parties) 
                {
                    string[] tokens = CSVParser(line);
                    if (tokens[1] == cmb_PartyName.Text) 
                    {
                        Worksheet.Cell("I5").Value = tokens[1];
                        Worksheet.Cell("A8").Value = tokens[2];
                        Worksheet.Cell("A9").Value = tokens[3];
                        Worksheet.Cell("A10").Value = tokens[4];
                        Worksheet.Cell("A11").Value = tokens[5];
                        Worksheet.Cell("A12").Value = tokens[6];
                        Worksheet.Cell("A13").Value = tokens[7];
                        Worksheet.Cell("A14").Value = tokens[8];

                        Worksheet.Cell("F8").Value = tokens[2];
                        Worksheet.Cell("F9").Value = tokens[3];
                        Worksheet.Cell("F10").Value = tokens[4];
                        Worksheet.Cell("F11").Value = tokens[5];
                        Worksheet.Cell("F12").Value = tokens[6];
                        Worksheet.Cell("F13").Value = tokens[7];
                        Worksheet.Cell("F14").Value = tokens[8];
                        break;
                    }
                }

                Worksheet.Cell("F2").Value = "INVOICE NO.";
                Worksheet.Cell("F4").Value = "BUYER'S ORDER NO. & DATE:	";
                Worksheet.Cell("F7").Value = "Ship To:-";

                Worksheet.Cell("I4").Value = "PARTY NAME AS PER BOOKS";

                Worksheet.Cell("I2").Value = "Date";
                Worksheet.Cell("I3").Value = dateTimePicker1.Value.ToShortDateString();

                //Invoice table header

                Worksheet.Cell("A15").Value = "SKU";
                Worksheet.Cell("D15").Value = "QTY";
                Worksheet.Cell("E15").Value = "BASE PRICE";
                Worksheet.Cell("F15").Value = "TOTAL TAXABLE VALUE";
                Worksheet.Cell("G15").Value = "SGST";
                Worksheet.Cell("H15").Value = "CGST";
                Worksheet.Cell("I15").Value = "IGST";
                Worksheet.Cell("J15").Value = "RATE";
                Worksheet.Cell("K15").Value = "AMOUNT";
                Worksheet.Cell("L15").Value = "HSN";
                int index = cmb_PartyName.SelectedIndex + 1;
                //string[] lineOfContents = File.ReadAllLines(@"C:\Users\moiza\Desktop\SKULIST.csv"); //Moiz Address
                //string[] lineOfContents = File.ReadAllLines(Application.StartupPath + "\\SKULIST.csv"); //Naqqash Address
                IDictionary<string, int> skuQty = new Dictionary<string, int>();
                for (int i = 0; i < skuList.Length; i++) 
                {
                    var record = skuList[i];
                    if (record == null) continue;
                    var values = record.Split(',');
                    if (!skuQty.ContainsKey(values[0]))
                    {
                        skuQty.Add(values[0], Convert.ToInt32(values[1]));
                    }
                    else
                    {
                        skuQty[values[0]] += Convert.ToInt32(values[1]);
                    }
                }
                int startIndexForSku = 16;
                string[] sku = File.ReadAllLines(Application.StartupPath + "\\SKUDetails.csv");
                foreach (KeyValuePair<string, int> entry in skuQty)
                {
                    //find sku in the database
                    //string[] sku = File.ReadAllLines(@"C:\Users\moiza\Desktop\SKUDetails.csv"); //Moiz Address
                     //Naqqash Address

                    foreach (var item in sku)
                    {
                        string[] skus = item.Split(',');
                        if (skus[0] == entry.Key)
                        {
                            Worksheet.Cell("A" + startIndexForSku).Value = entry.Key; //suk
                            Worksheet.Cell("D" + startIndexForSku).Value = entry.Value;//quantity
                            double.TryParse(entry.Value.ToString(), out quantity);

                            // to merge cell
                            var range = Worksheet.Range("A" + startIndexForSku + ":C" + startIndexForSku);
                            range.Merge();
                            //to set border
                            var borderRange = Worksheet.Range("A" + startIndexForSku + ":K" + startIndexForSku);
                            borderRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                            borderRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                            double.TryParse(skus[1], out basePrice);
                            double.TryParse(skus[2], out rate);
                            HSN = skus[3];

                            if (rb_sameState.Checked)
                            {
                                SGST = CGST = basePrice * rate / 200;
                            }
                            else 
                            {
                                IGST = basePrice * rate/100;
                            }

                            bool newHSN = true;
                            foreach (HSNData hsn in hsnDataList) 
                            {
                                if (hsn.HSN == HSN && hsn.rate == rate) //Debug required if any issue occurs in future.
                                {
                                    newHSN = false;
                                    hsn.quantity += quantity;
                                    hsn.totalTaxValue += (basePrice * quantity);
                                    break;
                                }
                            }
                            if (newHSN) 
                            {
                                HSNData data = new HSNData();
                                data.HSN = HSN;
                                data.rate = rate;
                                data.totalTaxValue = (basePrice * quantity);
                                data.quantity = quantity;
                                hsnDataList.Add(data);
                            }

                            taxRate = hsnDataList.Select(p=>p.rate).Distinct().ToList();

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
                            Worksheet.Cell("L" + startIndexForSku).Value = HSN; //HSN
                            startIndexForSku++;
                            break;
                        }
                        else 
                        {

                            
                        }

                    }

                    //if (tokens[0] == index.ToString())
                    //{
                    //    lab_Address.Text = tokens[2];

                    //}
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

                startIndexForSku++;
                startIndexForSku++;

                Worksheet.Cell("B" + startIndexForSku).Value = "Tax Rate";
                Worksheet.Cell("C" + startIndexForSku).Value = "Total Quantity";
                Worksheet.Cell("D" + startIndexForSku).Value = "Taxable Value";
                Worksheet.Cell("E" + startIndexForSku).Value = "CGST";
                Worksheet.Cell("F" + startIndexForSku).Value = "SGST";
                Worksheet.Cell("G" + startIndexForSku).Value = "IGST";
                Worksheet.Cell("H" + startIndexForSku).Value = "Total Tax Amount";
                Worksheet.Cell("I" + startIndexForSku).Value = "Total Invoice Amount";

                double t_qty = 0;
                double t_taxValue = 0;
                double t_sgst = 0;
                double t_cgst = 0;
                double t_igst = 0;
                double t_total = 0;
                double t_invoiceAmount = 0;

                foreach (double tax in taxRate)
                {
                    double qty = 0;
                    double taxValue = 0;
                    double sgst = 0;
                    double cgst = 0;
                    double igst = 0;

                    foreach (HSNData hsnItem in hsnDataList)
                    {
                        if (hsnItem.rate == tax) 
                        {
                            qty += hsnItem.quantity;                           
                            taxValue += hsnItem.totalTaxValue;
                        }
                    }

                    if (rb_sameState.Checked)
                    {
                        sgst = cgst = taxValue * tax / 200;
                    }
                    else
                    {
                        igst = taxValue * tax / 100;
                    }

                    double total = igst + cgst + sgst;

                    startIndexForSku++;

                    t_qty += qty;
                    t_taxValue += taxValue;
                    t_sgst += sgst;
                    t_cgst += cgst;
                    t_igst += igst;
                    t_total += total;
                    t_invoiceAmount += total + taxValue;

                    Worksheet.Cell("B" + startIndexForSku).Value = tax;
                    Worksheet.Cell("C" + startIndexForSku).Value = qty;
                    Worksheet.Cell("D" + startIndexForSku).Value = taxValue;
                    Worksheet.Cell("E" + startIndexForSku).Value = cgst;
                    Worksheet.Cell("F" + startIndexForSku).Value = sgst;
                    Worksheet.Cell("G" + startIndexForSku).Value = igst;
                    Worksheet.Cell("H" + startIndexForSku).Value = total;
                    Worksheet.Cell("I" + startIndexForSku).Value = total + taxValue;
                }

                startIndexForSku++;

                Worksheet.Cell("B" + startIndexForSku).Value = "Total";
                Worksheet.Cell("C" + startIndexForSku).Value = t_qty;
                Worksheet.Cell("D" + startIndexForSku).Value = t_taxValue;
                Worksheet.Cell("E" + startIndexForSku).Value = t_cgst;
                Worksheet.Cell("F" + startIndexForSku).Value = t_sgst;
                Worksheet.Cell("G" + startIndexForSku).Value = t_igst;
                Worksheet.Cell("H" + startIndexForSku).Value = t_total;
                Worksheet.Cell("I" + startIndexForSku).Value = t_invoiceAmount;

                startIndexForSku++;
                startIndexForSku++;

                Worksheet.Cell("B" + startIndexForSku).Value = "DATE";
                Worksheet.Cell("C" + startIndexForSku).Value = "INVOICE NO";
                Worksheet.Cell("D" + startIndexForSku).Value = "PO NO";
                Worksheet.Cell("E" + startIndexForSku).Value = "PARTY";
                Worksheet.Cell("F" + startIndexForSku).Value = "HSN";
                Worksheet.Cell("G" + startIndexForSku).Value = "Tax";
                Worksheet.Cell("H" + startIndexForSku).Value = "Qty";
                Worksheet.Cell("I" + startIndexForSku).Value = "Total Taxable Value";
                Worksheet.Cell("J" + startIndexForSku).Value = "Total Tax";
                Worksheet.Cell("K" + startIndexForSku).Value = "Final";

                foreach (HSNData hsnItem in hsnDataList) 
                {
                    startIndexForSku++;

                    Worksheet.Cell("B" + startIndexForSku).Value = dateTimePicker1.Value.ToShortDateString();
                    Worksheet.Cell("C" + startIndexForSku).Value = invoiceNo;
                    Worksheet.Cell("D" + startIndexForSku).Value = txt_OrderNo.Text;
                    Worksheet.Cell("E" + startIndexForSku).Value = cmb_PartyName.Text;
                    Worksheet.Cell("F" + startIndexForSku).Value = hsnItem.HSN;
                    Worksheet.Cell("G" + startIndexForSku).Value = hsnItem.rate;
                    Worksheet.Cell("H" + startIndexForSku).Value = hsnItem.quantity;
                    Worksheet.Cell("I" + startIndexForSku).Value = hsnItem.totalTaxValue;
                    Worksheet.Cell("J" + startIndexForSku).Value = (hsnItem.totalTaxValue * hsnItem.rate)/100;
                    Worksheet.Cell("K" + startIndexForSku).Value = (hsnItem.totalTaxValue  * hsnItem.rate / 100) + (hsnItem.totalTaxValue);
                }

                //Workbook.SaveAs(@"C:\Users\moiza\Desktop\file.xlsx"); //Moiz Address
                Workbook.SaveAs(Application.StartupPath + @"\file.xlsx"); //Moiz Address
                //SaveFileDialog saveFileDialog1 = new SaveFileDialog();    
                //saveFileDialog1.Title = "Save Invoice";
                //saveFileDialog1.CheckPathExists = true;
                //saveFileDialog1.DefaultExt = "xlsx";
                //saveFileDialog1.Filter = "Excel (*.xlsx)|*.xlsx"; ;
                //saveFileDialog1.RestoreDirectory = true;
                //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                //{
                //    Workbook.SaveAs(saveFileDialog1.FileName);
                //}
                //Naqqash Address
                unavailableSKU = FindNewSKU();

                counter++;
                lab_CurrentInvoice.Text = " Current Invoice No: " + counter.ToString(); 
                using (StreamWriter sw = new StreamWriter(Application.StartupPath + "\\config.dat", false))
                {
                    sw.Write(counter);
                }
                if (unavailableSKU.Count > 0) 
                {
                    lab_notFound.Text = unavailableSKU.Count + " items not found. [Download Log]";
                    lab_notFound.Visible = true;
                }
            }
        }
        
        private string[] CSVParser(string csvLine) 
        {
            TextFieldParser parser = new TextFieldParser(new StringReader(csvLine));

            // You can also read from a file
            // TextFieldParser parser = new TextFieldParser("mycsvfile.csv");

            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");

            string[] fields = new string[7];

            while (!parser.EndOfData)
            {
               fields = parser.ReadFields();
            }

            parser.Close();
            return fields;
        }

        private void lab_notFound_Click(object sender, EventArgs e)
        {
            lab_notFound.Visible = false;
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Text files (.txt)|.txt";
            saveDlg.FilterIndex = 0;
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "Save Log";

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveDlg.FileName, true))
                {
                    foreach (string sku in unavailableSKU) 
                    {
                        sw.WriteLine(sku);
                    }
                }
            }

        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            resetPanel.Visible = true;
            btn_Reset.Visible = false;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (password == txt_Password.Text)
            {
                string[] billFrom = File.ReadAllLines(Application.StartupPath + "\\Setup\\billFrom.txt");
                billFrom[4] = txt_Prefix.Text;
                using (StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Setup\\billFrom.txt", false))
                {
                    for (int i = 0; i < billFrom.Length; i++)
                    {
                        sw.WriteLine(billFrom[i]);
                    }
                }
                counter = 0;
                lab_CurrentInvoice.Text = " Current Invoice No: " + counter.ToString();
                using (StreamWriter sw = new StreamWriter(Application.StartupPath + "\\config.dat", false))
                {
                    sw.Write(counter);
                }
                MessageBox.Show("Invoice number reset successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Invalid Password!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txt_Password.Clear();
            txt_Prefix.Clear();
            resetPanel.Visible = false;
            btn_Reset.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void btn_UploadSKU_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "";
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Open CSV File";
                dialog.Filter = "CSV Files (*.csv)|*.csv";
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filename = dialog.FileName;
                }
                else
                {
                    return;
                }
                skuList = File.ReadAllLines(filename);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
