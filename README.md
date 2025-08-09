XR Lab Prototype with LLM.
A modular VR prototype for a training and research lab, featuring interactive puzzles and a conversational AI assistant powered by a local Large Language Model (LLM).

<img width="1158" height="742" alt="image" src="https://github.com/user-attachments/assets/4e9f10d7-2f4e-47f0-8973-8fed9685e3ff" />

This project was developed as a technical assessment, demonstrating a robust, scalable, and intuitive VR application built from the ground up in Unity. It showcases core VR mechanics, advanced interaction design, a clean, event-driven architecture, and direct integration with local AI to create a truly dynamic and intelligent training tool.

Features
Conversational AI Assistant (ALISA): _Advanced Laboratory Intelligence System Assistant_ The smart assistant is powered by a locally-run Llama 3.1:8b, Qwen3:8b, and tinyllama models via Ollama and the Neocortex SDK. It provides guidance and answers user questions through an interactive, in-world chat interface, complete with a scrollable history and virtual keyboard input.

Guided Locomotion: A teleportation system using specific anchors guides the user to points of interest, controlling the flow of the training scenario.

Advanced Object Interaction: A robust grab-and-place system allows users to interact with objects. The system is built on a modular parent-child structure that separates logic from visuals for easy art replacement.

Stateful Puzzle Mechanics: A "key and lock" puzzle requires users to place specific objects in matching sockets, with Interaction Layer Masks preventing incorrect solutions.

User-Controlled Session Persistence: A full Save/Load/Reset system allows researchers to manage the simulation state. The exact position, rotation, and completion status of all puzzle objects are saved to a JSON file.

VR-Native UI: All UI elements are fully compatible with VR controllers, using a ray-based interaction model.

Hardware-Independent Testing: Developed and tested entirely within the Unity Editor using the XR Device Simulator.

Getting Started
Follow these instructions to get the project running on your local machine.

Prerequisites
Unity Hub

Unity 2022.3.48 (LTS) with the Android Build Support module installed.

Ollama: You must have Ollama installed and running on your machine.

Llama 3.1 Model: You must have the llama3.1:8b model pulled and available in Ollama. (Command: ollama pull llama3.1:8b)

Installation
Clone the repository from GitHub: git clone https://github.com/iyad-salameh/XR-LLM-Lab.git

Ensure Ollama is running in your terminal with the required model.

Open Unity Hub, click the "Open" button, and navigate to the cloned project folder.

Unity will open the project and automatically import all assets and resolve packages. This may take several minutes.

Usage
Once the project is open, navigate to the main scene file located at: Assets/Scenes/VRSetup.unity.

Press the Play button at the top of the Unity Editor.

The simulation will start, and the XR Device Simulator will be active. The AI Assistant will connect to your local Ollama instance.

Simulator Controls
The primary controls for the XR Device Simulator are as follows:

Look/Aim: Mouse

Move Player Rig: W, A, S, D

Control Left Hand: Hold Left Shift + Move Mouse

Control Right Hand: Hold Left Ctrl + Move Mouse

Grab/Grip Object: Middle Mouse Button

Teleport: Aim at an anchor and press the controller's thumbstick.

UI & Virtual Keyboard Interaction:

Point the controller's ray at a UI element (button, keyboard key).

Press the Trigger button to "click."

(Right Controller Trigger: Left Mouse Button / Left Controller Trigger: Right Mouse Button)

License
This project is licensed under the MIT License. See the LICENSE file for full details.

The MIT License is a permissive free software license originating at the Massachusetts Institute of Technology (MIT). As a permissive license, it puts only very limited restrictions on reuse and has, therefore, high license compatibility. It permits reuse within proprietary software, provided that all copies of the licensed software include a copy of the MIT License terms and the copyright notice.

Contributing
Please read CONTRIBUTING.md for details on the process for submitting pull requests.

Acknowledgments
Built with the Unity Engine.

Interaction and locomotion systems are powered by the XR Interaction Toolkit package.

Local LLM functionality is enabled by the Neocortex SDK for Unity.
