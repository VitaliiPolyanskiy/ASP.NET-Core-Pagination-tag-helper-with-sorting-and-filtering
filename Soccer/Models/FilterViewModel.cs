using Microsoft.AspNetCore.Mvc.Rendering;

namespace Soccer.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Teams> teams, int team, string position)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            teams.Insert(0, new Teams { Name = "All", Id = 0 });
            Teams = new SelectList(teams, "Id", "Name", team);
            SelectedTeam = team;
            SelectedPosition = position;
        }
        public SelectList Teams { get; } // список клубов
        public int SelectedTeam { get; } // выбранный клуб
        public string SelectedPosition { get; } // введенная позиция
    }
}
