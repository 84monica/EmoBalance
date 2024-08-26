#anim adolescent sad
#anim narrator
A adolescente acabou de chegar a casa e foi a correr para o quarto.

#anim parent talking
Então, como correu o dia hoje na escola?

#anim adolescent talking
#anim adolescent sad
...
	-> emotion

=== emotion === 

#puzzle tristeza
#clue: A adolescente não quer sair da cama
#clue: A adolescente demonstra falta de interesse em ir dar um passeio com os pais
#clue: A adolescente quer ficar sozinha no quarto
#clue: A adolescente parece cansada
Qual é a emoção que a adolescente está a sentir?
	-> correct_answer

=== correct_answer ===

#anim feedback
Parabéns, acertou! A adolescente está a sentir-se triste.
	-> dialog
    
=== dialog ===

#anim parent talking
O que se passa?

#anim adolescent talking
Tens de assinar o meu teste de matemática ...

#anim think
A sério? A nota do teste é negativa ...
	-> options

=== options ===

+ Pois, estás sempre agarrada ao telemóvel e depois tiras estas notas. #score -5 #anim parent arguing #anim adolescent sad
	-> feedback

+ Só 48%? O teu irmão mais velho era muito melhor a matemática, vais ter de te empenhar mais. #score -5 #anim parent arguing #anim adolescent sad 
	-> feedback

+ Quando tinha a tua idade também tinha dificuldades com a matématica. E se pensares que na semana passada tiveste muito boa nota a história? Às vezes não somos naturalmente bons em certas disciplinas. Se quiseres posso marcar uma explicação para tirares as tuas dúvidas. #strategy 0 #score 10 #anim parent talking 
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Reavaliação Cognitiva! #anim feedback
	-> ending

+ Nem todos os testes vão correr sempre bem. Este correu mal mas não significa que vão todos correr mal. Se quiseres posso marcar uma explicação para tirares as tuas dúvidas. #strategy 0 #score 10 #anim parent talking 
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Reavaliação Cognitiva! #anim feedback
	-> ending
    
=== feedback ===
#anim feedback
Nesta situação a adolescente pode ficar desiludida com a falta de apoio por parte dos seus pais.
No futuro, a adolescente poderá esconder os resultados dos pais ou aumentar a sua ansiedade em relação aos estudos.
Você agiu impulsivamente de acordo com a emoção que experienciou.
Mas será que poderia responder de uma forma que levasse a que a filha e os pais se sentissem melhor com a situação?
Tente escolher outra opção:
	-> options

=== ending ===
#anim feedback
Parabéns! Você aprendeu a lidar melhor com estas situações no futuro!
Como acha que o/a seu/sua parceiro\(a\) responderia nesta situação?
Comuniquem os dois para futuramente reagirem melhor quando esta situação surgir.
	-> END