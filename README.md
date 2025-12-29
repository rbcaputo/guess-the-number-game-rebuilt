# Guess the Number - Architecture Evolution Showcase

## 📖 The Story

This project represents my journey as a developer.

**Original version (2022):** My very first programming project - a simple number guessing game built with vanilla HTML/CSS/JavaScript. Basic structure, procedural code.

**Rebuilt version (2025):** The same game, reimagined with everything I've learned about software architecture in the past 3 years.

[Link to original version - Archived](https://github.com/rbcaputo/guess-the-number-game)

## 🎯 What Changed

| Aspect | Original(2022) | Rebuilt(2025) |
|--------|----------------|---------------|
| **Language** | JavaScript | C#/.NET 8 |
| **UI** | HTML/CSS | Avalonia (cross-platform XAML) |
| **Architecture** | Basic structure, no clear separation | Clean architecture, MVVM |
| ** Testing** | None | xUnit with 15+ tests |
| **Code quality** | Procedural, global state | OOP, immutable data, encapsulation |
| **Patterns** | None | Command, observer, DI |

## 🛠️ Tech Stack

* **.NET 8** - Latest LTS framework
* **C# 12** - Modern language features (primary constructors, records, nullable reference types)
* **Avalonia UI 11.3** - Cross-platform XAML framework (works on Windows, macOS, Linux)
* **xUnit + FluentAssertions** - Testing framework with expressive assertions
* **CommunityToolkit.Mvvm** - MVVM helpers and base classes

## 🏗️ Project Structure

```
GuessTheNumber/
├── GuessTheNumber.Engine/   # Domain logic (pure C#, no UI dependencies)
│   ├── Game.cs              # Game orchestrator
│   ├── Match.cs             # Single match logic
│   ├── Score.cs             # Score tracking
│   ├── Settings.cs          # Game configuration
│   └── Result.cs            # Result enumeration
├── GuessTheNumber.App/      # Avalonia UI (MVVM)
│   ├── ViewModels/          # ViewModels (presentation logic)
│   ├── Views/               # XAML views (UI)
│   └── Commands/            # Command implementations
└── GuessTheNumber.Tests/    # Unit tests
    ├── GameTests.cs
    ├── MatchTests.cs
    ├── ScoreTests.cs
    └── SettingsTests.cs
```

## ✨ Features

**Game Mechanics:**

* Configurable number range (default 1-9)
* Configurable difficulty (number of chances)
* Real-time feedback on guesses
* Score tracking (Player vs CPU)
* Settings persistence across matches

**UI/UX:**

* Smooth color-coded feedback (Green = correct, Red = incorrect, Yellow = already tried, Orange = invalid)
* Animated transitions
* Keyboard navigation (Tab order, Enter to guess)
* Auto-focus input after each guess
* Custom settings dialog
 
**Code Quality:**

* 100% test coverage on domain logic
* Immutable configuration objects
* Null-safe code (nullable reference types enabled)
* Defensive input validation
* SOLID principles applied

## 🧪 What I Learned

**Architecture:**

* Separating domain logic from presentation allows the engine to be reused (console app, web API, mobile app, etc.)
* MVVM makes UI code testable and maintainable
* Clean architecture prevents UI concearns from leaking into business logic
 
**C# & .NET:**

* Modern C# features improve code clarity (records for immutable data, primary constructors for concise class definitions)
* Avalonia's XAML is similar to WPF but cross-platform
* Proper dependency management (Engine has zero dependencies, App depends on Engine)

**Testing:**

* Writing tests first forces better design (testable code = well-structured code)
* FluentAssertions makes tests readable as documentation
* Seeded random numbers make non-deterministic code testable
 
**Design Patterns:**

* Command pattern decouples UI actions from logic
* Observer pattern (`INotifyPropertyChanged`) enables reactive UI
* Factory pattern (Match creation) encapsulates complexity
 
## 🚀 Running the Project

**Prerequisites:**
* .NET 8 SDK
 
**Steps:**
```bash
#Clone the repository
git clone https://](https://github.com/rbcaputo/GuessTheNumber.git
cd GuessTheNumber

# Run the application
dotnet run --project GuessTheNumber.App

# Run tests
dotnet test
```

**Or download the pre-built Windows x64 executable:** [Releases](https://github.com/rbcaputo/GuessTheNumber/releases)

## 📸 Screenshots

[Main window](https://github.com/rbcaputo/guess-the-number-game-rebuilt/blob/main/Screenshots/gtn-main-window.png) [Settings window](https://github.com/rbcaputo/guess-the-number-game-rebuilt/blob/main/Screenshots/gtn-settings-window.png) [Win game window](https://github.com/rbcaputo/guess-the-number-game-rebuilt/blob/main/Screenshots/gtn-wingame-window.png)
  
## 🔮 Possible Future Enhancements

* [ ] Add difficulty presets (Easy, Medium, Hard)
* [ ] Leaderboard with local high scores
* [ ] Multiplayer mode (hot-seat)
* [ ] Sound effects and music
* [ ] Themes (dark mode, custom colors)
* [ ] Deploy as WebAssembly (Avalonia supports WASM)

## 📚 Key Takeaways

This project demonstrates that software architecture matters even for simple problems. The original version worked, but it was fragile and unmaintainable. The rebuilt version is:

* **Testable** (15+ unit tests)
* **Extensible** (easy to add features without breaking existing code)
* **Maintainable** (clear structure, separation of concerns)
* **Reusable** (engine can power different UIs)

**The complexity didn't increase. The structure improved.**

---

**Original version (2022):** [Link to original version - Archived](https://github.com/rbcaputo/guess-the-number-game)

**Contact:** [LinkedIn](https://linkedin.com/in/rbcaputo) | [GitHub](https://github.com/rbcaputo)
