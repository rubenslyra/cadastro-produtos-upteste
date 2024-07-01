using CPU.Business.Interfaces;
using CPU.Business.Services;
using System;

namespace CPU.Web.Views.Categoria
{
    public partial class Listagem : System.Web.UI.Page
    {
        private readonly ICategoriaService _categoriaService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        public Listagem()
        {
            _categoriaService = new CategoriaService(); // Instancie conforme a injeção de dependência do seu projeto
        }

        protected void BindGrid()
        {
            var categorias = _categoriaService.GetAll(); // Implemente GetAll() no serviço
            gvCategorias.DataSource = categorias;
            gvCategorias.DataBind();
        }
    }
}
