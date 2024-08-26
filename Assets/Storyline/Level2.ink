#anim narrator
Você está a jogar padel com o seu filho, e ele falha várias bolas sucessivamente.

#anim adolescent angry
#anim narrator
O adolescente fica frustrado e atira violentamente com a raquete ao chão.
	-> emotion

=== emotion === // MINI-JOGO

#puzzle raiva
#clue: O adolescente está com a cara vermelha
#clue: O adolescente está a dizer asneiras
#clue: O adolescente está tenso
#clue: O adolescente demonstra dificuldade de autocontrolo
Qual é a emoção que o adolescente está a sentir?
	-> correct_answer

=== correct_answer ===

#anim feedback
Parabéns! A emoção que o adolescente está a sentir é raiva.
Como acha que deve reagir a esta situação?
	-> options
    
=== options ===

+ \(Gritar com o adolescente e atirar também com a raquete para o chão\) #score -5 #anim parent yelling #anim narrator #anim adolescent upset
	-> continue_story_1

+ Nunca mais vens jogar padel! #score -5 #anim parent yelling #anim adolescent upset
	-> continue_story_1

+ Calma, respira fundo. #strategy 1 #score 10 #anim parent talking #anim adolescent sad
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Modulação de Resposta Emocional \(Intervenção Fisiológica\)! #anim feedback
	-> continue_story

=== continue_story_1 ===

#anim adolescent talking
#anim adolescent upset
Não é justo! Eu sou o melhor jogador de padel da minha turma!
Tu não percebes nada disto! Estás a arruinar o meu jogo!
	-> options1

=== options1 ===

+ Deixa de ser mimado! #score -5 #anim parent yelling #anim adolescent upset
-> feedback

+ Desculpa, tem calma! Respira fundo. #strategy 1 #score 10 #anim parent talking #anim adolescent sad
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Modulação de Resposta Emocional \(Intervenção Fisiológica\)! #anim feedback
	-> continue_story

=== feedback ===

#anim feedback
Em geral, os adolescentes têm mais dificuldade em controlar as suas emoções.
Tente acalmá-lo primeiro.
Depois pode corrigir o comportamento dele e ensiná-lo a controlar as suas emoções mais eficazmente.
Tente escolher outra opção:
	-> options1

=== continue_story ===

#anim feedback
Agora que já acalmou o adolescente pode corrigir o comportamento dele.

+ E se tentares pensar que não és um jogador profissional? É normal falhares, estás só a aprender! #strategy 0 #score 10 #anim parent talking 
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Reavaliação Cognitiva! #anim feedback
	-> ending

+ Em vez de te focares nas bolas que não apanhas porque não te focas na tua pontuação que é maior que a minha? #strategy 3 #score 10 #anim parent talking 
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Alteração do Foco Atencional! #anim feedback
	-> ending

+ Há situações em que não devias mostrar as tuas emoções. Estão todas as equipas a olhar para ti, não é adequado exprimires assim a tua raiva. Há situações em que deves tentar controlar.  É normal sentires frustração, mas não devias demonstrar dessa forma. #strategy 2 #score 10 #anim parent talking 
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Supressão Emocional! #anim feedback
	-> ending
    
=== ending ===

#anim feedback
Parabéns! Você aprendeu a lidar melhor com estas situações no futuro!
Como acha que o/a seu/sua parceiro\(a\) responderia nesta situação?
Comuniquem os dois para futuramente reagirem melhor quando esta situação surgir.
	-> END