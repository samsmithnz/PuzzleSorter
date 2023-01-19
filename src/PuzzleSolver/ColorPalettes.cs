using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PuzzleSolver
{
    public static class ColorPalettes
    {
        /// <summary>
        /// Just Primary colors
        /// </summary>
        /// <returns>List of Rgb24</returns>
        public static List<Rgb24> Get3ColorPalette()
        {
            return new List<Rgb24> {
                Color.Red.ToPixel<Rgb24>(),
                Color.Blue.ToPixel<Rgb24>(),
                Color.Yellow.ToPixel<Rgb24>()
            };
        }


        /// <summary>
        /// Primary colors + Black + White
        /// </summary>
        /// <returns>List of Rgb24</returns>
        public static List<Rgb24> Get5ColorPalette()
        {
            return new List<Rgb24> {
                Color.Red.ToPixel<Rgb24>(),
                Color.Blue.ToPixel<Rgb24>(),
                Color.Yellow.ToPixel<Rgb24>(),
                Color.White.ToPixel<Rgb24>(),
                Color.Black.ToPixel<Rgb24>()
            };
        }

        /// <summary>
        /// Primary and Secondary colors 
        /// </summary>
        /// <returns>List of Rgb24</returns>
        public static List<Rgb24> Get6ColorPalette()
        {
            return new List<Rgb24> {
                Color.Red.ToPixel<Rgb24>(),
                Color.Purple.ToPixel<Rgb24>(),
                Color.Blue.ToPixel<Rgb24>(),
                Color.Green.ToPixel<Rgb24>(),
                Color.Yellow.ToPixel<Rgb24>(),
                Color.Orange.ToPixel<Rgb24>()
            };
        }

        /// <summary>
        /// Primary and Secondary colors + Black + White
        /// </summary>
        /// <returns>List of Rgb24</returns>
        public static List<Rgb24> Get8ColorPalette()
        {
            return new List<Rgb24> {
                Color.Red.ToPixel<Rgb24>(),
                Color.Purple.ToPixel<Rgb24>(),
                Color.Blue.ToPixel<Rgb24>(),
                Color.Green.ToPixel<Rgb24>(),
                Color.Yellow.ToPixel<Rgb24>(),
                Color.Orange.ToPixel<Rgb24>(),
                Color.White.ToPixel<Rgb24>(),
                Color.Black.ToPixel<Rgb24>()
            };
        }

        /// <summary>
        /// 16 colors
        /// </summary>
        /// <returns>List of Rgb24</returns>
        public static List<Rgb24> Get16ColorPalette()
        {
            //https://htmlcolorcodes.com/
            return new List<Rgb24> {
                new Rgb24(255, 255, 255), //White
                new Rgb24(192, 192, 192), //Silver
                new Rgb24(128, 128, 128), //Gray
                new Rgb24(0, 0, 0), //Black            
                new Rgb24(255, 0, 0), //Red
                new Rgb24(128, 0, 0), //Maroon  
                new Rgb24(255, 255, 0), //Yellow 
                new Rgb24(128, 128, 0), //Olive
                new Rgb24(0, 255, 0), //Lime
                new Rgb24(0, 128, 0), //Green
                new Rgb24(0, 255, 255), //Aqua
                new Rgb24(0, 128, 128), //Teal
                new Rgb24(0, 0, 255), //Blue
                new Rgb24(0, 0, 128), //Navy
                new Rgb24(255, 0, 255), //Fuchsia         
                new Rgb24(128, 0, 128), //Purple              
            };
        }

        /// <summary>
        /// 24 colors 
        /// </summary>
        /// <returns>List of Rgb24</returns>
        public static List<Rgb24> Get24ColorPalette()
        {
            return new List<Rgb24> {
                new Rgb24(0, 0, 0), //black
                new Rgb24(85,85,85), //(dark) gray
                new Rgb24(0, 0, 170), //blue
                new Rgb24(85, 85, 255), //bright blue
                new Rgb24(0, 170, 0), //green
                new Rgb24(85, 255, 85), //bright green
                new Rgb24(0, 170, 170), //cyan
                new Rgb24(85, 255, 255), //bright cyan
                new Rgb24(170, 0, 0), //red
                new Rgb24(255, 85, 85), //bright red
                new Rgb24(170, 0, 170), //magenta
                new Rgb24(255, 85, 255), //bright magenta
                new Rgb24(170, 85, 0), //brown
                new Rgb24(255, 255, 85), //yellow
                new Rgb24(170, 170, 170), //white (light gray)
                new Rgb24(255, 255, 255), //bright white
            };
        }

        /// <summary>
        /// 32 colors 
        /// </summary>
        /// <returns>List of Rgb24</returns>
        public static List<Rgb24> Get32ColorPalette()
        {
            return new List<Rgb24> {
                new Rgb24(0, 0, 0), //black
                new Rgb24(85,85,85), //(dark) gray
                new Rgb24(0, 0, 170), //blue
                new Rgb24(85, 85, 255), //bright blue
                new Rgb24(0, 170, 0), //green
                new Rgb24(85, 255, 85), //bright green
                new Rgb24(0, 170, 170), //cyan
                new Rgb24(85, 255, 255), //bright cyan
                new Rgb24(170, 0, 0), //red
                new Rgb24(255, 85, 85), //bright red
                new Rgb24(170, 0, 170), //magenta
                new Rgb24(255, 85, 255), //bright magenta
                new Rgb24(170, 85, 0), //brown
                new Rgb24(255, 255, 85), //yellow
                new Rgb24(170, 170, 170), //white (light gray)
                new Rgb24(255, 255, 255), //bright white
            };
        }

        /// <summary>
        /// 140 colors (All C# named colors)
        /// </summary>
        /// <returns>List of Rgb24</returns>
        public static List<Rgb24> Get140ColorPalette()
        {
            return new List<Rgb24> {
                Color.AliceBlue.ToPixel<Rgb24>(),
                Color.AntiqueWhite.ToPixel<Rgb24>(),
                Color.Aqua.ToPixel<Rgb24>(),
                Color.Aquamarine.ToPixel<Rgb24>(),
                Color.Azure.ToPixel<Rgb24>(),
                Color.Beige.ToPixel<Rgb24>(),
                Color.Bisque.ToPixel<Rgb24>(),
                Color.Black.ToPixel<Rgb24>(),
                Color.BlanchedAlmond.ToPixel<Rgb24>(),
                Color.Blue.ToPixel<Rgb24>(),
                Color.BlueViolet.ToPixel<Rgb24>(),
                Color.Brown.ToPixel<Rgb24>(),
                Color.BurlyWood.ToPixel<Rgb24>(),
                Color.CadetBlue.ToPixel<Rgb24>(),
                Color.Chartreuse.ToPixel<Rgb24>(),
                Color.Chocolate.ToPixel<Rgb24>(),
                Color.Coral.ToPixel<Rgb24>(),
                Color.CornflowerBlue.ToPixel<Rgb24>(),
                Color.Cornsilk.ToPixel<Rgb24>(),
                Color.Crimson.ToPixel<Rgb24>(),
                Color.Cyan.ToPixel<Rgb24>(),
                Color.DarkBlue.ToPixel<Rgb24>(),
                Color.DarkCyan.ToPixel<Rgb24>(),
                Color.DarkGoldenrod.ToPixel<Rgb24>(),
                Color.DarkGray.ToPixel<Rgb24>(),
                Color.DarkGreen.ToPixel<Rgb24>(),
                Color.DarkKhaki.ToPixel<Rgb24>(),
                Color.DarkMagenta.ToPixel<Rgb24>(),
                Color.DarkOliveGreen.ToPixel<Rgb24>(),
                Color.DarkOrange.ToPixel<Rgb24>(),
                Color.DarkOrchid.ToPixel<Rgb24>(),
                Color.DarkRed.ToPixel<Rgb24>(),
                Color.DarkSalmon.ToPixel<Rgb24>(),
                Color.DarkSeaGreen.ToPixel<Rgb24>(),
                Color.DarkSlateBlue.ToPixel<Rgb24>(),
                Color.DarkSlateGray.ToPixel<Rgb24>(),
                Color.DarkTurquoise.ToPixel<Rgb24>(),
                Color.DarkViolet.ToPixel<Rgb24>(),
                Color.DeepPink.ToPixel<Rgb24>(),
                Color.DeepSkyBlue.ToPixel<Rgb24>(),
                Color.DimGray.ToPixel<Rgb24>(),
                Color.DodgerBlue.ToPixel<Rgb24>(),
                Color.Firebrick.ToPixel<Rgb24>(),
                Color.FloralWhite.ToPixel<Rgb24>(),
                Color.ForestGreen.ToPixel<Rgb24>(),
                Color.Fuchsia.ToPixel<Rgb24>(),
                Color.Gainsboro.ToPixel<Rgb24>(),
                Color.GhostWhite.ToPixel<Rgb24>(),
                Color.Gold.ToPixel<Rgb24>(),
                Color.Goldenrod.ToPixel<Rgb24>(),
                Color.Gray.ToPixel<Rgb24>(),
                Color.Green.ToPixel<Rgb24>(),
                Color.GreenYellow.ToPixel<Rgb24>(),
                Color.Honeydew.ToPixel<Rgb24>(),
                Color.HotPink.ToPixel<Rgb24>(),
                Color.IndianRed.ToPixel<Rgb24>(),
                Color.Indigo.ToPixel<Rgb24>(),
                Color.Ivory.ToPixel<Rgb24>(),
                Color.Khaki.ToPixel<Rgb24>(),
                Color.Lavender.ToPixel<Rgb24>(),
                Color.LavenderBlush.ToPixel<Rgb24>(),
                Color.LawnGreen.ToPixel<Rgb24>(),
                Color.LemonChiffon.ToPixel<Rgb24>(),
                Color.LightBlue.ToPixel<Rgb24>(),
                Color.LightCoral.ToPixel<Rgb24>(),
                Color.LightCyan.ToPixel<Rgb24>(),
                Color.LightGoldenrodYellow.ToPixel<Rgb24>(),
                Color.LightGray.ToPixel<Rgb24>(),
                Color.LightGreen.ToPixel<Rgb24>(),
                Color.LightPink.ToPixel<Rgb24>(),
                Color.LightSalmon.ToPixel<Rgb24>(),
                Color.LightSeaGreen.ToPixel<Rgb24>(),
                Color.LightSkyBlue.ToPixel<Rgb24>(),
                Color.LightSlateGray.ToPixel<Rgb24>(),
                Color.LightSteelBlue.ToPixel<Rgb24>(),
                Color.LightYellow.ToPixel<Rgb24>(),
                Color.Lime.ToPixel<Rgb24>(),
                Color.LimeGreen.ToPixel<Rgb24>(),
                Color.Linen.ToPixel<Rgb24>(),
                Color.Magenta.ToPixel<Rgb24>(),
                Color.Maroon.ToPixel<Rgb24>(),
                Color.MediumAquamarine.ToPixel<Rgb24>(),
                Color.MediumBlue.ToPixel<Rgb24>(),
                Color.MediumOrchid.ToPixel<Rgb24>(),
                Color.MediumPurple.ToPixel<Rgb24>(),
                Color.MediumSeaGreen.ToPixel<Rgb24>(),
                Color.MediumSlateBlue.ToPixel<Rgb24>(),
                Color.MediumSpringGreen.ToPixel<Rgb24>(),
                Color.MediumTurquoise.ToPixel<Rgb24>(),
                Color.MediumVioletRed.ToPixel<Rgb24>(),
                Color.MidnightBlue.ToPixel<Rgb24>(),
                Color.MintCream.ToPixel<Rgb24>(),
                Color.MistyRose.ToPixel<Rgb24>(),
                Color.Moccasin.ToPixel<Rgb24>(),
                Color.NavajoWhite.ToPixel<Rgb24>(),
                Color.Navy.ToPixel<Rgb24>(),
                Color.OldLace.ToPixel<Rgb24>(),
                Color.Olive.ToPixel<Rgb24>(),
                Color.OliveDrab.ToPixel<Rgb24>(),
                Color.Orange.ToPixel<Rgb24>(),
                Color.OrangeRed.ToPixel<Rgb24>(),
                Color.Orchid.ToPixel<Rgb24>(),
                Color.PaleGoldenrod.ToPixel<Rgb24>(),
                Color.PaleGreen.ToPixel<Rgb24>(),
                Color.PaleTurquoise.ToPixel<Rgb24>(),
                Color.PaleVioletRed.ToPixel<Rgb24>(),
                Color.PapayaWhip.ToPixel<Rgb24>(),
                Color.PeachPuff.ToPixel<Rgb24>(),
                Color.Peru.ToPixel<Rgb24>(),
                Color.Pink.ToPixel<Rgb24>(),
                Color.Plum.ToPixel<Rgb24>(),
                Color.PowderBlue.ToPixel<Rgb24>(),
                Color.Purple.ToPixel<Rgb24>(),
                Color.Red.ToPixel<Rgb24>(),
                Color.RosyBrown.ToPixel<Rgb24>(),
                Color.RoyalBlue.ToPixel<Rgb24>(),
                Color.SaddleBrown.ToPixel<Rgb24>(),
                Color.Salmon.ToPixel<Rgb24>(),
                Color.SandyBrown.ToPixel<Rgb24>(),
                Color.SeaGreen.ToPixel<Rgb24>(),
                Color.SeaShell.ToPixel<Rgb24>(),
                Color.Sienna.ToPixel<Rgb24>(),
                Color.Silver.ToPixel<Rgb24>(),
                Color.SkyBlue.ToPixel<Rgb24>(),
                Color.SlateBlue.ToPixel<Rgb24>(),
                Color.SlateGray.ToPixel<Rgb24>(),
                Color.Snow.ToPixel<Rgb24>(),
                Color.SpringGreen.ToPixel<Rgb24>(),
                Color.SteelBlue.ToPixel<Rgb24>(),
                Color.Tan.ToPixel<Rgb24>(),
                Color.Teal.ToPixel<Rgb24>(),
                Color.Thistle.ToPixel<Rgb24>(),
                Color.Tomato.ToPixel<Rgb24>(),
                Color.Transparent.ToPixel<Rgb24>(),
                Color.Turquoise.ToPixel<Rgb24>(),
                Color.Violet.ToPixel<Rgb24>(),
                Color.Wheat.ToPixel<Rgb24>(),
                Color.White.ToPixel<Rgb24>(),
                Color.WhiteSmoke.ToPixel<Rgb24>(),
                Color.Yellow.ToPixel<Rgb24>(),
                Color.YellowGreen.ToPixel<Rgb24>() };

        }

        public static string ToName(Rgb24 rgb24)
        {
            if (Color.AliceBlue.ToPixel<Rgb24>() == rgb24) { return "AliceBlue"; }
            else if (Color.AntiqueWhite.ToPixel<Rgb24>() == rgb24) { return "AntiqueWhite"; }
            else if (Color.Aqua.ToPixel<Rgb24>() == rgb24) { return "Aqua"; }
            else if (Color.Aquamarine.ToPixel<Rgb24>() == rgb24) { return "Aquamarine"; }
            else if (Color.Azure.ToPixel<Rgb24>() == rgb24) { return "Azure"; }
            else if (Color.Beige.ToPixel<Rgb24>() == rgb24) { return "Beige"; }
            else if (Color.Bisque.ToPixel<Rgb24>() == rgb24) { return "Bisque"; }
            else if (Color.Black.ToPixel<Rgb24>() == rgb24) { return "Black"; }
            else if (Color.BlanchedAlmond.ToPixel<Rgb24>() == rgb24) { return "BlanchedAlmond"; }
            else if (Color.Blue.ToPixel<Rgb24>() == rgb24) { return "Blue"; }
            else if (Color.BlueViolet.ToPixel<Rgb24>() == rgb24) { return "BlueViolet"; }
            else if (Color.Brown.ToPixel<Rgb24>() == rgb24) { return "Brown"; }
            else if (Color.BurlyWood.ToPixel<Rgb24>() == rgb24) { return "BurlyWood"; }
            else if (Color.CadetBlue.ToPixel<Rgb24>() == rgb24) { return "CadetBlue"; }
            else if (Color.Chartreuse.ToPixel<Rgb24>() == rgb24) { return "Chartreuse"; }
            else if (Color.Chocolate.ToPixel<Rgb24>() == rgb24) { return "Chocolate"; }
            else if (Color.Coral.ToPixel<Rgb24>() == rgb24) { return "Coral"; }
            else if (Color.CornflowerBlue.ToPixel<Rgb24>() == rgb24) { return "CornflowerBlue"; }
            else if (Color.Cornsilk.ToPixel<Rgb24>() == rgb24) { return "Cornsilk"; }
            else if (Color.Crimson.ToPixel<Rgb24>() == rgb24) { return "Crimson"; }
            else if (Color.Cyan.ToPixel<Rgb24>() == rgb24) { return "Cyan"; }
            else if (Color.DarkBlue.ToPixel<Rgb24>() == rgb24) { return "DarkBlue"; }
            else if (Color.DarkCyan.ToPixel<Rgb24>() == rgb24) { return "DarkCyan"; }
            else if (Color.DarkGoldenrod.ToPixel<Rgb24>() == rgb24) { return "DarkGoldenrod"; }
            else if (Color.DarkGray.ToPixel<Rgb24>() == rgb24) { return "DarkGray"; }
            else if (Color.DarkGreen.ToPixel<Rgb24>() == rgb24) { return "DarkGreen"; }
            else if (Color.DarkKhaki.ToPixel<Rgb24>() == rgb24) { return "DarkKhaki"; }
            else if (Color.DarkMagenta.ToPixel<Rgb24>() == rgb24) { return "DarkMagenta"; }
            else if (Color.DarkOliveGreen.ToPixel<Rgb24>() == rgb24) { return "DarkOliveGreen"; }
            else if (Color.DarkOrange.ToPixel<Rgb24>() == rgb24) { return "DarkOrange"; }
            else if (Color.DarkOrchid.ToPixel<Rgb24>() == rgb24) { return "DarkOrchid"; }
            else if (Color.DarkRed.ToPixel<Rgb24>() == rgb24) { return "DarkRed"; }
            else if (Color.DarkSalmon.ToPixel<Rgb24>() == rgb24) { return "DarkSalmon"; }
            else if (Color.DarkSeaGreen.ToPixel<Rgb24>() == rgb24) { return "DarkSeaGreen"; }
            else if (Color.DarkSlateBlue.ToPixel<Rgb24>() == rgb24) { return "DarkSlateBlue"; }
            else if (Color.DarkSlateGray.ToPixel<Rgb24>() == rgb24) { return "DarkSlateGray"; }
            else if (Color.DarkTurquoise.ToPixel<Rgb24>() == rgb24) { return "DarkTurquoise"; }
            else if (Color.DarkViolet.ToPixel<Rgb24>() == rgb24) { return "DarkViolet"; }
            else if (Color.DeepPink.ToPixel<Rgb24>() == rgb24) { return "DeepPink"; }
            else if (Color.DeepSkyBlue.ToPixel<Rgb24>() == rgb24) { return "DeepSkyBlue"; }
            else if (Color.DimGray.ToPixel<Rgb24>() == rgb24) { return "DimGray"; }
            else if (Color.DodgerBlue.ToPixel<Rgb24>() == rgb24) { return "DodgerBlue"; }
            else if (Color.Firebrick.ToPixel<Rgb24>() == rgb24) { return "Firebrick"; }
            else if (Color.FloralWhite.ToPixel<Rgb24>() == rgb24) { return "FloralWhite"; }
            else if (Color.ForestGreen.ToPixel<Rgb24>() == rgb24) { return "ForestGreen"; }
            else if (Color.Fuchsia.ToPixel<Rgb24>() == rgb24) { return "Fuchsia"; }
            else if (Color.Gainsboro.ToPixel<Rgb24>() == rgb24) { return "Gainsboro"; }
            else if (Color.GhostWhite.ToPixel<Rgb24>() == rgb24) { return "GhostWhite"; }
            else if (Color.Gold.ToPixel<Rgb24>() == rgb24) { return "Gold"; }
            else if (Color.Goldenrod.ToPixel<Rgb24>() == rgb24) { return "Goldenrod"; }
            else if (Color.Gray.ToPixel<Rgb24>() == rgb24) { return "Gray"; }
            else if (Color.Green.ToPixel<Rgb24>() == rgb24) { return "Green"; }
            else if (Color.GreenYellow.ToPixel<Rgb24>() == rgb24) { return "GreenYellow"; }
            else if (Color.Honeydew.ToPixel<Rgb24>() == rgb24) { return "Honeydew"; }
            else if (Color.HotPink.ToPixel<Rgb24>() == rgb24) { return "HotPink"; }
            else if (Color.IndianRed.ToPixel<Rgb24>() == rgb24) { return "IndianRed"; }
            else if (Color.Indigo.ToPixel<Rgb24>() == rgb24) { return "Indigo"; }
            else if (Color.Ivory.ToPixel<Rgb24>() == rgb24) { return "Ivory"; }
            else if (Color.Khaki.ToPixel<Rgb24>() == rgb24) { return "Khaki"; }
            else if (Color.Lavender.ToPixel<Rgb24>() == rgb24) { return "Lavender"; }
            else if (Color.LavenderBlush.ToPixel<Rgb24>() == rgb24) { return "LavenderBlush"; }
            else if (Color.LawnGreen.ToPixel<Rgb24>() == rgb24) { return "LawnGreen"; }
            else if (Color.LemonChiffon.ToPixel<Rgb24>() == rgb24) { return "LemonChiffon"; }
            else if (Color.LightBlue.ToPixel<Rgb24>() == rgb24) { return "LightBlue"; }
            else if (Color.LightCoral.ToPixel<Rgb24>() == rgb24) { return "LightCoral"; }
            else if (Color.LightCyan.ToPixel<Rgb24>() == rgb24) { return "LightCyan"; }
            else if (Color.LightGoldenrodYellow.ToPixel<Rgb24>() == rgb24) { return "LightGoldenrodYellow"; }
            else if (Color.LightGray.ToPixel<Rgb24>() == rgb24) { return "LightGray"; }
            else if (Color.LightGreen.ToPixel<Rgb24>() == rgb24) { return "LightGreen"; }
            else if (Color.LightPink.ToPixel<Rgb24>() == rgb24) { return "LightPink"; }
            else if (Color.LightSalmon.ToPixel<Rgb24>() == rgb24) { return "LightSalmon"; }
            else if (Color.LightSeaGreen.ToPixel<Rgb24>() == rgb24) { return "LightSeaGreen"; }
            else if (Color.LightSkyBlue.ToPixel<Rgb24>() == rgb24) { return "LightSkyBlue"; }
            else if (Color.LightSlateGray.ToPixel<Rgb24>() == rgb24) { return "LightSlateGray"; }
            else if (Color.LightSteelBlue.ToPixel<Rgb24>() == rgb24) { return "LightSteelBlue"; }
            else if (Color.LightYellow.ToPixel<Rgb24>() == rgb24) { return "LightYellow"; }
            else if (Color.Lime.ToPixel<Rgb24>() == rgb24) { return "Lime"; }
            else if (Color.LimeGreen.ToPixel<Rgb24>() == rgb24) { return "LimeGreen"; }
            else if (Color.Linen.ToPixel<Rgb24>() == rgb24) { return "Linen"; }
            else if (Color.Magenta.ToPixel<Rgb24>() == rgb24) { return "Magenta"; }
            else if (Color.Maroon.ToPixel<Rgb24>() == rgb24) { return "Maroon"; }
            else if (Color.MediumAquamarine.ToPixel<Rgb24>() == rgb24) { return "MediumAquamarine"; }
            else if (Color.MediumBlue.ToPixel<Rgb24>() == rgb24) { return "MediumBlue"; }
            else if (Color.MediumOrchid.ToPixel<Rgb24>() == rgb24) { return "MediumOrchid"; }
            else if (Color.MediumPurple.ToPixel<Rgb24>() == rgb24) { return "MediumPurple"; }
            else if (Color.MediumSeaGreen.ToPixel<Rgb24>() == rgb24) { return "MediumSeaGreen"; }
            else if (Color.MediumSlateBlue.ToPixel<Rgb24>() == rgb24) { return "MediumSlateBlue"; }
            else if (Color.MediumSpringGreen.ToPixel<Rgb24>() == rgb24) { return "MediumSpringGreen"; }
            else if (Color.MediumTurquoise.ToPixel<Rgb24>() == rgb24) { return "MediumTurquoise"; }
            else if (Color.MediumVioletRed.ToPixel<Rgb24>() == rgb24) { return "MediumVioletRed"; }
            else if (Color.MidnightBlue.ToPixel<Rgb24>() == rgb24) { return "MidnightBlue"; }
            else if (Color.MintCream.ToPixel<Rgb24>() == rgb24) { return "MintCream"; }
            else if (Color.MistyRose.ToPixel<Rgb24>() == rgb24) { return "MistyRose"; }
            else if (Color.Moccasin.ToPixel<Rgb24>() == rgb24) { return "Moccasin"; }
            else if (Color.NavajoWhite.ToPixel<Rgb24>() == rgb24) { return "NavajoWhite"; }
            else if (Color.Navy.ToPixel<Rgb24>() == rgb24) { return "Navy"; }
            else if (Color.OldLace.ToPixel<Rgb24>() == rgb24) { return "OldLace"; }
            else if (Color.Olive.ToPixel<Rgb24>() == rgb24) { return "Olive"; }
            else if (Color.OliveDrab.ToPixel<Rgb24>() == rgb24) { return "OliveDrab"; }
            else if (Color.Orange.ToPixel<Rgb24>() == rgb24) { return "Orange"; }
            else if (Color.OrangeRed.ToPixel<Rgb24>() == rgb24) { return "OrangeRed"; }
            else if (Color.Orchid.ToPixel<Rgb24>() == rgb24) { return "Orchid"; }
            else if (Color.PaleGoldenrod.ToPixel<Rgb24>() == rgb24) { return "PaleGoldenrod"; }
            else if (Color.PaleGreen.ToPixel<Rgb24>() == rgb24) { return "PaleGreen"; }
            else if (Color.PaleTurquoise.ToPixel<Rgb24>() == rgb24) { return "PaleTurquoise"; }
            else if (Color.PaleVioletRed.ToPixel<Rgb24>() == rgb24) { return "PaleVioletRed"; }
            else if (Color.PapayaWhip.ToPixel<Rgb24>() == rgb24) { return "PapayaWhip"; }
            else if (Color.PeachPuff.ToPixel<Rgb24>() == rgb24) { return "PeachPuff"; }
            else if (Color.Peru.ToPixel<Rgb24>() == rgb24) { return "Peru"; }
            else if (Color.Pink.ToPixel<Rgb24>() == rgb24) { return "Pink"; }
            else if (Color.Plum.ToPixel<Rgb24>() == rgb24) { return "Plum"; }
            else if (Color.PowderBlue.ToPixel<Rgb24>() == rgb24) { return "PowderBlue"; }
            else if (Color.Purple.ToPixel<Rgb24>() == rgb24) { return "Purple"; }
            else if (Color.Red.ToPixel<Rgb24>() == rgb24) { return "Red"; }
            else if (Color.RosyBrown.ToPixel<Rgb24>() == rgb24) { return "RosyBrown"; }
            else if (Color.RoyalBlue.ToPixel<Rgb24>() == rgb24) { return "RoyalBlue"; }
            else if (Color.SaddleBrown.ToPixel<Rgb24>() == rgb24) { return "SaddleBrown"; }
            else if (Color.Salmon.ToPixel<Rgb24>() == rgb24) { return "Salmon"; }
            else if (Color.SandyBrown.ToPixel<Rgb24>() == rgb24) { return "SandyBrown"; }
            else if (Color.SeaGreen.ToPixel<Rgb24>() == rgb24) { return "SeaGreen"; }
            else if (Color.SeaShell.ToPixel<Rgb24>() == rgb24) { return "SeaShell"; }
            else if (Color.Sienna.ToPixel<Rgb24>() == rgb24) { return "Sienna"; }
            else if (Color.Silver.ToPixel<Rgb24>() == rgb24) { return "Silver"; }
            else if (Color.SkyBlue.ToPixel<Rgb24>() == rgb24) { return "SkyBlue"; }
            else if (Color.SlateBlue.ToPixel<Rgb24>() == rgb24) { return "SlateBlue"; }
            else if (Color.SlateGray.ToPixel<Rgb24>() == rgb24) { return "SlateGray"; }
            else if (Color.Snow.ToPixel<Rgb24>() == rgb24) { return "Snow"; }
            else if (Color.SpringGreen.ToPixel<Rgb24>() == rgb24) { return "SpringGreen"; }
            else if (Color.SteelBlue.ToPixel<Rgb24>() == rgb24) { return "SteelBlue"; }
            else if (Color.Tan.ToPixel<Rgb24>() == rgb24) { return "Tan"; }
            else if (Color.Teal.ToPixel<Rgb24>() == rgb24) { return "Teal"; }
            else if (Color.Thistle.ToPixel<Rgb24>() == rgb24) { return "Thistle"; }
            else if (Color.Tomato.ToPixel<Rgb24>() == rgb24) { return "Tomato"; }
            else if (Color.Transparent.ToPixel<Rgb24>() == rgb24) { return "Transparent"; }
            else if (Color.Turquoise.ToPixel<Rgb24>() == rgb24) { return "Turquoise"; }
            else if (Color.Violet.ToPixel<Rgb24>() == rgb24) { return "Violet"; }
            else if (Color.Wheat.ToPixel<Rgb24>() == rgb24) { return "Wheat"; }
            else if (Color.White.ToPixel<Rgb24>() == rgb24) { return "White"; }
            else if (Color.WhiteSmoke.ToPixel<Rgb24>() == rgb24) { return "WhiteSmoke"; }
            else if (Color.Yellow.ToPixel<Rgb24>() == rgb24) { return "Yellow"; }
            else if (Color.YellowGreen.ToPixel<Rgb24>() == rgb24) { return "YellowGreen"; }

            //CGA colors
            else if (new Rgb24(0, 0, 0) == rgb24) { return "black"; }
            else if (new Rgb24(85, 85, 85) == rgb24) { return "(dark) gray"; }
            else if (new Rgb24(0, 0, 170) == rgb24) { return "blue"; }
            else if (new Rgb24(85, 85, 255) == rgb24) { return "bright blue"; }
            else if (new Rgb24(0, 170, 0) == rgb24) { return "green"; }
            else if (new Rgb24(85, 255, 85) == rgb24) { return "bright green"; }
            else if (new Rgb24(0, 170, 170) == rgb24) { return "cyan"; }
            else if (new Rgb24(85, 255, 255) == rgb24) { return "bright cyan"; }
            else if (new Rgb24(170, 0, 0) == rgb24) { return "red"; }
            else if (new Rgb24(255, 85, 85) == rgb24) { return "bright red"; }
            else if (new Rgb24(170, 0, 170) == rgb24) { return "magenta"; }
            else if (new Rgb24(255, 85, 255) == rgb24) { return "bright magenta"; }
            else if (new Rgb24(170, 85, 0) == rgb24) { return "brown"; }
            else if (new Rgb24(255, 255, 85) == rgb24) { return "yellow"; }
            else if (new Rgb24(170, 170, 170) == rgb24) { return "white (light gray)"; }
            else if (new Rgb24(255, 255, 255) == rgb24) { return "bright white"; }
            else { return ""; }
        }
    }
}
