# ECS Demo


This is a version of my Entity Component System that I use in my Monogame Engine, that is powering my game. You can watch the Devlogs here. 

I would recommend watching the video -here- that shows me building the ECS from the ground up. It offers more information then you will get from this repo, and further explanation of design choices.


_Note: The project was created in Visual Studio 2017 using Monogame version 3.6._

# Incluced in the Repo: 
- Entity
- Component -> base class all components inherit from
- Entity_Manager
- Drawing System
- Scripts System -> this is for user created scripts (player controller, health etc...)
- Transform Component
- Renderer Component
- Script Component -> all user created scripts should inherite from this component
- Mover -> this is an example of what a  "user created script" could look like


_All classes are heavily commented, and explain what every line of code is doing._

To better understand the "flow" of how the ECS operates I would suggest reviewing 
Game1 -> Entity -> Component -> Transform/Renderer -> Entity_Manager -> Drawing_System in that order. 




