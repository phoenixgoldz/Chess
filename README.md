# Chess Game ♟️

A fully functional chess game built using C#. This project includes core chess mechanics, piece movement validation, and a graphical user interface.

![Chess Game](Chess/images/chess-image.jpg)

## Features 🎮
- ✅ Full implementation of chess rules
- 🎨 Graphical user interface (GUI)
- ⚡ Move validation for all pieces
- 🔄 Turn-based gameplay
- 📌 Game state tracking
- 🔀 **New:** Chess960 game mode

## Installation 🛠️
1. **Clone the Repository**  
   ```sh
   git clone https://github.com/phoenixgoldz/Chess.git
   ```
2. **Open the Project**  
   - Use **Visual Studio** or any C#-compatible IDE to open the solution file.

3. **Build and Run**  
   - Compile and run the project within the IDE.

## New Feature: Chess960 ♟️🎲
- Players can now choose between **Traditional Chess** and **Chess960** before starting a game.
- In **Chess960**, the initial piece setup is randomized according to Chess960 rules.
- All standard chess movement rules apply.
- Castling is currently **disabled** for Chess960.

## Usage 🏆
- Click on a piece to see its available moves.
- Move pieces by selecting the destination square.
- The game follows standard chess rules, including castling and en passant (except in Chess960).
- Choose **Chess960 Mode** from the start menu to play with a randomized starting board.

![Gameplay Preview](https://upload.wikimedia.org/wikipedia/commons/7/7e/ChessAnimation.gif)

## Future Enhancements 🚀
- 🤖 AI opponent for single-player mode
- 🌍 Online multiplayer functionality
- ✨ Improved UI/UX with animations
- 💾 Save and load game state
- 🔬 **Unit Tests:** Additional test cases for Chess960 validation

## Testing ✅
- Added **unit tests** to ensure both **Traditional Chess** and **Chess960** board setups work correctly.
- Implemented multiple tests to validate piece placements and initial board configurations.

## Contributing 🤝
1. Fork the repository.
2. Create a new branch:  
   ```sh
   git checkout -b feature-branch
   ```
3. Commit your changes:  
   ```sh
   git commit -m "Add new feature"
   ```
4. Push to the branch:  
   ```sh
   git push origin feature-branch
   ```
5. Submit a pull request.

## License 📜
This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.

## Contact 📧
For any questions or suggestions, feel free to open an issue or reach out!

![Chess Logo](https://upload.wikimedia.org/wikipedia/commons/thumb/b/bb/Chess_piece_-_King.svg/1024px-Chess_piece_-_King.svg.png)

