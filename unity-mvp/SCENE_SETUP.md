# Unity M1 Scene Setup — Level 1 (Drag Race)

This guide walks you through assembling the Level 1 prototype scene in Unity.

## Prerequisites
- Unity 2021.3 LTS or later.
- All C# scripts from `Assets/Scripts` imported into your project.

## Scene Hierarchy

Create a new scene named `MainScene` and build this GameObject hierarchy:

```
MainScene
├── GameManager (GameObject)
│   ├── GameManager (script)
│   ├── UIManager (script)
│   └── InputManager (script)
├── Level1Manager (GameObject)
│   └── Level1Manager (script)
├── Main Camera (GameObject)
│   └── CameraFollowController (script)
├── Player (Capsule or your car model)
│   ├── Rigidbody
│   ├── Collider (Box or Capsule)
│   ├── VehicleController (script)
│   └── Tag: "Player"
├── Track (empty GameObject) - parent for track objects
│   ├── Road (Plane, scaled long, flat)
│   └── Finish Line (Cube, trigger collider)
│       └── FinishLine (script)
└── Canvas
    ├── MoneyText (Text)
    ├── PostRacePanel (Image or Panel)
    │   └── PostRaceText (Text)
    └── HUDPanel (optional — speedometer, controls hint)
```

## Step-by-Step Setup

### 1. Create Core GameObjects

**GameManager**
- Hierarchy: Right-click in Hierarchy > Create Empty > name it `GameManager`
- Script: Drag `GameManager.cs` onto the object
- Script: Drag `UIManager.cs` onto the object
- Script: Drag `InputManager.cs` onto the object
  - This creates a singleton input bus for the whole game

**Level1Manager**
- Create Empty > `Level1Manager`
- Drag `Level1Manager.cs` onto it
- In Inspector, assign the `GameManager` object to the `gameManager` field

### 2. Create Player Car

**Player GameObject**
- Hierarchy: 3D Object > Capsule > name it `Player`
- Position: (0, 1, 0)
- Scale: (0.8, 1, 2) — makes it car-shaped
- Add Rigidbody:
  - Mass: 1
  - Drag: 0.5
  - Angular Drag: 1
  - Constraints: Freeze Rotation X, Y (keeps it from tipping)
- Collider: (auto Box Collider is fine)
- Script: Drag `VehicleController.cs` onto `Player`
- In Inspector, assign a CarTemplate asset to `VehicleController > template` field
  - If no CarTemplate exists, create one: Right-click Project > Create > MakeRace > CarTemplate
  - Set Base Speed: 50, Handling: 5, Durability: 10, Cost: 0
  - Save as `Assets/CarTemplates/DefaultCar.asset`
- Tag: Select "Player" (or create new tag)

### 3. Create the Track

**Road (Track Surface)**
- 3D Object > Plane > name it `Road`, parent it under a `Track` GameObject
- Transform:
  - Position: (0, 0, 50) — extends down the +Z axis
  - Scale: (5, 1, 100) — 5 units wide, 100 units long
- Material/Color: Light gray or blue (visual)

**Finish Line (Trigger)**
- 3D Object > Cube > name it `FinishLine`, parent it under `Track`
- Transform:
  - Position: (0, 1, 100) — at far end of road
  - Scale: (10, 3, 1) — wide trigger plane
- Collider:
  - Is Trigger: **ON**
- Script: Drag `FinishLine.cs`
- In Inspector, assign `GameManager` object to `gameManager` field

### 4. Create Camera

**Main Camera**
- Select the default `Main Camera` (or create: 3D Object > Camera)
- Transform:
  - Position: (0, 5, -10) — behind and above player
- Script: Drag `CameraFollowController.cs` onto it
- In Inspector, assign `Player` object to `target` field
- Tweak offsets as needed (distance, height, smoothSpeed)

### 5. Create UI Canvas

**Canvas**
- Right-click in Hierarchy > UI > Canvas
- In Inspector, set Canvas Scaler > UI Scale Mode: `Scale with Screen Size`

**Money Text**
- Right-click Canvas > UI > Text (Legacy) > name it `MoneyText`
- Transform: position top-right corner (e.g., 900, 500, 0 in RectTransform)
- Text: "$100"
- Font size: 36
- Color: white

**Post-Race Panel**
- Right-click Canvas > UI > Image > name it `PostRacePanel`
- Transform: anchor to center, size 600x400
- Image: set color to semi-transparent black (or use panel)
- Visibility: Initially OFF (unchecked in Inspector)

**Post-Race Text**
- Right-click PostRacePanel > UI > Text (Legacy) > name it `PostRaceText`
- Transform: full size of panel
- Text: "Win!\nYou earned $50"
- Font size: 40
- Alignment: center

**Wire UIManager**
- Select `GameManager` object
- In `UIManager` script:
  - Drag `MoneyText` into `Money Text` field
  - Drag `PostRacePanel` into `Post Race Panel` field
  - Drag `PostRaceText` into `Post Race Text` field

### 6. Build Settings & Tags

- File > Build Settings
  - Add current scene to Scenes in Build (drag scene or use "Add Open Scenes")
  - Build Target: Standalone (or WebGL for browser build)

- Tags:
  - Create a "Player" tag if not present
  - Assign it to the `Player` GameObject

## Testing the Scene

1. Press **Play** in the Editor.
2. You should see:
   - The car capsule at the start
   - Camera following behind
   - Money display in top-right corner ($100)
3. Controls:
   - **W / Up Arrow**: accelerate forward
   - **A / D / Left / Right**: steer
   - **Space / Mouse Click**: jump
4. Drive forward to the Finish Line (cube at far end).
5. Cross the finish line:
   - You should see a post-race modal: "Win! You earned $50"
   - Money should update to $150
6. Click anywhere to close modal (optional UI button).

## Next Enhancements

- [ ] Add visual road borders (cubes on sides)
- [ ] Add ground texture
- [ ] Smooth vehicle acceleration (using Rigidbody velocity, not MovePosition)
- [ ] Sound effects (win, accelerate, jump)
- [ ] Particle effects (exhaust, landing dust)
- [ ] Pause menu
- [ ] Return to Garage from post-race screen

## Scripts Summary

| Script | Purpose |
|--------|---------|
| `InputManager` | Centralized input handling |
| `VehicleController` | Car physics and controls |
| `GameManager` | Game state and event dispatch |
| `UIManager` | HUD and modal display |
| `Level1Manager` | Level 1-specific logic (drag race) |
| `CameraFollowController` | 3rd-person racing camera |
| `FinishLine` | Finish line trigger, calls `OnPlayerFinish()` |
| `SaveSystem` | PlayerPrefs-based saving |
| `CarTemplate` | Car stat data asset |

## Troubleshooting

**Player doesn't move:**
- Check `VehicleController > template` is assigned.
- Check Rigidbody has gravity enabled and constraints are correct.

**Camera doesn't follow:**
- Check `CameraFollowController > target` points to your Player.

**Finish line doesn't trigger:**
- Ensure `FinishLine` collider has `Is Trigger` enabled.
- Ensure Player has a Collider and Rigidbody.
- Check Player is tagged "Player".

**UI doesn't show:**
- Ensure Canvas and Text objects are active in Hierarchy.
- Check `UIManager` references are correctly wired in Inspector.
