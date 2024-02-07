using Werewolf.Engine;
using Werewolf.Engine.EngineManagement;

namespace Werewolf.Engine
{
    public class Level
    {
        public string Name;
        public List<AnimatedSprite2D> Sprites = new List<AnimatedSprite2D>();

        public Level(string name, LevelManager levelManager)
        {
            this.Name = name;
            levelManager.AddLevel(this);
        }

        public void AddSprite(AnimatedSprite2D sprite)
        {
            Sprites.Add(sprite);
        }

        public void AddSpriteRuntime(AnimatedSprite2D sprite)
        {
            AddSprite(sprite);
            EngineInstance.AddSprite(sprite);
        }

        public void RemoveSprite(AnimatedSprite2D sprite)
        {
            Sprites.Remove(sprite);
            sprite.Disable();
        }

        public async Task ReloadLevel()
        {
            await Task.Run(async () =>
            {
                Sprites.Clear();
                await LoadLevelSprites(Name);
            });
        }

        public async Task LoadLevelSprites(string pathName)
        {
            await Task.Run(() =>
            {
                string fullPath = EngineInstance.MainDirectory + $@"\LEVEL\{pathName}";
                string[] dataLines = File.ReadAllLines(fullPath);

                foreach (string line in dataLines)
                {
                    string[] lineData = line.Split('|');

                    List<string> imageNames = new List<string>();
                    foreach (string imgName in lineData[1].Split("~"))
                    {
                        if (imgName == "" || imgName == null)
                            continue;

                        imageNames.Add(Path.GetFileNameWithoutExtension(imgName));
                    }

                    AnimatedSprite2D sp = new AnimatedSprite2D(
                        new Maths.Vector2<float>(float.Parse(lineData[2]), float.Parse(lineData[3])),
                        imageNames, float.Parse(lineData[5]), float.Parse(lineData[4]), lineData[0], int.Parse(lineData[6])
                    );

                    sp.DoCollision = bool.Parse(lineData[7]);
                    sp.IsVisible = bool.Parse(lineData[8]);
                
                    if (lineData[9] != "")
                        sp.AttachScript(lineData[9]);
                
                    sp.KeyframeAnimator.LoadAnimation(lineData[10]);

                    AddSprite(sp);
                }
            });
        }

        public async Task Load(LevelManager levelManager, bool isReload = false)
        {
            try
            {
                Debug.Log($"Level [{Name}] loading...");

                levelManager.Status = "Sorting";
                var SortedSprites = Sprites.OrderBy(sprite => sprite.Layer).ToList();

                Sprites = SortedSprites;

                levelManager.Status = "Initializing";
                foreach (Sprite2D sprite in Sprites)
                {
                    if (sprite.IsInit)
                        continue;

                    await sprite.Init();
                }

                if (isReload)
                    EngineInstance.ClearSprites();

                levelManager.Status = "Loading";
                await Task.Run(async () =>
                {
                    foreach (Sprite2D sprite in Sprites)
                    {
                        EngineInstance.AddSprite(sprite);
                    }
                    await Task.Delay(250);
                });
            }
            catch (Exception ex)
            {
                Debug.Error($"Error while loading level! Exception: {ex}");
            }
        }

        public async Task Unload()
        {
            for (int i = Sprites.Count - 1; i >= 0; i--)
            {
                Sprites.RemoveAt(i);

                if ((i + 1) % ((float)Sprites.Count / 1000f) == 0)
                    await Task.Delay(1);
            }
        }

        public void UpdateSpritesInLevel(float dt)
        {
            foreach (Sprite2D sprite in Sprites)
            {
                try
                {
                    sprite.UpdateSprite(dt);
                }
                catch
                {
                    Debug.Warning("Failed to update sprite!");
                }
            }
        }

        public async Task Dispose()
        {
            await Task.Run(async () =>
            {
                await Unload();
            });
        }
    }
}
