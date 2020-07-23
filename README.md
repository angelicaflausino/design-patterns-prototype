# design-patterns-prototype

# Replicação do Objeto

O Prototype é simplesmente um objeto parcial ou totalmente inicializado do qual faz uma cópia e é utilizado posteriormente por um propósito.

Motivos para utilizar Prototype
 - Objetos complicados (ex. Carros) não são projetados do zero. Eles reiteram os projetos existentes.
 - Um projeto existente (compartilhado ou totalemnte construído) é um Prototype
 - Fazer uma cópia (clone) do protótipo e costumiza-lo. Envolve o Deep Copy, não apenas copiar o objeto mas também as referências de seus
 objetos criando novos objetos que replicam o estado das referências.
 - Tornar a cópia conveniente fornecendo uma API como exemplo Factory para tornar a clonagem de objetos existentes.

 Interface IClonable (System.Runtime.InteropServices)

 - Suporta a cópia (clonagem) de um objeto que uma nova instância de uma classe com o mesmo valor que uma instância existente
 - A desvantagem de utilizar essa abordagem é que invés do Clone retornar a classe ele retorna um objeto, que faz com que seja necessário fazer o CAST para classe, isso pode permitir falhas no consumo da api.

 Cópia do Construtor

 - Ideia originária do C++ que torna-se uma melhor abordagem retornando uma nova instância sem cópia da refência

 Interface de cópia explícita

- Abordagem de implementar a interface DeepCopy e ter implementações em todos os lugares que se deseja copiar e ter o
construtor apropriado para que realmente possa se copiar a classe, ainda sim é burocrático, pois se você tiver 10
diferentes classes envolvidas nesse tipo de configuração, é muito trabalhoso.

Copiar através da serialização

- Abordagem que utiliza um serializador que deve serializar a árvore inteira do objeto
- Essa é a abordagem mais utiliza quando se utiliza o patterns Prototype
- Necessário colocar a annotation [Serializable] nas classes

Copiar através de serialização XML

- É necessário que o objeto tenha um construtor sem parametros

# Resumo

- O uso do Prototype é definido quando se precisa construir um objeto que possa ser parcialmente ou totalmente construído e em seguida armazená-lo onde seria necessário sua réplica.

- Há diferentes abordagens de utilização:
    - Implementar uma cópia profunda do objeto, onde implementa a funcionalidade, criando construtores de cópias do objeto em todos os lugares, ou criando uma interface IPrototype<T>, porém é uma maneira mais trabalhosa de se alcançar a cópia, já que deverá fazer em todas as classes que seja deseja copiar.
    - Serializando, é uma maneira mais simples e rápida de fazer a cópia profunda do objeto.
