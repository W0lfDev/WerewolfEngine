using Werewolf.Engine.EngineManagement;

namespace Werewolf.Engine.Editor
{
    public class Tile
    {
        public string Name;
        public int Width, Height;
        public string AssociatedChar;
        public bool DoCollision;

        public List<Image> TileImages;
        public List<string> ImagePaths;

        public Image PreviewImage;
        public Size PreviewSize;
        public Size PreviewSizeSmall;

        public string AttachedScriptName;

        public Tile(string name, int width, int height, string assChar, List<Image> imgs, List<string> imagePaths, string scriptName, bool hasCollider)
        {
            this.Name = name;
            this.Width = width;
            this.Height = height;
            this.AssociatedChar = assChar;
            this.TileImages = imgs;
            this.ImagePaths = imagePaths;
            this.AttachedScriptName = scriptName;
            this.DoCollision = hasCollider;

            this.PreviewSize = new Size(192, 192);
            this.PreviewSizeSmall = new Size(128, 128);

            int totalWidth = 0;
            int maxHeight = 0;

            foreach (Image img in TileImages)
            {
                totalWidth += img.Width;
                maxHeight = Math.Max(maxHeight, img.Height);
            }

            Bitmap compositeImage = new Bitmap(totalWidth, maxHeight);
            using (Graphics g = Graphics.FromImage(compositeImage))
            {
                int x = 0;

                foreach (Image img in TileImages)
                {
                    g.DrawImage(img, x, 0);
                    x += img.Width;
                }
            }

            PreviewImage = compositeImage;
        }

        public Bitmap GetImageSized(Size desiredSize, int index)
        {
            return new Bitmap(TileImages[index], desiredSize);
        }
    }

    public class TileControl : FlowLayoutPanel
    {
        public Tile AssignedTile;

        public void Create(Tile tile)
        {
            this.AssignedTile = tile;

            this.Size = new Size(AssignedTile.PreviewSize.Width, AssignedTile.PreviewSizeSmall.Height);
            this.BackColor = Color.FromArgb(55, 55, 55);
            this.FlowDirection = FlowDirection.TopDown;
            this.WrapContents = true;

            PictureBox previewImage = new PictureBox();
            previewImage.Size = AssignedTile.PreviewSizeSmall;
            previewImage.Image = new Bitmap(tile.PreviewImage, AssignedTile.PreviewSizeSmall);

            Label name = new Label();
            name.AutoSize = true;
            name.Text = this.AssignedTile.Name;
            name.Padding = new Padding(0, 50, 0, 0);

            Label size = new Label();
            size.AutoSize = true;
            size.Text = $"{AssignedTile.Width} x {AssignedTile.Height}";
            
            this.Controls.Add(previewImage);
            this.Controls.Add(name);
            this.Controls.Add(size);
        }
    }

    public class Tileset
    {
        static List<Tile> Tiles = new List<Tile>();
        static bool IsLoaded = false;

        public static void LoadFromTilesetData()
        {
            if (IsLoaded)
                return;

            try
            {
                string[] data = File.ReadAllLines(EngineInstance.MainDirectory + @"\LEVEL\tileset.tsdata");
            
                foreach (string line in data)
                {
                    string[] lineData = line.Split("|");

                    List<Image> images = new List<Image>();
                    List<string> paths = new List<string>();
                    
                    foreach (string imagePath in lineData[4].Split("~"))
                    {
                        string fullPath = EngineInstance.MainDirectory + $@"\IMAGE\{imagePath}";

                        images.Add(Image.FromFile(fullPath));
                        paths.Add(fullPath);
                    }

                    Tile tile = new Tile(
                        lineData[0],
                        int.Parse(lineData[1]),
                        int.Parse(lineData[2]),
                        lineData[3],
                        images,
                        paths,
                        lineData[5],
                        bool.Parse(lineData[6])
                    );

                    AddTile(tile);
                }

                IsLoaded = true;
            }
            catch (Exception ex)
            {
                Debug.Error("Error while loading Tileset Data: " + ex.Message);
            }
        }

        public static void AddTile(Tile tile)
        {
            if (Tiles.Contains(tile) == false)
                Tiles.Add(tile);
        }
        public static void RemoveTile(Tile tile)
        {
            if (Tiles.Contains(tile) == true)
                Tiles.Remove(tile);
        }
        public static List<Tile> GetTiles()
        {
            return Tiles;
        }
        public static List<int> GetTilesWidths()
        {
            List<int> widths = new List<int>();
            foreach (Tile tile in Tiles)
            {
                widths.Add(tile.Width);
            }

            return widths;
        }
        public static List<int> GetTilesHeights()
        {
            List<int> heights = new List<int>();
            foreach (Tile tile in Tiles)
            {
                heights.Add(tile.Height);
            }

            return heights;
        }
    }
}
