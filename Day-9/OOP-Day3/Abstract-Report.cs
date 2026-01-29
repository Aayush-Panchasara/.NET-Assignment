using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Day3
{
    public abstract class ReportGenerator
    {
        public abstract void GenerateReport();
    }

    public class PDFReport : ReportGenerator
    {
        public override void GenerateReport()
        {
            Console.WriteLine("PDF Report is generated...");
        }
    }
    public class ExcelReport : ReportGenerator
    {
        public override void GenerateReport()
        {
            Console.WriteLine("Excel Report is generated...");
        }
    }
    internal class Abstract_Report
    {
        public static void Main()
        {
            PDFReport pdfReport = new PDFReport();
            pdfReport.GenerateReport();

            ExcelReport excelReport = new ExcelReport(); 
            excelReport.GenerateReport();
        }
    }
}
