using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;

namespace EventsCallboard.Models
{
    public class EventTag
    {
        public string Header { get; }
        public string Category { get; }
        public ObservableCollection<CityEvent> Events
        {
            get
            {
                var res = new ObservableCollection<CityEvent>();
                foreach (var Event in Storage._This.eventsList)
                    if (Event.CheckCat(Category)) res.Add(Event);
                return res;
            }
        }
        public Bitmap? CategoryImage { get; }
        public EventTag(string header, string cat, string image)
        {
            Header = header;
            Category = cat;

            var app = Application.Current;
            if (app == null) return;
            var ress = app.Resources;
            var img = (Image?)ress[image];
            if (img == null) return;
            CategoryImage = (Bitmap?)img.Source;
        }
    }
}
