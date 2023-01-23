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

        /// <summary>
        /// Lego colors 
        /// </summary>
        /// <returns>List of Rgb24</returns>
        public static List<Rgb24> GetLegoColorPalette()
        {
            return new List<Rgb24> {
new Rgb24(114, 14, 15), //Dark Red



new Rgb24(254, 186, 189), //Light Salmon



new Rgb24(254, 204, 207), //Light Pink




new Rgb24(189, 125, 133), //Modulex Violet



new Rgb24(255, 135, 156), //Duplo Pink



new Rgb24(214, 0, 38), //Pearl Red



new Rgb24(252, 151, 172), //Pink



new Rgb24(255, 105, 143), //Coral



new Rgb24(247, 133, 177), //Medium Dark Pink



new Rgb24(247, 133, 177), //Modulex Pink



new Rgb24(223, 102, 149), //Glitter Trans-Dark Pink



new Rgb24(223, 102, 149), //Trans-Dark Pink



new Rgb24(254, 120, 176), //Clikits Pink



new Rgb24(205, 98, 152), //Light Purple



new Rgb24(228, 173, 200), //Bright Pink



new Rgb24(228, 173, 200), //Trans-Pink



new Rgb24(200, 112, 160), //Dark Pink



new Rgb24(206, 29, 155), //Trans-Medium Reddish Violet Opal



new Rgb24(146, 57, 120), //Magenta



new Rgb24(170, 77, 142), //Chrome Pink



new Rgb24(129, 0, 123), //Purple



new Rgb24(132, 94, 132), //Sand Purple



new Rgb24(142, 85, 151), //Reddish Lilac



new Rgb24(150, 112, 159), //Trans-Light Purple



new Rgb24(172, 120, 186), //Medium Lavender



new Rgb24(131, 32, 183), //Trans-Purple Opal



new Rgb24(75, 0, 130), //Modulex Foil Violet



new Rgb24(225, 213, 237), //Lavender



new Rgb24(77, 76, 82), //Modulex Black



new Rgb24(63, 54, 145), //Dark Purple



new Rgb24(147, 145, 0), //Medium Violet



new Rgb24(165, 165, 203), //Trans-Purple




new Rgb24(165, 165, 203), //Glitter Trans-Purple



new Rgb24(201, 202, 226), //Light Violet



new Rgb24(32, 50, 176), //Dark Blue-Violet



new Rgb24(104, 116, 202), //Medium Bluish Violet




new Rgb24(76, 97, 219), //Royal Blue



new Rgb24(0, 32, 160), //Trans-Dark Blue Opal



new Rgb24(0, 32, 160), //Trans-Dark Blue



new Rgb24(67, 84, 163), //Violet




new Rgb24(175, 181, 199), //Modulex Light Bluish Gray



new Rgb24(10, 19, 39), //Pearl Black



new Rgb24(96, 116, 161), //Sand Blue



new Rgb24(121, 136, 161), //Metal Blue




new Rgb24(0, 85, 191), //Blue



new Rgb24(90, 147, 219), //Medium Blue



new Rgb24(10, 52, 99), //Dark Blue



new Rgb24(180, 212, 247), //Trans-Light Royal Blue



new Rgb24(207, 226, 247), //Trans-Medium Blue



new Rgb24(97, 175, 255), //Modulex Medium Blue



new Rgb24(159, 195, 233), //Bright Light Blue



new Rgb24(0, 87, 166), //Modulex Tile Blue



new Rgb24(0, 87, 166), //Modulex Foil Dark Blue



new Rgb24(108, 150, 191), //Chrome Blue



new Rgb24(0, 89, 163), //Pearl Blue



new Rgb24(89, 93, 96), //Modulex Charcoal Gray



new Rgb24(89, 93, 96), //Modulex Foil Dark Gray



new Rgb24(5, 19, 29), //Speckle Black-Copper



new Rgb24(5, 19, 29), //Speckle Black-Silver



new Rgb24(5, 19, 29), //Speckle Black-Gold



new Rgb24(180, 210, 227), //Light Blue



new Rgb24(193, 223, 240), //Trans-Very Lt Blue



new Rgb24(53, 146, 195), //Maersk Blue



new Rgb24(7, 139, 201), //Dark Azure



new Rgb24(104, 174, 206), //Modulex Foil Light Blue



new Rgb24(104, 174, 206), //Modulex Pastel Blue



new Rgb24(70, 112, 131), //Modulex Teal Blue



new Rgb24(125, 191, 221), //Sky Blue



new Rgb24(62, 149, 182), //Duplo Medium Blue



new Rgb24(0, 158, 206), //Duplo Blue



new Rgb24(3, 156, 189), //Vintage Blue
new Rgb24(90, 196, 218), //Pastel Blue



new Rgb24(54, 174, 191), //Medium Azure



new Rgb24(85, 165, 175), //Light Turquoise



new Rgb24(104, 188, 197), //Glitter Trans-Light Blue



new Rgb24(104, 188, 197), //Trans-Blue Opal



new Rgb24(0, 143, 155), //Dark Turquoise



new Rgb24(174, 239, 236), //Trans-Light Blue



new Rgb24(39, 134, 126), //Modulex Aqua Green



new Rgb24(173, 195, 192), //Light Aqua



new Rgb24(179, 215, 209), //Aqua



new Rgb24(24, 70, 50), //Dark Green



new Rgb24(60, 179, 113), //Chrome Green



new Rgb24(115, 220, 161), //Medium Green



new Rgb24(0, 142, 60), //Pearl Green



new Rgb24(160, 188, 172), //Sand Green



new Rgb24(70, 138, 95), //Duplo Medium Green



new Rgb24(35, 120, 65), //Green



new Rgb24(148, 229, 171), //Trans-Light Green



new Rgb24(96, 186, 118), //Duplo Light Green



new Rgb24(132, 182, 141), //Trans-Green



new Rgb24(132, 182, 141), //Trans-Green Opal



new Rgb24(100, 0, 0), //Modulex Foil Dark Green



new Rgb24(30, 96, 30), //Vintage Green
new Rgb24(120, 252, 120), //Fabuland Lime



new Rgb24(75, 159, 74), //Bright Green



new Rgb24(194, 218, 184), //Light Green



new Rgb24(125, 181, 56), //Modulex Foil Light Green



new Rgb24(125, 181, 56), //Modulex Pastel Green



new Rgb24(189, 198, 173), //Glow In Dark Trans



new Rgb24(108, 110, 104), //Speckle DBGray-Silver



new Rgb24(124, 144, 81), //Modulex Olive Green



new Rgb24(201, 231, 136), //Trans-Light Bright Green



new Rgb24(106, 121, 68), //Pearl Lime



new Rgb24(137, 155, 95), //Metallic Green



new Rgb24(192, 245, 0), //Glitter Trans-Neon Green



new Rgb24(187, 233, 11), //Lime



new Rgb24(223, 238, 165), //Yellowish Green



new Rgb24(217, 228, 167), //Light Lime



new Rgb24(217, 228, 167), //Trans-Bright Green



new Rgb24(199, 210, 60), //Medium Lime



new Rgb24(212, 213, 201), //Glow In Dark Opaque



new Rgb24(189, 198, 24), //Modulex Lemon



new Rgb24(155, 154, 90), //Olive Green



new Rgb24(255, 242, 48), //Duplo Lime



new Rgb24(248, 241, 132), //Trans-Neon Green



new Rgb24(235, 216, 0), //Vibrant Yellow



new Rgb24(255, 240, 58), //Bright Light Yellow



new Rgb24(187, 165, 61), //Chrome Gold



new Rgb24(251, 232, 144), //Trans-Fire Yellow



new Rgb24(218, 176, 0), //Trans-Neon Yellow



new Rgb24(243, 195, 5), //Vintage Yellow
new Rgb24(245, 205, 47), //Trans-Yellow



new Rgb24(242, 205, 55), //Yellow



new Rgb24(255, 227, 113), //Modulex Light Yellow



new Rgb24(251, 230, 150), //Light Yellow



new Rgb24(254, 213, 87), //Modulex Ochre Yellow



new Rgb24(254, 213, 87), //Modulex Foil Yellow



new Rgb24(99, 95, 82), //Trans-Black IR Lens




new Rgb24(219, 172, 52), //Metallic Gold




new Rgb24(92, 80, 48), //Modulex Terracotta



new Rgb24(248, 187, 61), //Bright Light Orange



new Rgb24(228, 205, 158), //Tan



new Rgb24(149, 138, 115), //Dark Tan



new Rgb24(170, 127, 46), //Pearl Gold



new Rgb24(220, 188, 129), //Pearl Light Gold



new Rgb24(255, 167, 11), //Medium Orange



new Rgb24(222, 198, 156), //Modulex Buff



new Rgb24(53, 33, 0), //Dark Brown



new Rgb24(221, 152, 46), //Curry



new Rgb24(243, 201, 136), //Light Tan



new Rgb24(180, 106, 0), //Metallic Copper



new Rgb24(250, 156, 28), //Earth Orange



new Rgb24(249, 186, 97), //Light Orange



new Rgb24(172, 130, 71), //Reddish Gold



new Rgb24(243, 207, 155), //Very Light Orange



new Rgb24(100, 90, 76), //Chrome Antique Brass



new Rgb24(144, 116, 80), //Modulex Brown



new Rgb24(240, 143, 28), //Glitter Trans-Orange



new Rgb24(240, 143, 28), //Trans-Orange



new Rgb24(239, 145, 33), //Fabuland Orange



new Rgb24(204, 163, 115), //Warm Tan



new Rgb24(246, 215, 179), //Light Nougat



new Rgb24(252, 183, 109), //Trans-Flame Yellowish Orange



new Rgb24(169, 85, 0), //Dark Orange



new Rgb24(254, 138, 24), //Orange



new Rgb24(247, 173, 99), //Modulex Foil Orange



new Rgb24(247, 173, 99), //Modulex Light Orange



new Rgb24(180, 132, 85), //Flat Dark Gold



new Rgb24(115, 114, 113), //Two-tone Silver



new Rgb24(255, 128, 13), //Trans-Neon Orange



new Rgb24(255, 128, 20), //Fabuland Red



new Rgb24(170, 125, 85), //Medium Nougat



new Rgb24(182, 123, 80), //Fabuland Brown



new Rgb24(117, 89, 69), //Medium Brown



new Rgb24(171, 103, 58), //Two-tone Gold



new Rgb24(208, 145, 104), //Nougat



new Rgb24(244, 123, 48), //Modulex Orange



new Rgb24(88, 57, 39), //Trans-Brown Opal



new Rgb24(88, 57, 39), //Brown




new Rgb24(174, 122, 89), //Copper





new Rgb24(88, 42, 18), //Reddish Brown



new Rgb24(124, 80, 58), //Light Brown



new Rgb24(173, 97, 64), //Dark Nougat



new Rgb24(87, 57, 44), //Pearl Brown



new Rgb24(135, 43, 23), //Rust Orange



new Rgb24(238, 84, 52), //Reddish Orange



new Rgb24(244, 92, 64), //Modulex Pink Red



new Rgb24(202, 31, 8), //Vintage Red
new Rgb24(242, 112, 94), //Salmon



new Rgb24(148, 81, 72), //Two-tone Copper



new Rgb24(201, 26, 9), //Red



new Rgb24(201, 26, 9), //Trans-Red



new Rgb24(179, 16, 4), //Rust



new Rgb24(181, 44, 32), //Modulex Red



new Rgb24(214, 117, 114), //Sand Red



new Rgb24(139, 0, 0), //Modulex Foil Red



new Rgb24(51, 0, 0), //Modulex Tile Brown



new Rgb24(255, 255, 255), //Milky White



new Rgb24(252, 252, 252), //Trans-Clear



new Rgb24(242, 243, 242), //Pearl White



new Rgb24(230, 227, 218), //Very Light Gray



new Rgb24(230, 227, 224), //Very Light Bluish Gray



new Rgb24(224, 224, 224), //Chrome Silver



new Rgb24(165, 169, 180), //Metallic Silver





new Rgb24(171, 173, 172), //Pearl Very Light Gray



new Rgb24(160, 165, 169), //Light Bluish Gray



new Rgb24(156, 163, 168), //Pearl Light Gray





new Rgb24(155, 161, 157), //Light Gray



new Rgb24(137, 135, 136), //Flat Silver



new Rgb24(109, 110, 92), //Dark Gray



new Rgb24(108, 110, 104), //Dark Bluish Gray



new Rgb24(99, 95, 82), //Trans-Black



new Rgb24(87, 88, 87), //Pearl Dark Gray




new Rgb24(27, 42, 52), //Chrome Black



new Rgb24(107, 90, 90), //Modulex Tile Gray



new Rgb24(5, 19, 29), //Black




new Rgb24(255, 255, 255), //Glitter Trans-Clear



new Rgb24(255, 255, 255), //White



new Rgb24(255, 255, 255), //Modulex Clear



new Rgb24(252, 252, 252), //Trans-Clear Opal



new Rgb24(244, 244, 244), //Modulex White



new Rgb24(217, 217, 217), //Glow in Dark White



new Rgb24(156, 156, 156), //Modulex Foil Light Gray



new Rgb24(156, 156, 156), //Modulex Light Gray

            };
        }

        /// <summary>
        /// 141 colors (All C# named colors)
        /// </summary>
        /// <returns>List of Rgb24</returns>
        public static List<Rgb24> Get141ColorPalette()
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
            //else if (Color.Cyan.ToPixel<Rgb24>() == rgb24) { return "Cyan"; }
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
            //else if (Color.Magenta.ToPixel<Rgb24>() == rgb24) { return "Magenta"; }
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
            //else if (Color.Transparent.ToPixel<Rgb24>() == rgb24) { return "Transparent"; }
            else if (Color.Turquoise.ToPixel<Rgb24>() == rgb24) { return "Turquoise"; }
            else if (Color.Violet.ToPixel<Rgb24>() == rgb24) { return "Violet"; }
            else if (Color.Wheat.ToPixel<Rgb24>() == rgb24) { return "Wheat"; }
            else if (Color.White.ToPixel<Rgb24>() == rgb24) { return "White"; }
            else if (Color.WhiteSmoke.ToPixel<Rgb24>() == rgb24) { return "WhiteSmoke"; }
            else if (Color.Yellow.ToPixel<Rgb24>() == rgb24) { return "Yellow"; }
            else if (Color.YellowGreen.ToPixel<Rgb24>() == rgb24) { return "YellowGreen"; }

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




            else if (new Rgb24(114, 14, 15) == rgb24) { return "Dark Red"; }



            else if (new Rgb24(254, 186, 189) == rgb24) { return "Light Salmon"; }



            else if (new Rgb24(254, 204, 207) == rgb24) { return "Light Pink"; }




            else if (new Rgb24(189, 125, 133) == rgb24) { return "Modulex Violet"; }



            else if (new Rgb24(255, 135, 156) == rgb24) { return "Duplo Pink"; }



            else if (new Rgb24(214, 0, 38) == rgb24) { return "Pearl Red"; }



            else if (new Rgb24(252, 151, 172) == rgb24) { return "Pink"; }



            else if (new Rgb24(255, 105, 143) == rgb24) { return "Coral"; }



            else if (new Rgb24(247, 133, 177) == rgb24) { return "Medium Dark Pink"; }



            else if (new Rgb24(247, 133, 177) == rgb24) { return "Modulex Pink"; }



            else if (new Rgb24(223, 102, 149) == rgb24) { return "Glitter Trans-Dark Pink"; }



            else if (new Rgb24(223, 102, 149) == rgb24) { return "Trans-Dark Pink"; }



            else if (new Rgb24(254, 120, 176) == rgb24) { return "Clikits Pink"; }



            else if (new Rgb24(205, 98, 152) == rgb24) { return "Light Purple"; }



            else if (new Rgb24(228, 173, 200) == rgb24) { return "Bright Pink"; }



            else if (new Rgb24(228, 173, 200) == rgb24) { return "Trans-Pink"; }



            else if (new Rgb24(200, 112, 160) == rgb24) { return "Dark Pink"; }



            else if (new Rgb24(206, 29, 155) == rgb24) { return "Trans-Medium Reddish Violet Opal"; }



            else if (new Rgb24(146, 57, 120) == rgb24) { return "Magenta"; }



            else if (new Rgb24(170, 77, 142) == rgb24) { return "Chrome Pink"; }



            else if (new Rgb24(129, 0, 123) == rgb24) { return "Purple"; }



            else if (new Rgb24(132, 94, 132) == rgb24) { return "Sand Purple"; }



            else if (new Rgb24(142, 85, 151) == rgb24) { return "Reddish Lilac"; }



            else if (new Rgb24(150, 112, 159) == rgb24) { return "Trans-Light Purple"; }



            else if (new Rgb24(172, 120, 186) == rgb24) { return "Medium Lavender"; }



            else if (new Rgb24(131, 32, 183) == rgb24) { return "Trans-Purple Opal"; }



            else if (new Rgb24(75, 0, 130) == rgb24) { return "Modulex Foil Violet"; }



            else if (new Rgb24(225, 213, 237) == rgb24) { return "Lavender"; }



            else if (new Rgb24(77, 76, 82) == rgb24) { return "Modulex Black"; }



            else if (new Rgb24(63, 54, 145) == rgb24) { return "Dark Purple"; }



            else if (new Rgb24(147, 145, 0) == rgb24) { return "Medium Violet"; }



            else if (new Rgb24(165, 165, 203) == rgb24) { return "Trans-Purple"; }




            else if (new Rgb24(165, 165, 203) == rgb24) { return "Glitter Trans-Purple"; }



            else if (new Rgb24(201, 202, 226) == rgb24) { return "Light Violet"; }



            else if (new Rgb24(32, 50, 176) == rgb24) { return "Dark Blue-Violet"; }



            else if (new Rgb24(104, 116, 202) == rgb24) { return "Medium Bluish Violet"; }




            else if (new Rgb24(76, 97, 219) == rgb24) { return "Royal Blue"; }



            else if (new Rgb24(0, 32, 160) == rgb24) { return "Trans-Dark Blue Opal"; }



            else if (new Rgb24(0, 32, 160) == rgb24) { return "Trans-Dark Blue"; }



            else if (new Rgb24(67, 84, 163) == rgb24) { return "Violet"; }




            else if (new Rgb24(175, 181, 199) == rgb24) { return "Modulex Light Bluish Gray"; }



            else if (new Rgb24(10, 19, 39) == rgb24) { return "Pearl Black"; }



            else if (new Rgb24(96, 116, 161) == rgb24) { return "Sand Blue"; }



            else if (new Rgb24(121, 136, 161) == rgb24) { return "Metal Blue"; }




            else if (new Rgb24(0, 85, 191) == rgb24) { return "Blue"; }



            else if (new Rgb24(90, 147, 219) == rgb24) { return "Medium Blue"; }



            else if (new Rgb24(10, 52, 99) == rgb24) { return "Dark Blue"; }



            else if (new Rgb24(180, 212, 247) == rgb24) { return "Trans-Light Royal Blue"; }



            else if (new Rgb24(207, 226, 247) == rgb24) { return "Trans-Medium Blue"; }



            else if (new Rgb24(97, 175, 255) == rgb24) { return "Modulex Medium Blue"; }



            else if (new Rgb24(159, 195, 233) == rgb24) { return "Bright Light Blue"; }



            else if (new Rgb24(0, 87, 166) == rgb24) { return "Modulex Tile Blue"; }



            else if (new Rgb24(0, 87, 166) == rgb24) { return "Modulex Foil Dark Blue"; }



            else if (new Rgb24(108, 150, 191) == rgb24) { return "Chrome Blue"; }



            else if (new Rgb24(0, 89, 163) == rgb24) { return "Pearl Blue"; }



            else if (new Rgb24(89, 93, 96) == rgb24) { return "Modulex Charcoal Gray"; }



            else if (new Rgb24(89, 93, 96) == rgb24) { return "Modulex Foil Dark Gray"; }



            else if (new Rgb24(5, 19, 29) == rgb24) { return "Speckle Black-Copper"; }



            else if (new Rgb24(5, 19, 29) == rgb24) { return "Speckle Black-Silver"; }



            else if (new Rgb24(5, 19, 29) == rgb24) { return "Speckle Black-Gold"; }



            else if (new Rgb24(180, 210, 227) == rgb24) { return "Light Blue"; }



            else if (new Rgb24(193, 223, 240) == rgb24) { return "Trans-Very Lt Blue"; }



            else if (new Rgb24(53, 146, 195) == rgb24) { return "Maersk Blue"; }



            else if (new Rgb24(7, 139, 201) == rgb24) { return "Dark Azure"; }



            else if (new Rgb24(104, 174, 206) == rgb24) { return "Modulex Foil Light Blue"; }



            else if (new Rgb24(104, 174, 206) == rgb24) { return "Modulex Pastel Blue"; }



            else if (new Rgb24(70, 112, 131) == rgb24) { return "Modulex Teal Blue"; }



            else if (new Rgb24(125, 191, 221) == rgb24) { return "Sky Blue"; }



            else if (new Rgb24(62, 149, 182) == rgb24) { return "Duplo Medium Blue"; }



            else if (new Rgb24(0, 158, 206) == rgb24) { return "Duplo Blue"; }



            else if (new Rgb24(3, 156, 189) == rgb24) { return "Vintage Blue"; }
            else if (new Rgb24(90, 196, 218) == rgb24) { return "Pastel Blue"; }



            else if (new Rgb24(54, 174, 191) == rgb24) { return "Medium Azure"; }



            else if (new Rgb24(85, 165, 175) == rgb24) { return "Light Turquoise"; }



            else if (new Rgb24(104, 188, 197) == rgb24) { return "Glitter Trans-Light Blue"; }



            else if (new Rgb24(104, 188, 197) == rgb24) { return "Trans-Blue Opal"; }



            else if (new Rgb24(0, 143, 155) == rgb24) { return "Dark Turquoise"; }



            else if (new Rgb24(174, 239, 236) == rgb24) { return "Trans-Light Blue"; }



            else if (new Rgb24(39, 134, 126) == rgb24) { return "Modulex Aqua Green"; }



            else if (new Rgb24(173, 195, 192) == rgb24) { return "Light Aqua"; }



            else if (new Rgb24(179, 215, 209) == rgb24) { return "Aqua"; }



            else if (new Rgb24(24, 70, 50) == rgb24) { return "Dark Green"; }



            else if (new Rgb24(60, 179, 113) == rgb24) { return "Chrome Green"; }



            else if (new Rgb24(115, 220, 161) == rgb24) { return "Medium Green"; }



            else if (new Rgb24(0, 142, 60) == rgb24) { return "Pearl Green"; }



            else if (new Rgb24(160, 188, 172) == rgb24) { return "Sand Green"; }



            else if (new Rgb24(70, 138, 95) == rgb24) { return "Duplo Medium Green"; }



            else if (new Rgb24(35, 120, 65) == rgb24) { return "Green"; }



            else if (new Rgb24(148, 229, 171) == rgb24) { return "Trans-Light Green"; }



            else if (new Rgb24(96, 186, 118) == rgb24) { return "Duplo Light Green"; }



            else if (new Rgb24(132, 182, 141) == rgb24) { return "Trans-Green"; }



            else if (new Rgb24(132, 182, 141) == rgb24) { return "Trans-Green Opal"; }



            else if (new Rgb24(100, 0, 0) == rgb24) { return "Modulex Foil Dark Green"; }



            else if (new Rgb24(30, 96, 30) == rgb24) { return "Vintage Green"; }
            else if (new Rgb24(120, 252, 120) == rgb24) { return "Fabuland Lime"; }



            else if (new Rgb24(75, 159, 74) == rgb24) { return "Bright Green"; }



            else if (new Rgb24(194, 218, 184) == rgb24) { return "Light Green"; }



            else if (new Rgb24(125, 181, 56) == rgb24) { return "Modulex Foil Light Green"; }



            else if (new Rgb24(125, 181, 56) == rgb24) { return "Modulex Pastel Green"; }



            else if (new Rgb24(189, 198, 173) == rgb24) { return "Glow In Dark Trans"; }



            else if (new Rgb24(108, 110, 104) == rgb24) { return "Speckle DBGray-Silver"; }



            else if (new Rgb24(124, 144, 81) == rgb24) { return "Modulex Olive Green"; }



            else if (new Rgb24(201, 231, 136) == rgb24) { return "Trans-Light Bright Green"; }



            else if (new Rgb24(106, 121, 68) == rgb24) { return "Pearl Lime"; }



            else if (new Rgb24(137, 155, 95) == rgb24) { return "Metallic Green"; }



            else if (new Rgb24(192, 245, 0) == rgb24) { return "Glitter Trans-Neon Green"; }



            else if (new Rgb24(187, 233, 11) == rgb24) { return "Lime"; }



            else if (new Rgb24(223, 238, 165) == rgb24) { return "Yellowish Green"; }



            else if (new Rgb24(217, 228, 167) == rgb24) { return "Light Lime"; }



            else if (new Rgb24(217, 228, 167) == rgb24) { return "Trans-Bright Green"; }



            else if (new Rgb24(199, 210, 60) == rgb24) { return "Medium Lime"; }



            else if (new Rgb24(212, 213, 201) == rgb24) { return "Glow In Dark Opaque"; }



            else if (new Rgb24(189, 198, 24) == rgb24) { return "Modulex Lemon"; }



            else if (new Rgb24(155, 154, 90) == rgb24) { return "Olive Green"; }



            else if (new Rgb24(255, 242, 48) == rgb24) { return "Duplo Lime"; }



            else if (new Rgb24(248, 241, 132) == rgb24) { return "Trans-Neon Green"; }



            else if (new Rgb24(235, 216, 0) == rgb24) { return "Vibrant Yellow"; }



            else if (new Rgb24(255, 240, 58) == rgb24) { return "Bright Light Yellow"; }



            else if (new Rgb24(187, 165, 61) == rgb24) { return "Chrome Gold"; }



            else if (new Rgb24(251, 232, 144) == rgb24) { return "Trans-Fire Yellow"; }



            else if (new Rgb24(218, 176, 0) == rgb24) { return "Trans-Neon Yellow"; }



            else if (new Rgb24(243, 195, 5) == rgb24) { return "Vintage Yellow"; }
            else if (new Rgb24(245, 205, 47) == rgb24) { return "Trans-Yellow"; }



            else if (new Rgb24(242, 205, 55) == rgb24) { return "Yellow"; }



            else if (new Rgb24(255, 227, 113) == rgb24) { return "Modulex Light Yellow"; }



            else if (new Rgb24(251, 230, 150) == rgb24) { return "Light Yellow"; }



            else if (new Rgb24(254, 213, 87) == rgb24) { return "Modulex Ochre Yellow"; }



            else if (new Rgb24(254, 213, 87) == rgb24) { return "Modulex Foil Yellow"; }



            else if (new Rgb24(99, 95, 82) == rgb24) { return "Trans-Black IR Lens"; }




            else if (new Rgb24(219, 172, 52) == rgb24) { return "Metallic Gold"; }




            else if (new Rgb24(92, 80, 48) == rgb24) { return "Modulex Terracotta"; }



            else if (new Rgb24(248, 187, 61) == rgb24) { return "Bright Light Orange"; }



            else if (new Rgb24(228, 205, 158) == rgb24) { return "Tan"; }



            else if (new Rgb24(149, 138, 115) == rgb24) { return "Dark Tan"; }



            else if (new Rgb24(170, 127, 46) == rgb24) { return "Pearl Gold"; }



            else if (new Rgb24(220, 188, 129) == rgb24) { return "Pearl Light Gold"; }



            else if (new Rgb24(255, 167, 11) == rgb24) { return "Medium Orange"; }



            else if (new Rgb24(222, 198, 156) == rgb24) { return "Modulex Buff"; }



            else if (new Rgb24(53, 33, 0) == rgb24) { return "Dark Brown"; }



            else if (new Rgb24(221, 152, 46) == rgb24) { return "Curry"; }



            else if (new Rgb24(243, 201, 136) == rgb24) { return "Light Tan"; }



            else if (new Rgb24(180, 106, 0) == rgb24) { return "Metallic Copper"; }



            else if (new Rgb24(250, 156, 28) == rgb24) { return "Earth Orange"; }



            else if (new Rgb24(249, 186, 97) == rgb24) { return "Light Orange"; }



            else if (new Rgb24(172, 130, 71) == rgb24) { return "Reddish Gold"; }



            else if (new Rgb24(243, 207, 155) == rgb24) { return "Very Light Orange"; }



            else if (new Rgb24(100, 90, 76) == rgb24) { return "Chrome Antique Brass"; }



            else if (new Rgb24(144, 116, 80) == rgb24) { return "Modulex Brown"; }



            else if (new Rgb24(240, 143, 28) == rgb24) { return "Glitter Trans-Orange"; }



            else if (new Rgb24(240, 143, 28) == rgb24) { return "Trans-Orange"; }



            else if (new Rgb24(239, 145, 33) == rgb24) { return "Fabuland Orange"; }



            else if (new Rgb24(204, 163, 115) == rgb24) { return "Warm Tan"; }



            else if (new Rgb24(246, 215, 179) == rgb24) { return "Light Nougat"; }



            else if (new Rgb24(252, 183, 109) == rgb24) { return "Trans-Flame Yellowish Orange"; }



            else if (new Rgb24(169, 85, 0) == rgb24) { return "Dark Orange"; }



            else if (new Rgb24(254, 138, 24) == rgb24) { return "Orange"; }



            else if (new Rgb24(247, 173, 99) == rgb24) { return "Modulex Foil Orange"; }



            else if (new Rgb24(247, 173, 99) == rgb24) { return "Modulex Light Orange"; }



            else if (new Rgb24(180, 132, 85) == rgb24) { return "Flat Dark Gold"; }



            else if (new Rgb24(115, 114, 113) == rgb24) { return "Two-tone Silver"; }



            else if (new Rgb24(255, 128, 13) == rgb24) { return "Trans-Neon Orange"; }



            else if (new Rgb24(255, 128, 20) == rgb24) { return "Fabuland Red"; }



            else if (new Rgb24(170, 125, 85) == rgb24) { return "Medium Nougat"; }



            else if (new Rgb24(182, 123, 80) == rgb24) { return "Fabuland Brown"; }



            else if (new Rgb24(117, 89, 69) == rgb24) { return "Medium Brown"; }



            else if (new Rgb24(171, 103, 58) == rgb24) { return "Two-tone Gold"; }



            else if (new Rgb24(208, 145, 104) == rgb24) { return "Nougat"; }



            else if (new Rgb24(244, 123, 48) == rgb24) { return "Modulex Orange"; }



            else if (new Rgb24(88, 57, 39) == rgb24) { return "Trans-Brown Opal"; }



            else if (new Rgb24(88, 57, 39) == rgb24) { return "Brown"; }




            else if (new Rgb24(174, 122, 89) == rgb24) { return "Copper"; }





            else if (new Rgb24(88, 42, 18) == rgb24) { return "Reddish Brown"; }



            else if (new Rgb24(124, 80, 58) == rgb24) { return "Light Brown"; }



            else if (new Rgb24(173, 97, 64) == rgb24) { return "Dark Nougat"; }



            else if (new Rgb24(87, 57, 44) == rgb24) { return "Pearl Brown"; }



            else if (new Rgb24(135, 43, 23) == rgb24) { return "Rust Orange"; }



            else if (new Rgb24(238, 84, 52) == rgb24) { return "Reddish Orange"; }



            else if (new Rgb24(244, 92, 64) == rgb24) { return "Modulex Pink Red"; }



            else if (new Rgb24(202, 31, 8) == rgb24) { return "Vintage Red"; }
            else if (new Rgb24(242, 112, 94) == rgb24) { return "Salmon"; }



            else if (new Rgb24(148, 81, 72) == rgb24) { return "Two-tone Copper"; }



            else if (new Rgb24(201, 26, 9) == rgb24) { return "Red"; }



            else if (new Rgb24(201, 26, 9) == rgb24) { return "Trans-Red"; }



            else if (new Rgb24(179, 16, 4) == rgb24) { return "Rust"; }



            else if (new Rgb24(181, 44, 32) == rgb24) { return "Modulex Red"; }



            else if (new Rgb24(214, 117, 114) == rgb24) { return "Sand Red"; }



            else if (new Rgb24(139, 0, 0) == rgb24) { return "Modulex Foil Red"; }



            else if (new Rgb24(51, 0, 0) == rgb24) { return "Modulex Tile Brown"; }



            else if (new Rgb24(255, 255, 255) == rgb24) { return "Milky White"; }



            else if (new Rgb24(252, 252, 252) == rgb24) { return "Trans-Clear"; }



            else if (new Rgb24(242, 243, 242) == rgb24) { return "Pearl White"; }



            else if (new Rgb24(230, 227, 218) == rgb24) { return "Very Light Gray"; }



            else if (new Rgb24(230, 227, 224) == rgb24) { return "Very Light Bluish Gray"; }



            else if (new Rgb24(224, 224, 224) == rgb24) { return "Chrome Silver"; }



            else if (new Rgb24(165, 169, 180) == rgb24) { return "Metallic Silver"; }





            else if (new Rgb24(171, 173, 172) == rgb24) { return "Pearl Very Light Gray"; }



            else if (new Rgb24(160, 165, 169) == rgb24) { return "Light Bluish Gray"; }



            else if (new Rgb24(156, 163, 168) == rgb24) { return "Pearl Light Gray"; }





            else if (new Rgb24(155, 161, 157) == rgb24) { return "Light Gray"; }



            else if (new Rgb24(137, 135, 136) == rgb24) { return "Flat Silver"; }



            else if (new Rgb24(109, 110, 92) == rgb24) { return "Dark Gray"; }



            else if (new Rgb24(108, 110, 104) == rgb24) { return "Dark Bluish Gray"; }



            else if (new Rgb24(99, 95, 82) == rgb24) { return "Trans-Black"; }



            else if (new Rgb24(87, 88, 87) == rgb24) { return "Pearl Dark Gray"; }




            else if (new Rgb24(27, 42, 52) == rgb24) { return "Chrome Black"; }



            else if (new Rgb24(107, 90, 90) == rgb24) { return "Modulex Tile Gray"; }



            else if (new Rgb24(5, 19, 29) == rgb24) { return "Black"; }




            else if (new Rgb24(255, 255, 255) == rgb24) { return "Glitter Trans-Clear"; }



            else if (new Rgb24(255, 255, 255) == rgb24) { return "White"; }



            else if (new Rgb24(255, 255, 255) == rgb24) { return "Modulex Clear"; }



            else if (new Rgb24(252, 252, 252) == rgb24) { return "Trans-Clear Opal"; }



            else if (new Rgb24(244, 244, 244) == rgb24) { return "Modulex White"; }



            else if (new Rgb24(217, 217, 217) == rgb24) { return "Glow in Dark White"; }



            else if (new Rgb24(156, 156, 156) == rgb24) { return "Modulex Foil Light Gray"; }



            else if (new Rgb24(156, 156, 156) == rgb24) { return "Modulex Light Gray"; }







            else { return ""; }
        }
    }
}
