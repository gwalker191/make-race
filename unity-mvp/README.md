Make-Race — Unity MVP Scaffold

What I added
- A minimal set of Unity C# scripts you can drop into a new Unity project to start the Level 1 (drag race) prototype.
- Scripts are under `Assets/Scripts` (see list below).

Recommended Unity version
- Use a Unity LTS (2021.3 or 2022.3+) for stability and WebGL support.

Files added
- Assets/Scripts/CarTemplate.cs
- Assets/Scripts/VehicleController.cs
- Assets/Scripts/GameManager.cs
- Assets/Scripts/FinishLine.cs
- Assets/Scripts/UIManager.cs
- Assets/Scripts/SaveSystem.cs
- Assets/Scripts/GarageManager.cs

Quick setup
1. Create a new 3D Unity project (LTS recommended).
2. In the Project window create a folder `Assets/Scripts` and paste the C# files into it.
3. Create a new Scene `MainScene` and set up GameObjects:
   - Create an empty `GameManager` object and attach `GameManager` + `UIManager` (or separate objects) scripts.
   - Create a `Player` object (capsule or model), add `Rigidbody` and `VehicleController`. Tag it as `Player`.
   - Create a finish object (cube) with `IsTrigger` enabled and attach `FinishLine` script (assign `GameManager`).
   - Create a Canvas with `Text` elements for money and post-race panel; assign them to `UIManager` references.
4. Create `CarTemplate` assets: Right-click in Project > Create > MakeRace/CarTemplate and configure base stats.
5. Run the scene and control the car with `W/A/S/D` or arrow keys, jump with `Space`.

Notes
- The scripts are intentionally minimal to keep the prototype fast to assemble. They include PlayerPrefs-based saving for money.
- Next step I can implement a sample Unity scene and small prefabs, but that requires a Unity project binary (I can provide guidance and scripts which you can drop in).

Want me to create a small sample Unity package (.unitypackage) with a prebuilt scene and prefabs you can import? If so I can create the steps to generate it and bundle assets.