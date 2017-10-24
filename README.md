# ProyectoUnity

![<h1 style="text-align:center;"> JUMPING GUY</h1>](https://github.com/MarioBlancosoto/ProyectoUnity/blob/master/jumpingGuy.jpg)

<b><p>Proyecto 2D para PMDM con unity </p></b>

<ol>
  <li value="1">Creación de los Sprites renderizados</li>
  <li value="2">Animación de los Sprites</li>
  <li value="3">Interacción con los estados del animator</li>
</ol>
<br/>
<h3><b><p>1. La creación de los sprites renderizados se realiza a partir de un jpg o un png normalmente,Para poder tratar las<br/>
  imagenes debemos usar el sprite editor,comunmente solemos descargarnos plantillas con los movimientos completos de los personajes<br/> con lo que debemos "recortarlos",para ello selecionaremos la plantilla a recortar,Sprite editor y primeramente seleccionar bottom <br/>
 en el selector de pivot,para que nos recorte los sprites pegados a su borde inferior,se podría hacer manualmente también<br/>
  seguidamente presionaremos en slice y aplicamos slice,esto nos troceará las imagenes en cada toma de la animación<br/>
  como si de fotogramas se tratase
 </p></h3></b>
 <br>
 <h3><b><p>2. La animación de los Sprites se realiza a través de Create animation,una vez clikamos en create animation debemos<br/>
  darle un nombre a la misma y seleccionar body,Seguidamente Sprite renderer y por último Sprite,que será el cuerpo de nuestro personaje,en este caso el Sprite 0 recortado anteriormente.Para poder realizar la animación debemos seleccionar los fotogramas deseados y arrastrarlos a la "Linea temporal" medida en segundos que tenemos a la derecha,extendiendo o acortando la misma a nuestro gusto.<br/>
  También podremos manipular la posición del objeto,personaje en cuestión a la hora de grabar la animación moviendo en el mismo en el momento exacto a la posición deseada,por ejemplo cuando salta,en la mitad de la animación debemos elevar la altura del personaje para conseguir ese efecto de salto.</p></b></h3>
  <br/>
  <h3><b><p>3.La interacción de los estados del animator se realizan a través de transiciones,cuando creamos una animación se crea un estado de "Animator",por ejemplo cuando creamos la animación de correr para nuestro personaje,se genera un estado con el mismo nombre de la animación,cada estado recibe el mismo nombre,esto nos da mucho juego,dado que podemos cambiar los estados a nuestro antojo,por ejemplo:
  el estado por defecto del personaje es parado,en el vemos como solo parpadea y realiza una animación de respiración, en ese momento el animator da prioridad a esa animación,si queremos que de estar parado se ponga a correr,realizaremos una transición desde el animator,seleccionaremos el nombre del animator,botón derecho y make transition,esto nos dará una flecha que direccionaremos hacia el otro animator al que deseemos hacer la transición,en este caso correr.Tambiém podremos cambiar el estado por defecto haciendo click derecho,set as layer default state y ese será el estado por defecto,la animación por defecto o con la que se inicia el juego.
  *Las transiciones también las podemos modificar clikando sobre la flecha e iniciando el inspector.
  
  <br/>
  
 <h4>FUENTES</h4>
 <p><b>Sprite Renderer :</b>https://docs.unity3d.com/es/current/Manual/class-SpriteRenderer.html</p>
 <p><b>Animator :</b>https://docs.unity3d.com/Manual/class-Animator.html?_ga=2.4363251.1591272476.1508782176-1976787986.1507378551</p>
 <p><b>Animations :</b>https://docs.unity3d.com/Manual/AnimationClips.html</p>
 <br/>
 <h1>Tutorial</h1>
 
<a>http://www.youtube.com/watch?feature=player_embedded&v=sT5sBkkmuaQ&list</a>
