
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using EWS.Services.Interface;
using EWS.Services.Models;
using EWS.Services.Setup;
using Microsoft.Extensions.DependencyInjection;


public class Program
{

    private static AppSettings? appSettings;
    private static SettingWAChrome? settingWAChrome;
    static async Task Main(string[] args)
    {

        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

        appSettings = new AppSettings(configuration);
        settingWAChrome = new SettingWAChrome(configuration);

        var services = new ServiceCollection();
        services.RegisterContext(configuration);
        services.RegisterService(configuration);
        services.AddHttpClient();


        var serviceProvider = services.BuildServiceProvider();
        var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
        var _businessUnitService = serviceProvider.GetService<IDataService>();

        var msBusinessUnit = _businessUnitService?.GetDataBusinessUnit().ToList() ?? new List<T_MsBusinessUnit>();



        if (appSettings.generatePDF == "1")
        {
    
            foreach (var data in msBusinessUnit)
            {
                try
                {
                    await GeneratePDF(data.Company, data.Location, data.RegionCode, httpClientFactory);

                }
                catch (Exception err)
                {

                    Console.WriteLine(err.ToString());

                }
            }

        }


        // if (appSettings.sendPDFProd == "1")
        // {
        // await openChromeWhatshap();

        // }

    }




    static async Task GeneratePDF(string? company, string? location, string? kodeRegion, IHttpClientFactory? httpClientFactory)
    {


        try
        {
            string apiUrl = $"{settingWAChrome.apiBaseUrl}/api/EWS/RekapAfdeling/?company={company}&location={location}&kodeRegion={kodeRegion}";

            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response from API:" + responseContent);

                }

            }

        }
        catch (Exception e)
        {
            Console.WriteLine("Response from API:" + e.ToString());
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