using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;
using Dane;

namespace Logika
{
    public static class Logger
    {
        public static void Logguj(LogicApi api) 
        {
            XmlDocument xmlDocument = new XmlDocument();
            string sciezka = "E:\\studia\\Wspol\\data.xml";
            xmlDocument.Load(sciezka);
            XmlNode log = xmlDocument.CreateElement("log");

            XmlNode czas = xmlDocument.CreateElement("czas");
            czas.InnerText = DateTime.Now.ToString();
            log.AppendChild(czas);

            XmlNode ruch = xmlDocument.CreateElement("ruch");
            if (api.RuchKul)
            {
                ruch.InnerText = "Prawda";
            }
            else
            {
                ruch.InnerText = "Fałsz";
            }
            log.AppendChild(ruch);

            XmlNode iloscKul = xmlDocument.CreateElement("iloscKul");
            iloscKul.InnerText = $"{api.Kule.Count}";
            log.AppendChild(iloscKul);

            XmlNode listaKul = xmlDocument.CreateElement("listaKul");
            int i = 1;
            foreach (var kula in api.Kule)
            {
                XmlNode kulaX = xmlDocument.CreateElement("kula");
                kulaX.InnerText = $"Kula {i}";

                XmlNode X = xmlDocument.CreateElement("X");
                X.InnerText = $"{kula.X}";
                kulaX.AppendChild(X);

                XmlNode Y = xmlDocument.CreateElement("Y");
                Y.InnerText = $"{kula.Y}";
                kulaX.AppendChild(Y);

                XmlNode PredkoscX = xmlDocument.CreateElement("PredkoscX");
                PredkoscX.InnerText = $"{kula.PredkoscX}";
                kulaX.AppendChild(PredkoscX);

                XmlNode PredkoscY = xmlDocument.CreateElement("PredkoscY");
                PredkoscY.InnerText = $"{kula.PredkoscY}";
                kulaX.AppendChild(PredkoscY);

                XmlNode Srednica = xmlDocument.CreateElement("Srednica");
                Srednica.InnerText = $"{kula.Srednica}";
                kulaX.AppendChild(Srednica);

                XmlNode Masa = xmlDocument.CreateElement("Masa");
                Masa.InnerText = $"{kula.Masa}";
                kulaX.AppendChild(Masa);

                listaKul.AppendChild(kulaX);
                i++;
            }
            log.AppendChild(listaKul);
            xmlDocument.DocumentElement.AppendChild(log);
            xmlDocument.Save(sciezka);
        }
    }
}
