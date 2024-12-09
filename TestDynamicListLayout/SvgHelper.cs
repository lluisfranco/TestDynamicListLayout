using DevExpress.Utils.Svg;
using DevExpress.Utils;

namespace TestDynamicListLayout
{
    public static class SvgHelper
    {
        public static SvgImage GetImageFromResources(string imageName)
        {
            var ic = new SvgImageCollection
            {
                { imageName, $"TestDynamicListLayout.Resources.Images.{imageName}.svg", "TestDynamicListLayout.Resources" }
            };
            return ic.FirstOrDefault();
        }

        public static SvgImageCollection GetImageCollection(string imageName)
        {
            return new SvgImageCollection
            {
                { imageName, $"TestDynamicListLayout.Resources.Images.{imageName}.svg", "TestDynamicListLayout.Resources" }
            };
        }

        public static SvgImageCollection GetImageCollection(
            IEnumerable<string> imageNames, System.Drawing.Size size = default)
        {
            var ic = new SvgImageCollection() { ImageSize = size };
            foreach (var imageName in imageNames)
            {
                ic.Add(imageName, $"TestDynamicListLayout.Resources.Images.{imageName}.svg", "TestDynamicListLayout.Resources");
            }
            return ic;
        }
    }

}
