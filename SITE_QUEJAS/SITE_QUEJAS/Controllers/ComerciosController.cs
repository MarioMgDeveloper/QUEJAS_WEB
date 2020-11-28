using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SITE_QUEJAS.Helpers;
using SITE_QUEJAS.Models.Comercios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Controllers
{
    [Authorize(Roles = "ADMINISTRADOR")]
    public class ComerciosController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> BusquedaComercios(int IdDepto, int IdMuni, string NombreBusqueda)
        {
            ClsPeticiones peticiones = new ClsPeticiones();
            ClsFiltroBusquedaComercio filtros = new ClsFiltroBusquedaComercio() {
                IdDepto = IdDepto,
                IdMuni = IdMuni,
                Nombre = NombreBusqueda.Equals("0")? null:NombreBusqueda
            };
            var response = await peticiones.PostComplejo<ClsFiltroBusquedaComercio, Cls_Response<List<ClsInfoSucursales>>>(filtros, "Comercios/GetComercios");

            if (!response.Error)
            {
                ViewBag.LisComercios = response.Body;
            }
            else
            {
                ViewBag.Error = response.Error;
            }
            
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> RegistrarComercios()
        {
            ClsCatalogos catalogos = new ClsCatalogos();
            List<int> ids = new List<int> { 1, 2 };
            ViewBag.ListEstados = new SelectList(await catalogos.ListEstados(ids), "IdEstado", "NombreEstado");
            ClsCreateEmpresa model = new ClsCreateEmpresa();
            model.Empresa = new  TbEmpresa();

            AdminSession sesion = new AdminSession(HttpContext);
            if (sesion.GetString(VariablesDeSession.MensajeExito) != null)
            {
                ViewBag.Exito = sesion.GetString(VariablesDeSession.MensajeExito);
                sesion.Remove(VariablesDeSession.MensajeExito);
            }
          
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> GuardarEmpresa(ClsCreateEmpresa model)
        {
            ClsCatalogos catalogos = new ClsCatalogos();
            List<int> ids = new List<int> { 1, 2 };
            ViewBag.ListEstados = new SelectList(await catalogos.ListEstados(ids), "IdEstado", "NombreEstado");
            if (ModelState.IsValid)
            {
                ClsPeticiones peticiones = new ClsPeticiones();
                AdminSession sesion = new AdminSession(HttpContext);
                var response = await peticiones.PostComplejoAutenticado<TbEmpresa, Cls_Response<string>>(model.Empresa, "Comercios/GuardarEmpresa", sesion.GetClaim(VariablesDeSession.Token));

                if (response != null)
                {
                    if (!response.Error)
                    {
                        sesion.SetString(response.Body, VariablesDeSession.MensajeExito);
                        return RedirectToAction("RegistrarComercios", "Comercios");
                    }
                    else
                    {
                        ViewBag.Error = response.Message;
                        return View("RegistrarComercios", model);
                    }
                }
                else
                {
                    ViewBag.Error = "Error al comunicarse con el servicio.";
                    return View("RegistrarComercios", model);
                }


            }
            else
            {
                return View("RegistrarComercios", model);
            }
       }

        [HttpPost]
        public async Task<IActionResult> AdminEmpresas()
        {
            ClsPeticiones peticiones = new ClsPeticiones();
            AdminSession sesion = new AdminSession(HttpContext);
            ClsFiltroBusquedaComercio filtros = new ClsFiltroBusquedaComercio();
            var response = await peticiones.PostComplejoAutenticado<ClsFiltroBusquedaComercio, Cls_Response<List<TbEmpresa>>>(filtros, "Comercios/GetEmpresas", sesion.GetClaim(VariablesDeSession.Token));

            if (!response.Error)
            {
                ViewBag.Lista = response.Body;
            }
            else
            {
                ViewBag.Error = response.Error;
            }


            return PartialView();
        }


        [HttpGet]
        public async Task<IActionResult> AdminEstablecimientos(string IdEmpresa)
        {
            ClsPeticiones peticiones = new ClsPeticiones();
            ClsCatalogos catalogos = new ClsCatalogos();
            AdminSession sesion = new AdminSession(HttpContext);
            List<int> ids = new List<int> { 1, 2 };
            ViewBag.ListEstados = new SelectList(await catalogos.ListEstados(ids), "IdEstado", "NombreEstado");
            ViewBag.ListaDepartamentos = new SelectList(await catalogos.ListDepartamentos(), "IdDepartamento", "NombreDepartamento");
            sesion.SetString(IdEmpresa, VariablesDeSession.IdEmpresa);
            //var result = await peticiones.GetComplejoAnonimo<string, Cls_Response<List<ClsInfoSucursales>>>("Comercios/GetEstablecimientosById/" + IdEmpresa);
            ClsCreateEstablecimiento model = new ClsCreateEstablecimiento();
            model.Establecimiento = new TbEstablecimiento();

            if (sesion.GetString(VariablesDeSession.MensajeExito) != null)
            {
                ViewBag.Exito = sesion.GetString(VariablesDeSession.MensajeExito);
                sesion.Remove(VariablesDeSession.MensajeExito);
            }

            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ListarEstablecimientos()
        {
            ClsPeticiones peticiones = new ClsPeticiones();
            AdminSession sesion = new AdminSession(HttpContext);
            var result = await peticiones.GetComplejoAnonimo<string, Cls_Response<List<ClsInfoSucursales>>>("Comercios/GetEstablecimientosById/" + sesion.GetString(VariablesDeSession.IdEmpresa));
            ViewBag.Lista = result.Body;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> GuardarEstablecimiento(ClsCreateEstablecimiento model)
        {
            ClsPeticiones peticiones = new ClsPeticiones();
            ClsCatalogos catalogos = new ClsCatalogos();
            List<int> ids = new List<int> { 1, 2 };
            ViewBag.ListEstados = new SelectList(await catalogos.ListEstados(ids), "IdEstado", "NombreEstado");
            ViewBag.ListaDepartamentos = new SelectList(await catalogos.ListDepartamentos(), "IdDepartamento", "NombreDepartamento");
            AdminSession session = new AdminSession(HttpContext);
            if (ModelState.IsValid)
            {
                model.Establecimiento.IdEmpresa = int.Parse(session.GetString(VariablesDeSession.IdEmpresa));
                var response = await peticiones.PostComplejoAutenticado<TbEstablecimiento, Cls_Response<string>>(model.Establecimiento, "Comercios/GuardarEstablecimiento", session.GetClaim(VariablesDeSession.Token));
                if (!response.Error)
                {
                  
                    session.SetString(response.Body, VariablesDeSession.MensajeExito);
                    return RedirectToAction("AdminEstablecimientos", "Comercios", new { IdEmpresa = session.GetString(VariablesDeSession.IdEmpresa) });
                }
                else
                {
                    ViewBag.Error = response.Message;
                    return View("AdminEstablecimientos", model);
                }
            }
            else
            {
                return View("AdminEstablecimientos", model);
            }
        }

    }
}
