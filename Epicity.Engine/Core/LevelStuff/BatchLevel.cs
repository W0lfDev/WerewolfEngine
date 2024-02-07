using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Engine.Core.LevelStuff
{
    public class BatchLevel : Level
    {
        private List<Level> levelsInBatch = new List<Level>();
        private List<AnimatedSprite2D> spritesInBatch = new List<AnimatedSprite2D>();

        private LevelManager levelManager;

        string[] levelsNames;

        public BatchLevel(string name, LevelManager levelManager) : base(name, levelManager)
        {
            this.levelManager = levelManager;
        }

        public async Task InitBatch(string[] names = null)
        {
            if (names != null)
            {
                this.levelsNames = names;
            }

            // Clear lists
            levelsInBatch.Clear();
            spritesInBatch.Clear();

            // Get levels in batch
            foreach (var name in levelsNames)
            {
                foreach (var level in levelManager.GetLevels())
                {
                    if (name == level.Name)
                    {
                        levelsInBatch.Add(level);
                    }
                }
            }

            // Get sprites from levels
            foreach (var level in levelsInBatch)
            {
                spritesInBatch.AddRange(level.Sprites);
            }

            // Add all sprites to batch
            foreach (var sprite in spritesInBatch)
            {
                base.AddSprite(sprite);
            }
        }
    }
}
