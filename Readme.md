
# Grasshopper AutoSave on New Document

This Grasshopper plugin automatically saves any **new Grasshopper document** that has not yet been saved by the user.  
When a new document is created and has no file path, the plugin will:

- Create a `GrasshopperAutoSaves` folder inside your **Documents** directory.
- Save the new document with a timestamped filename (e.g., `NewGHFile_20260112_140600.gh`).

This ensures you never lose work when starting a new Grasshopper file.

---

## ✅ Features
- Automatically detects when a new Grasshopper document is created.
- Saves the document quietly without user interaction.
- Stores autosaves in a dedicated folder:  
  `C:\Users\<YourUser>\Documents\GrasshopperAutoSaves`

---

## 🛠 How It Works
- Hooks into Grasshopper's `DocumentAdded` event via `GH_AssemblyPriority`.
- Checks if the document has no `FilePath` (unsaved).
- Uses `GH_DocumentIO.SaveQuiet()` to save the file.

> **Important:**  
> This plugin **only saves the document once when it is created** and has no file path.  
> After that, you should rely on Grasshopper’s built-in **Autosave** feature for ongoing backups.

---

## 📂 Installation

### 1. **Download the Plugin**
- Go to the Releases section of this repository.
- Download the latest `.GHA` file.

### 2. **Install the Plugin**
- Copy the `.GHA` file to your Grasshopper **Libraries** folder:
