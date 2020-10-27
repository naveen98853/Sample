using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            

            for (var i = 0; i < 5; i++)
            {
                var value = i;
                //byte[] doc = File.ReadAllBytes(@"D:\Data\input\15114_0120631064_02.pdf");
                byte[] doc = File.ReadAllBytes(@"C: \Users\782655\OneDrive - Cognizant\Desktop\CLGX - Docs\Veracode\DetailedReport_Tax__Research_Production_Tracking_(RPT)_7_Jul_2020.pdf");
                string tempImageFolder = @"D:\Data\ReadyToShip\";
                string pdfFile = System.IO.Path.GetRandomFileName();
                string tiffFile = System.IO.Path.GetRandomFileName();

                PdfToImage.PDFConvert converter = null;
                File.WriteAllBytes(tempImageFolder + pdfFile, doc);
                converter = new PdfToImage.PDFConvert();

                converter.OutputToMultipleFile = false; //Can use this option to output each page of the PDF to a separate image file
                converter.FirstPageToConvert = -1;
                converter.LastPageToConvert = -1;
                converter.FitPage = false;
                converter.JPEGQuality = 30;
                converter.ResolutionX = 600;
                converter.ResolutionY = 600;
                converter.OutputFormat = "tifflzw";
                //converter.OutputFormat = "png256";


                string inputFile = tempImageFolder + pdfFile;

                string outputFile = tempImageFolder + tiffFile;
                bool Converted = converter.Convert(inputFile, outputFile);

                byte[] imageBytes = File.ReadAllBytes(tempImageFolder + tiffFile);


                var runningTask = Task.Factory.StartNew(() => mlt.Write1(value));
            }
            Console.ReadKey();
        }
    }
}
