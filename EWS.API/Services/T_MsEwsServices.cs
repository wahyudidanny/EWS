
using EWS.API.Repositories;
using EWS.API.Responses;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using Microsoft.AspNetCore.Mvc;

namespace EWS.API.Services
{
    public class T_MsEwsServices
    {
        private readonly T_MsEwsRepository _msEwsRepository;
        public T_MsEwsServices(T_MsEwsRepository msEwsRepository)
        {
            _msEwsRepository = msEwsRepository;
        }


        private string GetCellColor(int columnIndex)
        {
            switch (columnIndex)
            {
                case 1:
                    return "blue";
                case 2:
                    return "green";
                case 3:
                    return "yellow";
                case 4:
                    return "red";
                case 5:
                    return "grey";
                default:
                    return "transparent"; // Default color or adjust as needed
            }
        }


        private string GetHeaderPdf()
        {

            string htmlcontent = "<div style='text-align: center;'>";

            htmlcontent += "<table style='border: 1px solid black; border-collapse: collapse; width: 100%;margin: auto;'>";

            for (int i = 0; i < 3; i++)
            {
                htmlcontent += "<tr>";

                for (int j = 0; j < 7; j++)
                {
                    var tdWidthPercentage = 100 / 7;
                    string cellColor = GetCellColor(j);
                    htmlcontent += "<td style='width: " + tdWidthPercentage + "%; text-align: left; padding: 2px; background-color: " + cellColor + ";'>";
                    htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 11px;'>Cell 1</span>";
                    htmlcontent += "</td>";
                }

                htmlcontent += "</tr>";

            }

            htmlcontent += "</table>";
            htmlcontent += "</div>";

            return htmlcontent;
        }


        private string GetBodyPdf()
        {

            string htmlcontent = "<div style='text-align: center;'>";

            htmlcontent += "<table style='border: 1px solid black; border-collapse: collapse; width: 100%; margin: auto;'>";

            // Merged cells for the first two columns in the first row
            htmlcontent += "<tr>";
            htmlcontent += "<td style='width: " + (100 / 11 * 2) + "%; text-align: left; padding: 2px; border: 1px solid black;' rowspan='3'>";
            htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 12px;'>Merged Cells 1-2</span>";
            htmlcontent += "</td>";

            // Remaining columns in the first row
            for (int j = 2; j < 11; j++)
            {
                var tdWidthPercentage = 100 / 11;

                string cellColor = GetCellColor(j);

                htmlcontent += "<td style='width: " + tdWidthPercentage + "%; text-align: left; padding: 2px; background-color: " + cellColor + "; border: 1px solid black;'>";
                htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 12px;'>Cell " + (j + 1) + "</span>";
                htmlcontent += "</td>";
            }

            htmlcontent += "</tr>";

            // Additional rows
            for (int i = 1; i < 3; i++)
            {
                htmlcontent += "<tr>";

                // Remaining columns
                for (int j = 0; j < 11; j++)
                {
                    var tdWidthPercentage = 100 / 11;

                    string cellColor = GetCellColor(j);

                    htmlcontent += "<td style='width: " + tdWidthPercentage + "%; text-align: left; padding: 2px; background-color: " + cellColor + "; border: 1px solid black;'>";
                    htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 12px;'>Cell " + (j + 1) + "</span>";
                    htmlcontent += "</td>";
                }

                htmlcontent += "</tr>";
            }

            htmlcontent += "</table>";
            htmlcontent += "</div>";

            return htmlcontent;
        }




        public byte[] GeneratePdfContent()
        {
            byte[] response;

            var document = new PdfDocument();

            string htmlcontent = "<div style='width:100%; text-align:center'>";
            htmlcontent += "<h4 style='text-align:center'><span style='font-family:Arial,Helvetica,sans-serif'><span style='font-size:9px'><strong>&nbsp;PERINGATAN DINI - EARLY WARNING SYSTEM - BLOK UN-SATISFACTORY (US) PRODUKSI VS BGT - PT CLP </strong></span></span></h4>";
            htmlcontent += "<h4 style='text-align:center'><span style='font-family:Arial,Helvetica,sans-serif'><span style='font-size:9px'><strong>PERIODE DATA SD OKTOBER - TANGGAL 24 NOVEMBER 2023</strong></span></span></h4>";

            htmlcontent += GetHeaderPdf();
            htmlcontent += "<br>";
            htmlcontent += GetBodyPdf();

            htmlcontent += "</div>";

            PdfGenerator.AddPdfPages(document, htmlcontent, PageSize.A4);

            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }

            return response;

        }

    }
}