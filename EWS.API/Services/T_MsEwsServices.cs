
using EWS.API.Repositories;
using EWS.API.Requests;
using EWS.API.Entities;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using System.Text.RegularExpressions;

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


        static string RemoveIntegerAndDot(string input)
        {
            // Use regular expression to match the pattern "digit(dot)"
            string pattern = @"^\d+\.\s*";
            string result = Regex.Replace(input, pattern, "");

            return result;
        }



        private string GetValuePdf(IEnumerable<T_MsEwsRequests> responsePdf)
        {

            string htmlcontent = "";

            for (int i = 0; i < responsePdf.Count(); i++)
            {
                var contentList = responsePdf.ElementAt(i);
                var properties = contentList.GetType().GetProperties();

                htmlcontent += "<tr>";
                htmlcontent += "<td style='text-align: left;height: 12.5px; border: 1px solid black;width:100px;'>";
                htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif; font-weight: bold;font-size: 10px;'>" + RemoveIntegerAndDot(properties[0].GetValue(contentList).ToString()) + "</span>";
                htmlcontent += "</td>";

                for (int j = 1; j < properties.Length; j++)
                {

                    if (properties[0].GetValue(contentList).ToString().Contains("Achv"))
                    {

                        htmlcontent += "<td style='width:25px;height: 12.5px;padding: 2px; border: 1px solid black; background-color: red;'>";
                        htmlcontent += "<span style='color:white;font-weight: bold;font-family: Arial, Helvetica, sans-serif; font-size: 11px;'>" + properties[j].GetValue(contentList) + "</span>";
                        htmlcontent += "</td>";

                    }
                    else
                    {

                        htmlcontent += "<td style='width:25px;height: 12.5px; padding: 2px; border: 1px solid black;'>";
                        htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif;font-size: 11px;'>" + properties[j].GetValue(contentList) + "</span>";
                        htmlcontent += "</td>";

                    }

                }

                htmlcontent += "</tr>";
            }

            return htmlcontent;

        }

        private string GetBodyPdf(IEnumerable<T_MsEws> chartRotasiSensus)
        {

            var responsePdfBlok = chartRotasiSensus.Where(g => g.Header.Contains("Blok")).Select(g => MapToT_MsEwsBlokRequests(g)).ToList();

            var responsePdfBody = chartRotasiSensus.Where(g => !g.Header.Contains("Blok")).Select(g => MapToT_MsEwsRequests(g)).ToList();

            string htmlcontent = "<div style='text-align: center;'>";

            htmlcontent += "<table style='border: 0.75px solid black; border-collapse: collapse; width: 90%;margin-left:25px;'>";

            for (int i = 1; i <= 3; i++)
            {

                htmlcontent += "<tr>";

                if (i == 1)
                {

                    htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;width:100px;background-color:#00695C;' rowspan='3'>";
                    htmlcontent += "<span style='color:white;font-family: Arial, Helvetica, sans-serif; font-weight: bold;font-size: 10px;'>Uraian</span>";
                    htmlcontent += "</td>";

                }

                if (i == 3)
                {

                    htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;width:30px;background-color:#00695C'>";
                    htmlcontent += "<span style='color:white;font-family: Arial, Helvetica, sans-serif; font-weight: bold;font-size: 10px;'>Stn</span>";
                    htmlcontent += "</td>";
                    htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;' colspan='10'></td>";

                }
                else
                {

                    if (i == 1)
                    {

                        htmlcontent += "<td style='padding: 0; margin: 0; width:30px;height: 12.5px padding: 2px;background-color:#00695C; border: 1px solid black;'>";
                        htmlcontent += "<span style='color:white;font-family: Arial, Helvetica, sans-serif; font-weight: bold;font-size: 10px;'>Blok :</span>";
                        htmlcontent += "</td>";

                        Type type = responsePdfBlok[0].GetType();

                        foreach (var property in type.GetProperties())
                        {


                            htmlcontent += "<td style='padding: 0; margin: 0; width:30px;height: 12.5px padding: 2px;border: 1px solid black; background-color: red;'>";
                            htmlcontent += "<span style='color:white;font-family: Arial, Helvetica, sans-serif; font-weight: bold;font-size: 10px;'>" + property.GetValue(responsePdfBlok[0]) + "</span>";
                            htmlcontent += "</td>";

                        }


                    }
                    else
                    {

                        htmlcontent += "<td style='padding: 0; margin: 0; width:30px;height: 12.5px padding: 2px;background-color:#00695C; border: 1px solid black;'>";
                        htmlcontent += "<span style='color:white;font-family: Arial, Helvetica, sans-serif; font-weight: bold;font-size: 10px;'>Rank :</span>";
                        htmlcontent += "</td>";

                        for (int j = 0; j < 10; j++)
                        {

                            htmlcontent += "<td style='padding: 0; margin: 0; width:30px;height: 12.5px padding: 2px;border: 1px solid black; background-color: red;'>";
                            htmlcontent += "<span style='color:white;font-family: Arial, Helvetica, sans-serif; font-weight: bold;font-size: 10px;'>" + (j + 1) + "</span>";
                            htmlcontent += "</td>";

                        }

                    }

                }

                htmlcontent += "</tr>";
            }

            htmlcontent += GetValuePdf(responsePdfBody);
            htmlcontent += "</table>";
            htmlcontent += "</div>";
            return htmlcontent;

        }


        T_MsEwsRequests MapToT_MsEwsRequests(T_MsEws g)
        {

            return new T_MsEwsRequests
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
            };

        }


        T_MsEwsBlokRequests MapToT_MsEwsBlokRequests(T_MsEws g)
        {

            return new T_MsEwsBlokRequests
            {
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
            };

        }


        public async Task<byte[]?> GenerateContentPdf()
        {

            var document = new PdfDocument();

            var chartRotasiSensus = await _msEwsRepository.GetContentPdf();

            if (chartRotasiSensus == null)
            {

                return null;

            }
            else
            {

                string htmlcontent = GetTitlePdf();
                htmlcontent += GetHeaderPdf();


                int batchSize = 10;

                // Loop through the data in batches
                for (int batchIndex = 0; batchIndex < 3; batchIndex++)
                {
                    // Determine the range for the current batch

                    var currentBatch = chartRotasiSensus
                                    .Skip(batchIndex * batchSize)
                                    .Take(batchSize)
                                    .ToList();
                                    
                }



                // int batchSize = 10;
                // int numberOfBatches = 3;

                // for (int batchIndex = 0; batchIndex < numberOfBatches; batchIndex++)
                // {
                //         int startIndex = batchIndex * batchSize;

                //         for (int i = startIndex; i < startIndex + batchSize && i < chartRotasiSensus.Count(); i++)
                //         {
                //             // var currentItem = chartRotasiSensus();

                //                      htmlcontent += GetBodyPdf(chartRotasiSensus);
                //                      htmlcontent += "<br>";

                //         }

                // }


                // for (int i = 0; i < chartRotasiSensus.Count(); i += batchSize) {

                //     var currentBatch = chartRotasiSensus.Skip(i).Take(batchSize);

                //     foreach (var item in currentBatch) {

                //         htmlcontent += GetBodyPdf(chartRotasiSensus);
                //         htmlcontent += "<br>";
                //     }

                // }

                // for (int i = 0; i < 1; i++) {
                // htmlcontent += GetBodyPdf(chartRotasiSensus);
                // htmlcontent += "<br>";
                // }

                PdfGenerator.AddPdfPages(document, htmlcontent, PageSize.A4);

                using (MemoryStream ms = new MemoryStream())
                {

                    document.Save(ms);
                    byte[] response = ms.ToArray();
                    return response;

                }

            }

        }

    }
}