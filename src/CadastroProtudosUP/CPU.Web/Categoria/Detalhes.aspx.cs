using CPU.Business.Interfaces;
using CPU.Business.Services;
using System;

namespace CPU.Web.Views.Categoria
{
    public partial class Detalhes : System.Web.UI.Page
    {
        private readonly ICategoriaService _categoriaService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int categoriaId;
                if (int.TryParse(Request.QueryString["CategoriaId"], out categoriaId))
                {
                    ExibirDetalhes(categoriaId);
                }
                else
                {
                    // Tratar erro de parâmetro inválido
                }
            }
        }

        public Detalhes()
        {
            _categoriaService = new CategoriaService(); // Instancie conforme a injeção de dependência do seu projeto
        }

        protected void ExibirDetalhes(int categoriaId)
        {
            var categoria = _categoriaService.GetById(categoriaId); // Implemente GetById() no serviço
            if (categoria != null)
            {
                txtNome.Text = categoria.Nome;
                txtDescricao.Text = categoria.Descricao;
            }
            else
            {
                // Tratar categoria não encontrada
            }
        }
    }
}
