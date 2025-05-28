# Valorant Gameplay FPS - Gun System (Unity)

A modular and optimized first-person shooter gun system built in Unity, inspired by Valorant. This project focuses on clean code architecture, visual polish, and scalable gameplay features such as shooting, bullet visuals, and impact effects.

---

## ✨ What's New

The original gun system was functional but lacked visual polish and performance optimizations. This new version has been **rebuilt from scratch** with:

* ScriptableObjects for modular weapon data
* TrailRenderer bullets for tracer effects
* Particle-based muzzle flashes
* Impact visuals on hit
* Object Pooling (Unity 2021+) for bullet trails
* Strategy Pattern for fire behavior types

---

## 🔊 Features

### 🔧 Modular Architecture

* Each weapon uses a `WeaponDataSO` ScriptableObject
* Clean separation of input, logic, and visuals

### 🔫 Realistic Bullet Behavior

* Raycast for accurate and immediate hit detection
* Tracer effect using a trail renderer (not Rigidbody physics)
* Impact effect instantiated at hit point

### ⚖️ Performance-Ready

* Uses `ObjectPool<T>` (UnityEngine.Pool) to pool TrailRenderers
* Avoids runtime `Instantiate()`/`Destroy()` spikes

### 🔍 Extensible Gun Types

* Strategy Pattern (`IFireStrategy`) allows adding different firing behaviors
* Easily extendable to add semi-auto, burst, and auto fire types

---

## 📂 Project Structure

```
Assets/
├── Scripts/
│   ├── Weapon/
│   │   ├── Weapon.cs
│   │   ├── FireCommand.cs
│   │   ├── FireStrategyFactory.cs
│   │   ├── IFireStrategy.cs
│   │   └── WeaponDataSO.cs
│   ├── Bullet/
│   │   ├── BulletService.cs
│   │   └── BulletMover.cs
│   └── Player/
│       └── PlayerView.cs
├── Prefabs/
│   ├── Weapons/
│   ├── BulletTrail/
│   └── Effects/
├── ScriptableObjects/
│   └── WeaponData/
```

---

## 🔢 How It Works

1. Player input is captured using Unity's Input System
2. Weapon retrieves its fire behavior from ScriptableObject
3. Performs raycast to detect hit
4. TrailRenderer is spawned and animated toward hit point
5. Muzzle flash and impact effects are shown
6. Everything except raycast is handled visually (no physics)

---

## 🔝 Built With

* Unity 2021.3+
* C#
* Unity Input System
* ScriptableObject architecture
* TrailRenderer & ParticleSystem
* UnityEngine.Pool (Object Pooling)

---

## 🙏 Acknowledgements

* 🎩 [**LlamAcademy**](https://www.youtube.com/c/LlamAcademy) — For the gun system design and tutorials
* 🚀 [**Outscal**](https://outscal.com) — For mentorship and teaching clean game architecture

---

## 🔍 Next Steps

* Add player abilities (e.g. smoke, dash)
* UI for ammo count and reload
* Sound FX integration (shoot, reload)
* Weapon switching system

---

## 🔖 License

MIT License — Free to use, modify, and distribute.
