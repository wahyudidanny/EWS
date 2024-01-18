using EWS.Job.Entities;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


public class Program
{

    private static AppSettings appSettings;
    private static SettingWAChrome settingWAChrome;
    static async Task Main(string[] args)
    {

        // Log.Logger = new LoggerConfiguration()
        // .MinimumLevel.Debug()
        // .WriteTo.File($"EWS.File/logs/EWSGeneratePDF_log_.txt", rollingInterval: RollingInterval.Day)
        // .CreateLogger();

        // Log.Information("Service start at {0}", DateTime.Now);

        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

        appSettings = new AppSettings(configuration);
        settingWAChrome = new SettingWAChrome(configuration);


        // Console.WriteLine("asdasd");
        await openChromeWhatshap();

        // Console.WriteLine("aaaa");
        // if (appSettings.generatePDF == "1")
        // {


        // }

        // if (appSettings.sendPDFProd == "1")
        // {


        // }





    }


    private static void RunSeleniumSendAttachment()
    {
        try
        {
            // IWebDriver driver;

            // ChromeOptions options = new ChromeOptions();
            // options.AddArguments(
            //     MasterParameter
            //         .Where(s => s.ParameterCode == "User-data-dir")
            //         .FirstOrDefault()
            //         .ParameterValue
            // ); // --Prod

            // driver = new ChromeDriver(
            //     MasterParameter
            //         .Where(s => s.ParameterCode == "Chrome-driver-path")
            //         .FirstOrDefault()
            //         .ParameterValue,
            //     options
            // ); //Chrome driver path on server
            // driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(60);

            // driver
            //     .Navigate()
            //     .GoToUrl(
            //         MasterParameter
            //             .Where(s => s.ParameterCode == "URL")
            //             .FirstOrDefault()
            //             .ParameterValue
            //     ); // --URL
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(60);
            // driver.Manage().Window.Maximize();

            // string Elementsearchgrup = MasterParameter
            //     .Where(s => s.ParameterCode == "Element-search-grup-contact")
            //     .FirstOrDefault()
            //     .ParameterValue;
            // string Elementclickgrup = MasterParameter
            //     .Where(s => s.ParameterCode == "Element-click-grup-contact")
            //     .FirstOrDefault()
            //     .ParameterValue;
            // string Elementtextmessage = MasterParameter
            //     .Where(s => s.ParameterCode == "Element-text-message")
            //     .FirstOrDefault()
            //     .ParameterValue;
            // string Elementchecksendedmessage = MasterParameter
            //     .Where(s => s.ParameterCode == "Element-check-sended-message")
            //     .FirstOrDefault()
            //     .ParameterValue;
            // string Elementclicksend = MasterParameter
            //     .Where(s => s.ParameterCode == "Element-click-send-file")
            //     .FirstOrDefault()
            //     .ParameterValue;
            // string Elementclickfiledokumen = MasterParameter
            //     .Where(s => s.ParameterCode == "Element-click-file_attachment_dokumen")
            //     .FirstOrDefault()
            //     .ParameterValue;
            // string Elementclip = MasterParameter
            //     .Where(s => s.ParameterCode == "Element-click-clip")
            //     .FirstOrDefault()
            //     .ParameterValue;
            // string Spliter = MasterParameter
            //     .Where(s => s.ParameterCode == "Enter-split-by")
            //     .FirstOrDefault()
            //     .ParameterValue;

            // List<string> SendTo = null;
            // SendTo = new List<string>();
            // SendTo.Add("TESTING-FR-SENSUS");

            // foreach (var sendTo in SendTo)
            // {
            //     string Elementclickgrup2 = Elementclickgrup.Replace("@GroupContactName", sendTo);

            //     //Element execution step
            //     driver.FindElement(By.XPath(Elementsearchgrup)).SendKeys(sendTo); //--> Element search grup
            //     Thread.Sleep(5000);
            //     driver.FindElement(By.XPath(Elementclickgrup2)).Click(); //--> Element click grup
            //     Thread.Sleep(3000);
            //     driver.FindElement(By.XPath(Elementclickgrup2)).Click(); //--> Element click grup
            //     Thread.Sleep(2000);
            //     driver.FindElement(By.XPath(Elementclickgrup2)).Click(); //--> Element click grup
            //     Thread.Sleep(2000);

            //     driver
            //         .FindElement(By.XPath(Elementtextmessage))
            //         .SendKeys(
            //             "In a few minutes you will recieved auto notification from *WhatsApp Automation System*"
            //         ); //--> Element text message value
            //     driver.FindElement(By.XPath(Elementtextmessage)).SendKeys(Keys.Enter); //--> Element text message

            //     driver.FindElement(By.XPath(Elementclip)).Click();
            //     for (int i = 0; i <= pathParam.Count() - 1; i++)
            //     {
            //         Thread.Sleep(2000);
            //         driver.FindElement(By.XPath(Elementclickfiledokumen)).SendKeys(pathParam[i]);
            //     }

            //     //driver.FindElement(By.XPath("//span[@data-icon='send']/parent::div[@aria-label='Send']//span")).Click();
            //     driver
            //         .FindElement(
            //             By.XPath("//span[@data-icon='send']/parent::div[@aria-label='Send']//span")
            //         )
            //         .Click();

            //     driver
            //         .FindElement(By.XPath(Elementtextmessage))
            //         .SendKeys("-------------------------------------"); //--> Element text message value
            //     driver.FindElement(By.XPath(Elementtextmessage)).SendKeys(Keys.Shift + Keys.Enter); //--> Element text message new line
            //     driver
            //         .FindElement(By.XPath(Elementtextmessage))
            //         .SendKeys("Thankyou *WhatsApp Automation System*"); //--> Element text message value
            //     driver.FindElement(By.XPath(Elementtextmessage)).SendKeys(Keys.Enter); //--> Element text message send

            //     Thread.Sleep(1000);
            // }
            Thread.Sleep(5000);
            //driver.Quit();
            Thread.Sleep(2000);
        }
        catch (Exception e)
        {

        }
    }



