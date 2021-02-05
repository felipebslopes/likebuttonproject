
Informações sobre o projeto:

- O back-end foi feito usando .net core, usando jwt authentication para segurança de acesso.
- No primeiro acesso é criado um usuário
- Depois é feito o login onde é gerado um token que tem a validade de uma hora.
- Necessário verificar validade do token em qualquer operação no botão.
- Operaçoes de consulta, quantidade de likes e inserção de likes são feitas somente  com usuário autenticado.
- Foi usando o banco de dados sqlite para facilidade na implementação da solução.
- Acessando url_api/swagger/index.html pode se ter uma visão de toda api.
- Todos os métodos fazem chamadas assincronas isso ajuda no desempenho onde serão feitas muitas requisições ao mesmo tempo.

- Front end feito em react.
- Componente do botão criado para mostrar likes acima de 0.
- Todas as validações com api devem ser feitas antes do botão ser usado.
- Se  usuário já curtiu botão fica desabilitado mas mostrando quantidade de curtidas
- Usuário só consegue curtir se estiver autenticado na api.

