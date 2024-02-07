using SkiaSharp;
using Werewolf.Engine.EngineManagement;

namespace Werewolf.Engine
{
    public class SpriteImage
    {
        public SKBitmap Bitmap { get; set; }
        public string Name { get; set; }
        public int Width, Height;

        public SpriteImage(SKBitmap bitmap, string name)
        {
            this.Bitmap = bitmap;
            this.Name = name;

            Width = bitmap.Width;
            Height = bitmap.Height;
        }
        public SpriteImage() { }
    }

    public class ImageManager
    {
        public static List<SpriteImage> images = new List<SpriteImage>();

        public static async Task<SpriteImage> GetSpriteImageFromImageName(string imageName)
        {
            SpriteImage? searchImage = SearchForImageByName(imageName);
            if (searchImage == null)
            {
                searchImage = await LoadImage(imageName);
                return searchImage;
            }

            return searchImage;
        }

        private static async Task<SpriteImage> LoadImage(string imageName)
        {
            SpriteImage? image = SearchForImageByName(imageName);
            if (image != null)
                return image;

            SKBitmap? temp = new SKBitmap(1, 1);

            try
            {
                string fullDir = $@"{EngineInstance.MainDirectory}\IMAGE\{imageName}.png";
                temp = await Task.Run(() => SKBitmap.Decode(fullDir));
            }
            catch (Exception ex)
            {
                Debug.Error($"Failed to load IMAGE: {imageName} \n{ex.Message}");
            }

            SpriteImage img = new SpriteImage(temp, imageName);
            images.Add(img);

            return img;
        }

        private static SpriteImage SearchForImageByName(string name)
        {
            foreach (var image in images)
            {
                if (image.Name == name)
                    return image;
            }

            return null;
        }
    }
}
