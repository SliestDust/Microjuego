# Resumen
Un juego en el que intentas sobrevivir con tu nave a una cantidad siempre creciente de asteroides
# Game Loop
El objetivo del juego es sobrevivir el máximo tiempo posible, destruyendo el mayor número de asteroides para aumentar tu puntuación. Cuanto más tiempo sobrevivas más difícil se volverá el juego al aumentar la cantidad de asteroides que aparecerán en la pantalla.
# Features
## La nave
La nave es el personaje con el que jugaremos, tiene controles de tanque y puede disparar balas con el espacio para destruir a los asteroides, las balas iran en la dirección que apunte la nave. Las balas usan pooling para reducir su impacto en el rendimiento. Si la nave se sale de la pantalla volverá a aparecer por el otro lado de esta.
## Asteroides
El único enemigo del juego, si tocan tu nave se reiniciará tu partida, si una bala colisiona con ellos aumentará tu puntuación en 1. Se mueven con el motor de gravedad de unity aunque con la gravedad reducida a -6 para tener más tiempo para reaccionar.
## UI
Consiste de un texto que te indica tu puntuación y un botón que pausa y despausa el juego, esta misma acción se puede realizar con la tecla Escape. Mientras el juego este pausado no se podrá relizar ninguna acción y aparecerá un texto diciendo "PAUSADO".
