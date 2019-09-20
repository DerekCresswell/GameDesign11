# Rube Goldberg Machine

Here we will talk more about the Rigidbody and Physics in Unity.

## Rigidbody

In the last lesson we added a Rigidbody to our circle and saw it fall. Let's talk a bit more about how this Rigidbody works.\
The basic idea behind the Rigidbody is that it gives an object a physical presence in the world. Just like how you have mass and therefore are affected by gravity. If you didn't have mass you wouldn't be affected by gravity.\
There are many other things the Rigidbody, such as apply drag to objects, but we are just using the basis of the component for this project.

## Collisions

Collisions are one of the most important part of making your game work so let's get some going.\
First thing we are going to do is disable the Camera "Gizmo" so we can better see our scene.\

### Gizmos

In Unity, Gizmos are little things added to the Scene View to make it easier to manipulate objects. They can be made by the user but in this course it will just be the defualt ones.\
Two of the most notable examples of Gizmos are the grid shown in the Scene View and the colored arrows shown when using the Move Tool.\
Back to the Camera. In the Scene View we can see the Camera Icon in the middle of the view. This is going to be in our way so let's get rid of it. We do not want to loss the Camera though, just the Gizmo.\
To do this click on "Gizmos" at the top right of the screen view. This will give us a dropdown menu. Scroll down and find the Camera and click on the icon listed to disable it.

![DisableCameraGizmo](Images/DisableCameraGizmo.JPG)

If you'd like to enable it, do the same thing. We are leaving it off for now though.\
Later on you may find other Gizmos getting in your way. Try searching them up in the dropdown menu to disable/enable them (Usually search by the Component that is making the Gizmo).

### Colliders

In order for our objects to collide we need to give a Collider. This allows an object to collide or hit other collider Objects.\
Colliders are added to an Object the exact same way as Rigidbody. This is because a Collider is yet another Component.\
Click on our first Circle Object and click add component. 

## Physics

