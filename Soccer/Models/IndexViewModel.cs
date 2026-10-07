namespace Soccer.Models;

public class IndexViewModel(
    IEnumerable<Player> players,
    PageViewModel pageViewModel,
    FilterViewModel filterViewModel,
    SortViewModel sortViewModel)
{
    public IEnumerable<Player> Players { get; } = players;
    public PageViewModel PageViewModel { get; } = pageViewModel;
    public FilterViewModel FilterViewModel { get; } = filterViewModel;
    public SortViewModel SortViewModel { get; } = sortViewModel;
}