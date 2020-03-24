# Platformer

Here we will create a script that simulates the parallax effect.

## Parallax

First off, what is parallax?\
Well according to [Wikipedia](https://en.wikipedia.org/wiki/Parallax_scrolling) the parallax effect (in the article it's called parallax scrolling) is :

> a technique in computer graphics where background images move past the camera more slowly than foreground images, creating an illusion of depth in a 2D scene and adding to the sense of immersion in the virtual experience.

To put it another way. We want to make our background look like it's actually far away.\
The main way to achieve this is to make that background move slowly.\
This creates the same effect as looking into the distance on a car trip. The trees near the side of the road race by while the mountains in the distance seemingly move across your vision much slower.

This is purely asethetic for our game but if you use it correctly it is a really going to make your game look better. Let's set off to create this.

### Tracking An Object

One of the main parts of parallax is that it has to do with moving objects. This means we need to track an object and move based on it.