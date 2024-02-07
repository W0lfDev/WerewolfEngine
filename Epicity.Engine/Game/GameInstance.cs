using SkiaSharp;
using Werewolf.Engine.Core.LevelStuff;
using Werewolf.Engine.EngineManagement;
using Werewolf.Engine.SplashScreen;

namespace Werewolf.Engine.Game
{
    public class GameInstance : EngineInstance
    {
        public LevelManager? LevelManager;


        public GameInstance() : base("New Epicity!") { }

        public override async void Init()
        {
            Splash.DoDrawSpash = true;

            LevelManager = new LevelManager();
            LevelManager.AttachGameInstance(this);

            GameManager startManager = new GameManager(LevelManager);
            await startManager.AddAllLevels();
            
            GameCamera.Zoom = 1;
            this.editorControls.AttachGameInstance(this);

            BatchLevel batchLevel = new BatchLevel("Test Batch", LevelManager);
            await batchLevel.InitBatch(new string[] { "School", "tes111", "Hello", "HelloWorld" });

            await Task.Delay(2500);
            Splash.DoDrawSpash = false;
            
            await LevelManager.LoadLevel("Test Batch");
        }

        public override void Update(float dt)
        {
            LevelManager?.UpdateSpritesInCurrentLevel(dt);
        }

        public override void Draw(SKCanvas g)
        {
            DebugUI.DrawDiagnostics();
            LevelManager?.DrawLoadingScreen(g);
        }
    }
}
