
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea_Semana4.Models;
using Tarea_Semana4.Data;

public class EstudianteController : Controller
{
    private readonly ApplicationDbContext _context;

    public EstudianteController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ESTUDIANTEMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Estudiantes.ToListAsync());
    }

    // GET: ESTUDIANTEMODELS/Details/5
    public async Task<IActionResult> Details(int? estudianteid)
    {
        if (estudianteid == null)
        {
            return NotFound();
        }

        var estudiantemodel = await _context.Estudiantes
            .FirstOrDefaultAsync(m => m.EstudianteId == estudianteid);
        if (estudiantemodel == null)
        {
            return NotFound();
        }

        return View(estudiantemodel);
    }

    // GET: ESTUDIANTEMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ESTUDIANTEMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EstudianteId,Nombre,Apellido,Email,Telefono")] EstudianteModel estudiantemodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(estudiantemodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(estudiantemodel);
    }

    // GET: ESTUDIANTEMODELS/Edit/5
    public async Task<IActionResult> Edit(int? estudianteid)
    {
        if (estudianteid == null)
        {
            return NotFound();
        }

        var estudiantemodel = await _context.Estudiantes.FindAsync(estudianteid);
        if (estudiantemodel == null)
        {
            return NotFound();
        }
        return View(estudiantemodel);
    }

    // POST: ESTUDIANTEMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? estudianteid, [Bind("EstudianteId,Nombre,Apellido,Email,Telefono")] EstudianteModel estudiantemodel)
    {
        if (estudianteid != estudiantemodel.EstudianteId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(estudiantemodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteModelExists(estudiantemodel.EstudianteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(estudiantemodel);
    }

    // GET: ESTUDIANTEMODELS/Delete/5
    public async Task<IActionResult> Delete(int? estudianteid)
    {
        if (estudianteid == null)
        {
            return NotFound();
        }

        var estudiantemodel = await _context.Estudiantes
            .FirstOrDefaultAsync(m => m.EstudianteId == estudianteid);
        if (estudiantemodel == null)
        {
            return NotFound();
        }

        return View(estudiantemodel);
    }

    // POST: ESTUDIANTEMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? estudianteid)
    {
        var estudiantemodel = await _context.Estudiantes.FindAsync(estudianteid);
        if (estudiantemodel != null)
        {
            _context.Estudiantes.Remove(estudiantemodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EstudianteModelExists(int? estudianteid)
    {
        return _context.Estudiantes.Any(e => e.EstudianteId == estudianteid);
    }
}
