## Roll a Ball (Week 1)

Game to roll a ball around a board and pick up objects until there are no objects left.

[Tutorial followed from here](https://www.youtube.com/watch?v=lv0SqtSzBxc)

![image](imgs/demo.gif)

An introduction to the Roll-a-ball assignment, showing the final game and describing what will be covered in this assignment.

### Setting up the game
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

### Moving the player
Lets think about how we want the player to move. We want to be able to roll around on the game area, stay on the ground, bump into walls and not fly off into space. We also want to be able to collect objects and pick them up.
[Tutorial followed from here](https://www.youtube.com/watch?v=IZlaZsQM1Fw)

1. We first need to add a `Ridged body` to our player object.
  1. Do this by selecting the sphere then clicking Component > Physics > RidgedBody
2. Now we need to accept input from the player and apply these as forces to move the player object in the scene. We will do this by creating a script we attach to the game object.
  1. Create a folder in the `Assets` directory by looking at the project view, right clicking  the `Assets` folder and Create > Folder. Call this new folder `Scripts`.
  2. Next we need to create a script. Click the `Player` object and under the `Inspector` view click `Add Component`.
  3. Click `New Script` and Call the script `PlayerControl` and select the language as `C#`.
  4. This creates the script file in the Assets directory and attaches it to the `Player` object
  5. We need to move the script from the 'Assets' folder to the 'Scripts' folder.
3. The next step involves programming the script.
  1. Right click the script file and click `open` this will open it in Unity's text editor.
  2. You will see that some of the standard code has already been added.
  3. If we look at the [MonoBehaviour documentation](http://docs.unity3d.com/ScriptReference/MonoBehaviour.html) we can see that there are some functions which interest us. `Update()` and `FixedUpdate()`. Update is called before rendering a frame and fixed update is called before applying physics to the game.
  4. For movement we will be using the `FixedUpdate` function. This is not added by default so you will need to add it yourself.  Your Code should now look like this.
    ```c
      using UnityEngine;
    using System.Collections;

    public class PlayerMovement : MonoBehaviour {

    	// Use this for initialization, this runs when the script is loaded
    	void Start () {

    	}

    	// Update is called once per frame
    	void Update () {

    	}
    	//Called before performing any physics calculations. This is the one we will be using.
    	void FixedUpdate () {

    	}
    }
    ```
  5. Next we need to get input from the user. We will do this by using the `Input.getAxis()` function which returns if an arrow button is being pressed. You can see examples of this function  [here](http://docs.unity3d.com/ScriptReference/Input.GetAxis.html).
  6. We now need to add the code which detects if the user is pressing a directional key.
    ```c
    float moveHorizontal = Input.GetAxis ("Horizontal");
    float moveVertical = Input.GetAxis ("Vertical");
    ```
    This code is calling the `GetAxis` function of `Input` and saving its value to a variable. We are getting the values for horizontal & vertical which represents left/right & up/down respectively.
  7. Now we need to apply forces to the RigidBody, we can see from the [documentation](http://docs.unity3d.com/ScriptReference/30_search.html?q=rigidbody) that there is a function called `AddForce` ([info](http://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html)). This will add a force to the rigid body and cause it to move.
  8. We can see [examples](http://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html) on how this function can be used. It needs to take a [_Vector3_](http://www.bbc.co.uk/schools/gcsebitesize/maths/geometry/vectorshirev1.shtml) which determines the direction the force is applied.
  9. Add this line of code to the `FixedUpdate()` function.
    ```c
    rigidbody.AddForce (Vector3);
    ```
  10. Now we need to get out two float values (moveHorizontal & moveVertical) into a Vector3 value.
    1. First we need to crate a new Vector3 value called `movement`.
    ```c
    Vector3 movement = new Vector3(x, y z)
    ```
    2. Then as horizontal movement is in the X axis and vertical movement is in the Y axis we can add our floats in to our Vector3.
    ```c
    Vector3 movement = new Vector3 (moveHorizontal, y, moveVertical);
    ```
    3. We still have the Y value unfilled, what should this be?... 0, because we do not want the player to move up or down.
    ```c
    Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
    ```
    4. Now we use `movement` as our Vector3 value in the function `AddForce()`
    ```c
		rigidbody.AddForce (movement);
    ```
  11. Now we can save this script and see what we've done! Go back to unity and click the play button towards the top and try to move the ball. To stop testing, click the play button again.
  12. You can see that the ball moves but it is very slow. We need to speed it up again to make it playable.
    1. Open the script file again.
    2. We need to multiply the vector force to make it move faster. We could do this in out script with a fixed value, but that would mean editing the script again to change it. Instead we will create a variable that can be changed from within Unity.
    3. We need to create a public variable in our script, underneath the class declaration add the line `public float speed;`.
    ```c
    public class PlayerMovement : MonoBehaviour {
      public float speed;
    ```
    4. We then need to multiply the vector by the speed.
    ```c
    rigidbody.AddForce (movement * speed * Time.deltaTime);
    ```
    `delaTime` is used to smooth the movement out while holding the key.
    5. Save the changes and return to Unity.
  13. We can now see there is a `speed` setting below the script when clicking on the `Player` object. Try messing around with this setting to see what is best for the game!
