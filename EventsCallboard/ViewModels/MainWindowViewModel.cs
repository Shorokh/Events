using EventsCallboard.Models;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace EventsCallboard.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ObservableCollection<EventTag> eventTags = new();
        public MainWindowViewModel() {
            eventTags = new ObservableCollection<EventTag> {
                new EventTag("Для детей",    "kids",         "img_a"),
                new EventTag("Спорт",        "wellness",     "img_b"),
                new EventTag("Культура",     "culture",      "img_c"),
                new EventTag("Экскурсии",    "excursion",    "img_d"),
                new EventTag("Образ жизни",  "lifestyle",    "img_e"),
                new EventTag("Вечеринки",    "parties",      "img_f"),
                new EventTag("Образование",  "study",        "img_g"),
                new EventTag("Онлайн",       "online",       "img_h"),
                new EventTag("Шоу",          "shows",        "img_i"),
            };
        }

        public ObservableCollection<EventTag> EventTags {
            get => eventTags;
            set => this.RaiseAndSetIfChanged(ref eventTags, value);
        }
    }
}