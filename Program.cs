using iText.Forms;
using iText.Kernel.Pdf;
using System;

namespace QuoteGenerator
{
    class Program
    {
        static string home = "D:\\Workshop\\VB-Projects\\QuoteGenerator\\";
        static void Main(string[] args)
        {
            Console.WriteLine("What is the Source File?");
            string src = Console.ReadLine();

            Console.WriteLine("Okay I'll read in " + src);
            PdfReader reader = new PdfReader(home+src);

            Console.WriteLine("Where do you want me to save it to After?");
            string dest = Console.ReadLine();
            PdfWriter writer = new PdfWriter(home+dest);
            PdfDocument pdfDoc = new PdfDocument(reader, writer);
            var form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            var fields = form.GetFormFields();

            Console.WriteLine("What field would you like to Modify?");
            Console.WriteLine("Options:"+fields.Keys);
            string key = Console.ReadLine();

            Console.WriteLine("What would you like to set it to?");
            string value = Console.ReadLine();
            fields[key].SetValue(value);
            form.FlattenFields();
            pdfDoc.Close();
        }
    }
}
