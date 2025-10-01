## 2D Farming Game (Unity) - Starter Kit

This is a minimal, production-ready starter for a top-down 2D farming game in Unity (2021.3+ or 2022+ recommended). It includes player movement, camera follow, farm tile interactions, crop lifecycle via ScriptableObjects, inventory/tool usage, a simple time system, and basic save/load.

### Folder Layout
- `Assets/Scripts/Player` — player controller and input
- `Assets/Scripts/Camera` — camera follow behavior
- `Assets/Scripts/Farming` — farm tiles, crop definitions, growth
- `Assets/Scripts/Inventory` — inventory and tool selection
- `Assets/Scripts/Core` — core utilities (time, events)
- `Assets/Scripts/SaveLoad` — basic JSON save/load

### Quick Start
1. Open this folder (`UnityFarming`) with Unity Hub to generate the project files.
2. Create a new Scene at `Assets/Scenes/Main.unity`.
3. In the Scene, add:
   - An empty `GameObject` named `Systems` and add components:
     - `GameTime` (from `Assets/Scripts/Core/GameTime.cs`)
     - `SaveSystem` (from `Assets/Scripts/SaveLoad/SaveSystem.cs`)
   - A `GameObject` named `Player` with components:
     - `SpriteRenderer` (assign a placeholder sprite)
     - `Rigidbody2D` (Body Type: Dynamic, Freeze Rotation Z)
     - `PlayerController` (from `Assets/Scripts/Player/PlayerController.cs`)
   - A `Camera` with `CameraFollow` targeting `Player`.
4. Create a `Grid` in the Scene (GameObject → 2D Object → Tilemap → Rectangular).
   - Under the Grid, create empty child `GameObject`s with `FarmTile` for interactable tiles (or tilemap proxy, see `FarmTile` notes).
5. Create a crop definition: Right-click in Project → Create → Farming → Crop Definition.
   - Set name, stages, durations, and sprites.
6. Press Play. Move with WASD or Arrow Keys. Use tools 1-3 to switch (Hoe, WateringCan, Scythe). Interact on a `FarmTile` with `Space`.

### Controls (default)
- Move: WASD / Arrow Keys
- Interact/Use Tool: Space
- Cycle Tools: Mouse Wheel or Keys 1-3

### Farm Tiles
- `FarmTile` supports these states: Untilled → Tilled → Planted → Growing → Harvestable.
- Hoe to till, use a seed item to plant (basic seed included in inventory initialization), water to progress growth, scythe to harvest when ready.

### Save/Load
- Saves are stored in `Application.persistentDataPath` as `save.json`.
- On Play, `SaveSystem` can auto-load; press `L` to load and `K` to save (configurable in inspector).

### Extending
- Add new tools in `ToolType` and handle in `ToolController`/`FarmTile`.
- Add new crops by creating new `CropDefinition` assets.
- Use a Tilemap-backed farm by making a small manager that maps tile positions to `FarmTile` state data. The included `FarmTile` MonoBehaviour focuses on per-tile GameObjects for clarity.

### Disclaimer
This is a starter. You will likely replace placeholder sprites, add UI, quests, audio, pathfinding, seasons, weather, and polish. The code aims for clarity over completeness.

