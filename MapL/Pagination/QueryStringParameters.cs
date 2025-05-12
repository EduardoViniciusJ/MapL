namespace MapL.Pagination
{
    public class QueryStringParameters
    {
        const int maxPageSize = 50; // Tamanho máximo de itens por página. 
        public int PageNumber { get; set; } = 1; // Número da página atual, sendo 1 a primeira página.

        private int _pageSize = maxPageSize; 
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value; // Se o valor dos itens for maior que o máximo, define como o máximo de itens que é 50.
        }   

    }
}
