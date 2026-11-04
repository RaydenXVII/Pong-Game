# Pong

A classic 2D Pong game built in Unity with C#, featuring local two-player gameplay on a single keyboard.

## Features

- Local two-player multiplayer on one keyboard
- Physics-based ball bouncing using Unity's 2D physics and a bouncy physics material
- Score tracking with on-screen score display for each side
- Goal zones that detect when the ball passes a paddle
- Player input handled with Unity's new Input System

## Controls

| Player | Move Up | Move Down |
|--------|---------|-----------|
| Player 1 (left) | `W` | `S` |
| Player 2 (right) | `Up Arrow` | `Down Arrow` |

## Getting Started

### Requirements

- [Unity Hub](https://unity.com/download) and a Unity Editor version that supports the Input System package
- Input System package (installed via Package Manager)

### Run the project

1. Clone the repository:
   ```bash
   git clone https://github.com/RaydenXVII/Pong-Game.git
   ```
2. Open Unity Hub, click **Add** > **Add project from disk**, and select the cloned folder.
3. Open the project with a compatible Unity version.
4. Open `Assets/Scenes/SampleScene.unity`.
5. Press **Play**.

> If Unity asks to enable the new Input System backend, click **Yes** and let the editor restart.

## Project Structure

```
Assets/
├── Materials/
│   └── BouncyMat            # Physics material for ball bounce
├── Prefabs/
│   ├── Goal
│   ├── Player               # Paddle prefab (used by both players)
│   ├── ScoreText
│   └── Wall
├── Scenes/
│   └── SampleScene          # Main game scene
└── Scripts/
    ├── BallController.cs    # Ball movement and behavior
    ├── GameManager.cs       # Tracks and updates scores
    ├── GoalController.cs    # Detects when the ball enters a goal
    ├── PlayerController.cs  # Paddle movement (Player 1 or Player 2)
    └── ScoreTextController.cs  # Displays the score
```

## How It Works

- **PlayerController** reads input from the `PongControls` Input Actions asset. Each paddle has a `Control` setting in the Inspector (`Player1` or `Player2`) that decides which keys move it.
- **GoalController** notifies the **GameManager** when the ball reaches a goal zone, and the manager increments the correct player's score.
- **ScoreTextController** updates the on-screen text for each side.

## Built With

- [Unity](https://unity.com/)
- C#
- Unity Input System
- TextMesh Pro

## Future Improvements

- Win condition (first to a set score)
- Ball speed increase after each paddle hit
- Restart button and main menu
- Optional computer-controlled opponent

## Author

**Randy Deniz Manzarasi**

## License

This project is open source.
