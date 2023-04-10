RF1: Cadastro na Rede Social Animes
Ator: Usuário.
Requisitos funcionais relacionados: RF
Pré condição: O usuário não pode estar cadastrado na rede social Animes.
Fluxo Principal
1. Usuário acessa o cadastro da rede social.
2. Usuário informa os dados de cadastro: Nome, Sobrenome, E-mail,Data do aniversario, Senha, Confirmar Senha.
3. Usuário executa o cadastro.

Fluxo de Exceção
 3.1. E-mail já existe.
 3.1.1. Deve ser informado que o E-mail já existe.

Pós-condição: Usuário cadastrado na rede social Animes. 
 
 
RF2: Visualizar os dados do Usuário cadastrados na rede social Animes.
Ator: Usuário.
Requisitos funcionais relacionados: RF1
Pré condição: O usuário deve estar cadastrado na rede social Animes.
Fluxo Principal
1. Usuário visualiza o seu cadastro da rede social: Nome, Sobrenome, E-mail.

RF3: O usuário deve poder editar os seus dados cadastrados.
Ator: Usuário.
Requisitos funcionais relacionados: RF2
Pré condição: O usuário deve estar logado na rede social Animes e visualizar os seus dados cadastrais (ver RF2) antes de iniciar a edição dos seus dados.
Fluxo Principal
1. Usuário acessa o cadastro da rede social.
2. Usuário pode editar qualquer um dos dados cadastrados: Nome, Sobrenome, E-mail, Data de aniversario, Senha.
3. Usuário executa a atualização de cadastro.

Fluxo de Exceção
2.1. Para editar a senha, será necessário informar: senha atual, nova senha e confirmar nova senha.
2.2. Ao editar o e-mail, deve ser validado se o novo e-mail já está cadastrado para outro usuário e, se estiver, deve ser informado para o usuário.

Pós-condição: Usuário atualiza o cadastrado na rede social Animes. 
 
RF4: O usuário deve poder apagar os seus dados cadastrados, assim excluindo sua conta da rede social Animes.
Ator: Usuário.
Requisitos funcionais relacionados: RF2
Pré condição: O usuário deve estar logado na rede social Animes e visualizar os seus dados cadastrais (ver RF2) antes de excluir seus dados.
Fluxo Principal
1. Usuário acessa o cadastro da rede social.
2. Usuário executa a exclusão de cadastro.

Fluxo de Exceção
2.1. Antes de confirmar a exclusão do usuário, uma mensagem será exibida com a opção de cancelar esta ação e outra para confirmar.
2.2. Se optar por cancelar a exclusão, o mesmo retornará para a tela de visualização dos dados cadastrais.
2.3. Se optar por confirmar a exclusão, o mesmo será informado que os seus dados foram excluídos do cadastro da rede social Animes e 
este será redirecionado para a de login na rede.

Pós-condição: Usuário exclui o seu cadastro da rede social Animes.

RF-5: A rede social deve permitir o cadastro de outros usuarios(comunidade) para promoverem seus posts.
Ator: comunidade.
Requisitos funcionais relacionados: 
Pré condição: O comunidade não pode estar cadastrado na rede social Animes.

Fluxo Principal
1.Comunidade acessa o cadastro da rede social.
2.Comunidade informa os dados de cadastro: Primeiro Nome, Ultimo Nome, Data do nascimento , email , senha,confirma senha
3.Comunidade executa o cadastro.

Fluxo de Exceção
 3.1. E-mail já existe.
 3.1.1. Deve ser informado que o E-mail já existe.

Pós-condição: Comunidade cadastrado na rede social Animes. 
 
 
RF-6:A rede social deve permitir que os comunidade possam visualizar seus dados cadastrados.
Ator: Comunidade.
Requisitos funcionais relacionados: RF5
Pré condição: A Comunidade deve estar cadastrado na rede social Animes.

Fluxo Principal
1.Comunidade visualiza o seu cadastro da rede social: Primeiro Nome, Ultimo Nome, Data do nascimento , email

RF-7:A rede social deve permitir que a comunidade possam editar os seus dados cadastrados.
Ator: Comunidade.
Requisitos funcionais relacionados: RF6
Pré condição: A Comunidade deve estar logado na rede social Animes e visualizar os seus dados cadastrais (ver RF6) antes de iniciar a edição dos seus dados.

Fluxo Principal
1.Comunidade acessa o cadastro da rede social.
2.Comunidade pode editar qualquer um dos dados cadastrados: Email, senha rimeiro Nome, Ultimo Nome, Data do nascimento , email , senha   
3.Comunidade executa a atualização de cadastro.

Fluxo de Exceção
2.1. Para editar a senha, será necessário informar: senha atual, nova senha e confirmar nova senha.
2.2. Ao editar o e-mail, deve ser validado se o novo e-mail já está cadastrado para outro integrante comunidade e, se estiver, deve ser informado para a comunidade.

Pós-condição: comunidade atualiza o cadastrado na rede social Animes. 
 
 
RF-8:A rede social deve permitir que os comunidade possam deletar os dados cadastrados.
Ator: Comunidade.
Requisitos funcionais relacionados: RF6
Pré condição: O usuário deve estar logado na rede social Comunidade e visualizar os seus dados cadastrais (ver RF6) antes de excluir seus dados.

Fluxo Principal
1.Comunidade acessa o cadastro da rede social.
2.Comunidade executa a exclusão de cadastro.

Fluxo de Exceção
2.1. Antes de confirmar a exclusão do Comunidade, uma mensagem será exibida com a opção de cancelar esta ação e outra para confirmar.
2.2. Se optar por cancelar a exclusão, o mesmo retornará para a tela de visualização dos dados cadastrais.
2.3. Se optar por confirmar a exclusão, o mesmo será informado que os seus dados foram excluídos do cadastro da rede social Animes e 
este será redirecionado para a de login na rede.

Pós-condição: Comunidade exclui o seu cadastro da rede social Animes.

RF-9: Configuração de Perfil.
Ator: Usuário.
Requisitos funcionais relacionados: RF
Pré condição: 
O usuário deve estar autenticado na rede social Animes.
Fluxo Principal
1. Após o usuário criar uma conta, por padrão, sua pagina de perfil é composto pelos dados informados nos dados cadastrado (Ver RF 1)
2. Além de adiconar, editar (ver RF1 e RF3), é possível configurar o recurso de foto, avatar.

Fluxo de Exceção

Pós-condição: Usuário cadastrado na rede social Animes.
