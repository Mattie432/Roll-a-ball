### Setting up the game

[Tutorial followed from here](https://www.youtube.com/watch?v=lv0SqtSzBxc)

1. Start a new project
2. Choose the destination of the project and click create (no imports are needed for this task)
3. You now need to `save your scene`. Click File > Save Scene and create a new folder under the `Assets` directory called `Scenes`. Name the save `MiniGame` and click save.
4. Now create a `plane` object by going to GameObject > 3D Object > Plane. And rename this object to `ground` in the Hierarchy view.
5. Now we need to center the plane to 0,0,0 (the origin point of the game).
  1. Clicking `Ground` in the Hierarchy view which will show the options in the Inspector view
  2. Now look for the settings cog for the `transform` section of the Inspector view
  3. Click the cog > reset, this will set the position of the plane to to center of the world.
6. Now we change the scale of the ground plane.
  1. First click the `scale tool` from the menu bar at the top (bellow edit).
  2. Next click on the `ground` object and then drag the directional arrows to change the size. **Note** as a plane has no volume dragging the Y (yellow) axis below the origin will invert it causing it to not be seen.
7. We now create our player object. Create a sphere from the GameObject > 3D Object > Sphere.
  1. Rename the sphere `player`
  2. Reset the transform to origin (same as we did in #5)
  3. You can now see that the sphere is half buried below the `ground` object. This is because the center of coordinates of the sphere are from its center. To correct this set the y-position of the sphere equal to its radius (1).
8. If you switch to the `game view` you will notice that it is very dark. This is because we have not added any lights to the scene.
  1. Click Game Object > Light > Directional Light to add a light.
  2. Rename this `main light`
  3. Reset the lights transform to origin (same as in #5).
  4. Set the x-rotation to 30 so that it shines down on the game board.
  5. Have another look at the game view to see what we have done.
  6. This is not the best angle for the light, so also set the y-roation to 60 so that we have a better angle for the light.
  7. To help the player see how they are looking at the ball, we need some shadows. Set the shadows of the `main light` to soft.
  8. *Optional* set the resolution to `high resolution`
  9. Switch back to game view and we can see that the ball is clearly visible with a shadow.
8. We should now add a `Fill Light` which is a light from the opposite direction of the main light. This shines on the dark side of the sphere and allows the player to better see where the sphere ends and the shadow begins.
  1. Duplicate the main light (by right clicking it)
  2. Rename the duplicate to `Fill Light`
  3. Invert the rotations of the fill light to -30 for X and -60 for Y.
  4. This makes the light shine up from below.
  5. Change the color of the light to one of your choosing.
  6. Lower the intensity of the light to 0.1
  7. Then turn off shadows for this light.
9. Lets reorganize the `Hierarchy` of the game. This is important to keep track of what we have and allows us to access objects quickly.
  1. We can use empty game objects as folders to better structure our project.
  2. Create a new game object. Game object > Empty Game object.
  3. Rename this empty game object to `Lights`
  4. Reset the transform to origin (#5)
  5. Drag and drop the `Fill light` & `Main light` to this game object.
10. Now see how the lights are in the middle of the game board? We can move them out of the way because `Directional Lights` light the whole scene regardless of there position.
  1. Click the `Lights` folder.
  2. Set the Y-position of this object to high above the game board.

  ###[Next Tutorial > 2](Section2.md)
