using Werewolf.Engine.Maths;

namespace Werewolf.Engine
{
    public class AnimatedSprite2D : Sprite2D
    {
        internal List<string> ImageNames = new List<string>();
        internal List<SpriteImage> Images = new List<SpriteImage>();

        public bool IsPlaying {  get; private set; }
        private Thread AnimationThread;
        public float AnimationSpeed;

        public bool PlayOnStart = true;

        private float InitialAnimSpeed;
        internal int loopN;

        public AnimatedSprite2D(Vector2<float> position, List<string> imageNames, float speed = 1, float scale = 1, string name = "Default", int layer = 0) : base(position, imageNames[0], scale, name, layer)
        {
            this.ImageNames = imageNames;
            this.AnimationSpeed = speed;

            this.InitialAnimSpeed = AnimationSpeed;
        }

        public override async Task CustomInit()
        {
            foreach (string name in ImageNames)
            {
                SpriteImage temp = await ImageManager.GetSpriteImageFromImageName(name);
                Images.Add(temp);
            }

            if (PlayOnStart)
                Play();
        }

        public override void CustomDisable()
        {
            Stop();
        }

        public override void CustomReset()
        {
            if (PlayOnStart)
                Play();

            AnimationSpeed = InitialAnimSpeed;
        }

        public void Play(bool loop = true, bool hideAfterFinished = false)
        {
            if (IsPlaying)
                return;

            base.Enable();

            AnimationSpeed = InitialAnimSpeed;
            IsPlaying = true;

            AnimationThread = new Thread(() =>
            {
                int n = 0;
                List<SpriteImage> imagesCopy = new List<SpriteImage>();

                while(IsPlaying)
                {
                    imagesCopy.Clear();
                    imagesCopy = new List<SpriteImage>(Images);

                    foreach (SpriteImage img in imagesCopy)
                    {
                        if (loop == false)
                        {
                            n++;
                            if (n >= (imagesCopy.Count / 2 + 1) * loopN)
                            {
                                n = 0;

                                Stop(hideAfterFinished);
                                this.IsVisible = false;
                                break;
                            }
                        }

                        try
                        {
                            this.AttachImageFromImage(img);
                            try
                            {
                                if (AnimationSpeed <= 0)
                                    AnimationSpeed = 1;

                                Thread.Sleep((int)(100.0f / AnimationSpeed));
                            }
                            catch
                            {
                                Debug.Warning("Failed to delay animation!");
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Error("Error while performing animation! Exception: " + ex);

                            IsPlaying = false;
                            break;
                        }
                    }
                }
            });
            AnimationThread.Start();
        }

        public void Stop(bool hide = false)
        {
            if (!IsPlaying)
                return;

            IsPlaying = false;

            if (hide)
            {
                base.Disable();
            }
        }
    }
}
