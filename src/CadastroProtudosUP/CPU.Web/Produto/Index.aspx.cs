using CPU.Business.Interfaces;
using CPU.Business.Services;
using System;

namespace CPU.Web.Produto
{
    public partial class Listagem : System.Web.UI.Page
    {
        private readonly IProdutoService _produtoService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        public Listagem()
        {
            _produtoService = new ProdutoService(); // Instancie conforme a injeção de dependência do seu projeto
        }

        protected void BindGrid()
        {
            var produtos = _produtoService.GetAll(); // Implemente GetAll() no serviço
            gvProdutos.DataSource = produtos;
            gvProdutos.DataBind();
        }

        protected void gvProdutos_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvProdutos.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}
