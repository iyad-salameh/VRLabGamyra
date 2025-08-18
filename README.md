
XR Lab Prototype with LLM
A modular VR prototype for a training and research lab, featuring interactive puzzles and a conversational AI assistant powered by a local Large Language Model (LLM).

This project was developed as a technical assessment, demonstrating a robust, scalable, and intuitive VR application built from the ground up in Unity. It showcases core VR mechanics, advanced interaction design, a clean, event-driven architecture, and direct integration with local AI to create a truly dynamic and intelligent training tool.

🎥 Project Demo

<img width="1158" height="742" alt="image" src="https://github.com/user-attachments/assets/4e9f10d7-2f4e-47f0-8973-8fed9685e3ff" />

✨ Features
🤖 Conversational AI Assistant (ALISA): The smart assistant is powered by locally-run models (Llama 3.1:8b, Qwen2:7b, tinyllama) via Ollama and the Neocortex SDK. It provides guidance and answers user questions through an interactive, in-world chat interface. The AI is context-aware, receiving the current game state with each prompt to provide relevant responses.

🧭 Guided Locomotion: A teleportation system using specific Teleportation Anchors guides the user to points of interest, controlling the flow of the training scenario and ensuring comfort for new VR users.

🖐️ Advanced Object Interaction: A robust grab-and-place system allows users to interact with objects. The system is built on a modular parent-child structure where the parent GameObject holds the XR Grab Interactable logic, while child objects handle the visuals (Mesh Renderer) and physics (Rigidbody and Collider). This separation allows for easy art replacement and optimized physics.

🧩 Stateful Puzzle Mechanics: A "key and lock" puzzle requires users to place specific objects in matching sockets. This is enforced by Interaction Layer Masks on the XR Socket Interactor components, which prevent incorrect solutions and provide clear visual feedback (hover materials) and audio cues.

💾 User-Controlled Session Persistence: A full Save/Load/Reset system allows researchers to manage the simulation state. The SaveManager script serializes a SessionData object containing the position, rotation, and completion status of all puzzle objects to a JSON file.

🖥️ VR-Native UI: All UI elements are built on a World Space Canvas and are fully compatible with VR controllers. The EventSystem uses the XR UI Input Module and Tracked Device Graphic Raycaster to translate controller ray interactions into UI clicks.

🖱️ Hardware-Independent Testing: Developed and tested entirely within the Unity Editor using the XR Device Simulator, allowing for rapid iteration and debugging without requiring a physical VR headset.

🏗️ Architecture Overview
The project follows a modular, event-driven architecture designed for scalability. Core systems are separated to ensure a clean data flow and clear responsibilities.

Player Rig (Input Layer): The XR Origin prefab acts as the user. It translates controller inputs into actions like movement (Teleportation Provider) and interaction (Direct and Ray Interactors).

Scene Systems (Logic Layer): These are the brains of the application. The XR Interaction Manager acts as a central hub for all interactions. The AssistantManager script manages the game state and puzzle logic, while the SaveManager handles all file I/O for persistence.

Interactive Objects (Interaction Layer): These are the "smart" objects in the world. Grab Interactables (spheres) and Socket Interactors (platforms) register with the XR Interaction Manager and fire events when used.

UI & Data (Presentation/Data Layer): The AssistantManager sends updates to the World Space Canvas. When the user saves, the SaveManager writes the state to a saveFile.json.

🚀 Getting Started
Follow these instructions to get the project running on your local machine.

Prerequisites
Unity Hub

Unity 2022.3.48 (LTS) with the Android Build Support module installed.

Ollama: You must have Ollama installed and running on your machine. Ollama serves the LLM that the Unity project will connect to.

LLM Models: You must have at least one of the supported models pulled and available in Ollama.

ollama pull llama3.1:8b

Installation
Clone the repository from GitHub:

git clone https://github.com/iyad-salameh/XR-LLM-Lab.git

Ensure Ollama is running in your terminal with the required model.

Open Unity Hub, click the "Open" button, and navigate to the cloned project folder.

Unity will open the project and automatically import all assets and resolve packages. This may take several minutes.

🎮 Usage
Once the project is open, navigate to the main scene file located at: Assets/Scenes/VRSetup.unity.

Press the Play button at the top of the Unity Editor.

The simulation will start, and the XR Device Simulator will be active. The AI Assistant will connect to your local Ollama instance.

Simulator Controls
Action

Control

Look / Aim Ray

Mouse

Move Player Rig

W, A, S, D

Control Left Hand

Hold Left Shift + Mouse

Control Right Hand

Hold Left Ctrl + Mouse

Grab / Grip Object

Middle Mouse Button

Teleport

Aim at anchor + Press Thumbstick

UI / Keyboard Click

Aim ray + Press Trigger

(Right Trigger)

(Left Mouse Button)

(Left Trigger)

(Right Mouse Button)

📂 Project Structure
A brief overview of the key folders in the project:

/
├── Assets/
│   ├── Scenes/         # Contains the main VRSetup scene
│   ├── Scripts/        # All C# scripts (AssistantManager, SaveManager, etc.)
│   ├── Samples/        # Imported assets from the XR Toolkit and Neocortex
│   └── ...             # Other asset folders (Materials, Prefabs, etc.)
├── Packages/           # Unity Package Manager manifest
└── ProjectSettings/    # All project configuration files

📜 License
This project is licensed under the MIT License. See the LICENSE file for full details.

The MIT License is a permissive free software license originating at the Massachusetts Institute of Technology (MIT). As a permissive license, it puts only very limited restrictions on reuse and has, therefore, high license compatibility. It permits reuse within proprietary software, provided that all copies of the licensed software include a copy of the MIT License terms and the copyright notice.

🤝 Contributing
Please read CONTRIBUTING.md for details on the process for submitting pull requests.

🙏 Acknowledgments
Built with the Unity Engine.

Interaction and locomotion systems are powered by the XR Interaction Toolkit package.

Local LLM functionality is enabled by the Neocortex SDK for Unity.
