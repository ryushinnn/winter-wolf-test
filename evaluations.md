# Evaluations
### Advantages
- Divide related scripts into folders logically, making it easy to find the necessary script
- Straightforward logic, maintainers can quickly understand the code flow
- Logic between gameplay and UI is separated
- State transitions are event-driven designed, reducing coupling between classes

### Disadvantages
- Lots of pressure on GC due to lack of gameobject reuse and overuse of LingQ
- "Cell" and "Item" are tightly coupled. "Item" shouldn't have a reference of "Cell"
- Some classes (e.g. GameManager) have to pass their reference when initialize other things, while they can be implemented as a singleton
- Storing each neighbor individually is not a good practice. Instead use a Dictionary<Direction,Cell> to store neighbors
- "LevelMoves" and "LevelTime" inherit from "LevelCondition", but "LevelCondition" has 2 separate setup functions for its 2 children, this is a non-sense inheritance
- Multiple prefabs that are almost identical (normalItem prefabs), while using one is enough
- One canvas for all UIs
- Input handling is in BoardController, it should be separated into a separate class
