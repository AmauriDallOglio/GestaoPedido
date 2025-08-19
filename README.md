#  Trabalho de Conclusão de Pós-Graduação em Arquitetura de Software

## 1. Introdução

O presente trabalho de conclusão de curso de pós-graduação em **Arquitetura de Software** tem como objetivo apresentar uma solução completa e integrada para um sistema de vendas online, abordando desde a concepção da arquitetura de software até a sua implementação e *deployment* em um ambiente de nuvem de alta disponibilidade.  

A crescente demanda por serviços online, impulsionada pela transformação digital, exige que as aplicações sejam não apenas funcionais, mas também **robustas, escaláveis e resilientes**, capazes de operar ininterruptamente e de se adaptar dinamicamente às flutuações de carga.  

Neste contexto, a arquitetura de software assume um papel fundamental, definindo a estrutura, os componentes e as interações que garantem a qualidade e a sustentabilidade de um sistema.  

---

## 2. Fundamentos de Arquitetura de Software

A arquitetura de software é a estrutura fundamental de um sistema, englobando seus componentes, as relações entre eles e os princípios e diretrizes que governam seu design e evolução.  

### 2.1 Conceitos de Arquitetura de Software

- **Fundamentos de Arquitetura de Software**: Princípios básicos que guiam a construção de sistemas robustos.  
- **Requisitos Arquiteturais**: Desempenho, segurança e escalabilidade.  
- **Modelagem Arquitetural**: Representação visual da arquitetura com notações padronizadas.  
- **Design Patterns e Estilos Arquiteturais**: Soluções comprovadas para problemas recorrentes.  
- **Arquiteturas de Software da Atualidade**: Estudo das principais abordagens modernas.  

### 2.2 Modelagem Arquitetural: 

**Metodologias Utilizadas:**
O **C4 Model** permite descrever a arquitetura em diferentes níveis de abstração:

1. **C4 Model Diagrama de Contexto**: Mostra como o sistema interage com usuários e sistemas externos.  
2. **C4 Model Diagrama de Contêineres**: Detalha os principais componentes internos do sistema (Web, API, Banco de Dados).  
3. **C4 Model Diagrama de Componentes**: Aprofunda a visão de cada contêiner, destacando responsabilidades.  
4. **C4 Model Diagrama de Código (opcional)**: Mostra a estrutura detalhada do código.  
5. **5W2H**: Definições claras de escopo, motivos, locais, responsáveis, formas e custos.
6. **SWOT**: Pontos fortes, fracos, oportunidades e ameaças para a arquitetura.
7. **Design Thinking**: Empatia, definição de problema, ideação, prototipação e teste.


### 2.3 Padrão MVC (Model-View-Controller)

O padrão **MVC** organiza o sistema em três camadas:

- **Model**: Responsável pelos dados e regras de negócio.  
- **View**: Camada de apresentação (interface do usuário).  
- **Controller**: Intermediário entre Model e View, controlando o fluxo da aplicação.  

Vantagens:  
✅ Isolamento das camadas  
✅ Facilidade de testes  
✅ Reuso de componentes  
✅ Portabilidade de Views  

---

## 3. Arquitetura da Solução em Nuvem (Microsoft Azure)

A solução foi projetada para garantir **alta disponibilidade, resiliência e escalabilidade** utilizando a plataforma **Microsoft Azure**.  

### 3.1 Diagramas da Arquitetura em Nuvem

- **Diagrama de Contexto**: Interação entre usuário, navegador, rede e sistema.  
- **Diagrama de Contêineres**: Mostra VNets, Balanceador de Carga, VMs, IAM e Banco SQL.  
- **Diagrama de Componentes**: Detalha grupos de recursos, redes virtuais, balanceamento e comunicação entre backend e banco de dados.  

### 3.2 Componentes de Arquitetura do Azure

- **Resource Groups**   
- **Virtual Networks (VNets)** com segmentação por sub-redes  
- **Load Balancer** para distribuir tráfego entre VMs  
- **Storage Accounts** e **Azure Disks**  
- **Virtual Machines (VMs)** Linux com escalonamento automático (3 a 6 instâncias)  
- **SQL Database (PaaS)** com backup automático e replicação multi-regional  
- **Monitoramento)** Application Insights
- **App Service** API Backend: ASP.NET Core MVC
---

## 4. Projeto e Implementação da API RESTful

### 4.1 Organização do Projeto

Estrutura modular do sistema:

### 4.2 Modelo de Dados (DER)

Tabelas principais:  

- **Cliente**: (Id, Nome, Email, Ativo)  
- **Produto**: (Id, Nome, Descricao, Preco, Quantidade, Ativo, DataCadastro)  
- **Pedido**: (Id, Id_Cliente, DataPedido, ValorTotal)  
- **PedidoProduto**: (Id, Id_Pedido, Id_Produto, Quantidade, PrecoUnitario, Total)

### 4.3 Documentação da API com Swagger

Benefícios do Swagger:
Clareza e entendimento
Facilidade de integração
Manutenção e evolução
Automação de documentação
Exemplo de endpoints:
GET /api/Cliente/ObterTodos
POST /api/Produto/Inserir
DELETE /api/Pedido/Excluir/{id}

## 5. Conclusão

Estes trabalhos demonstrou a importância da integração entre arquitetura de software e computação em nuvem para o desenvolvimento de sistemas robustos e escaláveis.
Principais pontos:
Aplicação prática do MVC e do C4 Model
Implementação de uma API RESTful documentada com Swagger
Uso do Microsoft Azure para alta disponibilidade, resiliência e escalabilidade
Combinação de teoria e prática, resultando em uma solução completa e moderna
A combinação de uma arquitetura bem definida com infraestrutura de nuvem robusta é essencial para sistemas que precisam garantir alta disponibilidade, desempenho e segurança em um mercado cada vez mais dinâmico.


Trabalho final do bootcamp Arquiteto(a) de Software:
[1 - Projetar uma API REST seguindo o padrão arquitetural MVC.pdf](https://github.com/user-attachments/files/21873642/1.-.Projetar.uma.API.REST.seguindo.o.padrao.arquitetural.MVC.pdf)

Trabalho final do bootcamp Arquiteto(a) de Soluções:
[2 - Trabalho de Arquitetura em Nuvem Solução Escalável e Resiliente na Microsoft Azure.pdf](https://github.com/user-attachments/files/21873645/2.-.Trabalho.de.Arquitetura.em.Nuvem.Solucao.Escalavel.e.Resiliente.na.Microsoft.Azure.pdf)


Trabalho final do projeto Aplicado - Arquitetura de Software e Soluções
[Projeto Aplicado - Arquitetura de Software e Soluções Amauri DallOglio.pdf](https://github.com/user-attachments/files/21873679/Projeto.Aplicado.-.Arquitetura.de.Software.e.Solucoes.Amauri.DallOglio.pdf)


 
 
![fff](https://github.com/user-attachments/assets/3c7fc314-a4d9-4660-a7fc-793438dc8f8e)

![nova2](https://github.com/user-attachments/assets/6dafbd78-1cb3-4031-af3a-d673ed27695e)



<img width="607" height="867" alt="image" src="https://github.com/user-attachments/assets/a776e905-523f-422b-ba67-440bf70d1634" />





<img width="1916" height="866" alt="image" src="https://github.com/user-attachments/assets/b0bf7f5e-9b9a-4158-b429-f1ff4bcfb7ce" />


 <img width="1914" height="862" alt="image" src="https://github.com/user-attachments/assets/6a28dcad-84a0-447a-ad4e-f0758943dfed" />

 <img width="1891" height="864" alt="image" src="https://github.com/user-attachments/assets/57d69f70-a78e-4334-adca-fa9e628ff733" />

<img width="1912" height="859" alt="image" src="https://github.com/user-attachments/assets/66bb19ac-7a97-4650-a198-5b37623a20dc" />

<img width="1914" height="862" alt="image" src="https://github.com/user-attachments/assets/b0bebb09-3079-4f1a-90b4-804c9f858739" />

<img width="1912" height="854" alt="image" src="https://github.com/user-attachments/assets/05a25ecd-a2c3-4d7a-b3cc-764ae50b9787" />

<img width="1915" height="863" alt="image" src="https://github.com/user-attachments/assets/96ceb0e7-afbd-4304-9f44-e935674778e6" />













