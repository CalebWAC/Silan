namespace Silan;

class ImportManager {
    public void AddLibrary(string lib) {
        switch (lib) {
            case "game": case "game;":
                Game.IsActive = true;
                break;
        }
    }
}