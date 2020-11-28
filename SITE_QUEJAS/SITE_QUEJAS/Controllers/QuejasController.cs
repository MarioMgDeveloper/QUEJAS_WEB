using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SITE_QUEJAS.Helpers;
using SITE_QUEJAS.Models.Comercios;
using SITE_QUEJAS.Models.Informes;
using SITE_QUEJAS.Models.Quejas;

namespace SITE_QUEJAS.Controllers
{
    [Authorize(Roles = "ADMINISTRADOR, SUPERVISOR")]
    public class QuejasController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> Registrar()
        {
            ClsCatalogos catalogos = new ClsCatalogos();
            ClsRegistroQueja model = new ClsRegistroQueja();
            ViewBag.ListaDepartamentos = new SelectList(await catalogos.ListDepartamentos(), "IdDepartamento", "NombreDepartamento");
            ViewBag.LisCatQueja = new SelectList(await catalogos.ListCategoriaQueja(), "IdCategoriaQueja", "Nombre");
            ViewBag.Categoria = new SelectList(await catalogos.ListCategoriaQueja(), "IdCategoriaQueja", "Nombre");
            AdminSession session = new AdminSession(HttpContext);

            if (session.GetString(VariablesDeSession.MensajeExito) != null)
            {
                ViewBag.Exito = session.GetString(VariablesDeSession.MensajeExito);
                session.Remove(VariablesDeSession.MensajeExito);
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GuardarQueja(ClsRegistroQueja model)
        {
            ClsCatalogos catalogos = new ClsCatalogos();
            ViewBag.ListaDepartamentos = new SelectList(await catalogos.ListDepartamentos(), "IdDepartamento", "NombreDepartamento");
            ViewBag.LisCatQueja = new SelectList(await catalogos.ListCategoriaQueja(), "IdCategoriaQueja", "Nombre");
            ViewBag.Categoria = new SelectList(await catalogos.ListCategoriaQueja(), "IdCategoriaQueja", "Nombre");
            if (ModelState.IsValid)
            {
                TbQueja queja = new TbQueja
                {
                    Descripcion = model.DescripcionQueja,
                    IdEstado = 3,
                    IdEstablecimiento = model.IdComercio,
                    IdCategoriaQueja = 1
                };

                ClsPeticiones peticiones = new ClsPeticiones();
                var response = await peticiones.PostComplejo<TbQueja, Cls_Response<string>>(queja, "Quejas/GuardarQueja");

                if (!response.Error)
                {
                    AdminSession session = new AdminSession(HttpContext);
                    session.SetString(response.Body, VariablesDeSession.MensajeExito);
                    session.SetString(response.Body, VariablesDeSession.MensajeExito);
                    return RedirectToAction("Registrar", "Quejas");
                }
                else
                {
                    ViewBag.Error = response.Message;
                    return View("Registrar", model);
                }
            }
            else
            {
                return View("Registrar", model);
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> BuscarQueja()
        {

            return View();
        }
          [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> DetalleQueja(string IdQueja)
        {
            ClsPeticiones peticiones = new ClsPeticiones();
            var response = await peticiones.GetComplejo<string, Cls_Response<DetalleQueja>>("Quejas/GetQueja/" + IdQueja);

            if (!response.Error)
            {
                ViewBag.Detalle = response.Body;
            }
            else
            {
                ViewBag.Error = response.Message;
            }
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> AtenderQueja()
        {
            ClsPeticiones peticiones = new ClsPeticiones();
            AdminSession sesion = new AdminSession(HttpContext);
            ClsFiltrosInformesQuejas model = new ClsFiltrosInformesQuejas();

            model.IdEstado = 3;
            var result = await peticiones.PostComplejoAutenticado<ClsFiltrosInformesQuejas, Cls_Response<List<ClsInfoInformQuejas>>>(model, "Informes/GetInformeQuejas", sesion.GetClaim(VariablesDeSession.Token));
            if (sesion.GetString(VariablesDeSession.MensajeExito) != null)
            {
                ViewBag.Exito = sesion.GetString(VariablesDeSession.MensajeExito);
                sesion.Remove(VariablesDeSession.MensajeExito);
            }



            return View(result.Body);
        }

        [HttpPost]
        public async Task<IActionResult> ResolverQueja(List<ClsInfoInformQuejas> model)
        {
            ClsPeticiones peticiones = new ClsPeticiones();
            AdminSession sesion = new AdminSession(HttpContext);
            bool ok = true;

            foreach (var item in model)
            {
                if(item.check && string.IsNullOrEmpty(item.DescripcioResuelve))
                {
                    ok = false;
                }
            }

            if (ok)
            {
                var response = await peticiones.PostComplejoAutenticado<List<ClsInfoInformQuejas>, Cls_Response<string>>(model, "Quejas/AtenderQuejas", sesion.GetClaim(VariablesDeSession.Token));
                if (!response.Error)
                {
                    sesion.SetString(response.Body, VariablesDeSession.MensajeExito);
                    return RedirectToAction("AtenderQueja", "Quejas");
                }
                else
                {
                    return View("AtenderQueja", model);
                }
               
            }
            else
            {
                return View("AtenderQueja",model);
            }
            
        }
    }
}
