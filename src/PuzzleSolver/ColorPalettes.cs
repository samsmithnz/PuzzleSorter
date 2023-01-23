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
                ColorStats.Red.ToPixel<Rgb24>(),
                ColorStats.Blue.ToPixel<Rgb24>(),
                ColorStats.Yellow.ToPixel<Rgb24>()
            };
        }


        /// <summary>
        /// Primary colors + Black + White
        /// </summary>
        /// <returns>List of Rgb24</returns>
        public static List<Rgb24> Get5ColorPalette()
        {
            return new List<Rgb24> {
                ColorStats.Red.ToPixel<Rgb24>(),
                ColorStats.Blue.ToPixel<Rgb24>(),
                ColorStats.Yellow.ToPixel<Rgb24>(),
                ColorStats.White.ToPixel<Rgb24>(),
                ColorStats.Black.ToPixel<Rgb24>()
            };
        }

        /// <summary>
        /// Primary and Secondary colors 
        /// </summary>
        /// <returns>List of Rgb24</returns>
        public static List<Rgb24> Get6ColorPalette()
        {
            return new List<Rgb24> {
                ColorStats.Red.ToPixel<Rgb24>(),
                ColorStats.Purple.ToPixel<Rgb24>(),
                ColorStats.Blue.ToPixel<Rgb24>(),
                ColorStats.Green.ToPixel<Rgb24>(),
                ColorStats.Yellow.ToPixel<Rgb24>(),
                ColorStats.Orange.ToPixel<Rgb24>()
            };
        }

        /// <summary>
        /// Primary and Secondary colors + Black + White
        /// </summary>
        /// <returns>List of Rgb24</returns>
        public static List<Rgb24> Get8ColorPalette()
        {
            return new List<Rgb24> {
                ColorStats.Red.ToPixel<Rgb24>(),
                ColorStats.Purple.ToPixel<Rgb24>(),
                ColorStats.Blue.ToPixel<Rgb24>(),
                ColorStats.Green.ToPixel<Rgb24>(),
                ColorStats.Yellow.ToPixel<Rgb24>(),
                ColorStats.Orange.ToPixel<Rgb24>(),
                ColorStats.White.ToPixel<Rgb24>(),
                ColorStats.Black.ToPixel<Rgb24>()
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

        ///// <summary>
        ///// 24 colors 
        ///// </summary>
        ///// <returns>List of Rgb24</returns>
        //public static List<Rgb24> Get24ColorPalette()
        //{
        //    return new List<Rgb24> {
        //        new Rgb24(0, 0, 0), //black
        //        new Rgb24(85,85,85), //(dark) gray
        //        new Rgb24(0, 0, 170), //blue
        //        new Rgb24(85, 85, 255), //bright blue
        //        new Rgb24(0, 170, 0), //green
        //        new Rgb24(85, 255, 85), //bright green
        //        new Rgb24(0, 170, 170), //cyan
        //        new Rgb24(85, 255, 255), //bright cyan
        //        new Rgb24(170, 0, 0), //red
        //        new Rgb24(255, 85, 85), //bright red
        //        new Rgb24(170, 0, 170), //magenta
        //        new Rgb24(255, 85, 255), //bright magenta
        //        new Rgb24(170, 85, 0), //brown
        //        new Rgb24(255, 255, 85), //yellow
        //        new Rgb24(170, 170, 170), //white (light gray)
        //        new Rgb24(255, 255, 255), //bright white
        //    };
        //}

        ///// <summary>
        ///// 32 colors 
        ///// </summary>
        ///// <returns>List of Rgb24</returns>
        //public static List<Rgb24> Get32ColorPalette()
        //{
        //    return new List<Rgb24> {
        //        new Rgb24(0, 0, 0), //black
        //        new Rgb24(85,85,85), //(dark) gray
        //        new Rgb24(0, 0, 170), //blue
        //        new Rgb24(85, 85, 255), //bright blue
        //        new Rgb24(0, 170, 0), //green
        //        new Rgb24(85, 255, 85), //bright green
        //        new Rgb24(0, 170, 170), //cyan
        //        new Rgb24(85, 255, 255), //bright cyan
        //        new Rgb24(170, 0, 0), //red
        //        new Rgb24(255, 85, 85), //bright red
        //        new Rgb24(170, 0, 170), //magenta
        //        new Rgb24(255, 85, 255), //bright magenta
        //        new Rgb24(170, 85, 0), //brown
        //        new Rgb24(255, 255, 85), //yellow
        //        new Rgb24(170, 170, 170), //white (light gray)
        //        new Rgb24(255, 255, 255), //bright white
        //    };
        //}

        /// <summary>
        /// 141 colors (All C# named colors)
        /// </summary>
        /// <returns>List of Rgb24</returns>
        public static List<Rgb24> Get141ColorPalette()
        {
            return new List<Rgb24> {
                ColorStats.AliceBlue.ToPixel<Rgb24>(),
                ColorStats.AntiqueWhite.ToPixel<Rgb24>(),
                ColorStats.Aqua.ToPixel<Rgb24>(),
                ColorStats.Aquamarine.ToPixel<Rgb24>(),
                ColorStats.Azure.ToPixel<Rgb24>(),
                ColorStats.Beige.ToPixel<Rgb24>(),
                ColorStats.Bisque.ToPixel<Rgb24>(),
                ColorStats.Black.ToPixel<Rgb24>(),
                ColorStats.BlanchedAlmond.ToPixel<Rgb24>(),
                ColorStats.Blue.ToPixel<Rgb24>(),
                ColorStats.BlueViolet.ToPixel<Rgb24>(),
                ColorStats.Brown.ToPixel<Rgb24>(),
                ColorStats.BurlyWood.ToPixel<Rgb24>(),
                ColorStats.CadetBlue.ToPixel<Rgb24>(),
                ColorStats.Chartreuse.ToPixel<Rgb24>(),
                ColorStats.Chocolate.ToPixel<Rgb24>(),
                ColorStats.Coral.ToPixel<Rgb24>(),
                ColorStats.CornflowerBlue.ToPixel<Rgb24>(),
                ColorStats.Cornsilk.ToPixel<Rgb24>(),
                ColorStats.Crimson.ToPixel<Rgb24>(),
                ColorStats.Cyan.ToPixel<Rgb24>(),
                ColorStats.DarkBlue.ToPixel<Rgb24>(),
                ColorStats.DarkCyan.ToPixel<Rgb24>(),
                ColorStats.DarkGoldenrod.ToPixel<Rgb24>(),
                ColorStats.DarkGray.ToPixel<Rgb24>(),
                ColorStats.DarkGreen.ToPixel<Rgb24>(),
                ColorStats.DarkKhaki.ToPixel<Rgb24>(),
                ColorStats.DarkMagenta.ToPixel<Rgb24>(),
                ColorStats.DarkOliveGreen.ToPixel<Rgb24>(),
                ColorStats.DarkOrange.ToPixel<Rgb24>(),
                ColorStats.DarkOrchid.ToPixel<Rgb24>(),
                ColorStats.DarkRed.ToPixel<Rgb24>(),
                ColorStats.DarkSalmon.ToPixel<Rgb24>(),
                ColorStats.DarkSeaGreen.ToPixel<Rgb24>(),
                ColorStats.DarkSlateBlue.ToPixel<Rgb24>(),
                ColorStats.DarkSlateGray.ToPixel<Rgb24>(),
                ColorStats.DarkTurquoise.ToPixel<Rgb24>(),
                ColorStats.DarkViolet.ToPixel<Rgb24>(),
                ColorStats.DeepPink.ToPixel<Rgb24>(),
                ColorStats.DeepSkyBlue.ToPixel<Rgb24>(),
                ColorStats.DimGray.ToPixel<Rgb24>(),
                ColorStats.DodgerBlue.ToPixel<Rgb24>(),
                ColorStats.Firebrick.ToPixel<Rgb24>(),
                ColorStats.FloralWhite.ToPixel<Rgb24>(),
                ColorStats.ForestGreen.ToPixel<Rgb24>(),
                ColorStats.Fuchsia.ToPixel<Rgb24>(),
                ColorStats.Gainsboro.ToPixel<Rgb24>(),
                ColorStats.GhostWhite.ToPixel<Rgb24>(),
                ColorStats.Gold.ToPixel<Rgb24>(),
                ColorStats.Goldenrod.ToPixel<Rgb24>(),
                ColorStats.Gray.ToPixel<Rgb24>(),
                ColorStats.Green.ToPixel<Rgb24>(),
                ColorStats.GreenYellow.ToPixel<Rgb24>(),
                ColorStats.Honeydew.ToPixel<Rgb24>(),
                ColorStats.HotPink.ToPixel<Rgb24>(),
                ColorStats.IndianRed.ToPixel<Rgb24>(),
                ColorStats.Indigo.ToPixel<Rgb24>(),
                ColorStats.Ivory.ToPixel<Rgb24>(),
                ColorStats.Khaki.ToPixel<Rgb24>(),
                ColorStats.Lavender.ToPixel<Rgb24>(),
                ColorStats.LavenderBlush.ToPixel<Rgb24>(),
                ColorStats.LawnGreen.ToPixel<Rgb24>(),
                ColorStats.LemonChiffon.ToPixel<Rgb24>(),
                ColorStats.LightBlue.ToPixel<Rgb24>(),
                ColorStats.LightCoral.ToPixel<Rgb24>(),
                ColorStats.LightCyan.ToPixel<Rgb24>(),
                ColorStats.LightGoldenrodYellow.ToPixel<Rgb24>(),
                ColorStats.LightGray.ToPixel<Rgb24>(),
                ColorStats.LightGreen.ToPixel<Rgb24>(),
                ColorStats.LightPink.ToPixel<Rgb24>(),
                ColorStats.LightSalmon.ToPixel<Rgb24>(),
                ColorStats.LightSeaGreen.ToPixel<Rgb24>(),
                ColorStats.LightSkyBlue.ToPixel<Rgb24>(),
                ColorStats.LightSlateGray.ToPixel<Rgb24>(),
                ColorStats.LightSteelBlue.ToPixel<Rgb24>(),
                ColorStats.LightYellow.ToPixel<Rgb24>(),
                ColorStats.Lime.ToPixel<Rgb24>(),
                ColorStats.LimeGreen.ToPixel<Rgb24>(),
                ColorStats.Linen.ToPixel<Rgb24>(),
                ColorStats.Magenta.ToPixel<Rgb24>(),
                ColorStats.Maroon.ToPixel<Rgb24>(),
                ColorStats.MediumAquamarine.ToPixel<Rgb24>(),
                ColorStats.MediumBlue.ToPixel<Rgb24>(),
                ColorStats.MediumOrchid.ToPixel<Rgb24>(),
                ColorStats.MediumPurple.ToPixel<Rgb24>(),
                ColorStats.MediumSeaGreen.ToPixel<Rgb24>(),
                ColorStats.MediumSlateBlue.ToPixel<Rgb24>(),
                ColorStats.MediumSpringGreen.ToPixel<Rgb24>(),
                ColorStats.MediumTurquoise.ToPixel<Rgb24>(),
                ColorStats.MediumVioletRed.ToPixel<Rgb24>(),
                ColorStats.MidnightBlue.ToPixel<Rgb24>(),
                ColorStats.MintCream.ToPixel<Rgb24>(),
                ColorStats.MistyRose.ToPixel<Rgb24>(),
                ColorStats.Moccasin.ToPixel<Rgb24>(),
                ColorStats.NavajoWhite.ToPixel<Rgb24>(),
                ColorStats.Navy.ToPixel<Rgb24>(),
                ColorStats.OldLace.ToPixel<Rgb24>(),
                ColorStats.Olive.ToPixel<Rgb24>(),
                ColorStats.OliveDrab.ToPixel<Rgb24>(),
                ColorStats.Orange.ToPixel<Rgb24>(),
                ColorStats.OrangeRed.ToPixel<Rgb24>(),
                ColorStats.Orchid.ToPixel<Rgb24>(),
                ColorStats.PaleGoldenrod.ToPixel<Rgb24>(),
                ColorStats.PaleGreen.ToPixel<Rgb24>(),
                ColorStats.PaleTurquoise.ToPixel<Rgb24>(),
                ColorStats.PaleVioletRed.ToPixel<Rgb24>(),
                ColorStats.PapayaWhip.ToPixel<Rgb24>(),
                ColorStats.PeachPuff.ToPixel<Rgb24>(),
                ColorStats.Peru.ToPixel<Rgb24>(),
                ColorStats.Pink.ToPixel<Rgb24>(),
                ColorStats.Plum.ToPixel<Rgb24>(),
                ColorStats.PowderBlue.ToPixel<Rgb24>(),
                ColorStats.Purple.ToPixel<Rgb24>(),
                ColorStats.Red.ToPixel<Rgb24>(),
                ColorStats.RosyBrown.ToPixel<Rgb24>(),
                ColorStats.RoyalBlue.ToPixel<Rgb24>(),
                ColorStats.SaddleBrown.ToPixel<Rgb24>(),
                ColorStats.Salmon.ToPixel<Rgb24>(),
                ColorStats.SandyBrown.ToPixel<Rgb24>(),
                ColorStats.SeaGreen.ToPixel<Rgb24>(),
                ColorStats.SeaShell.ToPixel<Rgb24>(),
                ColorStats.Sienna.ToPixel<Rgb24>(),
                ColorStats.Silver.ToPixel<Rgb24>(),
                ColorStats.SkyBlue.ToPixel<Rgb24>(),
                ColorStats.SlateBlue.ToPixel<Rgb24>(),
                ColorStats.SlateGray.ToPixel<Rgb24>(),
                ColorStats.Snow.ToPixel<Rgb24>(),
                ColorStats.SpringGreen.ToPixel<Rgb24>(),
                ColorStats.SteelBlue.ToPixel<Rgb24>(),
                ColorStats.Tan.ToPixel<Rgb24>(),
                ColorStats.Teal.ToPixel<Rgb24>(),
                ColorStats.Thistle.ToPixel<Rgb24>(),
                ColorStats.Tomato.ToPixel<Rgb24>(),
                ColorStats.Transparent.ToPixel<Rgb24>(),
                ColorStats.Turquoise.ToPixel<Rgb24>(),
                ColorStats.Violet.ToPixel<Rgb24>(),
                ColorStats.Wheat.ToPixel<Rgb24>(),
                ColorStats.White.ToPixel<Rgb24>(),
                ColorStats.WhiteSmoke.ToPixel<Rgb24>(),
                ColorStats.Yellow.ToPixel<Rgb24>(),
                ColorStats.YellowGreen.ToPixel<Rgb24>() };

        }

        public static string ToName(Rgb24 rgb24)
        {
            if (ColorStats.AliceBlue.ToPixel<Rgb24>() == rgb24) { return "AliceBlue"; }
            else if (ColorStats.AntiqueWhite.ToPixel<Rgb24>() == rgb24) { return "AntiqueWhite"; }
            else if (ColorStats.Aqua.ToPixel<Rgb24>() == rgb24) { return "Aqua"; }
            else if (ColorStats.Aquamarine.ToPixel<Rgb24>() == rgb24) { return "Aquamarine"; }
            else if (ColorStats.Azure.ToPixel<Rgb24>() == rgb24) { return "Azure"; }
            else if (ColorStats.Beige.ToPixel<Rgb24>() == rgb24) { return "Beige"; }
            else if (ColorStats.Bisque.ToPixel<Rgb24>() == rgb24) { return "Bisque"; }
            else if (ColorStats.Black.ToPixel<Rgb24>() == rgb24) { return "Black"; }
            else if (ColorStats.BlanchedAlmond.ToPixel<Rgb24>() == rgb24) { return "BlanchedAlmond"; }
            else if (ColorStats.Blue.ToPixel<Rgb24>() == rgb24) { return "Blue"; }
            else if (ColorStats.BlueViolet.ToPixel<Rgb24>() == rgb24) { return "BlueViolet"; }
            else if (ColorStats.Brown.ToPixel<Rgb24>() == rgb24) { return "Brown"; }
            else if (ColorStats.BurlyWood.ToPixel<Rgb24>() == rgb24) { return "BurlyWood"; }
            else if (ColorStats.CadetBlue.ToPixel<Rgb24>() == rgb24) { return "CadetBlue"; }
            else if (ColorStats.Chartreuse.ToPixel<Rgb24>() == rgb24) { return "Chartreuse"; }
            else if (ColorStats.Chocolate.ToPixel<Rgb24>() == rgb24) { return "Chocolate"; }
            else if (ColorStats.Coral.ToPixel<Rgb24>() == rgb24) { return "Coral"; }
            else if (ColorStats.CornflowerBlue.ToPixel<Rgb24>() == rgb24) { return "CornflowerBlue"; }
            else if (ColorStats.Cornsilk.ToPixel<Rgb24>() == rgb24) { return "Cornsilk"; }
            else if (ColorStats.Crimson.ToPixel<Rgb24>() == rgb24) { return "Crimson"; }
            //else if (Color.Cyan.ToPixel<Rgb24>() == rgb24) { return "Cyan"; }
            else if (ColorStats.DarkBlue.ToPixel<Rgb24>() == rgb24) { return "DarkBlue"; }
            else if (ColorStats.DarkCyan.ToPixel<Rgb24>() == rgb24) { return "DarkCyan"; }
            else if (ColorStats.DarkGoldenrod.ToPixel<Rgb24>() == rgb24) { return "DarkGoldenrod"; }
            else if (ColorStats.DarkGray.ToPixel<Rgb24>() == rgb24) { return "DarkGray"; }
            else if (ColorStats.DarkGreen.ToPixel<Rgb24>() == rgb24) { return "DarkGreen"; }
            else if (ColorStats.DarkKhaki.ToPixel<Rgb24>() == rgb24) { return "DarkKhaki"; }
            else if (ColorStats.DarkMagenta.ToPixel<Rgb24>() == rgb24) { return "DarkMagenta"; }
            else if (ColorStats.DarkOliveGreen.ToPixel<Rgb24>() == rgb24) { return "DarkOliveGreen"; }
            else if (ColorStats.DarkOrange.ToPixel<Rgb24>() == rgb24) { return "DarkOrange"; }
            else if (ColorStats.DarkOrchid.ToPixel<Rgb24>() == rgb24) { return "DarkOrchid"; }
            else if (ColorStats.DarkRed.ToPixel<Rgb24>() == rgb24) { return "DarkRed"; }
            else if (ColorStats.DarkSalmon.ToPixel<Rgb24>() == rgb24) { return "DarkSalmon"; }
            else if (ColorStats.DarkSeaGreen.ToPixel<Rgb24>() == rgb24) { return "DarkSeaGreen"; }
            else if (ColorStats.DarkSlateBlue.ToPixel<Rgb24>() == rgb24) { return "DarkSlateBlue"; }
            else if (ColorStats.DarkSlateGray.ToPixel<Rgb24>() == rgb24) { return "DarkSlateGray"; }
            else if (ColorStats.DarkTurquoise.ToPixel<Rgb24>() == rgb24) { return "DarkTurquoise"; }
            else if (ColorStats.DarkViolet.ToPixel<Rgb24>() == rgb24) { return "DarkViolet"; }
            else if (ColorStats.DeepPink.ToPixel<Rgb24>() == rgb24) { return "DeepPink"; }
            else if (ColorStats.DeepSkyBlue.ToPixel<Rgb24>() == rgb24) { return "DeepSkyBlue"; }
            else if (ColorStats.DimGray.ToPixel<Rgb24>() == rgb24) { return "DimGray"; }
            else if (ColorStats.DodgerBlue.ToPixel<Rgb24>() == rgb24) { return "DodgerBlue"; }
            else if (ColorStats.Firebrick.ToPixel<Rgb24>() == rgb24) { return "Firebrick"; }
            else if (ColorStats.FloralWhite.ToPixel<Rgb24>() == rgb24) { return "FloralWhite"; }
            else if (ColorStats.ForestGreen.ToPixel<Rgb24>() == rgb24) { return "ForestGreen"; }
            else if (ColorStats.Fuchsia.ToPixel<Rgb24>() == rgb24) { return "Fuchsia"; }
            else if (ColorStats.Gainsboro.ToPixel<Rgb24>() == rgb24) { return "Gainsboro"; }
            else if (ColorStats.GhostWhite.ToPixel<Rgb24>() == rgb24) { return "GhostWhite"; }
            else if (ColorStats.Gold.ToPixel<Rgb24>() == rgb24) { return "Gold"; }
            else if (ColorStats.Goldenrod.ToPixel<Rgb24>() == rgb24) { return "Goldenrod"; }
            else if (ColorStats.Gray.ToPixel<Rgb24>() == rgb24) { return "Gray"; }
            else if (ColorStats.Green.ToPixel<Rgb24>() == rgb24) { return "Green"; }
            else if (ColorStats.GreenYellow.ToPixel<Rgb24>() == rgb24) { return "GreenYellow"; }
            else if (ColorStats.Honeydew.ToPixel<Rgb24>() == rgb24) { return "Honeydew"; }
            else if (ColorStats.HotPink.ToPixel<Rgb24>() == rgb24) { return "HotPink"; }
            else if (ColorStats.IndianRed.ToPixel<Rgb24>() == rgb24) { return "IndianRed"; }
            else if (ColorStats.Indigo.ToPixel<Rgb24>() == rgb24) { return "Indigo"; }
            else if (ColorStats.Ivory.ToPixel<Rgb24>() == rgb24) { return "Ivory"; }
            else if (ColorStats.Khaki.ToPixel<Rgb24>() == rgb24) { return "Khaki"; }
            else if (ColorStats.Lavender.ToPixel<Rgb24>() == rgb24) { return "Lavender"; }
            else if (ColorStats.LavenderBlush.ToPixel<Rgb24>() == rgb24) { return "LavenderBlush"; }
            else if (ColorStats.LawnGreen.ToPixel<Rgb24>() == rgb24) { return "LawnGreen"; }
            else if (ColorStats.LemonChiffon.ToPixel<Rgb24>() == rgb24) { return "LemonChiffon"; }
            else if (ColorStats.LightBlue.ToPixel<Rgb24>() == rgb24) { return "LightBlue"; }
            else if (ColorStats.LightCoral.ToPixel<Rgb24>() == rgb24) { return "LightCoral"; }
            else if (ColorStats.LightCyan.ToPixel<Rgb24>() == rgb24) { return "LightCyan"; }
            else if (ColorStats.LightGoldenrodYellow.ToPixel<Rgb24>() == rgb24) { return "LightGoldenrodYellow"; }
            else if (ColorStats.LightGray.ToPixel<Rgb24>() == rgb24) { return "LightGray"; }
            else if (ColorStats.LightGreen.ToPixel<Rgb24>() == rgb24) { return "LightGreen"; }
            else if (ColorStats.LightPink.ToPixel<Rgb24>() == rgb24) { return "LightPink"; }
            else if (ColorStats.LightSalmon.ToPixel<Rgb24>() == rgb24) { return "LightSalmon"; }
            else if (ColorStats.LightSeaGreen.ToPixel<Rgb24>() == rgb24) { return "LightSeaGreen"; }
            else if (ColorStats.LightSkyBlue.ToPixel<Rgb24>() == rgb24) { return "LightSkyBlue"; }
            else if (ColorStats.LightSlateGray.ToPixel<Rgb24>() == rgb24) { return "LightSlateGray"; }
            else if (ColorStats.LightSteelBlue.ToPixel<Rgb24>() == rgb24) { return "LightSteelBlue"; }
            else if (ColorStats.LightYellow.ToPixel<Rgb24>() == rgb24) { return "LightYellow"; }
            else if (ColorStats.Lime.ToPixel<Rgb24>() == rgb24) { return "Lime"; }
            else if (ColorStats.LimeGreen.ToPixel<Rgb24>() == rgb24) { return "LimeGreen"; }
            else if (ColorStats.Linen.ToPixel<Rgb24>() == rgb24) { return "Linen"; }
            //else if (Color.Magenta.ToPixel<Rgb24>() == rgb24) { return "Magenta"; }
            else if (ColorStats.Maroon.ToPixel<Rgb24>() == rgb24) { return "Maroon"; }
            else if (ColorStats.MediumAquamarine.ToPixel<Rgb24>() == rgb24) { return "MediumAquamarine"; }
            else if (ColorStats.MediumBlue.ToPixel<Rgb24>() == rgb24) { return "MediumBlue"; }
            else if (ColorStats.MediumOrchid.ToPixel<Rgb24>() == rgb24) { return "MediumOrchid"; }
            else if (ColorStats.MediumPurple.ToPixel<Rgb24>() == rgb24) { return "MediumPurple"; }
            else if (ColorStats.MediumSeaGreen.ToPixel<Rgb24>() == rgb24) { return "MediumSeaGreen"; }
            else if (ColorStats.MediumSlateBlue.ToPixel<Rgb24>() == rgb24) { return "MediumSlateBlue"; }
            else if (ColorStats.MediumSpringGreen.ToPixel<Rgb24>() == rgb24) { return "MediumSpringGreen"; }
            else if (ColorStats.MediumTurquoise.ToPixel<Rgb24>() == rgb24) { return "MediumTurquoise"; }
            else if (ColorStats.MediumVioletRed.ToPixel<Rgb24>() == rgb24) { return "MediumVioletRed"; }
            else if (ColorStats.MidnightBlue.ToPixel<Rgb24>() == rgb24) { return "MidnightBlue"; }
            else if (ColorStats.MintCream.ToPixel<Rgb24>() == rgb24) { return "MintCream"; }
            else if (ColorStats.MistyRose.ToPixel<Rgb24>() == rgb24) { return "MistyRose"; }
            else if (ColorStats.Moccasin.ToPixel<Rgb24>() == rgb24) { return "Moccasin"; }
            else if (ColorStats.NavajoWhite.ToPixel<Rgb24>() == rgb24) { return "NavajoWhite"; }
            else if (ColorStats.Navy.ToPixel<Rgb24>() == rgb24) { return "Navy"; }
            else if (ColorStats.OldLace.ToPixel<Rgb24>() == rgb24) { return "OldLace"; }
            else if (ColorStats.Olive.ToPixel<Rgb24>() == rgb24) { return "Olive"; }
            else if (ColorStats.OliveDrab.ToPixel<Rgb24>() == rgb24) { return "OliveDrab"; }
            else if (ColorStats.Orange.ToPixel<Rgb24>() == rgb24) { return "Orange"; }
            else if (ColorStats.OrangeRed.ToPixel<Rgb24>() == rgb24) { return "OrangeRed"; }
            else if (ColorStats.Orchid.ToPixel<Rgb24>() == rgb24) { return "Orchid"; }
            else if (ColorStats.PaleGoldenrod.ToPixel<Rgb24>() == rgb24) { return "PaleGoldenrod"; }
            else if (ColorStats.PaleGreen.ToPixel<Rgb24>() == rgb24) { return "PaleGreen"; }
            else if (ColorStats.PaleTurquoise.ToPixel<Rgb24>() == rgb24) { return "PaleTurquoise"; }
            else if (ColorStats.PaleVioletRed.ToPixel<Rgb24>() == rgb24) { return "PaleVioletRed"; }
            else if (ColorStats.PapayaWhip.ToPixel<Rgb24>() == rgb24) { return "PapayaWhip"; }
            else if (ColorStats.PeachPuff.ToPixel<Rgb24>() == rgb24) { return "PeachPuff"; }
            else if (ColorStats.Peru.ToPixel<Rgb24>() == rgb24) { return "Peru"; }
            else if (ColorStats.Pink.ToPixel<Rgb24>() == rgb24) { return "Pink"; }
            else if (ColorStats.Plum.ToPixel<Rgb24>() == rgb24) { return "Plum"; }
            else if (ColorStats.PowderBlue.ToPixel<Rgb24>() == rgb24) { return "PowderBlue"; }
            else if (ColorStats.Purple.ToPixel<Rgb24>() == rgb24) { return "Purple"; }
            else if (ColorStats.Red.ToPixel<Rgb24>() == rgb24) { return "Red"; }
            else if (ColorStats.RosyBrown.ToPixel<Rgb24>() == rgb24) { return "RosyBrown"; }
            else if (ColorStats.RoyalBlue.ToPixel<Rgb24>() == rgb24) { return "RoyalBlue"; }
            else if (ColorStats.SaddleBrown.ToPixel<Rgb24>() == rgb24) { return "SaddleBrown"; }
            else if (ColorStats.Salmon.ToPixel<Rgb24>() == rgb24) { return "Salmon"; }
            else if (ColorStats.SandyBrown.ToPixel<Rgb24>() == rgb24) { return "SandyBrown"; }
            else if (ColorStats.SeaGreen.ToPixel<Rgb24>() == rgb24) { return "SeaGreen"; }
            else if (ColorStats.SeaShell.ToPixel<Rgb24>() == rgb24) { return "SeaShell"; }
            else if (ColorStats.Sienna.ToPixel<Rgb24>() == rgb24) { return "Sienna"; }
            else if (ColorStats.Silver.ToPixel<Rgb24>() == rgb24) { return "Silver"; }
            else if (ColorStats.SkyBlue.ToPixel<Rgb24>() == rgb24) { return "SkyBlue"; }
            else if (ColorStats.SlateBlue.ToPixel<Rgb24>() == rgb24) { return "SlateBlue"; }
            else if (ColorStats.SlateGray.ToPixel<Rgb24>() == rgb24) { return "SlateGray"; }
            else if (ColorStats.Snow.ToPixel<Rgb24>() == rgb24) { return "Snow"; }
            else if (ColorStats.SpringGreen.ToPixel<Rgb24>() == rgb24) { return "SpringGreen"; }
            else if (ColorStats.SteelBlue.ToPixel<Rgb24>() == rgb24) { return "SteelBlue"; }
            else if (ColorStats.Tan.ToPixel<Rgb24>() == rgb24) { return "Tan"; }
            else if (ColorStats.Teal.ToPixel<Rgb24>() == rgb24) { return "Teal"; }
            else if (ColorStats.Thistle.ToPixel<Rgb24>() == rgb24) { return "Thistle"; }
            else if (ColorStats.Tomato.ToPixel<Rgb24>() == rgb24) { return "Tomato"; }
            //else if (Color.Transparent.ToPixel<Rgb24>() == rgb24) { return "Transparent"; }
            else if (ColorStats.Turquoise.ToPixel<Rgb24>() == rgb24) { return "Turquoise"; }
            else if (ColorStats.Violet.ToPixel<Rgb24>() == rgb24) { return "Violet"; }
            else if (ColorStats.Wheat.ToPixel<Rgb24>() == rgb24) { return "Wheat"; }
            else if (ColorStats.White.ToPixel<Rgb24>() == rgb24) { return "White"; }
            else if (ColorStats.WhiteSmoke.ToPixel<Rgb24>() == rgb24) { return "WhiteSmoke"; }
            else if (ColorStats.Yellow.ToPixel<Rgb24>() == rgb24) { return "Yellow"; }
            else if (ColorStats.YellowGreen.ToPixel<Rgb24>() == rgb24) { return "YellowGreen"; }

            ////CGA colors
            //else if (new Rgb24(0, 0, 0) == rgb24) { return "black"; }
            //else if (new Rgb24(85, 85, 85) == rgb24) { return "(dark) gray"; }
            //else if (new Rgb24(0, 0, 170) == rgb24) { return "blue"; }
            //else if (new Rgb24(85, 85, 255) == rgb24) { return "bright blue"; }
            //else if (new Rgb24(0, 170, 0) == rgb24) { return "green"; }
            //else if (new Rgb24(85, 255, 85) == rgb24) { return "bright green"; }
            //else if (new Rgb24(0, 170, 170) == rgb24) { return "cyan"; }
            //else if (new Rgb24(85, 255, 255) == rgb24) { return "bright cyan"; }
            //else if (new Rgb24(170, 0, 0) == rgb24) { return "red"; }
            //else if (new Rgb24(255, 85, 85) == rgb24) { return "bright red"; }
            //else if (new Rgb24(170, 0, 170) == rgb24) { return "magenta"; }
            //else if (new Rgb24(255, 85, 255) == rgb24) { return "bright magenta"; }
            //else if (new Rgb24(170, 85, 0) == rgb24) { return "brown"; }
            //else if (new Rgb24(255, 255, 85) == rgb24) { return "yellow"; }
            //else if (new Rgb24(170, 170, 170) == rgb24) { return "white (light gray)"; }
            //else if (new Rgb24(255, 255, 255) == rgb24) { return "bright white"; }
            else { return ""; }
        }
    }
}
