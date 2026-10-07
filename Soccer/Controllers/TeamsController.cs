using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soccer.Models;

namespace Soccer.Controllers;

public class TeamsController : Controller
{
    private readonly SoccerContext _context;

    public TeamsController(SoccerContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Teams.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var team = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);

        return team == null ? NotFound() : View(team);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Coach")] Team team)
    {
        if (ModelState.IsValid)
        {
            _context.Add(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(team);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var team = await _context.Teams.FindAsync(id);
        if (team == null) return NotFound();

        return View(team);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Coach")] Team team)
    {
        if (id != team.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(team);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(team.Id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(team);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var team = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);

        return team == null ? NotFound() : View(team);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var team = await _context.Teams.FindAsync(id);
        if (team != null)
        {
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool TeamExists(int id)
    {
        return _context.Teams.Any(e => e.Id == id);
    }
}