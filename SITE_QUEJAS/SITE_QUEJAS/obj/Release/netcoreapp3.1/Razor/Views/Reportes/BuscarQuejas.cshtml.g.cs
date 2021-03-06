#pragma checksum "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "924042968f2e8f3c5d8ac56acf74cb4b3c862e29"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reportes_BuscarQuejas), @"mvc.1.0.view", @"/Views/Reportes/BuscarQuejas.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\_ViewImports.cshtml"
using SITE_QUEJAS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\_ViewImports.cshtml"
using SITE_QUEJAS.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\_ViewImports.cshtml"
using SITE_QUEJAS.Models.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\_ViewImports.cshtml"
using SITE_QUEJAS.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\_ViewImports.cshtml"
using SITE_QUEJAS.Models.Quejas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\_ViewImports.cshtml"
using SITE_QUEJAS.Models.Comercios;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\_ViewImports.cshtml"
using SITE_QUEJAS.Models.Informes;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"924042968f2e8f3c5d8ac56acf74cb4b3c862e29", @"/Views/Reportes/BuscarQuejas.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be701337afe496bed0c57d9a928c43f9cc5c3059", @"/Views/_ViewImports.cshtml")]
    public class Views_Reportes_BuscarQuejas : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
  
    List<ClsInfoInformQuejas> quejas = new List<ClsInfoInformQuejas>();

    if (ViewBag.Lista != null)
    {
        quejas = (List<ClsInfoInformQuejas>)ViewBag.Lista;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 11 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
 if (ViewBag.Error == null)
{
    if (quejas.Count > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <label class=\"font-weight-bold text-primary\">");
#nullable restore
#line 15 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
                                                Write(quejas.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" queja(s) relacionada(s) con la búsqueda</label>
        <table class=""table  table-sm w-100"" id=""TablaQuejas"">
            <thead>
                <tr class=""table-dark"">
                    <th scope=""col"">#</th>
                    <th scope=""col"">Comercio</th>
                    <th scope=""col"">Región</th>
                    <th scope=""col"">Ubicación</th>
                    <th scope=""col"">Dirección</th>
                    <th scope=""col"">Estado</th>
                    <th scope=""col"">Registrada el</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 29 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
                 for (int i = 0; i < quejas.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
#nullable restore
#line 32 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
                                Write(i+1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 33 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
                   Write(quejas[i].Empresa);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 34 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
                   Write(quejas[i].Region);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 35 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
                   Write(quejas[i].Ubicacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 36 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
                   Write(quejas[i].Direccion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 37 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
                   Write(quejas[i].Estado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 38 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
                   Write(quejas[i].FechaCreacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 40 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 43 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-warning w-100\" role=\"alert\">\r\n            La búsqueda no generó resultados.\r\n        </div>\r\n");
#nullable restore
#line 49 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
    }
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger w-100\" role=\"alert\">\r\n        ");
#nullable restore
#line 54 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
   Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 56 "C:\Users\alexa\source\repos\SITE_QUEJAS\SITE_QUEJAS\Views\Reportes\BuscarQuejas.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
