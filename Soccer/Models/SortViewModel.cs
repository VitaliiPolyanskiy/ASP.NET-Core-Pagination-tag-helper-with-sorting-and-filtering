namespace Soccer.Models;

public class SortViewModel
{
    public SortState NameSort { get; private set; }     // значення для сортування за ім'ям
    public SortState AgeSort { get; private set; }      // значення для сортування за віком
    public SortState PositionSort { get; private set; } // значення для сортування за позицією
    public SortState TeamSort { get; private set; }     // значення для сортування за командою
    public SortState Current { get; private set; }      // значення властивості, обраної для сортування

    public SortViewModel(SortState sortOrder)
    {
        NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
        AgeSort = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
        PositionSort = sortOrder == SortState.PositionAsc ? SortState.PositionDesc : SortState.PositionAsc;
        TeamSort = sortOrder == SortState.TeamAsc ? SortState.TeamDesc : SortState.TeamAsc;
        Current = sortOrder;
    }
}