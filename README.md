# SisTarefa - Sistema de controle de tarefas
 
O projeto é um sistema de gerenciamento de tarefas que permite aos usuários cadastrados armazenar e organizar suas tarefas de forma eficiente. Com recursos de adição, edição e categorização de tarefas, além de notificações e lembretes, os usuários podem acompanhar suas tarefas, visualizá-las em diferentes formatos e compartilhá-las com outros usuários. O sistema oferece uma solução completa para melhorar a organização pessoal e a produtividade.

## Pré-requisitos

Antes de executar o sistema de gerenciamento de tarefas, verifique se o seguinte pré-requisito foi atendido:

.NET 6
Certifique-se de ter instalado o SDK do .NET 6 em seu sistema. Você pode fazer o download e instalar o SDK adequado para o seu sistema operacional no site oficial do .NET.

Instalação e Configuração
Clone ou faça o download do repositório do projeto.
Abra um terminal ou prompt de comando e navegue até o diretório do projeto.
Execute o comando dotnet build para compilar o projeto.
Execute o comando dotnet run para iniciar o sistema.
Após executar essas etapas, o sistema de gerenciamento de tarefas estará em execução e você poderá acessá-lo por meio de um navegador da web.

Certifique-se de configurar quaisquer outras dependências necessárias, como um banco de dados ou serviços externos, de acordo com as instruções fornecidas no projeto.

Notas adicionais
Verifique a documentação do projeto para obter mais informações sobre a configuração e uso do sistema de gerenciamento de tarefas.
Certifique-se de cumprir quaisquer outros requisitos específicos do sistema operacional ou dependências do projeto mencionados na documentação.

## Instalação

1. Clone este repositório em sua máquina local.
2. Abra o arquivo `NomeDoArquivo.sln` em sua IDE preferida.
3. Restaure os pacotes NuGet necessários.
4. Compile e execute o projeto.
5. Para gerar o banco execute dentro do projeto: Sistarefa.Infra.Data digite: update-database

6.0  Instalar imagem docker :  docker pull mcr.microsoft.com/mssql/server:2019-latest
6.1 Instalar container     :  docker run -e "ACEEPT-EULA=Y" -e "SA_PASSWORD=fm1bl2xml33" -p 1450:1433 --name sqlserverdb -d mcr.microsoft.com/mssql/server:2019-latest

7.0 Instalar imagem docker :  docker build --no-cache -t sistarefapp . < Aplicação >
7.1 Instalar container     :  docker run -it -p 5001:80 --name sistarefapp_container sistarefapp < Aplicação >


## Uso
 O sistema de gerenciamento de tarefas foi projetado para ser intuitivo e fácil de usar. Siga as etapas abaixo para começar:

Acesse o sistema e crie uma conta fornecendo as informações necessárias de cadastro.
Após o cadastro, o sistema irá gerar um token exclusivo para você.
Guarde esse token com segurança, pois ele será necessário para acessar o sistema posteriormente.
Faça o login no sistema utilizando seu nome de usuário e senha.
Uma vez logado, você poderá adicionar novas tarefas, fornecendo detalhes como título, descrição, data de vencimento e prioridade.
Organize suas tarefas usando categorias, tags ou filtros disponíveis.
Receba notificações e lembretes sobre tarefas próximas da data de vencimento ou atribuídas a você.
Marque as tarefas como concluídas à medida que você as realiza para acompanhar seu progresso.
Compartilhe tarefas com outros usuários, caso necessário, para facilitar a colaboração.
Explore as diferentes visualizações, como lista ou calendário, para visualizar suas tarefas de forma conveniente.
Lembre-se de armazenar com segurança o token gerado durante o cadastro, pois ele será necessário para acessar suas tarefas novamente. O sistema foi projetado para simplificar o gerenciamento de tarefas, ajudando você a ser mais organizado e produtivo.

## Contribuição

As contribuições são bem-vindas! Para contribuir com este projeto, siga estas etapas:

1. Faça um fork deste repositório.
2. Crie uma nova branch com a feature desejada: `git checkout -b minha-feature`.
3. Commit suas alterações: `git commit -m 'Adicionando nova feature'`.
4. Push para o branch: `git push origin minha-feature`.
5. Abra um pull request neste repositório.

## Licença
 
Este projeto é licenciado sob a [MIT License](https://ingacode.com.br).

## Contato

Se você tiver alguma dúvida, sugestão ou precisar de suporte em relação ao sistema de gerenciamento de tarefas, entre em contato com o desenvolvedor responsável:

Desenvolvedor: Hamilton Valnet
E-mail: hamilton.valnet@gmail.com

Não hesite em entrar em contato por e-mail caso precise de assistência adicional ou queira contribuir com melhorias para o sistema. O desenvolvedor ficará feliz em ajudar e responder às suas perguntas.
