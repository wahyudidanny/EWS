
namespace EWS.API.Entities
{

    public class T_MsUrutan
    {
        public int? ranked { get; private set; }
        public string? uraian { get; private set; }
        public bool? asHeader { get; private set; }
        public bool? colspan { get; private set; }
        public bool? rowspan { get; private set; }

        private static List<T_MsUrutan> dataModels = new List<T_MsUrutan>();

        static T_MsUrutan()
        {
            InitializeDataModels();
        }

        private T_MsUrutan(int ranked, string uraian, bool asHeader, bool colspan, bool rowspan)
        {
            SetData(ranked, uraian, asHeader, colspan, rowspan);
            dataModels.Add(this);
        }

        public void SetData(int rankedVal, string uraianVal, bool asHeaderVal, bool colspanVal, bool rowspanVal)
        {
            ranked = rankedVal;
            uraian = uraianVal;
            asHeader = asHeaderVal;
            colspan = colspanVal;
            rowspan = rowspanVal;
        }

        public static List<T_MsUrutan> GetAllDataModels()
        {
            return dataModels;
        }

        
        public static void InitializeDataModels()
        {
            new T_MsUrutan(1, "blokCode", true, false, true);
            new T_MsUrutan(2, "ranked", true, false, false);
            new T_MsUrutan(3, "satuan", true, true, false);    
            new T_MsUrutan(4, "afdeling", false, false, false);   
            new T_MsUrutan(5, "hectaragePlanted", false, false, false);   
            new T_MsUrutan(6, "tonHa", false, false, false);   
            new T_MsUrutan(7, "roundTonHa", false, false, false);   
            new T_MsUrutan(8, "bdgtTonHa", false, false, false);   
            new T_MsUrutan(9, "roundBdgtTonHa", false, false, false);  
            new T_MsUrutan(10, "acHTonHaAktvsBgdt", false, false, false); 
            new T_MsUrutan(11, "jjgPkk", false, false, false); 
            new T_MsUrutan(12, "roundJjgPkk", false, false, false);  
            new T_MsUrutan(13, "bdgtJjgPkk", false, false, false); 
            new T_MsUrutan(14, "roundBdgtJjgPkk", false, false, false); 
            new T_MsUrutan(15, "achJjgAktvsBgdt", false, false, false); 
            new T_MsUrutan(16, "bjrAkt", false, false, false); 
            new T_MsUrutan(17, "roundBjrAkt", false, false, false); 
            new T_MsUrutan(18, "bjrBdgt", false, false, false); 
            new T_MsUrutan(19, "roundBjrBdgt", false, false, false); 
            new T_MsUrutan(20, "achBjrAktvsBgdt", false, false, false); 
            new T_MsUrutan(21, "aktRotPnn", false, false, false); 
            new T_MsUrutan(22, "roundAktRotPnn", false, false, false);  
            new T_MsUrutan(23, "bdgtRotasi", false, false, false); 
            new T_MsUrutan(24, "achRotasiAktvsBgdt", false, false, false); 
            new T_MsUrutan(25, "totAnotganikAkt", false, false, false); 
            new T_MsUrutan(26, "totAnotganikBdgt", false, false, false); 
            new T_MsUrutan(27, "achAnorganikAktvsBgdt", false, false, false); 
            new T_MsUrutan(28, "totpiringanAkt", false, false, false); 
            new T_MsUrutan(29, "totpiringanBdgt", false, false, false); 
            new T_MsUrutan(30, "achPiringanAktvsBgdt", false, false, false); 

        }


    }

}