    private static async Task openChromeWhatshap()
    {

        try
        {

            string ChromeUserData = settingWAChrome.chromeUserData;

            var options = new ChromeOptions();
            options.AddArgument(ChromeUserData);


            using (IWebDriver driver = new ChromeDriver(settingWAChrome.chromeDriverPath, options))
            {

                driver.Navigate().GoToUrl("https://web.whatsapp.com/");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(60);
                Thread.Sleep(10000);
                SendToWA(driver);

                driver.Quit();
            }


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());


        }
    }



    static void SendToWA(IWebDriver driver)
    {

        IWebElement searchBox = driver.FindElement(By.XPath(settingWAChrome.waSearchBox));
        searchBox.SendKeys(settingWAChrome.waRecipientGroup);
        //driver.FindElement(By.XPath(settingWAChrome.waTextBoxMessage)).SendKeys("In a few minutes you will recieved auto notification from *WhatsApp Automation System*"); //--> Element text message value
        Console.WriteLine("1");
        Thread.Sleep(3000); // Wait for the search results to load
        Console.WriteLine("2");
        driver.FindElement(By.XPath(string.Format(settingWAChrome.waSelectSearchResult ?? "", "TESTING-FR-SENSUS"))).Click();


        IWebElement attachmentButton = driver.FindElement(By.CssSelector(settingWAChrome.waAttachmentButton));
        attachmentButton.Click();
        Thread.Sleep(2000); // Wait for the search results to load

        string imageFullPath = Path.GetFullPath("C:\\AllProject\\EWS\\EWS.File\\File\\Riau\\01_21_EWS_DD01YY.pdf");
        IWebElement fileInput = driver.FindElement(By.CssSelector(settingWAChrome.waInputFileDefault));
        fileInput.SendKeys(imageFullPath);
        Thread.Sleep(2000); // Wait for the search results to load
        Console.WriteLine("3");

        driver.FindElement(By.XPath(settingWAChrome.waTextBoxMessageImage)).SendKeys(Keys.Enter);

        // driver.FindElement(By.XPath(appSettings.WA_TextBoxMessage)).SendKeys("In a few minutes you will recieved auto notification from *WhatsApp Automation System*"); //--> Element text message value
        // driver.FindElement(By.XPath(appSettings.WA_TextBoxMessage)).SendKeys(Keys.Enter);
        Thread.Sleep(10000);

        Console.WriteLine("4");

    }




}