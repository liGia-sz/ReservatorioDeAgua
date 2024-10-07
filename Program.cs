using System;

class Program
{
    static void Main(string[] args)
    {
        bool teste = true, boiaAAtivada, boiaBAtivada, boiaC, bomba, valvula, erro;
        
        while (teste)
        {
            EscreverTitulo();
            // Informa o estado do reservatório
            Console.WriteLine("Informe o nível de água no reservatório (0 para \u001b[91mNÃO ACIONADA\u001b[0m, 1 para \u001b[92mACIONADA\u001b[0m):");
            float nivelDeAgua = float.Parse(Console.ReadLine());

            // Verifica o estado das boias
            boiaAAtivada = LerEstadoBoia("Boia A [Reservatório 1 – Nível 1]");
            boiaBAtivada = LerEstadoBoia("Boia B [Reservatório 1 – Nível 2]");
            boiaC = LerEstadoBoia("Boia C [Reservatório 2 – Nível 3]");
            
            // Controle de S1 e S2 com base no nível das boias
            if (!boiaAAtivada && !boiaBAtivada && !boiaC) 
            {
                erro = false;
                bomba = false;
                valvula = false; // Ambos os reservatórios vazios, tudo off
            }
            else if (boiaAAtivada && !boiaBAtivada && !boiaC)
            {
                erro = false;
                bomba = true; // Liga apenas a bomba
                valvula = false;
            }
            else if (boiaAAtivada && boiaBAtivada && !boiaC)
            {
                erro = false;
                bomba = true; // Continua bombeando
                valvula = true; // Abre a válvula
            }
            else if (boiaAAtivada && boiaBAtivada && boiaC)
            {
                erro = false;
                bomba = false; // Desliga a bomba
                valvula = true; // Válvula segue aberta
            }
            else // Inconsistência detectada
            {
                erro = true; // Sinaliza erro
                bomba = false; // Desliga a bomba
                valvula = false; // Fecha a válvula
            }
            
            // Exibindo o status do sistema
            if (erro)
            {
                Console.WriteLine("\n\u001b[91mERRO: Inconsistência detectada!");
                Console.WriteLine("Travando a bomba e a válvula! Chame a manutenção!\u001b[0m\n");
            }
            else
            {
                Console.WriteLine("\n\u001b[92mSistema operando corretamente.");
                Console.WriteLine($"\u001b[36mBomba de água: {(bomba ? "\u001b[92mLIGADA" : "\u001b[91mDESLIGADA")}");
                Console.WriteLine($"\u001b[36mEletroválvula de entrada de água: {(valvula ? "\u001b[92mABERTA" : "\u001b[91mFECHADA")}\u001b[0m\n");
            }

            string continuarTeste; // Declarar a variável aqui

            while (true)
            {
                Console.Write("Deseja fazer um novo teste? (S/N): ");
                continuarTeste = Console.ReadLine().ToUpper(); // Lê a resposta do usuário
                if (continuarTeste == "S" || continuarTeste == "N") // Verifica a resposta
                    break;
                else
                    Console.WriteLine("\u001b[91mOpção inválida! Digite S ou N.\u001b[0m");
            }

            if (continuarTeste == "N")
            {
                teste = false; // Sai do loop se o usuário não quiser continuar
            }
        }
        EscreverTitulo();
        Console.WriteLine("\nSaindo...");
    }

    static void EscreverTitulo()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("-- RESERVATÓRIO DE ÁGUA --");
        Console.ResetColor();
    }

    static bool LerEstadoBoia(string boia)
    {
        string escolhaUsuario;
        
        while (true)
        {
            Console.Write($"> \u001b[36m{boia}\u001b[0m: ");
            escolhaUsuario = Console.ReadLine().ToUpper();
            if (escolhaUsuario == "0" || escolhaUsuario == "1")
                return escolhaUsuario == "1";
            else
                Console.WriteLine("\u001b[91mEntrada inválida! Digite 0 ou 1.\u001b[0m");
        }
    }
}
