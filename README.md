# MCScan
MCScan - Procura por cheats no seu jogo (Minecraft)

## Features

* Pega strings automaticamente
* Metodo de scan rapido
* Customizavel
* OpenSource :-)

## Como usar

[Link](https://youtu.be/N6YrLmJJy98)

## Erros reconhecidos

* 1
O release ta bugado pq coloquei link com cloudflare por cima ai da merda /shrug

* 2
Ja sei dos bugs, mas e o seguinte se o link que voce colocou retornar um erro `502` no codigo: `using (Stream stream = wc.OpenRead(url))` voce precisa usar um site diferente pois esse site contem cloudflare que ira bloquear sua request antes mesmo de entrar

* 3

Ja sei de outro erro olhai o erro e o seguinte 
![Print](https://i.imgur.com/7UYKuta.png)

Se sua url retornar esse icone bugado quer dizer que voce salvou em `ANSI` e ansi buga no simbulo. voce precisa salvar em `utf8` pra ter sucesso na host.
