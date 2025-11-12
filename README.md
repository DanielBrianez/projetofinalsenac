💰 Sistema Financeiro Pessoal / Empresarial

Projeto Integrador Final — SENAC (Etapa 1 a 3)
Desenvolvido por Daniel Nascimento, Gabriel Milone, Maryana Oliveira e Raphaga Willian.

🧭 Sobre o Projeto

O Sistema Financeiro Pessoal/Empresarial é uma aplicação desenvolvida com o objetivo de simplificar o controle financeiro de MEIs, freelancers e pequenas empresas, permitindo o gerenciamento eficiente de receitas e despesas em um ambiente moderno, responsivo e seguro.

O projeto surgiu da necessidade de oferecer uma solução intuitiva e acessível para usuários que desejam visualizar, organizar e analisar suas finanças sem depender de planilhas complexas ou sistemas pagos.

🎯 Objetivos do Sistema

O sistema foi planejado para atuar como uma ferramenta de gestão financeira centralizada, oferecendo ao usuário total controle sobre seu fluxo de caixa e uma visão clara de seus resultados mensais.

Objetivo Geral

Criar um sistema de controle financeiro completo e responsivo, que permita o registro, categorização e análise de receitas e despesas, com relatórios e gráficos dinâmicos.

Objetivos Específicos

Implementar cadastro e autenticação de usuários;

Permitir CRUD completo (criação, leitura, atualização e exclusão) de receitas e despesas;

Criar categorias personalizáveis (alimentação, transporte, aluguel etc.);

Exibir saldo e histórico por período;

Gerar gráficos interativos e relatórios mensais;

Oferecer uma interface moderna e intuitiva.

🧩 Principais Funcionalidades
Funcionalidade	Descrição
👤 Cadastro/Login	Sistema de autenticação seguro com validação de credenciais.
💸 Controle de Transações	Registro de receitas e despesas com descrição, valor e data.
🗂️ Categorias Personalizadas	Criação de categorias para melhor organização das finanças.
📅 Filtros Dinâmicos	Consulta de dados por período, tipo e categoria.
📊 Dashboard Interativo	Exibição de gráficos via Chart.js, com visão clara do desempenho mensal.
📄 Relatórios Financeiros	Geração de relatórios em tela e opção de exportação em PDF.

Relacionamentos:

1:N — Usuários → Categorias

1:N — Usuários → Transações

1:N — Categorias → Transações

🎨 Identidade Visual

A identidade visual foi desenvolvida com foco em confiança, clareza e acessibilidade — elementos fundamentais para qualquer sistema financeiro.

Paleta de Cores:

https://coolors.co/de1a1a-504746-bfada3-fbb7c0-97f9f9

Fontes Utilizadas:

Título: Poppins Bold — moderna, legível e com bom contraste.

Corpo: Roboto Regular — limpa e agradável para leitura de dados e relatórios.

⚙️ Tecnologias Utilizadas
Camada	Tecnologias
Frontend	HTML5, CSS3, JavaScript, Chart.js
Backend	C# (.NET 8)
Banco de Dados	SQL Server
Controle de Versão	Git & GitHub
Design / Planejamento Coolors.co, Canva

👥 Equipe de Desenvolvimento
Integrante	Função	Responsabilidades
Daniel Nascimento	QA / Dev Backend	Garantia da qualidade, desenvolvimento do backend e integração com o banco.
Gabriel Milone	Dev Backend / DBA	Estruturação do banco de dados e manutenção das regras de negócio.
Maryana Oliveira	Dev Frontend / Analista de Requisitos	Criação da interface, prototipagem e documentação funcional.
Raphaga Willian	Testes e Implementação	Testes de usabilidade, correção de bugs e apoio técnico.

🚀 Futuras Implementações

💾 Exportação completa de relatórios em PDF e Excel;

🔐 Recuperação de senha via e-mail;

💬 Sistema de notificações e lembretes financeiros;

🌙 Modo escuro (Dark Mode);

📱 Versão mobile responsiva aprimorada.

🧠 Aprendizados e Diferenciais

Este projeto consolida o aprendizado prático das disciplinas de Programação, Banco de Dados, Análise de Sistemas e Testes, evidenciando a capacidade do grupo em trabalhar colaborativamente, integrar tecnologias e entregar um produto funcional.

🔹 Código limpo e documentado.
🔹 Interface planejada com foco na experiência do usuário (UX).
🔹 Estrutura escalável e reutilizável.
🔹 Apresentação voltada também para contextos empresariais, como o ambiente da Serasa Experian, valorizando boas práticas de desenvolvimento seguro e confiável.

📦 Instalação e Execução
# Clonar o repositório
git clone https://github.com/DanielBrianez/projetofinalsenac

# Acessar o diretório
cd projetofinalsenac

# (Backend) Executar no Visual Studio / .NET CLI
dotnet run

# (Frontend) Abrir o arquivo index.html no navegador

📅 Entrega

🕒 Prazo da Etapa 1: 12/11/2025 — 21h59
📚 Instituição: SENAC
👨‍🏫 Projeto Final – Curso Técnico em Desenvolvimento de Sistemas

🧾 Licença

Este projeto é de uso educacional, sem fins comerciais.
© 2025 — Equipe do Projeto Integrador SENAC
