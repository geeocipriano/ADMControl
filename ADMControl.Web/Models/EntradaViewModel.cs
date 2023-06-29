using Microsoft.AspNetCore.Mvc.Rendering;

namespace ADMControl.Web.Models
{
    public class EntradaViewModel
    {
        public Entrada Entrada { get; set; }
        public List<Entrada> Entradas { get; set; }
        public List<ProdutoxEntrada> ProdutoxEntradas { get; set; }
        public SelectList? listaProdutos { get; set; }
        public int FilSelectedProduto { get; set; }
        public EntradaViewModel()
        {
            Entrada = new Entrada();
            Entradas = new List<Entrada>();
            ProdutoxEntradas = new();
        }

        public async Task Load(IProdutoRepositorio repProd, IEntradaRepositorio repEnt, int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    this.Entrada = await repEnt.BuscarEntradaPorId(id);
                }
                this.Entradas = await repEnt.ListarEntradas();

                List<Produto> produtosrep = await repProd.ListarProdutos();

                this.listaProdutos = new SelectList(
                    new[] { new { Text = "", Value = 0, Selected = true } }
                    .Concat(produtosrep.Select(c => new { Text = c.PRO_DESC.ToUpper(), Value = c.PRO_ID, Selected = false })),
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
