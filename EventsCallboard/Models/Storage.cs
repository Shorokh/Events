﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EventsCallboard.Models
{
    public class Storage
    {
        static Storage _this = new();
        public static Storage _This{get => _this;}
        public CityEvent[] eventsList;
        public string error = "";

        private Storage()
        {
            eventsList = Loader();
        }

        private static string Val(XAttribute? a) => a == null ? "" : a.Value;
        private CityEvent[] Loader()
        {
            List<CityEvent> list = new();
            XDocument xdoc;
            try
            {
                xdoc = XDocument.Load("../../../Assets/Storage.xml");
            }
            catch (Exception ex) { error = ex.Message; return list.ToArray(); }
            XElement? events = xdoc.Element("Events");
            if (events == null) { error = "Не найден корневой тег Events"; return list.ToArray(); }

            foreach (XElement Event in events.Elements("Event"))
            {
                XElement? title = Event.Element("Header");
                XElement? desc = Event.Element("Description");
                XElement? img = Event.Element("Image");
                XElement? date = Event.Element("Date");
                XElement? cats = Event.Element("Category");
                XElement? price = Event.Element("Price");

                if (title == null || img == null || date == null || cats == null) continue;

                string s_title = Val(title.Attribute("data"));
                string s_desc = desc == null ? "" : Val(title.Attribute("data"));
                string s_img = Val(img.Attribute("data"));
                string s_date = Val(date.Attribute("data"));
                List<string> s_cats = new();
                foreach (XElement cat in cats.Elements("CategoryItem")) s_cats.Add(Val(cat.Attribute("data")));
                string s_price = price == null ? "" : Val(price.Attribute("data")) + " \x20bd";
                string grand = Val(cats.Attribute("grand"));

                list.Add(new CityEvent(s_title, s_desc, s_img, s_date, s_cats.ToArray(), grand, s_price));
            }
            return list.ToArray();
        }
    }
}
