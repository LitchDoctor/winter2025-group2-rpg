# SETUP.md

## Overview
This document provides step-by-step instructions for setting up and deploying the 2D Unity game as a desktop application. The instructions cover dependencies, installation, and deployment steps for both Windows and macOS.

---

## System Requirements

### Minimum Hardware Requirements
- Processor: Intel Core i5 or equivalent
- RAM: 8GB
- GPU: Integrated graphics (for basic performance) or dedicated GPU (recommended)
- Storage: 500MB of available disk space

### Software Dependencies
- **Unity Engine** (Version: `6000.0.34f1`)
- **Visual Studio** (optional, for debugging and development)
- **Git** (for pulling from a repository)

---

## Installation Instructions

### Windows
1. Install Unity Hub from [Unity Download Page](https://unity.com/download).
2. Using Unity Hub, install Unity version `6000.0.34f1`.
3. Clone the project repository:
   ```sh
   git clone https://github.com/LitchDoctor/winter2025-group2-rpg
   cd winter2025-group2-rpg
   ```
4. Open the project in Unity Hub.
5. Install required Unity packages (if prompted by Unity Editor).
6. Build the project:
   - Navigate to `File` → `Build Settings`.
   - Select **PC, Mac & Linux Standalone**.
   - Choose **Windows** as the target platform.
   - Click **Build**, and select an output folder.
   - The built `.exe` file will be generated in the specified folder.
7. Run the generated `.exe` file to launch the game.

### macOS
1. Install Unity Hub from [Unity Download Page](https://unity.com/download).
2. Using Unity Hub, install Unity version `6000.0.34f1`.
3. Clone the project repository:
   ```sh
   git clone https://github.com/LitchDoctor/winter2025-group2-rpg
   cd winter2025-group2-rpg
   ```
4. Open the project in Unity Hub.
5. Install required Unity packages (if prompted by Unity Editor).
6. Build the project:
   - Navigate to `File` → `Build Settings`.
   - Select **PC, Mac & Linux Standalone**.
   - Choose **Mac OS X** as the target platform.
   - Click **Build**, and select an output folder.
   - The built `.app` file will be generated in the specified folder.
7. Run the generated `.app` file to launch the game.

---

## Deployment
- **For Distribution:**
  - Compress the built application folder into a `.zip` file for easier sharing.
  - Distribute via cloud storage, email, or a game launcher.

- **For Installer Creation (Windows only):**
  - Use `Inno Setup` or `NSIS` to create an `.exe` installer.

- **For macOS Notarization:**
  - Sign and notarize the app using Apple Developer tools to avoid security warnings.
  
---

## Troubleshooting

| Issue | Solution |
|--------|---------|
| Unity fails to open project | Ensure the correct Unity version is installed via Unity Hub. |
| Build errors in Unity | Check `Console` for missing scripts or dependencies. Make sure all assets are loaded. |

---