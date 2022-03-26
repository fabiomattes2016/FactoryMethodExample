<center>[![.NET](https://github.com/fabiomattes2016/FactoryMethodExample/actions/workflows/dotnet.yml/badge.svg)](https://github.com/fabiomattes2016/FactoryMethodExample/actions/workflows/dotnet.yml)</center>

<h1 align="center">FactoryMethodExample</h1>

<h3 align="left">O que é Factory Method?</h3>

<p align="justify">
Factory Method ou Construtor virtual, na ciência da computação, é um padrão de projeto de software (design pattern, em inglês) que permite às classes delegar para subclasses decidirem, isso é feito através da criação de objetos que chamam o método fabrica especificado numa interface e implementado por um classe filha ou implementado numa classe abstrata e opcionalmente sobrescrito por classes derivadas.</p>

<hr>

<h3 align="left">Estrutura</h3>

<p align="justify">
O padrão Factory Method, da forma como foi descrito no livro Design Patterns: Elements of Reusable Object-Oriented Software, contém os seguintes elementos:
</p>

<ul>
<li>Creator(Criador abstrato) — declara o factory method (método de fabricação) que retorna o objeto da classe Product (produto). Este elemento também pode definir uma implementação básica que retorna um objeto de uma classe ConcreteProduct (produto concreto) básica;</li>
<li>ConcreteCreator(Criador concreto) — sobrescreve o factory method e retorna um objeto da classe ConcreteProduct;</i>
<li>Product(Produto abstrato) — define uma interface para os objectos criados pelo factory method;</li>
  <li>ConcreteProduct(Produto concreto) — uma implementação para a interface Product.</li>
</ul>

<h3 align="left">Finalidade</h3>

<p align="justify">
Criar um objeto geralmente requer processos complexos não apropriados para incluir dentro da composição do objeto. A criação do objeto talvez necessite de uma duplicação de código significativa, talvez necessite informações não acessíveis para a composição do objeto, talvez não providencie um grau de abstração suficiente, ou então não faça parte da composição das preocupações do objeto. O padrão de design método fabrica maneja/trata esses problemas definindo um método separado para criação dos objetos, no qual as subclasses possam sobrescrever para especificar o "tipo derivado" do produto que vai ser criado.
</p>

<h3 align="left">Prós x Contras</h3>

<ul>
  <li>Prós: Baixo acoplamento, maior flexibilidade e elimina a necessidade de acoplar classes específicas para aplicação em nível de código.</li>
  <li>Contras: Alto número de classes, podendo sobrecarregar o sistema.</li>
</ul>
