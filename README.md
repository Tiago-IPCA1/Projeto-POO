# Sistema de Gestão de Alojamentos Turísticos

## Resumo

Este projeto tem como objetivo desenvolver um sistema de gestão de **alojamentos turísticos**, utilizando **Programação Orientada a Objetos (POO)**. O sistema é dedicada para a administração e controlo de processos como **gestão de clientes, alojamentos, reservas, pagamentos e check-in**. A principal funcionalidade é fornecer um conjunto de ferramentas para os administradores do sistema gerir dados relevantes.

## Tecnologias Usadas

- **Linguagem de Programação**: C#
- **Ambiente de Desenvolvimento**: Visual Studio
- **Paradigma de Programação**: Programação Orientada a Objetos (POO)
- **Persistência de Dados**: Ficheiros JSON
- **Biblioteca para Manipulação de JSON**: Newtonsoft.Json

## Funcionalidades

### 1. **Gestão de Alojamentos**
   - Adicionar, editar, visualizar e remover alojamentos turísticos.
   - Gerir os detalhes dos alojamentos, como tipo, capacidade, preços e disponibilidade.
   - Alteração do status dos alojamentos (disponível, indisponível, etc.).
### 2. **Gestão de Clientes**
   - Registo e edição de informações dos clientes.
   - Visualização dos dados pessoais.

### 3. **Gestão de Reservas**
   - Criar, editar, visualizar e cancelar reservas.
   - Verificar a disponibilidade dos alojamentos antes de confirmar a reserva.
   - Registrar detalhes como datas de check-in e check-out, número de hóspedes, etc.
   - Validação de dados de reservas, como disponibilidade de alojamento e informações do cliente.

### 4. **Gestão de Pagamentos**
   - Registo dos pagamentos realizados pelos clientes.
   - Verificar se o pagamento foi efetuado antes de confirmar a reserva.

### 5. **Gestão de Check-in**
   - Confirmar a chegada do cliente ao alojamento.
   - Registar a data e hora do check-in.
   - Atualizar o status.

### 6. **Interface do Administrador**
   - O sistema é projetado para ser utilizado por um **administrador**, que terá acesso a todas as funcionalidades.
   - Controlo completo de reservas, pagamentos e clientes.

## Estrutura do Projeto

O projeto está organizado em várias camadas, conforme descrito abaixo:

### 1. **Domain**
   - Contém as classes de domínio, que representam os principais objetos de negócio do sistema, como `Alojamento`, `Cliente`, `Reserva`, `Pagamento`, etc.

### 2. **App**
   - Contém a lógica de aplicação, que implementa as funcionalidades principais do sistema, como a gestão de clientes, reservas, pagamentos, etc.

### 3. **Utils**
   - Contém classes auxiliares e funções úteis para o sistema.

### 4. **Tests**
   - Contém os testes unitários que garantem o correto funcionamento do sistema e suas funcionalidades.

### 5. **Infrastructure**
   - Contém a implementação da persistência de dados, como o acesso a ficheiros JSON, que são utilizados para armazenar e recuperar os dados do sistema.

## Conclusão

Este sistema de gestão de alojamentos turísticos foi desenvolvido para atender às necessidades de um administrador de alojamentos, proporcionando uma forma eficiente e segura de gerenciar os processos de clientes, reservas, pagamentos e check-in. Com a utilização da Programação Orientada a Objetos (POO) e o armazenamento dos dados em ficheiros JSON, o sistema é facilmente escalável e mantém os dados persistentes de forma simples.

Este projeto serve como uma base sólida para a implementação de sistemas de gestão de alojamentos, podendo ser expandido com novas funcionalidades ou adaptado conforme necessário, com novos utilizadores, entre outros.

## Mais Informações

Para detalhes adicionais sobre o funcionamento do sistema, documentação técnica e relatórios de progresso, consulte o **relatório completo** que acompanha este projeto. O relatório contém informações detalhadas sobre o sistema.

