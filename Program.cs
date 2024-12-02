using System;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Inicializa um gerador de números aleatórios
Random random = new Random();
// Gera uma lista de hóspedes aleatória (1 a 4)
int numeroHospedes = random.Next(1, 5);

List<Pessoa> hospedes = new List<Pessoa>();

for (int i = 0; i < numeroHospedes; i++)
    {
      hospedes.Add(new Pessoa(nome: $"Hóspede {i + 1}"));
    }


// Gera a capacidade da suíte aleatoriamente (0 a 4)
int capacidadeSuite = random.Next(1, 5);
Suite suite = new Suite(tipoSuite: "Premium", capacidade: capacidadeSuite, valorDiaria: 30);
Console.WriteLine($"Capacidade da suíte: {suite.Capacidade}");

// Gera os dias reservados aleatoriamente (1 a 20)
int diasReservados = random.Next(1, 21);
Console.WriteLine($"Dias reservados: {diasReservados}");

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor Total: {reserva.CalcularValorDiaria():C}");