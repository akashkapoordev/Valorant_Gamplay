# 🔫 Modular FPS Gunplay System (Unity C#)

A scalable and cleanly architected First-Person Shooter (FPS) gunplay framework in Unity using **Command Pattern**, **Strategy Pattern**, and **ScriptableObjects**.

This project showcases clean code practices, modular design, and extendability with minimal gameplay mechanics like:

- Raycast Shooting  
- Ammo & Reloading  
- Weapon Switching  
- Recoil & Visual Feedback  
- Data-Driven Weapons via ScriptableObjects

---

## 🧠 Design Goals

✅ Scalable and extensible  
✅ Easy to integrate into any FPS project  
✅ Demonstrate solid understanding of OOP and design patterns  
✅ Separation of data and behavior using ScriptableObjects

---

## 🧱 Architecture Overview

```
[InputSystem] → [FireCommand.Execute()]
               ↓
         [Weapon.Fire()]
               ↓
  [FireStrategyFactory.GetStrategy()]
               ↓
  [SingleShotFire / BurstFire / ShotgunFire]
               ↓
       → Raycast, VFX, Target Hit
```

---

## 🧩 Design Patterns Used

| Pattern            | Purpose |
|--------------------|---------|
| 🎮 **Command**      | Encapsulates user actions like fire, reload, switch weapon |
| 🧠 **Strategy**     | Handles different firing behaviors (single, burst, shotgun) |
| 🧾 **ScriptableObject** | Stores data-driven weapon stats (fire rate, damage, ammo) |
| 🏭 **Factory**      | Returns correct fire behavior based on `FireType` enum |
| 🔄 **Service Locator (optional)** | Central access to recoil, audio, VFX services |

---

## 📁 Folder Structure

```
Assets/
├── Scripts/
│   ├── Input/
│   │   ├── IInputCommand.cs
│   │   ├── FireCommand.cs
│   │   ├── ReloadCommand.cs
│   │   └── InputHandler.cs
│   ├── Weapon/
│   │   ├── Weapon.cs
│   │   ├── WeaponDataSO.cs
│   │   ├── IFireStrategy.cs
│   │   ├── SingleShotFire.cs
│   │   └── FireStrategyFactory.cs
│   ├── Player/
│   │   ├── PlayerModel.cs
│   │   ├── PlayerView.cs
│   │   └── PlayerController.cs
│   ├── Systems/
│   │   └── WeaponManager.cs
├── Prefabs/
│   ├── Weapons/
├── ScriptableObjects/
│   └── WeaponData/
```

---

## 🔧 How to Use

1. **Create WeaponDataSO**:
   - Right-click in `ScriptableObjects/WeaponData/`
   - `Create → Weapons → Weapon Data`
   - Fill in weapon stats and visuals

2. **Create Weapon Prefab**:
   - Add `Weapon.cs`
   - Assign `WeaponDataSO` and `firePoint`

3. **Attach to Player**:
   - Add a `GunHolder` under Camera
   - Drag weapon prefab into it

4. **Use InputHandler**:
   - Assign `WeaponManager` or direct `Weapon` reference
   - Fire using mouse input (e.g. `FireCommand`)

---

## 📌 Features Implemented

- [x] FPS movement and camera
- [x] Raycast shooting
- [x] Muzzle and impact VFX
- [x] Ammo + reload system
- [x] ScriptableObject-based weapon data
- [x] Weapon switching via number keys
- [x] Clean architecture (Command + Strategy)

---

## 📚 Credits

Created by **Akash Kapoor**  
Powered by Unity Engine  
Architecture inspired by SOLID principles and real-world AAA systems

---

## 📈 Future Improvements

- ✅ Enemy AI with hit response  
- ✅ UI integration for ammo/weapon  
- ✅ Advanced firing modes (charge-up, spread, etc.)  
- ✅ Multiplayer adaptation using Photon or Netcode

---
