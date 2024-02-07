using Werewolf.Engine.Editor;
using Werewolf.Engine.EngineManagement;
using Werewolf.Engine.Maths;

namespace Werewolf.Engine
{
    public class Tilemap : Level
    {
        private string TilemapName;
        private string Filename;
        private float Scale;
        private float Size;

        public Tilemap(string name, string tilemapFilename, LevelManager levelManager) : base(name, levelManager)
        {
            this.TilemapName = name;
            this.Filename = tilemapFilename;

            Init();
        }

        /// <summary>
        /// This is called automatically in the constructor.
        /// </summary>
        public void Init()
        {
            int x = 0; int y = 0;

            Task load = new Task(async () =>
            {
                try
                {
                    List<string> tilemapData = File.ReadAllLines(Path.Combine(EngineInstance.MainDirectory, "LEVEL", $"{Filename}")).ToList();

                    // Set size data
                    this.Scale = float.Parse(tilemapData[0]);
                    this.Size = float.Parse(tilemapData[1]);
                    tilemapData.RemoveAt(0);
                    tilemapData.RemoveAt(0);

                    // Load Tileset Data
                    Tileset.LoadFromTilesetData();

                    Dictionary<string, Tile> tilesetData = new Dictionary<string, Tile>();
                    foreach (Tile tile in Tileset.GetTiles())
                    {
                        tilesetData.Add(tile.AssociatedChar, tile);
                    }

                    foreach (string line in tilemapData)
                    {
                        // Load sprites
                        string[] tilemapChars = line.Trim().Split('|');
                        foreach (string tilemapChar in tilemapChars)
                        {
                            LoadSprites(tilemapChar, x, y, tilesetData);
                            x++;
                        }
                        x = 0;
                        y++;
                    }
                }
                catch (Exception ex)
                {
                    Debug.Error($"Failed to initialize tilemap [{TilemapName}]: " + ex);
                }
            });
            load.Start();
            load.Wait();

            this.Name = this.TilemapName;
        }

        public async void ReInit()
        {
            Task reinit = new Task(() =>
            {
                Sprites.Clear();
                Init();
            });
            reinit.Start();
            reinit.Wait();
        }
        
        private void LoadSprites(string associatedChar, int x, int y, Dictionary<string, Tile> tileData)
        {
            if (associatedChar == "0")
                return;
            
            try
            {
                Tile tile = tileData[associatedChar];

                Vector2<float> position = new Vector2<float>(x * Size * Scale, y * Size * Scale);

                List<string> imageNames = new List<string>();
                foreach (string imagePath in tile.ImagePaths)
                {
                    imageNames.Add(Path.GetFileNameWithoutExtension(imagePath));
                }

                AnimatedSprite2D sprite = new AnimatedSprite2D(position, imageNames, 1, Scale, tile.Name, 0);
                if (imageNames.Count <= 1)
                {
                    sprite.PlayOnStart = false;
                }
                sprite.DoCollision = tile.DoCollision;
                
                if (tile.AttachedScriptName != "")
                    sprite.AttachScript(tile.AttachedScriptName);

                AddSprite(sprite);
            }
            catch (Exception ex)
            {
                Debug.Error("Error while loading sprites from tilemap! Exception: " + ex);
            }
        }
    }
}
