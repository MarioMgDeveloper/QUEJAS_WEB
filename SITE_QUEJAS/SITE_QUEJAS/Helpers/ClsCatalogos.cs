using SITE_QUEJAS.Models.Catalogos;
using SITE_QUEJAS.Models.Comercios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Helpers
{
    public  class ClsCatalogos
    {
        ClsPeticiones peticiones = new ClsPeticiones();
        public async Task<List<TbRegion>> ListRegiones()
        {
            var response = await peticiones.GetComplejo<string, Cls_Response<List<TbRegion>>>("Catalogos/GetRegiones");

            if (response.Error)
            {
                return new List<TbRegion>();
            }
            else
            {
                return response.Body;
            }
        }

        public async Task<List<TbDepartamento>> ListDepartamentos()
        {
            var response = await peticiones.GetComplejo<string, Cls_Response<List<TbDepartamento>>>("Catalogos/GetDepartamentos");

            if (response.Error)
            {
                return new List<TbDepartamento>();
            }
            else
            {
                return response.Body;
            }
        }

        public async Task<List<TbDepartamento>> ListDepartamentosById(string Id)
        {
            var response = await peticiones.GetComplejo<string, Cls_Response<List<TbDepartamento>>>("Catalogos/GetDepartamentosPorRegion/" + Id);

            if (response.Error)
            {
                return new List<TbDepartamento>();
            }
            else
            {
                return response.Body;
            }
        }

        public async Task<List<TbMunicipio>> ListMunicipios(string IdDepto)
        {
            IdDepto = IdDepto ?? "0";
            var response = await peticiones.GetComplejo<string, Cls_Response<List<TbMunicipio>>>("Catalogos/GetMunicipios/" + IdDepto);

            if (response.Error)
            {
                return new List<TbMunicipio>();
            }
            else
            {
                return response.Body;
            }
        }

        public async Task<List<TbEmpresa>> ListComercios()
        {
            var response = await peticiones.GetComplejo<string, Cls_Response<List<TbEmpresa>>>("Catalogos/GetListComercios");

            if (response.Error)
            {
                return new List<TbEmpresa>();
            }
            else
            {
                return response.Body;
            }
        }

        public async Task<List<TbEstablecimiento>> ListComercios(string IdComercio)
        {
            var response = await peticiones.GetComplejo<string, Cls_Response<List<TbEstablecimiento>>>("Catalogos/GetListSucursales/"+IdComercio);

            if (response.Error)
            {
                return new List<TbEstablecimiento>();
            }
            else
            {
                return response.Body;
            }
        }

        public async Task<List<TbCategoriaQueja>> ListCategoriaQueja()
        {
            var response = await peticiones.GetComplejo<string, Cls_Response<List<TbCategoriaQueja>>>("Catalogos/GetListTipoQueja");

            if (response.Error)
            {
                return new List<TbCategoriaQueja>();
            }
            else
            {
                return response.Body;
            }
        }

        public async Task<List<TbEstado>> ListEstados(List<int> ids)
        {
            var response = await peticiones.PostComplejo<List<int>, Cls_Response<List<TbEstado>>> (ids,"Catalogos/GetEstados");

            if (response.Error)
            {
                return new List<TbEstado>();
            }
            else
            {
                return response.Body;
            }
        }
    }
}
