using CPU.Business.Interfaces;
using CPU.Business.Services;
using CPU.Models.DTOs;
using System;

namespace CPU.Web.Views.Categoria
{
    public partial class Editar : System.Web.UI.Page
    {
        private readonly ICategoriaService _categoriaService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int categoriaId;
                if (int.TryParse(Request.QueryString["CategoriaId"], out categoriaId))
                {
                    CarregarCategoria(categoriaId);
                }
                else
                {
                    // Tratar erro de parâmetro inválido
                }
            }
        }

        public Editar()
        {
            _categoriaService = new CategoriaService(); // Instancie conforme a injeção de dependência do seu projeto
        }

        protected void CarregarCategoria(int categoriaId)
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

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            int categoriaId;
            if (int.TryParse(Request.QueryString["CategoriaId"], out categoriaId))
            {
                CategoriaDTO categoriaAtualizada = new CategoriaDTO
                {
                    CategoriaId = categoriaId,
                    Nome = txtNome.Text,
                    Descricao = txtDescricao.Text
                };

                _categoriaService.Update(categoriaAtualizada); // Implemente Update() no serviço

                // Redirecionar para a página de listagem após atualizar
                Response.Redirect("Listagem.aspx");
            }
            else
            {
                // Tratar erro de parâmetro inválido
            }
        }
    }
}
