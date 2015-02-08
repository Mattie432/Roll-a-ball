### Moving the camera
So far we can move the ball but the camera does not move and cannot see very much. We need to 'attach' the camera to the player object (the ball).
[Tutorial followed from here](https://www.youtube.com/watch?v=HocIybFeAvI)

1. Lets set the position of the camera.
  1. Click on the `Main Camera` object.
  2. Lets move it up by 10 units. Under the 'transform' section set position-Y to 10.
  3. If you click on the `Game View` you cannot see the ball so we need to rotate the camera down. Set rotation-X to 45.

2. Next we need to 'lock' the camera relative to the player object (the ball). This will mean that as the ball moves around the camera will follow it. To do this we need to create another script.
  1. Click on the `Main Camera` object, then `Add Component` > `New Script`. Set the language to `CSharp` and call it 'CameraController'.
  2. This will create the script file in the 'Assets' folder. Move it to the 'Scripts' folder we created in the second tutorial.
  3. Open the file for editing.
  4. We need to add two variables to the file. One is a reference to the ball (player) and the other is a vector which will determine where the camera is relative to the ball.
    1. Add these two variables below the `public class CameraController : MonoBehaviour` line.

        ```
        public GameObject player;
        private Vector3 offset;
         ```

    2. The `Player` variable will be used so that we can access the properties of the ball in the code.
    3. The `offset` variable holds our camera position relative to the ball.
  5. Next we need to set the value of the `offset` variable.
    1. Inside of the `Start()` function add the line.

         ```
         offset = transform.position;
         ```

    2. This is setting the value of offset equal to the camera's current position.
    3. *Remember* code in the `Start()` function is called only when the script is first loaded (so only once).
  6. Now we need to update the camera's position relative to the balls position. We do this every frame so that it moves with the ball.
    1. In the `Update()` function add the line.

         ```
         transform.position = player.transform.position + offset;
         ```

    2. This will set the camera's position to the balls position + the offset. The offset is saying set the camera 10 units above the ball (like we did in step 1).
  7. One last thing, `Update()` is not the best place for this code as we want to update the camera _after_ all other actions have been performed. We use the [LateUpdate()](http://docs.unity3d.com/ScriptReference/MonoBehaviour.LateUpdate.html) function for this.
    1. Rename `Update()` function to `LateUpdate()`.
    2. `LateUpdate()` is called after all other update functions have been called. If we used the `Update()` function then our camera could move before the ball had moved and cause us problems.
  8. We are finished with out code. [Here](https://github.com/Mattie432/Roll-a-ball/blob/master/code/Assets/Scripts/CameraController.cs) is how my code looks at this point. Check yours against mine.

3. Now we need to setup the script.
  1. First click on `Main Camera`
  2. You can see the `Camera Controller` script on the right hand side. Notice that the `Player` variable is visible and it says 'None' (it is empty.)
  3. We need to set the `player` variable to the player object. Drag the `Player` object from the hierarcy and drop it onto the variable in the script.
  4. The name should change from 'None' to 'Player'

4. Enter `Play` mode and check that everything is working fine!


You can download the project completed upto this point [here](https://github.com/Mattie432/Roll-a-ball/releases/tag/v0.3)

###[Next Tutorial > 4](Section4.md)
