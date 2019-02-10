using System.Collections.Generic;

namespace SVGPath
{
    public static class CmdConveterFactory
    {
        private static Dictionary<string, ICmdConverter> cmdModifiers = new Dictionary<string, ICmdConverter>
        {
            { "M", new AbsoluteMoveCmdConverter() },
            { "L", new AbsoluteLineToCmdConverter() },
            { "H", new AbsoluteHorizontalLineCmdConverter() },
            { "V", new AbsoluteVerticalLineToCmdConverter() },
            { "C", new AbsoluteCurveToCmdConveter() },
            { "S", new AbsoluteSmoothCurveToCmdConverter() },
            { "Q", new AbsoluteQuadraticBezierCurveCmdConverter() },
            { "T", new AbsoluteSmoothQuadraticBezierCurveToCmdConverter() },
            { "A", new AbsoluteEllipticalArcCmdConverter() },
            //
            { "m", new RelativeMoveToCmdConverter() },
            { "l", new RelativeLineToCmdConverter() },
            { "h", new RelativeHorizontalLineCmdConverter() },
            { "v", new RelativeVerticalLineToCmdConverter() },
            { "c", new RelativeCurveToCmdConverter() },
            { "s", new RelativeSmoothCurveToCmdConverter() },                        
            { "q", new RelativeQuadraticBezierCurveCmdConverter() },            
            { "t", new RelativeSmoothQuadraticBezierCurveToCmdConverter() },           
            { "a", new RelativeEllipticalArcConverter() },
            // 
            { "Z", new ClosePathCmdConverter() },
            { "z", new ClosePathCmdConverter() }
        };

        public static ICmdConverter Create(string cmd)
        {
            return cmdModifiers[cmd];
        }
    }
}