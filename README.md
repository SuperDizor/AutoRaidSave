# Auto Raid Save

**Auto Raid Save** is a RimWorld mod that automatically creates a save game whenever a raid or other red threat event occurs.

The save is triggered **after the raid is fully generated**, ensuring that enemies are present when loading the save.

---

## ✨ Features

- 🔴 Automatically saves on **red threat events** (raids, major threats)
- ⏱️ Save is performed **after raid generation** (no missing attackers)
- 🎛️ In-game **mod settings menu**
- 🔄 Option to **overwrite a single autosave** or create new saves
- ⏳ Configurable **cooldown** between saves
- 🧪 Optional **debug logging**
- ⚙️ Fully compatible with **RimWorld 1.6**

---

## ⚙️ Mod Settings

Available in **Options → Mods → Auto Raid Save**

- ✅ Enable / disable automatic saving
- ⏱️ Cooldown between saves (minutes)
- 🔄 Always overwrite the same save file
- 🧪 Enable debug logging

All settings are saved automatically and persist between sessions.

---

## 🧠 How it works

- The mod listens for **red threat letters** (`ThreatBig`, `ThreatSmall`)
- When detected, it waits until RimWorld finishes generating the raid
- A save is then created using RimWorld’s native save system
- This prevents “empty raids” when reloading a save

---

## 📦 Requirements

- **RimWorld 1.6**
- **Harmony**  
  Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=2009463077

---

## 📁 Installation

### Steam Workshop
Subscribe to the mod and activate it in the RimWorld mod menu.

### Manual installation
1. Download or clone this repository
2. Place the folder in: RimWorld/Mods/AutoRaidSave
3. Enable the mod in RimWorld
4. Restart the game

---

## 🧪 Debugging

Enable **Debug logging** in the mod settings to see detailed messages in: Player.log

Useful for verifying save timing and cooldown behavior.

---

## 🛠️ Compatibility

- Safe to add or remove mid-save
- Does not modify saves directly
- Compatible with most storyteller and raid mods
- Load **after Harmony**

---

## 📄 License

This project is released under the MIT License.  
Feel free to fork, modify, and contribute.

---

## 👤 Author

**SuperDizor**  
GitHub: https://github.com/superdizor

---

## ⭐ Feedback & Contributions

Issues, pull requests, and suggestions are welcome!  
If you enjoy the mod, consider leaving a ⭐ on GitHub or a rating on Steam Workshop.
Also you can buy me a ko-fi: https://ko-fi.com/felixdion



