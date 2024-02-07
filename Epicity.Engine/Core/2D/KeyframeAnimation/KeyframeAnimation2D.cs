using Werewolf.Engine.EngineManagement;
using Werewolf.Engine.Maths;

namespace Werewolf.Engine
{
    public class Keyframe
    {
        public float Time;

        public Vector2<float> KeyframePos;
        public bool ChangePos;

        public Vector2<float> KeyframeSize;
        public bool ChangeSize;

        public bool KeyframeVisible;
    
        public Keyframe(float time, Vector2<float> keyframePos, Vector2<float> keyframeSize, bool keyframeVisible)
        {
            Time = time;
            KeyframePos = keyframePos;
            KeyframeSize = keyframeSize;
            KeyframeVisible = keyframeVisible;
        }

        public void SetChanged(bool changePos, bool changeSize)
        {
            ChangePos = changePos;
            ChangeSize = changeSize;
        }
    }

    public class KeyframeAnimation2D
    {
        public string Name;
        public List<Keyframe> Keyframes = new List<Keyframe>();

        private Sprite2D ownerSprite;
        private bool IsPlaying = false;

        public KeyframeAnimation2D(Sprite2D owner) => ownerSprite = owner;

        public void AddKeyframe(Keyframe keyframe) => Keyframes.Add(keyframe);
        public void RemoveKeyframe(Keyframe keyframe) => Keyframes.Remove(keyframe);

        public async void LoadAnimation(string name)
        {
            if (name == "" || name == null)
                return;

            this.Name = name;;

            string fullPath = EngineInstance.MainDirectory + $@"\ANIMATION\{name}";
            string[] data = await File.ReadAllLinesAsync(fullPath);

            foreach (string line in data)
            {
                string[] lineData = line.Split('|');
                Keyframe currentKeyframe = new Keyframe(
                    float.Parse(lineData[0]),
                    new Vector2<float>(float.Parse(lineData[3]), float.Parse(lineData[4])),
                    new Vector2<float>(float.Parse(lineData[5]), float.Parse(lineData[6])),
                    bool.Parse(lineData[7])
                );
                currentKeyframe.SetChanged(bool.Parse(lineData[1]), bool.Parse(lineData[2]));

                AddKeyframe(currentKeyframe);
            }
        }

        public async Task Play(bool loop)
        {
            if (IsPlaying) return;
            IsPlaying = true;

            if (loop)
            {
                while (true)
                {
                    await Run();
                }
            }
            else
            {
                await Run();
            }
        }

        public void Stop()
        {
            if (!IsPlaying) return;
            IsPlaying = false;
        }

        private async Task Run()
        {
            foreach (Keyframe keyframe in Keyframes)
            {
                float elapsed = 0;
                float duration = keyframe.Time / 1000.0f; // To milliseconds

                Vector2<float> startPos = ownerSprite.Position.Copy();
                Vector2<float> targetPos = keyframe.KeyframePos.Copy();

                Vector2<float> startSize = ownerSprite.Size.Copy();
                Vector2<float> targetSize = keyframe.KeyframeSize.Copy();

                while (elapsed < duration)
                {
                    float lerpFactor = elapsed / duration;

                    if (keyframe.ChangePos) ownerSprite.Position = GameMath.Lerp(startPos, targetPos, lerpFactor);
                    if (keyframe.ChangeSize) ownerSprite.Size = GameMath.Lerp(startSize, targetSize, lerpFactor);
                    ownerSprite.IsVisible = keyframe.KeyframeVisible;

                    await Task.Delay((int)(EngineInstance.DeltaTime * 1000.0));
                    elapsed += (float)EngineInstance.DeltaTime;
                }
            }

            Stop();
        }
    }
}
