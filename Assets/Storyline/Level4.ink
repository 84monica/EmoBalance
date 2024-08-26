#anim adolescent upset
#anim narrator
O adolescente acabou de chegar a casa, vai para o quarto e fecha a porta com força.
	-> emotion

=== emotion === // MINI-JOGO

#puzzle raiva
#clue: O adolescente atirou com a mochila para o chão
#clue: O adolescente não quer falar consigo
#clue: O adolescente fala de maneira agressiva
#clue: O adolescente demonstra dificuldade de autocontrolo
Qual é a emoção que o adolescente está a sentir?
	-> correct_answer

=== correct_answer ===

#anim feedback
Parabéns! A emoção que o adolescente está a sentir é raiva.
Como acha que deve reagir a esta situação?
	-> options
    
=== options ===

+ A porta não é para estragar! Nunca mais faças isso. #score -5 #anim parent arguing
	-> feedback

+ Já não tens idade para te portares assim. Tens que ser um exemplo para o teu irmão mais novo! #score -5 #anim parent arguing  
	-> feedback

+ Então, tiveste um dia mau na escola? O que se passa? #score 8 #anim parent talking
	-> continue_story

=== feedback ===

#anim adolescent yelling
Não há sossego nesta casa! Odeio isto! Vai-te embora! Quero estar sozinho.

#anim feedback
#anim adolescent upset
Se você reagir com raiva o adolescente vai responder com ainda mais raiva.
E se você tentar conter as emoções e reagir de uma forma mais calma?
	-> options

=== continue_story ===

#anim adolescent talking
Hoje na escola o António fez-me uma rasteira. Depois eu empurrei-o.
#anim adolescent talking
Fomos os dois à direção da escola.
	-> options1

=== options1 ===

+ Vou ter uma conversinha com esse António! Isto não pode ser assim! Fizeste muito bem em responder na mesma moeda. #score -5 #anim parent arguing #anim adolescent upset
	-> feedback1
+ Esse tipo de coisas pode acontecer. Não está correto, mas não podes reagir com raiva. Nem toda a gente vai ser simpática contigo. Tenta respirar fundo e conter a tua raiva e se for preciso fala com a tua professora para te ajudar na situação! #strategy 2 #score 10 #anim parent talking #anim adolescent sad
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Supressão Emocional! #anim feedback
	-> continue_story_1
    
=== feedback1 ===

#anim feedback
Com esta resposta o adolescente não vai aprender a controlar as suas emoções e vai continuar a reagir com raiva nestas situações.
E se tentar responder de outra forma?
	-> options1

=== continue_story_1 ===

#anim adolescent talking
Tens razão. Mas o António faz sempre estas coisas durante o intervalo quando vamos jogar futebol.
	-> options2
    
=== options2 ===

+ Ele é sempre assim? Que miúdo mimado. Se ele continuar a fazer isso tens de fazer o mesmo. #score -5 #anim parent yelling #anim adolescent upset
	-> feedback3
+ E se tentares escolher atividades em que o António não esteja presente? Por exemplo, em vez de ires jogar futebol com o António, podes ir com os teus outros amigos jogar basquetebol. #strategy 5 #score 10 #anim parent talking
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Seleção de Situação! #anim feedback
	-> ending

=== feedback3 ===

#anim feedback
Talvez não seja a melhor forma de responder nesta situação!
	-> options2
    
=== ending ===

#anim feedback
Parabéns! Você aprendeu a lidar melhor com estas situações no futuro!
Como acha que o/a seu/sua parceiro\(a\) responderia nesta situação?
Comuniquem os dois para futuramente reagirem melhor quando esta situação surgir.
	-> END



