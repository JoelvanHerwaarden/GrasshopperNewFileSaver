
# Grasshopper AutoSave on New Document

This plugin automatically saves any **new Grasshopper document** that has not yet been saved by the user.  
When a new document is created and has no file path, the plugin will:

- Create an `GrasshopperAutoSaves` folder inside your **Documents** directory.
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

---

## 📂 Installation

### 1. **Build the Plugin**
- Open the project in **Visual Studio**.
- Target **.NET Framework 4.8** (recommended for Rhino 7).
- Add references to:
  - `RhinoCommon.dll` (found in `C:\Program Files\Rhino 7\System`)
  - `Grasshopper.dll` (found in `C:\Program Files\Rhino 7\Plug-ins\Grasshopper`)
- Compile the project. This will produce a `.GHA` file in your `bin\Release` folder.

### 2. **Install the Plugin**
- Copy the compiled `.GHA` file to your Grasshopper **Libraries** folder:
