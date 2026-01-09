# Task-Tracker-CLI
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

![JSON](https://img.shields.io/badge/json-5E5E5E?style=for-the-badge&logo=json&logoColor=white)

(PT-BR).

📝 **To-Do List CLI (C#)**

## **1. Sobre o Projeto**

Este é um projeto de estudo desenvolvido em C# e .NET para gerenciar tarefas diárias através do terminal. O objetivo principal é praticar os fundamentos da linguagem, manipulação de coleções e persistência de dados.

  ### **Objetivos de Aprendizado:**
  Manipulação de Listas, Arrays e Strings (List<T>).
  
  Estruturas de repetição e condicionais.
  
  Leitura e escrita de arquivos (JSON) para salvar os dados.
  
  Organização de código em classes (POO).

## **2. Arquitetura do Sistema**

**O projeto segue uma estrutura simples para facilitar a manutenção:**

Program.cs: Ponto de entrada que gerencia o loop principal e a interação com o usuário.

Task.cs: Modelo que define as propriedades de uma tarefa (ID, Descrição, Status).

TaskManager.cs: Classe responsável pela lógica de negócio (Adicionar, Remover, Listar).

## **3. Funcionalidades**
  Adicionar Tarefa: Cria uma nova nota com status pendente.

  Listar Tarefas: Exibe todas as tarefas com seus respectivos IDs e status.
  
  Concluir Tarefa: Marca uma tarefa específica como "Concluída".
  
  Remover Tarefa: Exclui uma tarefa da lista.
  
  Persistência: Salva automaticamente as tarefas ao sair.

## **4. Como Executar**
  Pré-requisitos:
  
  .NET SDK instalado (versão 6.0 ou superior).

**Passo a Passo**
  
  Clonar o repositório:
    
    Bash
    git clone https://github.com/Willian-Fagundes/To-Do-List-CLI

Navegar até a pasta:

    Bash
    cd todo-list
Executar a aplicação:

    Bash
    dotnet run
## **5. Exemplo de Uso**

  Após iniciar a aplicação com dotnet run, você poderá interagir com o sistema através dos seguintes comandos no console:
  
    add "description"
    
    update "id" "description"
    
    delete "id"
    
    list
    
    list todo
    
    list done
    
    list in-progress

## **6. Próximos Passos**

O desenvolvimento deste projeto permitiu uma imersão profunda em C# e lógica de programação. Embora funcional, o Task-Tracker-CLI é um projeto vivo. Futuras iterações podem incluir:

Implementação de datas de entrega (due dates).

Priorização de tarefas (Alta, Média, Baixa).

Categorização por tags/projetos.
