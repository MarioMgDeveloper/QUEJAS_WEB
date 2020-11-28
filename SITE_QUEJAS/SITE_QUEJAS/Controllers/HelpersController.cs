using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SITE_QUEJAS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Controllers
{
    public class HelpersController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> FillMunicipios(string IdDepartamento, string IdSelected)
        {
            ClsCatalogos catalogos = new ClsCatalogos();

            ViewBag.ListMunicipios = new SelectList(await catalogos.ListMunicipios(IdDepartamento), "IdMunicipio", "NombreMunicipio");
            ViewBag.Selected = IdSelected;

            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> FillDepartamentos(string IdRegion, string IdSelected)
        {
            ClsCatalogos catalogos = new ClsCatalogos();
            ViewBag.ListDepartamentos = new SelectList(await catalogos.ListDepartamentosById(IdRegion), "IdDepartamento", "NombreDepartamento");
            ViewBag.Selected = IdSelected;
            return PartialView();
        }
    }
}
