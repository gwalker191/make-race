# Make-Race — Game Design Reference

Quick reference for core game mechanics and progression.

## Level 1: Drag Race (Straight Track)

**Objective**: Drive straight to the finish line as fast as possible.

**Mechanics**:
- Linear track, no obstacles.
- Player accelerates forward, jumps for style points (optional).
- Finish line at far end triggers win.
- Reward: $50 + bonus time multiplier (optional).

**Controls**:
- **W / Up**: accelerate
- **A / D / Left / Right**: steer (minimal turning needed)
- **Space / Click**: jump

**Setup Notes**:
- Track: 100 units long, 5 units wide.
- Finish line at Z = 100.
- Vehicle starts at Z = 0.

---

## Level 2: Jumps (Straight + Obstacles)

**Objective**: Navigate jumps while maintaining speed.

**New Mechanics**:
- Jump surfaces appear mid-track at Y = 2.
- Player must time jumps or take damage.
- Reward: $75.

**Scripts Needed** (not yet created):
- `JumpPlatform.cs` — detects landing, applies bounce, tracks height.
- `Level2Manager.cs` — extends `Level.cs`.

---

## Level 3: Slime Hazard (Jumps + Slime)

**Objective**: Jump over slime without sinking.

**New Mechanics**:
- Slime pools under jumps.
- Landing in slime starts 2-second sink timer.
- Sinking resets player to Level 1; lose $25.
- Reward: $100.

**Scripts Needed**:
- `SlimeZone.cs` — trigger for slime damage + reset.
- `Level3Manager.cs` — extends `Level.cs`.

---

## Level 4: Rock & Wood (Mixed Obstacles)

**Objective**: Drive through mixed terrain without losing durability.

**New Mechanics**:
- Static rocks and wood planks block the road.
- Collision reduces durability; when durability <= 0, the car becomes slow until repaired.
- Repair cost in post-race: $15.
- Reward: $150.

**Scripts Needed**:
- `Obstacle.cs` — static collision, applies damage.
- `Level4Manager.cs` — extends `Level.cs`.

---

## Progression Loop (per race)

1. **Start**: Show pre-race UI, assign car from garage.
2. **Race**: Player drives level, time ticks up.
3. **Finish or Fail**:
   - **Finish**: Post-race shows time, money earned, option to retry or next level.
   - **Fail** (e.g., slime): Post-race shows failure reason, retry from current level.
4. **Garage**: Return to customize, repair, buy parts (if money available).

---

## Economy

**Starting Money**: $100

**Rewards**:
- Level 1 completion: +$50
- Level 2 completion: +$75
- Level 3 completion: +$100
- Level 4 completion: +$150

**Costs**:
- Car purchase (template unlocks): $0–$75 (varies)
- Car parts/upgrades: $10–$50 each
- Car repair (post-race, if damaged): $15

**Money Display**: Always visible top-right HUD.

---

## Car Templates (Starter 5)

| Name | Speed | Handling | Durability | Cost |
|------|-------|----------|-----------|------|
| Speedster | 8 | 4 | 7 | Free |
| Handler | 5 | 8 | 8 | $50 |
| Tank | 4 | 3 | 10 | $75 |
| Balanced | 6 | 6 | 8 | Free |
| Drift King | 7 | 7 | 6 | Free |

Stats influence gameplay:
- **Speed**: Acceleration + top speed (Level 1 advantage).
- **Handling**: Turn radius + collision recovery (Levels 3+ advantage).
- **Durability**: Max HP; affects performance when damaged (Levels 2+ matter).

---

## Input & Controls

Centralized in `InputManager.cs`:
- `GetAcceleration()` → 1.0 (forward), -0.5 (backward), 0.0 (idle)
- `GetSteer()` → -1 to 1 (left to right)
- `GetJumpInput()` → bool (Space / Click)
- `GetPauseInput()` → bool (Escape)

---

## Persistence

**Saved Data** (`SaveSystem.cs`):
- Player money (int)
- Owned cars (list of template IDs)
- Best times per level (float)
- Current car selection (int index)

**Storage**: PlayerPrefs (MVP) → JSON file (later) → Cloud (post-MVP).

---

## Next Art & Sound Todos

- [ ] Car model: low-poly 3D or 2D sprite.
- [ ] Track textures: road, grass, slime texture.
- [ ] Finish line: checkered flag or neon glow.
- [ ] Jump platform: bright ramp texture.
- [ ] Slime: animated goo liquid.
- [ ] SFX: engine rev, jump, collision bump, win chime.
- [ ] Music: upbeat race loop.

---

## Known Limitations (M1 MVP)

- Single-player only; no AI or multiplayer.
- Simple arcade physics (no realistic damage/degradation over time).
- No pause menu (can add later).
- No leaderboard or replay system.
- Camera is fixed 3rd-person (may need adjust for mobile).

---

**Feedback & Iteration**:
- Playtest Level 1 with 6-year-old and parent — adjust speed, controls, difficulty.
- Gather data on completion times; adjust rewards/difficulty balance.
- Add or remove obstacles based on feedback.
