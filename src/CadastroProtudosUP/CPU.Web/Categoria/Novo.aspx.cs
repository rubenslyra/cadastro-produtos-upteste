using CPU.Business.Interfaces;
using CPU.Business.Services;
using CPU.Models.DTOs;
using System;

namespace CPU.Web.Views.Categoria
{
    public partial class Novo : System.Web.UI.Page
    {
        private readonly ICategoriaService _categoriaService;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Nenhuma lógica necessária no carregamento inicial
        }

        public Novo()
        {
            _categoriaService = new CategoriaService(); // Instancie conforme a injeção de dependência do seu projeto
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            CategoriaDTO categoria = new CategoriaDTO
            {
                Nome = txtNome.Text,
                Descricao = txtDescricao.Text
            };

            _categoriaService.Add(categoria: categoria); // Implemente Create() no serviço

            // Redirecionar para a página de listagem após salvar
            Response.Redirect("Listagem.aspx");
        }
    }
}
