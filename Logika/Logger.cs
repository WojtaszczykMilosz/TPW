using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Dane;

namespace Logika
{
    public static class Logger
    {

        private static string sessionID = "0";
        private static string LogSciezka = "data.xml";
        private static int sessionIDint = 0;

        public static void NewSession()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(LogSciezka);

            XmlNodeList logs = xmlDocument.GetElementsByTagName("log");
            XmlElement log = (XmlElement)logs[logs.Count - 1];
            
            int id = Int16.Parse(log.GetAttribute("sessionID"));
            
            sessionIDint = id + 1;
            sessionID = sessionIDint.ToString();
        }




        public static void Logguj(AbstractLogicApi api) 
        {
            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.Load(LogSciezka);
            XmlNode log = xmlDocument.CreateElement("log");
            XmlElement logElement = (XmlElement)log;
            logElement.SetAttribute("sessionID", sessionID);
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
                XmlNode kulaX = ZapiszKule(kula, i, xmlDocument);
                listaKul.AppendChild(kulaX);
                i++;
            }
            log.AppendChild(listaKul);
            xmlDocument.DocumentElement.AppendChild(log);
            lock (xmlDocument)
            {
                xmlDocument.Save(LogSciezka);
            }
        }

        private static XmlNode ZapiszKule(Kula kula, int i,XmlDocument xmlDocument)
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

            return kulaX;   
        }


        public static void LoggujKolizje(DateTime time, int kulaIndex, int kulaKolizjaIndex)
        {
            XmlDocument xmlDocument = new XmlDocument();
            string sciezka = "collisions.xml";
            xmlDocument.Load(sciezka);

            XmlNode kolizja = xmlDocument.CreateElement("kolizja");
            XmlElement kolizjaElement = (XmlElement)kolizja;
            kolizjaElement.SetAttribute("sessionID", sessionID);
            XmlNode czas = xmlDocument.CreateElement("czas");
            czas.InnerText = time.ToString();
            kolizja.AppendChild(czas);

            XmlNode kula1 = xmlDocument.CreateElement("kula1");


            kula1.InnerText = kulaIndex.ToString();
            XmlNode kula2 = xmlDocument.CreateElement("kula2");
            kula2.InnerText = kulaKolizjaIndex.ToString();
            kolizja.AppendChild(kula1);
            kolizja.AppendChild(kula2);
            
            xmlDocument.DocumentElement.AppendChild(kolizja);
            lock (xmlDocument)
            {
                
                xmlDocument.Save(sciezka);
            }
        }
    }
}
