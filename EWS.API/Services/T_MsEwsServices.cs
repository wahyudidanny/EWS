
using EWS.API.Repositories;
using EWS.API.Requests;
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



        private string GetTitlePdf()
        {
            string htmlcontent = "<div style='margin-top:-27px; padding-top:10px;'>";
            htmlcontent += "<h4 style='text-align:center'><span style='font-family:Arial,Helvetica,sans-serif;font-size:10px'>";
            htmlcontent += "<strong>&nbsp;PERINGATAN DINI - EARLY WARNING SYSTEM - BLOK UN-SATISFACTORY (US) PRODUKSI VS BGT - PT CLP </strong><br>";
            htmlcontent += "<strong>&nbsp;PERIODE DATA SD OKTOBER - TANGGAL 24 NOVEMBER 2023 </strong>";
            htmlcontent += "</span></h4>";
            htmlcontent += "<div>";
            return htmlcontent;
        }

        private string GetHeaderPdf()
        {

            string htmlcontent = "<div style='margin-top:-25px;padding-top:10px;'>";
            htmlcontent += "<table style='border: 0.75px solid black; border-collapse: collapse; width: 90%;margin-left:25px;'>";

            for (int i = 0; i < 3; i++)
            {
                htmlcontent += "<tr>";
                for (int j = 0; j < 7; j++)
                {
                    // var tdWidthPercentage = 100 / 7;
                    string cellColor = GetCellColor(j);
                    htmlcontent += "<td style='text-align:left; padding: 0.5px; background-color: " + cellColor + ";'>";
                    htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 9px;'>Cell 1</span>";
                    htmlcontent += "</td>";
                }
                htmlcontent += "</tr>";
            }

            htmlcontent += "</table>";
            htmlcontent += "</div>";


            htmlcontent += "<br>";
            return htmlcontent;
        }

        private string GetValuePdf(List<T_MsEwsRequests> responsePdf)
        {


            string htmlcontent = "";

            // for (int i = 1; i <= responsePdf.Count(); i++) // rows
            // {
            // htmlcontent += "<tr>";
            // htmlcontent += "<td style='border: 1px solid black;width:100px;'>" + "Header" + "</td>";

            // for (int j = 0; j < 11; j++)
            // {
            //     string cellColor = GetCellColor(j);
            //     htmlcontent += "<td style='width:30px; text-align: left; padding: 2px; background-color: " + cellColor + "; border: 1px solid black;'>";
            //     htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 9px;'>Cell " + + "</span>";
            //     htmlcontent += "</td>";
            // }


            // htmlcontent += "</tr>";

            //}





            //for each
            // foreach (T_MsEwsRequests contentList in responsePdf)
            // {
            //     htmlcontent += "<tr>";
            //     htmlcontent += "<td style='border: 1px solid black;width:100px;'>" + "Header" + "</td>";
            //     foreach (var property in contentList.GetType().GetProperties())
            //     {

            //         htmlcontent += "<td style='width:30px; text-align: left; padding: 2px; border: 1px solid black;'>";
            //         htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 9px;'>" + property.GetValue(contentList) + "</span>";
            //         htmlcontent += "</td>";
            //     }
            //     htmlcontent += "</tr>";
            // }
            //end for each
            for (int i = 0; i < responsePdf.Count; i++)
            {
                var contentList = responsePdf[i];
                var properties = contentList.GetType().GetProperties();

                htmlcontent += "<tr>";
                htmlcontent += "<td style='text-align: left; border: 1px solid black;width:100px;font-size: 9px;'>" + properties[0].GetValue(contentList) + "</td>";


                for (int j = 1; j < properties.Length; j++)
                {

                    if (properties[0].GetValue(contentList).ToString().Contains("Achv"))
                    {
                        htmlcontent += "<td style='width:25px;padding: 2px; border: 1px solid black; background-color: red;'>";
                        htmlcontent += "<span style='color:white;font-family: Arial, Helvetica, sans-serif; font-weight: bold;font-size: 9px;'>" + properties[j].GetValue(contentList) + "</span>";
                        htmlcontent += "</td>";
                    }
                    else
                    {
                        htmlcontent += "<td style='width:25px; padding: 2px; border: 1px solid black;'>";
                        htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif;font-size: 9px; font-weight: bold;'>" + properties[j].GetValue(contentList) + "</span>";
                        htmlcontent += "</td>";
                    }

                }

                htmlcontent += "</tr>";
            }

            return htmlcontent;


        }

        private string GetBodyPdf(List<T_MsEwsRequests> responsePdf)
        {

            string htmlcontent = "<div style='text-align: center;'>";

            htmlcontent += "<table style='border: 0.75px solid black; border-collapse: collapse; width: 90%;margin-left:25px;'>";

            for (int i = 1; i <= 3; i++)
            {
                htmlcontent += "<tr>";

                if (i == 1)
                {
                    htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black; border-collapse: collapse;width:100px; ' rowspan='3'>Merge cell</td>";
                }

                if (i == 3)
                {
                    htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black; border-collapse: collapse;width:30px;'>Header</td>";
                    htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black; border-collapse: collapse;background-color:#DEDEDE;' colspan='10'></td>";
                }
                else
                {
                    for (int j = 0; j < 11; j++)
                    {
                        string cellColor = GetCellColor(j);
                        htmlcontent += "<td style='padding: 0; margin: 0; width:30px; text-align: left; padding: 2px; background-color: " + cellColor + "; border: 1px solid black;'>";
                        htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 9px;'>Cell " + (j + 1) + "</span>";
                        htmlcontent += "</td>";
                    }
                }
                htmlcontent += "</tr>";
            }
            htmlcontent += GetValuePdf(responsePdf);
            htmlcontent += "</table>";
            htmlcontent += "</div>";
            return htmlcontent;
        }

        public async Task<byte[]> GenerateContentPdf()
        {

            var chartRotasiSensus = await _msEwsRepository.GetContentPdf();

            var responsePdf = chartRotasiSensus
             .Select(g => new T_MsEwsRequests
             {
                 Header = g.Header,
                 Satuan = g.Satuan,
                 T1 = g.T1,
                 T2 = g.T2,
                 T3 = g.T3,
                 T4 = g.T4,
                 T5 = g.T5,
                 T6 = g.T6,
                 T7 = g.T7,
                 T8 = g.T8,
                 T9 = g.T9,
                 T10 = g.T10
             }).ToList();

            byte[] response;
            var document = new PdfDocument();
            string htmlcontent = "";

            htmlcontent += GetTitlePdf();

            //1 loop disini
            htmlcontent += GetHeaderPdf();

            for (int i = 0; i < 1; i++)
            {
                htmlcontent += GetBodyPdf(responsePdf);
                htmlcontent += "<br>";
            }

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