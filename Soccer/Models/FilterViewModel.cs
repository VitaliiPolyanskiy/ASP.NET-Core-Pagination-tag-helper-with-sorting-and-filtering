using Microsoft.AspNetCore.Mvc.Rendering;

namespace Soccer.Models;

public class FilterViewModel
{
    public SelectList Teams { get; }            // список команд
    public int SelectedTeam { get; }            // обрана команда
    public string? SelectedPosition { get; }    // введена позиція

    public FilterViewModel(List<Team> teams, int team, string? position)
    {
        // Встановлюємо початковий елемент, який дозволить обрати всіх
        teams.Insert(0, new Team { Name = "Всі", Id = 0, Coach = "Немає тренера" });
        Teams = new SelectList(teams, "Id", "Name", team);
        SelectedTeam = team;
        SelectedPosition = position;
    }
}