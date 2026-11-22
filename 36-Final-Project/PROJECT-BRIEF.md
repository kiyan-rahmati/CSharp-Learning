# Final Project: Console Task Manager

Build a command-line task manager that combines the concepts from this course. Work incrementally; do not try to write the whole application in one sitting.

## Required features

1. Add a task with a title and optional description.
2. List all tasks and show their completion state.
3. Mark a task completed or reopen it.
4. Delete a task after validating its ID.
5. Search tasks by title.
6. Save tasks to a JSON file and load them on startup.
7. Validate input and show friendly errors.
8. Keep responsibilities separated into model, service, and persistence classes.
9. Use collections, LINQ, methods, interfaces, and dependency injection where appropriate.
10. Include tests for important behavior and edge cases.

## Suggested design

- `TaskItem`: task data (ID, title, description, completion status, creation time).
- `ITaskRepository`: persistence contract.
- `JsonTaskRepository`: load/save task data to JSON.
- `TaskService`: business rules and task operations.
- `ConsoleMenu`: input/output and menu loop.

You may initially keep the project in a single console file, then refactor it as the course advances. The goal is to understand each refactor, not to create architecture for its own sake.

## Suggested milestones

- Milestone 1: menu and in-memory list (Lessons 1–15)
- Milestone 2: search, filtering, and ordering (Lessons 16–20, 27–30)
- Milestone 3: classes and clean domain rules (Lessons 21–25, 33–34)
- Milestone 4: JSON persistence and error handling (Lessons 26, 31)
- Milestone 5: async-aware improvements, tests, and cleanup (Lessons 32, 35)

## Acceptance checklist

- [ ] Menu handles invalid input without crashing.
- [ ] IDs are unique and stable.
- [ ] Task titles cannot be blank.
- [ ] CRUD operations work.
- [ ] Search returns correct matches.
- [ ] Data survives restarting the application.
- [ ] JSON errors are handled with a useful message.
- [ ] Code is organized and readable.
- [ ] Tests cover success and failure cases.
- [ ] README explains setup, usage, and design.
