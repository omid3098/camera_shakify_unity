# Camera Shakify Unity
Here is [Blender`s Shakify addon](https://github.com/EatTheFuture/camera_shakify) in Unity!



https://user-images.githubusercontent.com/6388730/174351323-a61f2193-fc28-4cca-8ca2-4e6c2361e0db.mp4



# Installation:
Method 1:
Download UnityPackage from release page and import into your project.

Method 2:
- Clone this repo into your project
- if you want to check all the source, add [NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes) and "com.unity.nuget.newtonsoft-json": "3.0.2" to your manifest.json to remove compile errors. if you dont care about the source, remove Editor folder.

# How to use:
- Add Shakify component to your camera and assign a scriptable shake data to it.

Note: Sometimes its better to have a separate parent on camera to apply these transformations to it.

## Article
You can read the article about how I did this on [Medium](https://medium.com/@omid3098/real-life-camera-shake-in-unity-ffae4b5976ac).

## Todo:
Add these shakedata to Cinemachine Virtual cameras noise component.
