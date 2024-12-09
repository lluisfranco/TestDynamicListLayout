using DevExpress.Utils;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors.Repository;

namespace TestDynamicListLayout
{
    public class UIHelper
    {
        public static SvgImageCollection GetBooleanImageList()
        {
            return new SvgImageCollection
            {
                SvgHelper.GetImageFromResources("Core.BoolYes"),
                SvgHelper.GetImageFromResources("Core.BoolNo"),
            };
        }

        public static RepositoryItemImageComboBox GetBooleanRealComboBox()
        {
            var combo = new RepositoryItemImageComboBox() { SmallImages = GetBooleanImageList() };
            combo.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem()
            {
                Value = true,
                Description = "Yes",
                ImageIndex = 0
            });
            combo.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem()
            {
                Value = false,
                Description = "No",
                ImageIndex = 1
            });
            return combo;
        }

        public static SvgImageCollection GetIsActiveImageList()
        {
            return new SvgImageCollection
        {
                    SvgHelper.GetImageFromResources("Core.IsActiveNo"),
                    SvgHelper.GetImageFromResources("Core.IsActiveYes"),
                };
        }

        public static RepositoryItemImageComboBox GetIsActiveComboBox()
        {
            var combo = new RepositoryItemImageComboBox() { SmallImages = GetIsActiveImageList() };
            combo.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem()
            {
                Value = null,
                Description = string.Empty
            });
            combo.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem()
            {
                Value = false,
                Description = "Not Active",
                ImageIndex = 0
            });
            combo.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem()
            {
                Value = true,
                Description = "Active",
                ImageIndex = 1
            });
            return combo;
        }

        public static SvgImageCollection GetIsActiveManagementImageList()
        {
            return new SvgImageCollection
            {
                SvgHelper.GetImageFromResources("Core.IsActiveManagementYes"),
                SvgHelper.GetImageFromResources("Core.IsActiveManagementNo"),
            };
        }

        public static RepositoryItemImageComboBox GetIsActiveManagementComboBox()
        {
            var combo = new RepositoryItemImageComboBox() { SmallImages = GetIsActiveManagementImageList() };
            combo.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem()
            {
                Value = 1,
                Description = "Active Management",
                ImageIndex = 0
            });
            combo.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem()
            {
                Value = 0,
                Description = "Not Active Management",
                ImageIndex = 1
            });
            return combo;
        }

        public static RepositoryItemImageComboBox GetIsActiveManagementBooleanComboBox()
        {
            var combo = new RepositoryItemImageComboBox() { SmallImages = GetIsActiveManagementImageList() };
            combo.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem()
            {
                Value = true,
                Description = "Active Management",
                ImageIndex = 0
            });
            combo.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem()
            {
                Value = false,
                Description = "Not Active Management",
                ImageIndex = 1
            });
            return combo;
        }

        public static SvgImageCollection GetAssetManagedImageList()
        {
            return new SvgImageCollection
            {
                SvgHelper.GetImageFromResources("Assets.IsAssetManagedNo"),
                SvgHelper.GetImageFromResources("Assets.IsAssetManagedYes"),
                SvgHelper.GetImageFromResources("Assets.IsAssetManagedAll"),
            };
        }

        public static RepositoryItemImageComboBox GetAssetManagedComboBox()
        {
            var combo = new RepositoryItemImageComboBox() { SmallImages = GetAssetManagedImageList() };
            combo.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem()
            {
                Value = 2,
                Description = "(All)",
                ImageIndex = 2
            });
            combo.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem()
            {
                Value = 1,
                Description = "Managed",
                ImageIndex = 1
            });
            combo.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem()
            {
                Value = 0,
                Description = "Not Managed",
                ImageIndex = 0
            });
            return combo;
        }

        public static RepositoryItemImageComboBox GetAssetManagedBooleanComboBox()
        {
            var combo = new RepositoryItemImageComboBox() { SmallImages = GetAssetManagedImageList() };
            combo.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem()
            {
                Value = true,
                Description = "Managed",
                ImageIndex = 1
            });
            combo.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem()
            {
                Value = false,
                Description = "Not Managed",
                ImageIndex = 0
            });
            return combo;
        }

    }

}
