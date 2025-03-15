namespace Soccer.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Players> Players { get; set; }
        public PageViewModel PageViewModel { get; }
        public FilterViewModel FilterViewModel { get; }
        public SortViewModel SortViewModel { get; }

        public IndexViewModel(IEnumerable<Players> players, PageViewModel pageViewModel,
            FilterViewModel filterViewModel, SortViewModel sortViewModel)
        {
            Players = players;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
            SortViewModel = sortViewModel;
        }
    }
}

