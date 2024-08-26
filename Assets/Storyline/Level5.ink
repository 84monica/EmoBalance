#anim adolescent phone
#anim narrator
À hora de jantar a adolescente está sorridente a falar ao telemóvel.
    -> emotion

=== emotion === // MINI-JOGO

#puzzle alegria
#clue: A adolescente diz que teve um dia muito bom na escola
#clue: A adolescente diz estar cheia de energia e que quer dar uma caminhada depois de jantar
#clue: A adolescente está mais entusiasmada para falar consigo 
#clue: A adolescente está a cantarolar

Qual é a emoção que a adolescente está a sentir? 
    -> correct_answer

=== correct_answer ===

#anim feedback
Parabéns! A adolescente está a sentir alegria.
    -> continue_story
    
=== continue_story ===

#anim think
Já não aguento, ela está sempre agarrada ao telemóvel.
    -> options_2

=== options_2 ===

+ Estás sempre agarrada ao telemóvel. Por isso é que tiras más notas. #score -5 #anim parent yelling #anim adolescent upset
    -> continue_story_1

+ Estamos a jantar, deixa já o telemóvel. #score -5 #anim parent arguing #anim adolescent upset
    -> continue_story_1

+ \(Suprimir a raiva\) Então, porquê estás tão risonha hoje? Como correram as aulas? #strategy 2 #score 10 #anim parent talking 
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Supressão Emocional! #anim feedback
    -> continue_story_2

=== continue_story_1 ===

#anim adolescent yelling
Oh, nunca posso fazer nada. Sexta-feira quero sair à noite com os meus amigos.

#anim feedback
Se você reagir com raiva a adolescente vai responder com ainda mais raiva. 
E se você tentar conter as emoções e reagir de uma forma mais calma?
    -> options_2

=== continue_story_2 ===

#anim adolescent talking
Correram bem. A professora de matemática elogiou o meu trabalho. Sexta-feira posso sair à noite com os meus amigos?
    -> options

=== options ===

+ Nem pensar! Sei bem como se porta a juventude de hoje em dia! #score -5 #anim parent arguing #anim adolescent upset
    -> continue_story_3

+ Não podes, tens teste na semana seguinte, vais ter de ficar a estudar! #score -5 #anim parent arguing #anim adolescent upset
    -> continue_story_3

+ Ok, podes ir, esta semana estudaste muito e também precisas de te divertir. Mas porta-te bem! Se precisares que te vá buscar liga-me. #score 8 #anim parent talking
    -> continue_story_4

=== continue_story_3 ===

#anim adolescent yelling
Nunca me deixas sair! Tenho de ficar sempre em casa fechada.
    -> options_3

=== options_3 ===

+ Não te vou deixar sair, já te disse! Nunca mais me fales assim. #score -5 #anim parent yelling #anim adolescent upset
    -> feedback

+ \(Suprimir a raiva\) Desculpa, tens razão. Tens de te ir divertir também. Realmente com a tua idade eu também gostava de sair ...  #strategy 0 #strategy 2 #score 10 #anim parent talking
Parabéns, acabou de usar duas estratégias de regulação emocional nesta resposta: Supressão Emocional e Reavaliação Cognitiva! #anim feedback
    -> continue_story_4

=== feedback ===

#anim feedback
Talvez não seja a melhor forma de responder nesta situação!
    -> options_3
 
=== continue_story_4 ===

#anim adolescent sit
#anim parent sit
#anim narrator
Vocês sentam-se à mesa para jantar.

#anim think
Hmm, ela não tocou na comida ainda. Porquê será que não está a comer?
    -> emotion_1

=== emotion_1 === // MINI-JOGO

#puzzle nojo
#clue: A adolescente está a fazer caretas
#clue: A adolescente está a torcer o nariz
#clue: A adolescente parece querer vomitar

Qual é a emoção que a adolescente está a sentir? 
    -> correct_answer_1

=== correct_answer_1 ===

#anim feedback
Parabéns, acertou! A adolescente está a sentir nojo.
    -> continue_story_5

