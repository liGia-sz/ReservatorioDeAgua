# ReservatorioDeAgua
Atividade desenvolvida durante as aulas de Interface Web do curso técnico em Informática 
para Internet. Simulamos o funcionamento de um programa para o controle e 
monitoramento do nível de água de dois reservatórios, 
seguindo as regras abaixo:

1. A bomba de água não pode funcionar com o reservatório vazio.
2. A bomba deverá ligar quando o nível de água do reservatório estiver abaixo da boia C.
3. A eletroválvula S2 irá permitir a entrada de água enquanto a boia B for acionada.
4. Exibir um sinal de erro quando houver inconsistência no sistema de monitoramento do reservatório 1, evitando que a bomba e a eletroválvula acionem.
   
<img src="![Reservatório Desenho](https://github.com/user-attachments/assets/58e5d115-eb85-4f0e-84df-38e64534487a)" alt="Atividade Proposta" style="border: 5px solid #000; padding: 10px;">
![Reservatório Desenho](https://github.com/user-attachments/assets/58e5d115-eb85-4f0e-84df-38e64534487a)

A tabela verdade abaixo apresenta as possíveis combinações dos estados das boias (A, B, C) 
e as ações resultantes no sistema (S1: Bomba, S2: Eletroválvula, E: Possíveis erros):

 | **TABELA VERDADE** |
 | A  | B  | C  | S1 | S2 | E  | 
 |----|----|----|----|----|----| 
 | 0  | 0  | 0  | 0  | 0  | 0  |  *Todos os reservatórios vazios*
 | 0  | 0  | 1  | 0  | 0  | 1  |  *Reservatório 2 cheio (erro)*
 | 0  | 1  | 0  | 0  | 0  | 1  |  *Reservatório 1 cheio (erro)*
 | 0  | 1  | 1  | 0  | 0  | 1  |  *Reservatório 1 e 2 cheios (erro)*
 | 1  | 0  | 0  | 1  | 0  | 0  |  *Reservatório 1 cheio, liga a bomba*
 | 1  | 0  | 1  | 0  | 0  | 1  |  *Reservatório 2 cheio (erro)*
 | 1  | 1  | 0  | 1  | 1  | 0  |  *Reservatório 1 cheio e 2 não,vai bombeando*
 | 1  | 1  | 1  | 0  | 1  | 0  |  *Reservatórios 1 e 2 cheios, desliga a bomba*


## O que foi utilizado
- Linguagem: C#
- Framework: .NET
- Estrutura de controle if-else, laço de repetição while e console para entrada e saída de dados

## Etapas implementadas
- Ler o estado das boias (A, B e C).
- Lógica de controle para determinar o estado da bomba e da válvula com base nas boias:
   - Quando nenhuma boia está acionada, a bomba e a válvula ficam desativadas.
   - Quando a boia A está acionada: liga a bomba.
   - Quando as boias A e B estão acionadas: continua bombeando e abre a válvula.
   - Quando todas as boias estão acionadas: desliga a bomba, mas mantém a válvula aberta.
   - Se houver inconsistência, desativa a bomba e a válvula e sinaliza um erro.
- Exibir o status do sistema após a leitura das boias.
- Opção para o usuário realizar um novo teste ou encerrar o programa.

## Backlog
 Implementar registro de histórico das operações.

## Conclusão
Esse código implementa um sistema de controle para monitorar o nível da água em reservatórios, 
utilizando uma tabela verdade para determinar o estado da bomba e da válvula com base no nível 
das boias. Ele também inclui tratamento de erros e interação com o usuário para facilitar 
a operação do sistema.
