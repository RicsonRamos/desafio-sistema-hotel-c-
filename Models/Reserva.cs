namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; private set; } = new List<Pessoa>();
        public Suite Suite { get; private set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte precisa ser cadastrada antes de cadastrar hóspedes.");
            }

            // Verifica se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
                Console.WriteLine("Hóspedes cadastrados com sucesso!");
            }
            else
            {
                throw new InvalidOperationException($"Número de hóspedes ({hospedes.Count}) excede a capacidade máxima permitida ({Suite.Capacidade}).");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            if (suite == null)
            {
                throw new ArgumentNullException(nameof(suite), "A suíte não pode ser nula.");
            }

            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            int quantidade = Hospedes?.Count ?? 0;
            
            return quantidade;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte precisa ser cadastrada antes de calcular o valor da diária.");
            }

            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplica o desconto de 10% para reservas de 10 dias ou mais
            if (DiasReservados >= 10)
            {
                valor -= valor * 0.10m;
            }

            return valor;
        }
    }
}