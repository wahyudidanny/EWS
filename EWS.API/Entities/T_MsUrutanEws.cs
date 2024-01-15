using Microsoft.EntityFrameworkCore;

namespace EWS.API.Entities
{
    [Keyless]
    public class T_MsUrutanEws
    {

        public int? ranked { get; set; }
        public string? uraian { get; set; }
        public string? headerName { get; set; }
        public string? satuan { get; set; }
        public bool? asHeader { get; set; }
        public bool? colspan { get; set; }
        public bool? rowspan { get; set; }

        // public int? ranked { get; private set; }
        // public string? uraian { get; private set; }
        // public bool? asHeader { get; private set; }
        // public bool? colspan { get; private set; }
        // public bool? rowspan { get; private set; }

        // private static List<T_MsUrutanEws> dataModels = new List<T_MsUrutanEws>();

        // static T_MsUrutanEws()
        // {
        //     InitializeDataModels();
        // }

        // private T_MsUrutanEws(int ranked, string uraian, bool asHeader, bool colspan, bool rowspan)
        // {
        //     SetData(ranked, uraian, asHeader, colspan, rowspan);
        //     dataModels.Add(this);
        // }

        // public void SetData(int rankedVal, string uraianVal, bool asHeaderVal, bool colspanVal, bool rowspanVal)
        // {
        //     ranked = rankedVal;
        //     uraian = uraianVal;
        //     asHeader = asHeaderVal;
        //     colspan = colspanVal;
        //     rowspan = rowspanVal;
        // }

        // public static List<T_MsUrutanEws> GetAllDataModels()
        // {
        //     return dataModels;
        // }

        
        // public static void InitializeDataModels()
        // {
        //     new T_MsUrutanEws(1, "blokCode", true, false, true);
        //     new T_MsUrutanEws(2, "ranked", true, false, false);
        //     new T_MsUrutanEws(3, "satuan", true, true, false);    
        //     new T_MsUrutanEws(4, "afdeling", false, false, false);   
        //     new T_MsUrutanEws(5, "hectaragePlanted", false, false, false);   
        //     new T_MsUrutanEws(6, "tonHa", false, false, false);   
        //     new T_MsUrutanEws(7, "roundTonHa", false, false, false);   
        //     new T_MsUrutanEws(8, "bdgtTonHa", false, false, false);   
        //     new T_MsUrutanEws(9, "roundBdgtTonHa", false, false, false);  
        //     new T_MsUrutanEws(10, "acHTonHaAktvsBgdt", false, false, false); 
        //     new T_MsUrutanEws(11, "jjgPkk", false, false, false); 
        //     new T_MsUrutanEws(12, "roundJjgPkk", false, false, false);  
        //     new T_MsUrutanEws(13, "bdgtJjgPkk", false, false, false); 
        //     new T_MsUrutanEws(14, "roundBdgtJjgPkk", false, false, false); 
        //     new T_MsUrutanEws(15, "achJjgAktvsBgdt", false, false, false); 
        //     new T_MsUrutanEws(16, "bjrAkt", false, false, false); 
        //     new T_MsUrutanEws(17, "roundBjrAkt", false, false, false); 
        //     new T_MsUrutanEws(18, "bjrBdgt", false, false, false); 
        //     new T_MsUrutanEws(19, "roundBjrBdgt", false, false, false); 
        //     new T_MsUrutanEws(20, "achBjrAktvsBgdt", false, false, false); 
        //     new T_MsUrutanEws(21, "aktRotPnn", false, false, false); 
        //     new T_MsUrutanEws(22, "roundAktRotPnn", false, false, false);  
        //     new T_MsUrutanEws(23, "bdgtRotasi", false, false, false); 
        //     new T_MsUrutanEws(24, "achRotasiAktvsBgdt", false, false, false); 
        //     new T_MsUrutanEws(25, "totAnotganikAkt", false, false, false); 
        //     new T_MsUrutanEws(26, "totAnotganikBdgt", false, false, false); 
        //     new T_MsUrutanEws(27, "achAnorganikAktvsBgdt", false, false, false); 
        //     new T_MsUrutanEws(28, "totpiringanAkt", false, false, false); 
        //     new T_MsUrutanEws(29, "totpiringanBdgt", false, false, false); 
        //     new T_MsUrutanEws(30, "achPiringanAktvsBgdt", false, false, false); 

        // }


    }

}