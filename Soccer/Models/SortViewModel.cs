namespace Soccer.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; set; } // значение для сортировки по имени
        public SortState AgeSort { get; set; }    // значение для сортировки по возрасту
        public SortState PositionSort { get; set; }    // значение для сортировки по позиции
        public SortState TeamSort { get; set; }   // значение для сортировки по компании
        public SortState Current { get; set; }     // значение свойства, выбранного для сортировки
        public bool Up { get; set; }  // Сортировка по возрастанию или убыванию

        public SortViewModel(SortState sortOrder)
        {
            // значения по умолчанию
            NameSort = SortState.NameAsc;
            AgeSort = SortState.AgeAsc;
            PositionSort = SortState.PositionAsc;
            TeamSort = SortState.TeamAsc;

            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            AgeSort = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
            PositionSort = sortOrder == SortState.PositionAsc ? SortState.PositionDesc : SortState.PositionAsc;
            TeamSort = sortOrder == SortState.TeamAsc ? SortState.TeamDesc : SortState.TeamAsc;
            Current = sortOrder;
        }
    }
}
