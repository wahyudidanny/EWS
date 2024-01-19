
    using EWS.API.Repositories;
    using EWS.API.Requests;
    using EWS.API.Entities;
    using Microsoft.Extensions.Options;
    using PdfSharpCore;
    using PdfSharpCore.Pdf;
    using TheArtOfDev.HtmlRenderer.PdfSharp;
    using System.Text.RegularExpressions;
    using System.Reflection;



    namespace EWS.API.Services
    {
        public class T_MsEwsServices
        {
            private readonly T_MsEwsRepository _msEwsRepository;
            private static AppSettings _appSettings;
            public T_MsEwsServices(T_MsEwsRepository msEwsRepository, IOptions<AppSettings> appSettings)
            {
                _msEwsRepository = msEwsRepository;
                _appSettings = appSettings.Value;
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
                        return "transparent";
                }
            }

            private string GetTitlePdf(string company, string location)
            {

                var msBusinessUnit = _msEwsRepository.GetDescriptionCompanyLocation(company, location);
                string htmlcontent = "<div style='margin-top:-27px; padding-top:10px;'>";
                htmlcontent += "<h4 style='text-align:center'><span style='font-family:Arial,Helvetica,sans-serif;font-size:10px'>";
                htmlcontent += "<strong>&nbsp;PERINGATAN DINI - EARLY WARNING SYSTEM - BLOK UN-SATISFACTORY (US) PRODUKSI VS BGT - " + msBusinessUnit.Description.ToUpper() + " </strong><br>";
                htmlcontent += "<strong>&nbsp;PERIODE DATA SD OKTOBER - TANGGAL " + DateTime.Now.ToString("dd MMMM yyyy").ToUpper() + " </strong>";
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
            private string GetBodyLevelKebun()
            {


                string htmlcontent = "<div style='text-align: center;'>";
                htmlcontent += "<table style='border: 0.75px solid black; border-collapse: collapse; width: 90%;margin-left:25px;'>";
               
                htmlcontent += "<tr>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;width:100px;background-color:#00695C;' rowspan='2'>";
                htmlcontent += "<span style='color:white;font-family: Arial, Helvetica, sans-serif; font-weight: bold;font-size: 10px;'>Uraian</span>";
                htmlcontent += "</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;' colspan='3'>E</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;' colspan='3'>G</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;' colspan='3'>N</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;' colspan='3'>US</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;' colspan='3'>NO BGT</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;' colspan='3'>TOTAL</td>";

                htmlcontent += "</tr>";

                htmlcontent += "<tr>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>Blok</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>LuasHa</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>%</td>";

                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>Blok</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>LuasHa</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>%</td>";

                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>Blok</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>LuasHa</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>%</td>";

                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>Blok</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>LuasHa</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>%</td>";


                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>Blok</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>LuasHa</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>%</td>";

                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>Blok</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>LuasHa</td>";
                htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;'>%</td>";
                htmlcontent += "</tr>";

                htmlcontent += "</table>";
                htmlcontent += "</div>";

                return htmlcontent;


            }

            private string GetBodyPdfNew(IEnumerable<T_MsEwsNew> valueGroupBody)
            {
                List<T_MsEwsNew> listvalueGroup = valueGroupBody.ToList();
                List<T_MsUrutanEws> allUrutan = _msEwsRepository.GetMsUrutan();

                string htmlcontent = "<div style='text-align: center;'>";
                htmlcontent += "<table style='border: 0.75px solid black; border-collapse: collapse; width: 90%;margin-left:25px;'>";

                foreach (var valueUrutan in allUrutan)
                {
                    htmlcontent += "<tr>";

                    if (valueUrutan.rowspan == true)
                    {

                        htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;width:100px;background-color:#00695C;' rowspan='3'>";
                        htmlcontent += "<span style='color:white;font-family: Arial, Helvetica, sans-serif; font-weight: bold;font-size: 10px;'>Uraian</span>";
                        htmlcontent += "</td>";
                    }

                    if (valueUrutan.asHeader == true)
                    {

                        htmlcontent += "<td style='padding: 0; margin: 0; width:30px;height: 12.5px padding: 2px;background-color:#00695C; border: 1px solid black;'>";
                        htmlcontent += "<span style='color:white;font-family: Arial, Helvetica, sans-serif; font-weight: bold;font-size: 10px;'>" + valueUrutan.headerName + "</span>";
                        htmlcontent += "</td>";

                        if (valueUrutan.colspan == true)
                        {
                            htmlcontent += "<td style='padding: 0; margin: 0;border: 1px solid black;height: 12.5px border-collapse: collapse;background-color:#DEDEDE;' colspan='10'></td>";

                        }
                        else
                        {

                            for (int j = 0; j < listvalueGroup.Count(); j++)
                            {

                                PropertyInfo property = typeof(T_MsEwsNew).GetProperty(valueUrutan.uraian);

                                object value = property.GetValue(listvalueGroup[j]);

                                htmlcontent += "<td style='padding: 0; margin: 0; width:30px;height: 12.5px padding: 2px;border: 1px solid black; background-color: red;'>";
                                htmlcontent += "<span style='color:white;font-family: Arial, Helvetica, sans-serif; font-weight: bold;font-size: 10px;'>" + value + "</span>";
                                htmlcontent += "</td>";

                            }

                        }

                    }
                    else
                    {


                        htmlcontent += "<td style='text-align: left;height: 13px; border: 1px solid black;width:100px;'>";
                        htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif; font-weight: bold;font-size: 10px;'>" + valueUrutan.headerName + "</span>";
                        htmlcontent += "</td>";

                        htmlcontent += "<td style='width:25px;height: 13px;padding: 2px; border: 1px solid black;'>";
                        htmlcontent += "<span style='text-align:center;font-family: Arial, Helvetica, sans-serif; font-size: 11px;'>" + valueUrutan.satuan + " </span>";
                        htmlcontent += "</td>";

                        for (int j = 0; j < listvalueGroup.Count(); j++)
                        {

                            PropertyInfo property = typeof(T_MsEwsNew).GetProperty(valueUrutan.uraian);

                            object value = property.GetValue(listvalueGroup[j]);


                            if (value == null)
                            {

                                htmlcontent += "<td style='width:25px;height: 13px; padding: 2px; border: 1px solid black;'>";
                                htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif;font-size: 11px;'></span>";
                                htmlcontent += "</td>";
                            }
                            else
                            {


                                if (valueUrutan.headerName.Contains("Achv"))
                                {

                                    var listColor = _msEwsRepository.GetColorAchieveEWS((decimal)value);

                                    if (listColor == null)
                                    {

                                        htmlcontent += "<td style='width:25px;height: 13px; padding: 2px; border: 1px solid black;'>";
                                        htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif;font-size: 11px;'>" + value + "</span>";
                                        htmlcontent += "</td>";
                                    }
                                    else
                                    {
                                        try
                                        {
                                            htmlcontent += "<td style='background-color: " + listColor[0].backgroundColor + "; width:25px;height: 13px; padding: 2px; border: 1px solid black;'>";
                                            htmlcontent += "<span style='color:" + listColor[0].fontColor + ";font-family: Arial, Helvetica, sans-serif;font-size: 11px;'>" + value + "</span>";
                                            htmlcontent += "</td>";

                                        }
                                        catch
                                        {
                                            htmlcontent += "<td style='width:25px;height: 13px; padding: 2px; border: 1px solid black;'>";
                                            htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif;font-size: 11px;'>" + value + "</span>";
                                            htmlcontent += "</td>";

                                        }


                                    }


                                }
                                else
                                {

                                    htmlcontent += "<td style='width:25px;height: 13px; padding: 2px; border: 1px solid black;'>";
                                    htmlcontent += "<span style='font-family: Arial, Helvetica, sans-serif;font-size: 11px;'>" + value + "</span>";
                                    htmlcontent += "</td>";
                                }

                            }



                        }

                    }


                    htmlcontent += "</tr>";

                }

                htmlcontent += "</table>";
                htmlcontent += "</div>";
                htmlcontent += "<br>";
                return htmlcontent;

            }


            public async Task<bool?> GenerateLevelRekapKebun()
            {

                if (_appSettings.filePath != null)

                {

                    var document = new PdfDocument();
                    var contentPdf = await _msEwsRepository.GetDataRekapLevelKebun();
                    if (contentPdf == null)
                    {
                        return null;
                    }
                    else
                    {

                        string htmlcontent = "";
                        string company = "01";
                        string location = "21";
                        htmlcontent += GetTitlePdf(company, location);

                        htmlcontent += GetBodyLevelKebun();

                        PdfGenerator.AddPdfPages(document, htmlcontent, PageSize.A4);

                        using (MemoryStream ms = new MemoryStream())
                        {
                            document.Save(ms);
                            var filename = company + "_" + location + "_EWS_Kebun_" + DateTime.Now.ToString("DDMMYY") + ".pdf";
                            byte[] response = ms.ToArray();
                            string fullPath = Path.Combine(_appSettings.filePath, filename);
                            File.WriteAllBytes(fullPath, response);

                        }

                        return true;

                    }

                }
                else
                {

                    return false;

                }


            }



            public async Task<bool?> GenerateLevelRekapAfdeling(string company, string location)
            {
                if (_appSettings.filePath != null)
                {

                    var document = new PdfDocument();
                    // var contentPdf = await _msEwsRepository.GetContentPdf();
                    var contentPdf = await _msEwsRepository.GetContentByCompanyLocationPdf(company, location);

                    if (contentPdf == null)
                    {
                        return null;
                    }
                    else
                    {

                        int groupSize = 10;
                        int checkPage = 0;
                        int totalItems = contentPdf.Count();
                        bool header = true;
                        string htmlcontent = "";

                        for (int startIndex = 0; startIndex < totalItems; startIndex += groupSize)
                        {

                            if (header)
                            {
                                htmlcontent += GetTitlePdf(company, location);
                                htmlcontent += GetHeaderPdf();
                                header = false;
                            }

                            List<T_MsEwsNew> result = contentPdf.Skip(startIndex).Take(groupSize).ToList();

                            htmlcontent += GetBodyPdfNew(result);

                            checkPage += 1;

                            if (checkPage == 2)
                            {
                                PdfGenerator.AddPdfPages(document, htmlcontent, PageSize.A4);
                                htmlcontent = "";
                                checkPage = 0;
                                header = true;
                            }

                        }

                        using (MemoryStream ms = new MemoryStream())
                        {
                            document.Save(ms);
                            var filename = company + "_" + location + "_EWS_" + DateTime.Now.ToString("DDMMYY") + ".pdf";
                            byte[] response = ms.ToArray();
                            string fullPath = Path.Combine(_appSettings.filePath, filename);
                            File.WriteAllBytes(fullPath, response);

                        }

                        return true;

                    }

                }
                else
                {

                    return false;

                }



            }

        }
    }