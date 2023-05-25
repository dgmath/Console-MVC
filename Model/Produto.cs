
namespace Console_MVC.Model
{
    public class Produto
    {
        //propriedades
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public float Preco { get; set; }
        
        //caminho de pasta e do arquivo csv
        
        private const string PATH = "Database/Produto.csv";

        public Produto()
        {
            //criar a logica para gerar a pasta e o arquivo

            //obter o caminho da pasta 
            string pasta = PATH.Split("/")[0];

            //verificar se no caminho já existe uma pasta
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            //verificar se no caminho já existe um arquivo
            if (!File.Exists(PATH))
            {
                File.Create(PATH);
            }
        }
        public List<Produto> Ler()
        {
            List<Produto> produtos = new List<Produto>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] atributos = item.Split(";");

                Produto p = new Produto();
                
                p.Codigo = int.Parse(atributos[0]);
                p.Nome = atributos[1];
                p.Preco = float.Parse(atributos[2]);

                produtos.Add(p);

            }

            return produtos;
        }

        //método para preparar as linhas a serem inseridas no csv
        public string PrepararLinhasCSV(Produto p)
        {
            return $"{p.Codigo};{p.Nome};{p.Preco}";
                    //8008132;  Doritos;   10,99
        }

        //metodo para inserir um produto na linha do csv

        public void Inserir(Produto p)
        {
            //array que armazena as linhas obtidas pelo metodo prepararlinhasCSV
            string[] linhas = {PrepararLinhasCSV(p)};

            //inserir todas as linhas no arquivo dentro do PATH
            File.AppendAllLines(PATH, linhas);
        }
    }
}