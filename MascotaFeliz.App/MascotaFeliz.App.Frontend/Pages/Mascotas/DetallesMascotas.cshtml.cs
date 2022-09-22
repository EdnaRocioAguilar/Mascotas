using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class DetallesMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;

        public Mascota mascota { get; set; }

        public DetallesMascotasModel()
        {
            this._repoMascota =
                new RepositorioMascota(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int mascotaId)
        {
            mascota = _repoMascota.GetMascota(mascotaId);
            if (mascota == null)
            {
                return RedirectToPage("./NotFount");
            }
            else
            {
                return Page();
            }
        }
    }
}
