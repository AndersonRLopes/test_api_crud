# test_api_crud Entrevista
Repositório com CRUD Api Rest, desenvolvido para atender avaliação técnica Cast Group

# Avaliação Técnica .Net
Criar uma API Rest que permita realizar as operações CRUD (criar, recuperar/consultar, editar e excluir) de Cursos para turmas de formação do Cast group.

# APi Rest - CRUD
Projeto criado para avaliação técnica .NET Cast group.

## Critérios de Aceite Obrigatórios

1 - Banco de Dados Pode-se utilizar qualquer gerenciador de banco de dados, desde que contenha as informações abaixo:  
• Curso  
o Descrição do assunto (obrigatório)  
o Data de início (obrigatório)  
o Data de término (obrigatório)  
o Quantidade de alunos por turma (opcional)  
o Categoria (obrigatório)  <br/>
• Categoria  
o Código  
o Descrição  

Observações:
a. Apesar de estar estruturada de forma relacional, pode-se utilizar bancos não relacionais.
b. As categorias são: Comportamental, Programação, Qualidade e Processos.

2 - Regras de Negócio
a. Não será permitida a inclusão de cursos dentro do mesmo período. O sistema deve identificar tal situação e retornar um código de erro e a mensagem:
“Existe(m) curso(s) planejados(s) dentro do período informado.”
b. Não será permitida a inclusão de cursos com a data de início menor que a data atual.

3 -API Rest
Deve-se disponibilizar um endpoint com a interface do Swagger para fácil visualização das operações disponíveis.

# Projeto criado:
SisApiRestCRUD

## Modelos:

1 - Atributos da Categoria
Uma categoria possui os seguintes atributos:
 - Codigo
 - Descrição
 
2 - Atributos do Curso
Um curso possui os seguintes atributos:
 - Codigo
 - DescricaoAssunto
 - DataInicio
 - DataTermino
 - QuantidadeAlunosTurma
 - CategoriaId
 
## Api Categoria
1 - Cadastrar Categoria
Informar o atributos abaixo:
  - Descrição: Obrigatório
  
2 - Alterar uma Categoria
Informar o atributos abaixo:
  - Codigo: Obrigatório
  - Descricao: Obrigatorio
    - Regra:  
      - Se o código informando não existir, será exibido a mensagem "Categoria não encontrado.".
      
3 - Deletar uma Categoria
Informar o atributos abaixo:
  - Codigo: Obrigatório
    - Regra:  
      - Caso essa categoria estiver vinculada a um curso, não será possível executar essa operação.
      - Se o código informando não existir, será exibido a mensagem "Categoria não encontrado.".
      
4 - Listar uma Categoria
Retorna lista com todas as categorias cadastradas;

5 - Listar uma Categoria por codigo
Informar o atributos abaixo:
  - Codigo: Obrigatório
    - Regra:  
      - Se o código informando não existir, será exibido a mensagem "Categoria não encontrado.".

## Api Curso

1 - Cadastrar Curso
Informar o atributos abaixo:
 - DescricaoAssunto: Obrigatório
 - DataInicio: Obrigatório
 - DataTermino: Obrigatório
 - QuantidadeAlunosTurma: Opcional
 - CategoriaId: Obrigatório
    - Regras:  
      - Não é permitida a inclusão de cursos com a data de início menor que a data atual.
      - A data ínicial do curso não pode ser posterior que a data de término.
      - Não será permitida a inclusão de cursos dentro do mesmo período
    
2 - Alterar um Curso
Informar o atributos abaixo:

  - Codigo: Obrigatório
  - DescricaoAssunto: Obrigatório
  - DataInicio: Obrigatório
  - DataTermino: Obrigatório
  - QuantidadeAlunosTurma: Opcional
  - CategoriaId: Obrigatório
    - Regras:  
      - Não é permitida a inclusão de cursos com a data de início menor que a data atual.
      - A data ínicial do curso não pode ser posterior que a data de término.
      - Não será permitida a inclusão de cursos dentro do mesmo período
      - Se o código informando não existir, será exibido a mensagem "Curso não encontrado.".
      
3 - Deletar um Curso
Informar o atributos abaixo:
  - Codigo: Obrigatório
    - Regra:  
      -Se o código informando não existir, será exibido a mensagem "Curso não encontrado.".
      
4 - Listar uma Curso
  Retorna lista com todos os cursos cadastradas;
  
5 - Listar uma Curso por codigo
Informar o atributos abaixo:
  - Codigo: Obrigatório
    - Regra:  
      - Se o código informando não existir, será exibido a mensagem "Curso não encontrado.".

# Banco de Dados
Ulizado servidor de dados SQL Server online;

## Tecnologias utilizadas:
  - .Net Core
  - EntityFramework
  - C#
  - Swagger
  
## Softwares utilizados:
  - Microsoft Visual Studio Community 2019 - Version 16.9.3
  - SQL Server Management Studio - 15.0.18369.0
