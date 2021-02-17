Cadastro de clientes • Processo seletivo CRMALL
=======

#### Objetivo:

- [ ] Desenvolver sistema para cadastro de clientes com as funcionalidades de listagem, adição/edição e remoção.              

- [ ] 1ª tela: Listagem dos clientes cadastrados em grid, disponibilizar botões: Adicionar, editar e remover clientes.

- [ ] 2ª tela: Tela para adicionar/editar clientes.

- [ ] OBS: Preferencialmente em angular

#### Diretrizes:

- [ ] Utilizar qualquer framework/biblioteca em C#

- [ ] Utilizar Mysql como banco de dados.

- [ ] Campos para o cadastro de cliente: Nome, data de nascimento, sexo, cep, endereço, número, complemento, bairro, estado, cidade.

- [ ] Consumir webservice para consulta de cep: https://viacep.com.br/, preencher campos do cadastro após a consulta do cep.

- [ ] Validar cadastro de cliente: Nome, data de nascimento e sexo obrigatórios.

#### Envio do teste:

- [ ] Disponibilizar o teste com o script de criação do banco de dados(ou migrations) através de um repositório no github.


## Resultado

#### Observações

- Foi criada uma API dotnet para a aplicação angular consumir, esta api está no seguinte caminho: https://localhost:44353/api/customer
- O caminho da API está referenciado de forma estática na aplicação angular, favor verificar se a porta permanecerá a mesma para realizar os testes
- A string connection que encontra-se no arquivo appsettings.json do projeto dotnet é a seguinte: "server=localhost;user id=root;password=senhat3st3;persistsecurityinfo=True;database=customersdb;port=3306"
- Por favor, verificar usuário e senha local e a porta para criar o banco ao realizar os testes

## Script para criação do schema MySQL
    CREATE SCHEMA `customersdb` ;
    
## Script de migration com primeiro dado inicial de exemplo
     CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` ( 
         `MigrationId` varchar(95) NOT NULL, 
         `ProductVersion` varchar(32) NOT NULL, 
         CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`) 
     ); 
    START TRANSACTION; 
    CREATE TABLE `Customers` ( 
        `Id` int NOT NULL AUTO_INCREMENT, 
        `Name` varchar(80) CHARACTER SET utf8mb4 NOT NULL, 
        `BirthDate` datetime(6) NOT NULL, 
        `Gender` char(1) CHARACTER SET utf8mb4 NOT NULL, 
        `ZipCode` longtext CHARACTER SET utf8mb4 NULL, 
        `Address` longtext CHARACTER SET utf8mb4 NULL, 
        `Number` int NULL, 
        `Complement` longtext CHARACTER SET utf8mb4 NULL, 
        `Area` longtext CHARACTER SET utf8mb4 NULL, 
        `State` longtext CHARACTER SET utf8mb4 NULL, 
        `City` longtext CHARACTER SET utf8mb4 NULL, 
        CONSTRAINT `PK_Customers` PRIMARY KEY (`Id`) 
    ); 
    INSERT INTO `Customers` (`Id`, `Address`, `Area`, `BirthDate`, `City`, `Complement`, `Gender`, `Name`, `Number`, `State`, `ZipCode`) 
    VALUES (1, 'Rua José Francisco da Mata', 'Jardim das Torres', '1999-01-28 00:00:00', 'Mandaguari', NULL, 'M', 'Pedro', 77, 'PR', '86975000'); 
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) 
    VALUES ('20210216230428_Initial', '5.0.3'); 
    COMMIT;
