Make-Race — Unity MVP Scaffold

What I added
- A minimal set of Unity C# scripts you can drop into a new Unity project to start the Level 1 (drag race) prototype.
- Scripts are under `Assets/Scripts` (see list below).

Recommended Unity version
- Use a Unity LTS (2021.3 or 2022.3+) for stability and WebGL support.

Files added
- Assets/Scripts/CarTemplate.cs — Car stat template (ScriptableObject)
- Assets/Scripts/VehicleController.cs — Car movement + input (uses InputManager)
- Assets/Scripts/GameManager.cs — Game state + rewards
- Assets/Scripts/FinishLine.cs — Finish trigger, calls GameManager
- Assets/Scripts/UIManager.cs — HUD + modals
- Assets/Scripts/SaveSystem.cs — Local save (PlayerPrefs)
- Assets/Scripts/GarageManager.cs — Car selection
- Assets/Scripts/InputManager.cs — Centralized input handler (singleton)
- Assets/Scripts/Level.cs — Base class for level logic
- Assets/Scripts/Level1Manager.cs — Level 1 (drag race) logic
- Assets/Scripts/CameraFollowController.cs — 3rd-person racing camera

Quick setup
1. Create a new 3D Unity project (LTS recommended).
2. In the Project window create a folder `Assets/Scripts` and paste the C# files into it.
3. See **SCENE_SETUP.md** in this folder for detailed step-by-step scene assembly instructions.
4. Open the scene, press Play, and drive to the finish line.