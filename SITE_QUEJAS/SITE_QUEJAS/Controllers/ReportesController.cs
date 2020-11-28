using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SITE_QUEJAS.Helpers;
using SITE_QUEJAS.Models.Informes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Controllers
{
    [Authorize(Roles = "ADMINISTRADOR")]
    public class ReportesController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> ReporteQuejas()
        {
            ClsCatalogos catalogos = new ClsCatalogos();
            ClsFiltrosInformesQuejas model = new ClsFiltrosInformesQuejas();
            ViewBag.ListRegion = new SelectList(await catalogos.ListRegiones(), "IdRegion", "NombrRegion");
            List<int> ids = new List<int> { 3, 4 };
            ViewBag.ListEstados = new SelectList(await catalogos.ListEstados(ids), "IdEstado", "NombreEstado");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BuscarQuejas(string region, string departamento, string municipio, string estado, string del, string al, string nombre)
        {
            ClsPeticiones peticiones = new ClsPeticiones();
            AdminSession session = new AdminSession(HttpContext);
            DateTime? Del = null, Al = null;

            if (!del.Equals("0"))
            {
                try
                {
                    Del = DateTime.Parse(del);
                }
                catch (Exception)
                {
                }
            }

            if (!al.Equals("0"))
            {
                try
                {
                    Al = DateTime.Parse(al);
                }
                catch (Exception)
                {
                }
            }

            int.TryParse(region, out int IdRegion);
            int.TryParse(departamento, out int IdDepartamento);
            int.TryParse(municipio, out int IdMunicipio);
            int.TryParse(estado, out int IdEstado);


            ClsFiltrosInformesQuejas model = new ClsFiltrosInformesQuejas()
            {
                IdRegion = IdRegion,
                IdDepartamento = IdDepartamento,
                IdMunicipio = IdMunicipio,
                IdEstado = IdEstado,
                Del = Del,
                Al = Al,
                Nombrecomercio = nombre.Equals("null") ? null : nombre
            };




            var result = await peticiones.PostComplejoAutenticado<ClsFiltrosInformesQuejas, Cls_Response<List<ClsInfoInformQuejas>>>(model, "Informes/GetInformeQuejas", session.GetClaim(VariablesDeSession.Token));

            if (!result.Error)
            {
                ViewBag.Lista = result.Body;
                session.SetObject(VariablesDeSession.DataReporte, result.Body);
            }
            else
            {
                ViewBag.Error = result.Message;
            }
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> DescargarReporte()
        {
            AdminSession sesion = new AdminSession(HttpContext);
            List<ClsInfoInformQuejas> data = sesion.GetObject<List<ClsInfoInformQuejas>>(VariablesDeSession.DataReporte);

            if (data != null)
            {
                var stream = new MemoryStream();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                await Task.Yield();
                //        var list = new List<UserInfo>()
                //{
                //    new UserInfo { UserName = "catcher", Age = 18 },
                //    new UserInfo { UserName = "james", Age = 20 },
                //};
                PropertyInfo[] properties = typeof(ClsInfoInformQuejas).GetProperties();

                using (var package = new ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.Add("Sheet1");

                    //C1 - J3
                    using (ExcelRange Title = workSheet.Cells[1, 1, 1, properties.Length -6])
                    {
                        Title.Merge = true;
                        Title.Style.Font.Size = 18;
                        Title.Style.Font.Bold = true;
                        Title.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        Title.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        Title.Value = "REPORTE DE QUEJAS";
                    }

                    var datos = (from d in data
                                 select new
                                 {
                                     d.Empresa,
                                     d.Region,
                                     d.Ubicacion,
                                     d.Direccion,
                                     d.Estado,
                                     d.FechaCreacion,
                                     d.FechaModificacion
                                 }).ToList();

                    workSheet.Cells[4, 1].Value = "Establecimiento";
                    workSheet.Cells[4, 1].Style.Font.Bold = true;
                    workSheet.Cells[4, 2].Value = "Región";
                    workSheet.Cells[4, 2].Style.Font.Bold = true;
                    workSheet.Cells[4, 3].Value = "Ubicación";
                    workSheet.Cells[4, 3].Style.Font.Bold = true;
                    workSheet.Cells[4, 4].Value = "Dirección";
                    workSheet.Cells[4, 4].Style.Font.Bold = true;
                    workSheet.Cells[4, 5].Value = "Estado";
                    workSheet.Cells[4, 5].Style.Font.Bold = true;
                    workSheet.Cells[4, 6].Value = "Fecha creación";
                    workSheet.Cells[4, 6].Style.Font.Bold = true;
                    workSheet.Cells[4, 7].Value = "Fecha resolución";
                    workSheet.Cells[4, 7].Style.Font.Bold = true;
                    workSheet.Cells[5, 1].LoadFromCollection(datos);


                    workSheet.Cells.AutoFitColumns();



                    package.Save();
                }
                stream.Position = 0;
                string excelName = $"Reporte_de_quejas" + $"-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

                //return File(stream, "application/octet-stream", excelName);  
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
            else
            {
                return Ok();
            }
        }
    }
}