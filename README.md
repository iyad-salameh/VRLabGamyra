VR Lab Prototype for Gamyra
A modular VR prototype for a training and research lab, featuring interactive puzzles, a stateful smart assistant, and a user-controlled session persistence system.

This project was developed as a technical assessment for Gamyra, demonstrating a robust, scalable, and intuitive VR application built from the ground up in Unity. It showcases core VR mechanics, advanced interaction design, and a clean, event-driven architecture.

Features
Guided Locomotion: A teleportation system using specific anchors guides the user to points of interest, controlling the flow of the training scenario.

Advanced Object Interaction: A robust grab-and-place system allows users to interact with objects. The system is built on a modular parent-child structure that separates logic from visuals for easy art replacement.

Stateful Puzzle Mechanics: A "key and lock" puzzle requires users to place specific objects in matching sockets, with Interaction Layer Masks preventing incorrect solutions.

Smart Assistant UI: A dynamic, world-space UI panel provides instructions and feedback to the user, acting as a smart assistant.

Event-Driven Logic: The assistant's guidance is not hard-coded; it reacts to user actions in real-time by listening to events fired from interactive objects (e.g., the sockets).

User-Controlled Session Persistence: A full Save/Load/Reset system allows researchers to manage the simulation state. The exact position, rotation, and completion status of all puzzle objects are saved to a JSON file and can be reloaded on demand or automatically at startup.

VR-Native UI: All UI elements are fully compatible with VR controllers, using a ray-based interaction model.

Hardware-Independent Testing: Developed and tested entirely within the Unity Editor using the XR Device Simulator, ensuring rapid iteration and functionality without requiring a physical VR headset.

Getting Started
Follow these instructions to get the project running on your local machine for development and testing purposes.

Prerequisites
Unity Hub

Unity 2022.3.48 (LTS) with the Android Build Support module installed.

Installation
Download the provided .zip file of the project from the shared Google Drive.

Unzip the folder to your desired location.

Open Unity Hub, click the "Open" button, and navigate to the unzipped project folder to add it to your projects list.

Unity will open the project and automatically import all assets and resolve all packages. This may take several minutes.

Usage
Once the project is open, navigate to the main scene file located at: Assets/Scenes/VRSetup.unity.

Press the Play button at the top of the Unity Editor.

The simulation will start in the Game view, and the XR Device Simulator will be active, allowing you to control the VR rig with your keyboard and mouse.

Examples (Simulator Controls)
The primary controls for the XR Device Simulator are as follows:

Look/Aim: Mouse

Move Player Rig: W, A, S, D

Control Left Hand: Hold Left Shift + Move Mouse

Control Right Hand: Hold Left Ctrl + Move Mouse

Grab/Grip Object: Middle Mouse Button

Click UI Button: Trigger (Left Mouse Button for right hand, Right Mouse Button for left hand)

Teleport: Aim at an anchor and press the controller's thumbstick.

License
This project is licensed under the MIT License. See the LICENSE file for full details.

The MIT License is a permissive free software license originating at the Massachusetts Institute of Technology (MIT). As a permissive license, it puts only very limited restrictions on reuse and has, therefore, high license compatibility. It permits reuse within proprietary software, provided that all copies of the licensed software include a copy of the MIT License terms and the copyright notice.
