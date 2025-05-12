namespace MapL.Pagination
{
    public class PagedList<T> : List<T> where T : class
    {
        public int CurrentPage { get; set; } // Representa a página atual
        public int TotalPage { get; set; }  // Total de páginas
        public int PageSize { get; set; } // Armazena o numero de itens por página
        public int TotalCount { get; set; } // Número total de itens

        public bool HasPrevious => (CurrentPage > 1); // Verifica se existe uma página anterior
        public bool HasNext => (CurrentPage < TotalPage); // Verifica se existe uma próxima página


        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        // Construtor que define os parâmentros da paginação
        {
            TotalCount = count;
            PageSize = pageSize; 
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            CurrentPage = pageNumber; 

            AddRange(items); // Adiciona os itens à lista atual
        }
        public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        // Método que cria uma lista paginada
        {
            var count = source.Count(); // Conta quantos dados tem no banco
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();   // Lógica para pegar somente os dados necessário, pulando os que não são necessários

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }








    }
}
