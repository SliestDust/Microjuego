# Resumen
Este juego se basa en sobrevivir con tu nave a una cantidad siempre creciente de asteroides
# Game Loop
El objetivo del juego es sobrevivir el máximo tiempo posible, destruyendo el mayor número de asteroides para aumentar tu puntuación. Cuanto más tiempo sobrevivas más difícil se volverá el juego al aumentar la cantidad de asteroides que aparecerán en la pantalla.

Para sobrevivir el jugador usará su movimiento para esquivar situaciones peligrosas, disparará a los asteroides que no pueda esquivar y intentará generalmente chocar con ellos.
# Assets y GameObjects
## La nave
La nave es el personaje con el que jugaremos, tiene controles de tanque y puede disparar balas con el espacio para destruir a los asteroides. 
## Balas
Son disparadas por la nave al pulsar la tecla Espacio, destruyen asteroides otorgandote puntuación.
## Asteroides
El único enemigo del juego, si tocan tu nave se reiniciará tu partida, si una bala colisiona con ellos aumentará tu puntuación en 1. Se mueven con el motor de gravedad de unity aunque con la gravedad reducida a -6 para tener más tiempo para reaccionar.
## UI
Consiste de un texto que te indica tu puntuación y un botón que pausa y despausa el juego, esta misma acción se puede realizar con la tecla Escape. Mientras el juego este pausado no se podrá relizar ninguna acción y aparecerá un texto diciendo "PAUSADO".
# Escenas
La unica escena del juego es una imagen del espacio donde ocurre todo el juego y menus. Contiene la nave, la UI y en ella aparecen los asteroides.
# Mecanicas
## Movimiento
El jugador movera la nave a traves de controles de tanque, al estar en el espacio la nave no tiene ni gravedad ni fricción, lo que hace que sea más difícil de controlar.  Si la nave se sale de la pantalla volverá a aparecer por el otro lado de esta.
## Disparo
El jugador puede disparar balas que destruiran a los asteroides consiguiendo puntos.
## Perder
El jugador perderá cuando se choque contra un asteroide, reiniciando sus puntos y el estado de la partida.
# Scripts
## Bullet
Se asocia a las balas cuando se instancia, tiene como funciones:
- Deactivate: se usa para desactivar las balas para que vuelvan a la pool
- Update: donde se mueven las balas y se llama a deactivate una vez haya pasado el tiempo limite de la bala
- IncreaseScore: Aumenta la puntuación y actualiza el texto
- OnCollisionEnter: si ha chocado con un asteroide destruye el asteroide y llama a Deactivate
## EnemySpawner
Script que se encarga de instanciar los asteroide cuando ha pasado suficiente tiempo instancia y tambien se encarga de destruirlos un tiempo despues.
## ObjectPool
Script que se encarga de gestionar la pool de balas
## Pause
Script responsable de la funcion de pausa tanto por el boton como por la tecla, tambien de actualizar el texto de PAUSADO.
## Player
Script que se encarga de todo el movimiento del jugador, de teletransportar el jugador cuando se sale de la pantalla, de la aparición de las balas y de reiniciar la partida en caso de chocar contra un asteroide.
