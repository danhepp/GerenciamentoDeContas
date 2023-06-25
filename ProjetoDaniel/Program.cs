using ProjetoDaniel;
using System.Linq;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

AtendimentoCliente();
void AtendimentoCliente()
{
    try
    {
        char opcao = '0';
        while(opcao != '5')
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=====  Bem Vindo ao atendimento ao cliente =====");
            Console.WriteLine("============ 1 - Cadastrar Conta ===============");
            Console.WriteLine("============ 2 - Atualizar Conta ===============");
            Console.WriteLine("============ 3 - Pesquisar Conta ===============");
            Console.WriteLine("============ 4 - Remover Conta   ===============");
            Console.WriteLine("============ 5 - Sair do Sistema ===============");
            Console.WriteLine("================================================");
            Console.WriteLine("\n\n");
            Console.Write("Digite a opção desejada: ");
            try
            {
                opcao = Console.ReadLine()[0];
            }
            catch (ProjetoException excecao)
            {
                throw new ProjetoException(excecao.Message);
            }
            switch (opcao)
            {
                case '1':
                    CadastrarConta();
                    break;
                case '2':
                    AtualizarConta();
                    break;
                case '3':
                    PesquisarConta();
                    break;
                case '4':
                    RemoverConta();
                    break;
                case '5':
                    EncerrarAplicação();
                    break;
            }
        }
    }
    catch (ProjetoException excecao)
    {
        Console.WriteLine($"{excecao.Message}");
    }
}

void EncerrarAplicação()
{
    Console.WriteLine("...Encerrando a aplicação...");
    Console.ReadKey();
}

void RemoverConta()
{
    using (var contexto = new ProjetoContext())
    {
        Console.Clear();
        Console.WriteLine("================================================");
        Console.WriteLine("=============== Remover Conta ==================");
        Console.WriteLine("================================================");
        Console.WriteLine("\n\n");
        Console.Write("Informe o Nome do Cliente: ");
        string nome = Console.ReadLine();
        if (nome == null)
        {
            Console.WriteLine("Não foi possivel localizar o cliente...");
            Environment.Exit(0);
        }
        var retorno = contexto.Clientes.FirstOrDefault(x => x.Nome == nome);
        contexto.Clientes.Remove(retorno);
        contexto.SaveChanges();
        Console.WriteLine("Cliente Removido com sucesso...");
        Console.ReadLine();
    }
}

void PesquisarConta()
{
    using(var contexto = new ProjetoContext())
    {
        Console.Clear();
        Console.WriteLine("================================================");
        Console.WriteLine("============== Pesquisar Conta =================");
        Console.WriteLine("================================================");
        Console.WriteLine("\n\n");
        Console.Write("Informe o Nome do Cliente: ");
        string nome = Console.ReadLine();
        if (nome == null)
        {
            Console.WriteLine("Não foi possivel localizar o cliente...");
            Environment.Exit(0);
        }
        var retorno = contexto.Clientes.FirstOrDefault(x => x.Nome == nome);
        Console.WriteLine(retorno.ToString());
        Console.ReadKey();
                
        

    }

}

void AtualizarConta()
{
    using (var contexto = new ProjetoContext())
    {
        Console.Clear();
        Console.WriteLine("================================================");
        Console.WriteLine("============= Atualizar a Conta ================");
        Console.WriteLine("================================================");
        Console.WriteLine("\n\n");
        Console.Write("Qual o Id do Cliente que deseja atualizar as informações?: ");
        int Id = int.Parse(Console.ReadLine()); 
        Cliente cliente = new Cliente();
        var retorno = contexto.Clientes.Find(Id);
        if(retorno == null)
        {
            Console.WriteLine("Não foi possivel localizar o cliente...");
            Environment.Exit(0);
        }
        Console.Write("Qual o novo email do cliente?: ");
        retorno.Email = Console.ReadLine();
        contexto.Clientes.Update(retorno);
        contexto.SaveChanges();
        Console.WriteLine("Email atualizado com sucesso!!!");
        Console.ReadKey();

    }
}



void CadastrarConta()
{
    using (var contexto = new ProjetoContext()) 
    { 
        Console.Clear();
        Console.WriteLine("================================================");
        Console.WriteLine("============= Cadastro de Contas ===============");
        Console.WriteLine("================================================");
        Console.WriteLine("\n\n");
        Cliente cliente = new Cliente();
        Console.Write("Nome completo do Cliente: ");
        cliente.Nome = Console.ReadLine();
        Console.Write("Idade: ");
        cliente.Idade = int.Parse(Console.ReadLine());
        Console.Write("Cpf: ");
        cliente.Cpf = Console.ReadLine();
        Console.Write("Email: ");
        cliente.Email = Console.ReadLine();

        contexto.Clientes.Add(cliente);
        contexto.SaveChanges();
        Console.WriteLine("...Conta cadastrada com sucesso! ...");
        Console.ReadKey();
    }

}