WebSocket Console Checker (C#)

A menu-driven C# console application for validating and testing WebSocket endpoints.
Designed as a learning-focused project emphasizing clean architecture, async correctness, and incremental refactoring.

Overview:

This application allows users to:
-Select from a registry of known WebSocket endpoints
-Enter and validate custom WebSocket URIs
-Test WebSocket connectivity with timeout handling
-Receive clear success or failure feedback via the console

The project was intentionally structured to demonstrate separation of concerns, async best practices, and defensive input handling in a console-based environment.

Features:
-Interactive main and secondary menus
-Known WebSocket registry
-User-entered WebSocket validation
-Asynchronous WebSocket connection testing
-Timeout-aware connection handling
-Clear, maintainable class responsibilities

Architecture:

The application is organized into the following core components:

Program.cs
-Owns application flow and lifecycle
-Controls menu loops and switch logic
-Coordinates calls between services

MenuService
-Responsible for all menu rendering and user input
-Centralizes console UI logic
-Ensures consistent and validated user selections

WebSocketRegistry
-Maintains a list of known WebSocket endpoints
-Supports indexed selection for user interaction
-Easily extensible for persistence or metadata

WebSocketValidator
-Validates WebSocket URIs (ws:// and wss://)
-Provides clear error messaging for invalid input

WebSocketTester
-Asynchronously tests WebSocket connectivity
-Returns structured results via a result object
-Designed to avoid async anti-patterns

Key Design Decisions:

Async correctness:
Async methods return result objects instead of using out parameters, avoiding common async design errors.

Separation of concerns:
UI logic, validation, networking, and orchestration are strictly separated.

Incremental refactoring:
Functionality was stabilized before refactoring, minimizing regressions and improving clarity.

Learning-first approach:
The project favors clarity and correctness over premature optimization or overengineering.

Requirements:
-.NET 6.0 or later
-Internet access for WebSocket testing

Running the Application:
-Clone the repository
-Open the solution in Visual Studio
-Build and run the console application
-Follow the on-screen menus

Possible Future Enhancements:

These features are intentionally deferred but easy to add given the current structure:
-Persisting known WebSockets to disk
-Retry logic for failed connections
-Configurable timeouts
-Logging or diagnostics
-Unit tests with mocked WebSocket connections
-Enhanced console UX (colors, progress indicators)

Purpose:

This project serves as:
-A learning exercise in async programming and console application design
-A reference for clean menu-driven console architectures
-A foundation for future feature expansion

License:
This project is provided for educational purposes. Stepping into a more casual tone now, please feel free to even fork this code for your own project.

Extra notes:
I struggled a lot when I first learned to code, and I was even slow at understanding what kind of questions I should be asking. By all means, if this can help one other person that is struggling to learn right now, then it's plenty worth staying active on Git. If you have any questions about this project or in general, then please reach out to me. Thank you for taking interest in my code. I'm just another struggler trying to stay afloat in a competitive world.