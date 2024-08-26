#anim adolescent walk
#anim parent walk
#anim narrator
Você está a passear com a adolescente e repara que ela está muito calada e com as mãos a tremer.
	-> emotion

=== emotion === // MINI-JOGO

#puzzle medo
#clue: A adolescente está a roer as unhas
#clue: A adolescente parece preocupada com alguma coisa
#clue: A adolescente demonstra sinais de nervosismo
Qual é a emoção que a adolescente está a sentir?
	-> correct_answer

=== correct_answer ===

#anim feedback
Parabéns, acertou! A adolescente está a sentir medo.
	-> dialog
    
=== dialog ===

+ \(Ignorar a adolescente e continuar a andar\) #score -2 #anim narrator
	-> feedback
+ Então, o que se passa? Estás tão caladinha. #score 8 #anim parent talking #anim adolescent sad
	-> continue_story

=== feedback ===

#anim feedback
A adolescente está com medo de alguma coisa. Talvez seja melhor tentar perceber o que se passa.
	-> dialog

=== continue_story ===

#anim adolescent talking
Perdi o meu telemóvel. Desculpa, por favor não te chateies comigo.

#anim think
Não acredito, acabei de lhe comprar o telemóvel e custou imenso dinheiro.

	-> options

=== options ===

+ E só me dizes agora? Onde é que o perdeste? Estás sempre distraída e depois é assim. #score -5 #anim parent arguing #anim adolescent sad
	-> feedback1
+ O telemóvel custou imenso dinheiro. Se fosses tu a trabalhar para pagar ias ver como era. #score -5 #anim parent arguing #anim adolescent sad
	-> feedback1
+ \(conter a raiva\) Acontece filha, não fico chateada contigo. Não te preocupes. Onde é que o perdeste? Podemos tentar procurá-lo. #strategy 2 #score 10 #anim parent talking
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Supressão Emocional! #anim feedback
	-> continue_story_2

=== feedback1 ===

#anim feedback
Talvez não seja a melhor resposta. 
Apesar da mãe sentir frustração com esta situação, pois trata-se de um objeto dispendioso, a adolescente também fica a perder sem o telemóvel que tanto usa, por isso também está a sofrer.
Tente escolher outra opção:
	-> options

=== continue_story_2 ===

#anim adolescent talking
Foi hoje de manhã. Estive a estudar na casa da Sofia e só reparei quando cheguei a casa que já não o tinha.

#anim parent talking
Oh, então deve estar na casa dela. Vou mandar mensagem à mãe da Sofia para ela ver se está la.

#anim adolescent talking
Ok... Espero que não o tenha mesmo perdido...
  
	-> options1

=== options1 ===

+ Se me tivesses dito mais cedo já tinhamos ido procurar e talvez tivessemos encontrado. #score -5 #anim parent arguing #anim adolescent sad
	-> feedback2
+ Tem calma, respira fundo! É só um telemóvel. Deve estar na casa da Sofia. #strategy 1 #score 10 #anim parent talking 
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Modulação de Resposta Emocional \(Intervenção Fisiológica\)! #anim feedback
	-> ending
+ Não vale a pena pensar nisso agora. Foca-te antes na nota excelente que tiraste hoje. Nós vamos encontrar o telefone. #strategy 3 #score 10 #anim parent talking
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Alteração do Foco Atencional! #anim feedback
	-> ending
+ Pensa que enquanto não o encontramos também não recebes aquelas chamadas de publicidade que tanto te chateavam. Podemos aproveitar o nosso passeio em paz! #strategy 0 #score 10 #anim parent talking
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Reavaliação Cognitiva! #anim feedback
	-> ending

=== feedback2 ===

#anim feedback
Talvez não seja a melhor resposta!
Tente outra vez.
	-> options1

=== ending ===
#anim adolescent talking
Tens razão.

#anim parent talking
Olha, a mãe da Sofia já me respondeu! Está mesmo em casa dela. O que achas de irmos comer um gelado e depois passamos lá?

#anim adolescent talking
Sim! Obrigada por me teres acalmado e ajudado a resolver o problema.

#anim feedback
Parabéns! Você aprendeu a lidar melhor com estas situações no futuro!
Como acha que o/a seu/sua parceiro\(a\) responderia nesta situação?
Comuniquem os dois para futuramente reagirem melhor quando esta situação surgir.
	-> END