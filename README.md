
# Unity-Max MSP UDP Communication Project

This Unity project establishes a bi-directional communication channel between Unity and Max MSP using the UDP protocol. The system allows for interactive audio-visual experiences where actions in Unity can trigger sound events in Max MSP, and data from Max MSP can control elements within the Unity scene.

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Requirements](#requirements)
- [Setup and Installation](#setup-and-installation)
- [How It Works](#how-it-works)
- [Usage](#usage)
- [File Descriptions](#file-descriptions)
- [Acknowledgements](#acknowledgements)
- [Pictures](#pictures)
- [Youtube](#youtube)


## Overview
This project connects Unity and Max MSP to create an interactive experience. A player entering a specific area in the Unity scene triggers a drum sound in Max MSP. Conversely, the state of a light source in Unity can be controlled directly from Max MSP.

## Features
- **UDP Communication**: Bi-directional UDP communication between Unity and Max MSP.
- **Interactive Audio**: Trigger drum sounds in Max MSP when the player interacts with objects in Unity.
- **Light Control**: Control a light source in Unity from Max MSP based on incoming UDP messages.
- **OSC Messaging**: Use OSC (Open Sound Control) within Unity to send trigger signals to Max MSP.

## Requirements
- Unity 2020.3 or later
- Max MSP 8 or later
- OscJack (OSC Library for Unity) [GitHub Link](https://github.com/keijiro/OscJack)
- Basic knowledge of C# scripting in Unity
- Basic knowledge of Max MSP patching

## Setup and Installation
1. **Clone the Repository**:

2. **Unity Project**:
    - Open the project in Unity.
    - Ensure the `UdpReceiver`, `OscSenderBang`, and `CollisionHandler` scripts are correctly attached to the respective GameObjects in the scene.
    - Set up the GameObjects with the appropriate tags and components as needed (e.g., the `Player` tag for the trigger detection).

3. **Max MSP**:
    - Open the Max MSP patch provided in the repository (`max_msp_patch.maxpat`).
    - Ensure the UDP receive block is set to listen on the correct port (8000 by default).
    - Adjust the patch as needed to respond to the OSC messages sent from Unity.

4. **Run the Project**:
    - Start the Unity scene.
    - Ensure that Max MSP is running the patch and listening on the correct UDP port.
    - Interact with the Unity scene to observe the interaction between Unity and Max MSP.

## How It Works
- **Collision Detection**: When the player enters the collider, the `CollisionHandler` script triggers an OSC message using the `OscSenderBang` script, which sends a "bang" to Max MSP.
- **Sound Trigger**: Max MSP receives this message and plays a drum sound.
- **Light Control**: Max MSP can send UDP messages back to Unity, which the `UdpReceiver` script listens for, toggling the light in the Unity scene based on the message content.

## Usage
- **Customizing Triggers**: Modify the `CollisionHandler` script to change which objects or events in Unity will trigger the OSC messages.
- **Adjusting Light Control**: Update the logic in the `UdpReceiver` script to change how the light or other objects in Unity are controlled via Max MSP.

## File Descriptions
- **Assets/Scripts/UdpReceiver.cs**: Handles receiving UDP messages from Max MSP and controls the light in Unity.
- **Assets/Scripts/OscSenderBang.cs**: Sends OSC messages from Unity to Max MSP to trigger events like playing a drum sound.
- **Assets/Scripts/CollisionHandler.cs**: Detects when the player enters or exits a collider and sends corresponding OSC messages.
- **Max MSP Patch**: A Max MSP patch that listens for OSC messages and plays a drum sound or sends light control messages to Unity.

## Acknowledgements

A special thanks to the [Andrew Robinson Youtube channel](https://www.youtube.com/watch?v=j1ySd99uXkM&t=347s) for their invaluable tutorials and guidance. Their content played a significant role in helping to create and refine this project.

## Pictures

![Unity to Maxmsp](image.png)

![Maxmsp to unity](image-1.png)

![Maxmsp](image-2.png)

## Youtube

[Watch this demo video](https://youtu.be/KyeJXhVzv0g)