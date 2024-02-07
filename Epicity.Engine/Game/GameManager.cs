using Werewolf.Engine.Core.LevelStuff;
using Werewolf.Engine.EngineManagement;

namespace Werewolf.Engine.Game
{
    public class GameManager
    {
        public LevelManager lvManager;

        public GameManager(LevelManager levelManager)
        {
            this.lvManager = levelManager;
        }

        public async Task AddAllLevels()
        {
            string dir = EngineInstance.MainDirectory + @"\LEVEL";

            await AddSignleLevels(dir);
            await AddBatchLevels(dir);
        }

        private async Task AddSignleLevels(string dir)
        {
            string[] levelFiles = Directory.GetFiles(dir, $"*.lvdata");
            foreach (string path in levelFiles)
            {
                string pathNameWithExt = Path.GetFileNameWithoutExtension(path + ".lvdata");
                string pathName = Path.GetFileNameWithoutExtension(pathNameWithExt);

                Level lvl = new Level(pathName, lvManager);
                await lvl.LoadLevelSprites(pathNameWithExt);
            }

            string[] tilemapFiles = Directory.GetFiles(dir, $"*.tmdata");
            foreach (string path in tilemapFiles)
            {
                string pathNameWithExt = Path.GetFileNameWithoutExtension(path + ".tmdata");
                string pathName = Path.GetFileNameWithoutExtension(pathNameWithExt);
                new Tilemap(pathName, pathNameWithExt, lvManager);
            }
        }

        private async Task AddBatchLevels(string dir)
        {
            string[] batchFiles = Directory.GetFiles(dir, $"*.lvbdata");
            foreach (string path in batchFiles)
            {
                string pathNameWithExt = Path.GetFileNameWithoutExtension(path + ".lvbdata");
                string pathName = Path.GetFileNameWithoutExtension(pathNameWithExt);

                string[] levelData = File.ReadAllText(@$"{dir}\{pathNameWithExt}").Split("|");

                BatchLevel batchLevel = new BatchLevel(pathName, lvManager);
                await batchLevel.InitBatch(levelData);
            }
        }
    }
}