=== continue_story_5 ===

+ Não gostas da comida? Então fazes tu o jantar amanhã! #score -5 #anim parent yelling
    -> continue_story_6

+ Não vais sair da mesa enquanto não comeres tudo! #score -5 #anim parent yelling
    -> continue_story_6

+ O que é que não gostas da comida? #score 8 #anim parent talking
    -> continue_story_7

=== continue_story_6 ===

#anim adolescent yelling
Esta comida está estragada! A sopa tem uma mosca.
    -> options_1

=== continue_story_7 ===

#anim adolescent talking
Acho que a sopa está estragada. Tem uma mosca.
    -> options_1

=== options_1 ===

+ Isso são desculpas para não comer a sopa! Come já tudo. #score -5 #anim parent yelling
    -> continue_story_8

+ Ah desculpa, não devo ter reparado. Come antes estes legumes que estão bons e vou deitar isso ao lixo. #strategy 4 #score 10 #anim parent talking
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Modificação de Situação! #anim feedback
    -> continue_story_9

=== continue_story_8 ===

#anim adolescent yelling
Não vou comer comida com moscas, que nojo!

#anim feedback
Como pode ver, se você reagir com raiva a adolescente vai responder com ainda mais raiva. 
E se você tentar conter as emoções e reagir de uma forma mais calma?
    -> options_1

=== continue_story_9 ===

#anim adolescent talking
#anim adolescent sit
Obrigada. Estes legumes estão deliciosos!
    -> continue_story_10

=== continue_story_10 ===

#anim adolescent sit
#anim parent sit
#anim narrator
Vocês sentam-se outra vez para comer.

#anim brother
#anim adolescent surprised
O irmão chegou à mesa para jantar e vai atrás e assusta a adolescente.
    -> emotion_2

=== emotion_2 === // MINI-JOGO

#puzzle surpresa
#clue: A adolescente ficou de boca aberta
#clue: A adolescente deu um grito 

Qual é a emoção que a adolescente está a sentir? 
    -> correct_answer_2

=== correct_answer_2 ===

#anim feedback
Parabéns! A adolescente está a sentir surpresa.
    -> continue_story_11
    
=== continue_story_11 ===

#anim adolescent yelling
És um parvo! Nunca se tem sossego nesta casa.

#anim feedback
Como você resolveria esta discussão?
    -> options_4

=== options_4 ===

+ Nada de gritaria! Sentem-se os dois à mesa. #score -5 #anim parent yelling
    -> feedback_1

+ Os dois para o quarto de castigo! #score -5 #anim parent yelling
    -> feedback_1

+ \(Não intervir\) #score -1 #anim narrator
    -> feedback_1

+ Acalmem-se os dois. Comuniquem um com o outro e resolvam a discussão calmamente. #strategy 2 #score 10 #anim parent talking
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Supressão Emocional! #anim feedback
    -> ending

+ Vê a situação de outra forma. Já pensaste que o teu irmão podia só querer brincar contigo? #strategy 0 #score 10 #anim parent talking
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Reavaliação Cognitiva! #anim feedback
    -> ending

+ Não fiquem chateados um com o outro. E se formos dar um passeio depois de jantar para se distrairem um bocadinho? #strategy 4 #score 10 #anim parent talking
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Modificação de Situação! #anim feedback
    -> ending

+ Olhem para a notícia que está a dar na televisão. Vem a Portugal a vossa banda favorita. #strategy 3 #score 10 #anim parent talking
Parabéns, acabou de usar uma estratégia de regulação emocional chamada Alteração do Foco Atencional! #anim feedback
    -> ending

=== feedback_1 ===

#anim feedback
Talvez não seja a melhor resposta! Tente outra vez.
    -> options_4

=== ending ===

#anim feedback
Parabéns! Você aprendeu a lidar melhor com estas situações no futuro!
Como acha que o/a seu/sua parceiro\(a\) responderia nesta situação?
Comuniquem os dois para futuramente reagirem melhor quando esta situação surgir.
	-> END
