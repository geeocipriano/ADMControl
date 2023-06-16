using Microsoft.AspNetCore.Mvc.Rendering;

namespace ADMControl.Web.Models
{
    public class ProdutoViewModel : Controller
    {
        public Produto Produto { get; set; }
        public List<Produto> Produtos { get; set; }
        public SelectList? listaCategorias { get; set; }
        public SelectList? listaUnidades { get; set; }

        public int FilSelectedCategoria { get; set; }
        public int FilSelectedUnidade { get; set; }
        public ProdutoViewModel()
        {
            Produto = new Produto();
            Produtos = new List<Produto>();
        }

        public async Task Load(ICategoriaRepositorio repCat, IUnidadeRepositorio repUni, IProdutoRepositorio repPro, int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    this.Produto = await repPro.BuscarProdutoPorId(id);
                }
                List<Produto> prod = await repPro.ListarProdutos();
                //foreach (Produto produto in prod)
                //{
                //    produto.Categoria = await repCat.BuscarCategoriaPorId(produto.PRO_IDCATEGORIA);
                //    produto.Unidade = await repUni.BuscarUnidadePorId(produto.PRO_IDUNIDADE);
                //    this.Produtos.Add(produto);
                //}

                this.Produtos = prod;
                List<Categoria> categoriasrep = await repCat.ListarCategorias();

                this.listaCategorias = new SelectList(
                    new[] { new { Text = "", Value = 0, Selected = (int)Produto.PRO_IDCATEGORIA } }
                    .Concat(categoriasrep.Select(c => new { Text = c.CAT_NOME.ToUpper(), Value = c.CAT_ID, Selected = (int)Produto.PRO_IDCATEGORIA })),
                    "Value", "Text"
                );

                List<Unidade> unidaderep = await repUni.ListarUnidades();
                this.listaUnidades = new SelectList(
                    new[] { new { Text = "", Value = 0, Selected = (int)Produto.PRO_IDCATEGORIA } }
                    .Concat(unidaderep.Select(c => new { Text = c.UNI_SIGLA, Value = c.UNI_ID, Selected = (int)Produto.PRO_IDUNIDADE })),
                    "Value", "Text"
                );


            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
