using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.Web;
//using System.Json.se;//Пакет JSON



namespace Polygon
{
  
    class ClassLoadAPIPoligon
    {
        public string funcPolygon(string userTextInput)

        {
            string userText = HttpUtility.UrlEncode("москва ювао");
            userText = HttpUtility.UrlEncode(userTextInput);
           // нужно для корректной работы url с русскими буквами
            string userAgentString = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36 OPR/71.0.3770.284";
            string webAddress = @"https://nominatim.openstreetmap.org/search?q=" + userText + "&format=json&polygon_geojson=1";
           // получаем данные с сайта
            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add("user-agent", userAgentString);
            string webpage = client.DownloadString(webAddress);
            // вывод данных
            string resu = "";
            resu = HttpUtility.UrlDecode(webpage);
            return resu;
        }
    }
}
